using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using UnityEngine;
using Random = System.Random;

namespace ChangeLoadingImage
{
    public class LoadingAnimationDetour : MonoBehaviour
    {
        #region variables

        RedirectCallsState redirectCallsState;
        private bool deployed;

        #endregion

        public void Deploy()
        {
            if (deployed)
            {
                return;
            }

            redirectCallsState = RedirectionHelper.RedirectCalls(
                typeof(LoadingAnimation).GetMethod("SetImage", BindingFlags.Public | BindingFlags.Instance),
                typeof(LoadingAnimationDetour).GetMethod("SetImage", BindingFlags.Public | BindingFlags.Instance));
            deployed = true;
        }

        private void Revert()
        {
            if (!deployed)
            {
                return;
            }

            RedirectionHelper.RevertRedirect(
                typeof(LoadingAnimation).GetMethod("SetImage", BindingFlags.Public | BindingFlags.Instance),
                redirectCallsState);
            deployed = false;
        }

        #region redirection

        #endregion

        public void SetImage(Mesh mesh, Material material, float scale, bool showAnimation)
        {
            try
            {
                var newTexture = GetRandomImgurImage(true);
                var newScale = getScaleFactor(newTexture);
                var newMaterial = new Material(material) {mainTexture = newTexture};
                SetImageOriginal(mesh, newMaterial, newScale, showAnimation);
            }
            catch (Exception)
            {
                SetImageOriginal(mesh, material, scale, showAnimation);
            }
        }

        private static Texture GetClassicImageForEnvironment()
        {
            var env = SimulationManager.instance.m_metaData.m_environment;
            var fileName = $"{Util.AssemblyDirectory}/{env} Loading Image.png";
            return Util.LoadTextureFromFile(fileName);
        }

        private static Texture GetRandomImgurImage(bool fromPredefinedList)
        {
            var attempt = 0;
            while (attempt < 10)
            {
                ++attempt;
                var pageNumber = new Random().Next(10);
                var entries = fromPredefinedList ? ImgurImages.DefaultImageList : ImgurImages.ImageListFromImgur(pageNumber);
                var entry = SelectFrom(entries);
                if (entry == null)
                {
                    throw new Exception("No entry was selected");
                }

                try
                {
                    return HandleHttp(entry.uri);
                }
                catch (Exception)
                {
                    // suppress
                }
            }

            throw new Exception("Failed to load an image from imgur");
        }

        private void SetImageOriginal(Mesh mesh, Material material, float scale, bool showAnimation)
        {
            var loadingAnimation = LoadingManager.instance.LoadingAnimationComponent;

            ReflectionUtils.WritePrivate<LoadingAnimation>(loadingAnimation, "m_imageMesh", mesh);
            ReflectionUtils.WritePrivate<LoadingAnimation>(loadingAnimation, "m_imageMaterial", new Material(material));
            ReflectionUtils.WritePrivate<LoadingAnimation>(loadingAnimation, "m_imageScale", scale);
            ReflectionUtils.WritePrivate<LoadingAnimation>(loadingAnimation, "m_imageShowAnimation", showAnimation);
            ReflectionUtils.WritePrivate<LoadingAnimation>(loadingAnimation, "m_imageLoaded", true);
            ReflectionUtils.WritePrivate<LoadingAnimation>(loadingAnimation, "m_imageAlpha", 0.0f);
        }

        private static ImageListEntry SelectFrom(IList<ImageListEntry> entries)
        {
            if (entries.Count == 0)
                return null;

            var random = new Random();
            return entries[random.Next(entries.Count)];
        }

        #region handle specific image sources

        private static Texture HandleHttp(string uri)
        {
            var imgData = new WebClient().DownloadData(uri);
            var bg = new Texture2D(1, 1);
            bg.LoadImage(imgData);
            if (bg.width < 1920 || bg.height < 1080)
            {
                throw new Exception("image is too small: " + uri);
            }

            return bg;
        }

        #endregion

        #region utilities

        private static float getScaleFactor(Texture texture)
        {
            var scaleFactor = 1f;
            if (texture == null)
                return scaleFactor;

            float screenWidth = Screen.currentResolution.width;
            float screenHeight = Screen.currentResolution.height;

            var imgWidth = texture.width;
            var imgHeight = texture.height;

            var widthFactor = screenWidth / imgWidth;
            var heightFactor = screenHeight / imgHeight;

            if (widthFactor > heightFactor)
            {
                var temp = heightFactor * imgWidth;
                scaleFactor = screenWidth / temp;
            }
            else
            {
                var temp = widthFactor * imgHeight;
                scaleFactor = screenHeight / temp;
            }

            return scaleFactor;
        }

        #endregion
    }
}
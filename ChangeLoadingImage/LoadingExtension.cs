using System;
using System.Net;
using System.Net.Security;
using System.Reflection;
using Harmony;
using ICities;
using UnityEngine;

namespace ChangeLoadingImage
{
    public class LoadingExtension : LoadingExtensionBase
    {
        private HarmonyInstance HarmonyInstance;
        private RemoteCertificateValidationCallback Callback = (sender, cert, chain, sslPolicyErrors) => true;

        public override void OnCreated(ILoading loading)
        {
            ServicePointManager.ServerCertificateValidationCallback += Callback;
            HarmonyInstance = HarmonyInstance.Create("github.com/bloodypenguin/ChangeLoadingImage");
            var original = GetOriginal();
            var prefix = typeof(LoadingAnimationPatch).GetMethod("Prefix", BindingFlags.Static | BindingFlags.Public);
            HarmonyInstance.Patch(original, new HarmonyMethod(prefix));
        }

        private MethodBase GetOriginal()
        {
            try
            {
                var loadingScreenModType = Util.FindType("LoadingScreenMod.LoadingScreen");
                if (loadingScreenModType != null)
                {
                    if (Util.IsModActive(667342976) || Util.IsModActive(833779378))
                    {
                        Debug.LogWarning("LoadingScreenMod was detected as active. Applying workaround...");
                        return loadingScreenModType.GetMethod("SetImage", BindingFlags.Instance | BindingFlags.Public);
                    }
                    else
                    {
                        Debug.LogWarning("LoadingScreenMod was detected as disabled");
                    }
                }
                else
                {
                    Debug.LogWarning("LoadingScreenMod was not detected");
                }
            }
            catch (Exception e)
            {
                Debug.LogError(
                    "Due to some unexpected problems Change Loading Image 2 wasn't able to detect if LoadingScreenMod is active");
                Debug.LogException(e);
            }
            return typeof(LoadingAnimation).GetMethod("SetImage", BindingFlags.Instance | BindingFlags.Public);
        }

        public override void OnReleased()
        {
            ServicePointManager.ServerCertificateValidationCallback -= Callback;
            HarmonyInstance?.UnpatchAll();
        }
    }
}
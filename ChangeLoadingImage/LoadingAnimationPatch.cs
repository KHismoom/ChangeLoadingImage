using Harmony;
using UnityEngine;


namespace ChangeLoadingImage
{
    public class LoadingAnimationPatch
    {
        public static void Prefix(LoadingAnimation __instance, Mesh mesh, ref Material material, ref float scale,
            bool showAnimation)
        {
            OverrideLoadingImage.OverrideTextureAndScale(ref material, ref scale);
        }

    }
}
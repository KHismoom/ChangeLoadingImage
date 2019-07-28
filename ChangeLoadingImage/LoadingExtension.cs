using System;
using System.Net;
using System.Reflection;
using Harmony;
using ICities;

namespace ChangeLoadingImage
{
    public class LoadingExtension : LoadingExtensionBase
    {
        private HarmonyInstance HarmonyInstance;
        
        public override void OnCreated (ILoading loading)
        {
            ServicePointManager
                    .ServerCertificateValidationCallback += 
                (sender, cert, chain, sslPolicyErrors) => true;
            HarmonyInstance = HarmonyInstance.Create("github.com/bloodypenguin/ChangeLoadingImage");
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly()); 
        }

        public override void OnReleased()
        {
            HarmonyInstance?.UnpatchAll();
        }
    }
}
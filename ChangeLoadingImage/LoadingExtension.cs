using System.Net;
using System.Net.Security;
using System.Reflection;
using Harmony;
using ICities;

namespace ChangeLoadingImage
{
    public class LoadingExtension : LoadingExtensionBase
    {
        private HarmonyInstance HarmonyInstance;
        private RemoteCertificateValidationCallback Callback = (sender, cert, chain, sslPolicyErrors) => true;
        
        public override void OnCreated (ILoading loading)
        {
            ServicePointManager.ServerCertificateValidationCallback += Callback;
            HarmonyInstance = HarmonyInstance.Create("github.com/bloodypenguin/ChangeLoadingImage");
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly()); 
        }

        public override void OnReleased()
        {
            ServicePointManager.ServerCertificateValidationCallback -= Callback;
            HarmonyInstance?.UnpatchAll();
        }
    }
}
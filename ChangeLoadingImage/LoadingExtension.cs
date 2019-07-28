using System;
using System.Net;
using ICities;

namespace ChangeLoadingImage
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnCreated (ILoading loading)
        {
            ServicePointManager
                    .ServerCertificateValidationCallback += 
                (sender, cert, chain, sslPolicyErrors) => true;
            LoadingAnimationDetour r = new LoadingAnimationDetour();
            r.Deploy ();      
        }

        public override void OnLevelUnloading ()
        {
            LoadingAnimationDetour r = new LoadingAnimationDetour();
            r.Deploy (); 
        }
    }
}
using ChangeLoadingImage.OptionsFramework;
using ChangeLoadingImage.OptionsFramework.Extensions;
using CitiesHarmony.API;
using ICities;
namespace ChangeLoadingImage
{
    public class ChangeLoadingImageMod : IUserMod
    {
        public string Name => "Change Loading Image 2";

        public string Description => "Changes the loading image";
        
        public void OnSettingsUI(UIHelperBase helper)
        {
            foreach (var uiComponent in helper.AddOptionsGroup(XmlOptionsWrapper<Settings>.Instance))
            {
                uiComponent.width = 700;
            }
        }
        
        public void OnEnabled() {
            HarmonyHelper.EnsureHarmonyInstalled();
        }
    }
}
using System.ComponentModel;

namespace ChangeLoadingImage.OptionsFramework
{
    public enum ImageType
    {
        [Description("Random image from imgur.com/r/CitiesSkylines")]
        RandomImageFromImgur = 0,
        [Description("Static environment image from pre-After Dark (a.k.a. Classic mode)")]
        ClassicEnvironmentImage = 1
    }
}
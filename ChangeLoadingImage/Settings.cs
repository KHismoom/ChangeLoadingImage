using ChangeLoadingImage.OptionsFramework;
using ChangeLoadingImage.OptionsFramework.Attributes;

namespace ChangeLoadingImage
{
    [XmlOptions("ChangeLoadingImage")]
    public class Settings
    {
        [EnumDropDown("Mode", typeof(ImageType))]
        public int Mode { get; set; } = (int) ImageType.RandomImageFromImgur;
    }
}
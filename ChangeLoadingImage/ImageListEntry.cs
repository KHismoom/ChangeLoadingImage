using System.IO;

namespace ChangeLoadingImage
{
    public class ImageListEntry
    {
        public string uri;


        public ImageListEntry(string uri)
        {
            this.uri = uri;
        }

        public bool IsHttp => this.uri.ToLower().StartsWith("http:") || this.uri.ToLower().StartsWith("https:");

        public bool IsFile => !IsHttp && !Directory.Exists(uri) && File.Exists(uri);

        public bool IsDirectory
        {
            get
            {
                if (IsHttp || IsFile)
                {
                    return false;
                }

                var attr = File.GetAttributes(uri);
                return (attr & FileAttributes.Directory) == FileAttributes.Directory;
            }
        }

        public override bool Equals(object other)
        {
            if (!(other is ImageListEntry entry))
            {
                return false;
            }

            return uri == entry.uri;
        }

        public override int GetHashCode()
        {
            return uri.GetHashCode();
        }
    }
}
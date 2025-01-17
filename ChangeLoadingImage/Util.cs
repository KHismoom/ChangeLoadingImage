using System;
using System.IO;
using System.Linq;
using ColossalFramework.Plugins;
using ICities;
using UnityEngine;

namespace ChangeLoadingImage
{
    public static class Util
    {
        public static string AssemblyDirectory
        {
            get
            {
                var pluginManager = PluginManager.instance;
                var plugins = pluginManager.GetPluginsInfo();

                foreach (var item in plugins)
                {
                    try
                    {
                        var instances = item.GetInstances<IUserMod>();
                        if (!(instances.FirstOrDefault() is ChangeLoadingImageMod))
                        {
                            continue;
                        }

                        return item.modPath;
                    }
                    catch
                    {
                    }
                }

                throw new Exception("Failed to find ChangeLoadingImage assembly!");
            }
        }

        public static Texture2D LoadTextureFromFile(string path, bool readOnly = false)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            try
            {
                using (var textureStream = File.OpenRead(path))
                {
                    return LoadTextureFromStream(readOnly, textureStream);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return null;
            }
        }

        private static Texture2D LoadTextureFromStream(bool readOnly, Stream textureStream)
        {
            var buf = new byte[textureStream.Length]; //declare arraysize
            textureStream.Read(buf, 0, buf.Length); // read from stream to byte array
            textureStream.Close();
            var tex = new Texture2D(2, 2, TextureFormat.ARGB32, false);
            tex.LoadImage(buf);
            tex.name = Guid.NewGuid().ToString();
            tex.filterMode = FilterMode.Trilinear;
            tex.anisoLevel = 9;
            tex.Apply(false, readOnly);
            return tex;
        }
        
        public static Type FindType(string classFullName)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    var types = assembly.GetTypes();
                    foreach (var type in types.Where(type => type.FullName == classFullName))
                    {
                        return type;
                    }
                }
                catch
                {
                    // ignored
                }
            }
            return null;
        }
        
        public static bool IsModActive(ulong modId)
        {
            var plugins = PluginManager.instance.GetPluginsInfo();
            return plugins.Any(p => p != null && p.isEnabled && p.publishedFileID.AsUInt64 == modId);
        }
    }
}
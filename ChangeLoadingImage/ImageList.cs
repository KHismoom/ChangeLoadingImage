using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using ColossalFramework.HTTP;
using Random = System.Random;
using ColossalFramework.IO;
using ColossalFramework.Threading;

namespace ChangeLoadingImage
{
    public class ImageList
    {
        public static List<ImageListEntry> imageListFromImgur(int page)
        {
            var entries = new List<ImageListEntry>();
            var imgurFeed = new WebClient().DownloadString($"http://imgur.com/r/CitiesSkylines/new/page/{page}/hit?scrolled");  //or http://imgur.com/r/CitiesSkylines/top?scrolled
            var matches = Regex.Matches(imgurFeed, @"<div id=\""(.*)\"" class=\""post\"">");
            foreach (Match match in matches)
            {
                var matchValue = match.Value;
                var index = matchValue.IndexOf("<div id=\"");
                var str = matchValue.Substring(index + 9, 7);
               UnityEngine.Debug.LogWarning($"http://i.imgur.com/{str}.jpg");
               entries.Add(new ImageListEntry($"http://i.imgur.com/{str}.jpg", "", "", ""));
            }

            return entries;
        }
        

   }
    
}

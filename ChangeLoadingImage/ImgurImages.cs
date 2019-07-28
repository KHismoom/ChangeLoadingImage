using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace ChangeLoadingImage
{
    public static class ImgurImages
    {
        public static List<ImageListEntry> ImageListFromImgur(int page)
        {
            var entries = new List<ImageListEntry>();
            var imgurFeed =
                new WebClient().DownloadString(
                    $"http://imgur.com/r/CitiesSkylines/new/page/{page}/hit?scrolled"); //or http://imgur.com/r/CitiesSkylines/top?scrolled
            var matches = Regex.Matches(imgurFeed, @"<div id=\""(.*)\"" class=\""post\"">");
            foreach (Match match in matches)
            {
                var matchValue = match.Value;
                var index = matchValue.IndexOf("<div id=\"");
                var str = matchValue.Substring(index + 9, 7);
                entries.Add(new ImageListEntry($"http://i.imgur.com/{str}.jpg"));
            }

            return entries;
        }

        public static List<ImageListEntry> DefaultImageList =>
            new List<ImageListEntry>
            {
                new ImageListEntry("http://i.imgur.com/JbWQLJX.jpg"),
                new ImageListEntry("http://i.imgur.com/wSqsUeG.jpg"),
                new ImageListEntry("http://i.imgur.com/4jZvqLy.jpg"),
                new ImageListEntry("http://i.imgur.com/Z58lVbd.jpg"),
                new ImageListEntry("http://i.imgur.com/ger5HID.jpg"),
                new ImageListEntry("http://i.imgur.com/CDYVa0G.jpg"),
                new ImageListEntry("http://i.imgur.com/ZRYNL6M.jpg"),
                new ImageListEntry("http://i.imgur.com/9PPtl5M.jpg"),
                new ImageListEntry("http://i.imgur.com/TewWRrV.jpg"),
                new ImageListEntry("http://i.imgur.com/uYWjck2.jpg"),
                new ImageListEntry("http://i.imgur.com/RbPjrLZ.jpg"),
                new ImageListEntry("http://i.imgur.com/C1LAmJE.jpg"),
                new ImageListEntry("http://i.imgur.com/KuHLYpC.jpg"),
                new ImageListEntry("http://i.imgur.com/btkOJuj.jpg"),
                new ImageListEntry("http://i.imgur.com/l005ZQa.jpg"),
                new ImageListEntry("http://i.imgur.com/z3KELWU.png"),
                new ImageListEntry("http://i.imgur.com/BQpbKP1.jpg"),
                new ImageListEntry("http://i.imgur.com/P6CMu1N.jpg"),
                new ImageListEntry("http://i.imgur.com/hB846Q5.jpg"),
                new ImageListEntry("http://i.imgur.com/Ahv4scy.jpg"),
                new ImageListEntry("http://i.imgur.com/QI0qxyb.jpg"),
                new ImageListEntry("http://i.imgur.com/oBihvV0.jpg"),
                new ImageListEntry("http://i.imgur.com/RxvSCFz.jpg"),
                new ImageListEntry("http://i.imgur.com/EeklbxQ.jpg"),
                new ImageListEntry("http://i.imgur.com/BgsVZEI.jpg"),
                new ImageListEntry("http://i.imgur.com/z3xQGT9.jpg"),
                new ImageListEntry("http://i.imgur.com/dyavD1s.jpg"),
                new ImageListEntry("http://i.imgur.com/nYeGAmr.jpg"),
                new ImageListEntry("http://i.imgur.com/GYzN9fX.jpg"),
                new ImageListEntry("http://i.imgur.com/ZIqLrJM.jpg"),
                new ImageListEntry("http://i.imgur.com/2QxzO98.jpg"),
                new ImageListEntry("http://i.imgur.com/3w9TSUh.jpg"),
                new ImageListEntry("http://i.imgur.com/khyuJxo.jpg"),
                new ImageListEntry("http://i.imgur.com/C3CxLlx.jpg"),
                new ImageListEntry("http://i.imgur.com/plprqgC.jpg"),
                new ImageListEntry("http://i.imgur.com/puJUL4s.jpg"),
                new ImageListEntry("http://i.imgur.com/zP5nndL.jpg"),
                new ImageListEntry("http://i.imgur.com/vWPw4aB.jpg"),
                new ImageListEntry("http://i.imgur.com/280KFEG.jpg"),
                new ImageListEntry("http://i.imgur.com/TwxmtYB.jpg"),
                new ImageListEntry("http://i.imgur.com/HZ9ZUGF.jpg"),
                new ImageListEntry("http://i.imgur.com/a0TeAwC.jpg"),
                new ImageListEntry("http://i.imgur.com/7J8nNus.jpg"),
                new ImageListEntry("http://i.imgur.com/q6zzMGP.jpg"),
                new ImageListEntry("http://i.imgur.com/n90hE77.jpg"),
                new ImageListEntry("http://i.imgur.com/rHq5lVQ.jpg"),
                new ImageListEntry("http://i.imgur.com/zoS4RBY.jpg")
            };
    }
}
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using UnityEngine;

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
                Debug.LogWarning($"http://i.imgur.com/{str}.jpg");
                entries.Add(new ImageListEntry($"http://i.imgur.com/{str}.jpg", "", "", ""));
            }

            return entries;
        }

        public static List<ImageListEntry> DefaultImageList =>
            new List<ImageListEntry>
            {
                new ImageListEntry("http://i.imgur.com/JbWQLJX.jpg", "Backyards", "nlight",
                    "imgur.com/a/DRQTy"),
                new ImageListEntry("http://i.imgur.com/wSqsUeG.jpg", "Highrises", "nlight",
                    "imgur.com/a/DRQTy"),
                new ImageListEntry("http://i.imgur.com/4jZvqLy.jpg", "100,000 strong today", "ossahib",
                    "redd.it/2zcd5v"),
                new ImageListEntry("http://i.imgur.com/Z58lVbd.jpg", "Back Roads", "rik4000",
                    "reddit.it/31xb4i"),
                new ImageListEntry("http://i.imgur.com/ger5HID.jpg", "Green Energy", "rik4000",
                    "reddit.com/user/rik4000"),
                new ImageListEntry("http://i.imgur.com/CDYVa0G.jpg", "First Person", "raiderofawesome",
                    "redd.it/2ypjuu"),
                new ImageListEntry("http://i.imgur.com/ZRYNL6M.jpg", "Urban T-Interchange", "laosimerah",
                    "redd.it/2ytzo2"),
                new ImageListEntry("http://i.imgur.com/9PPtl5M.jpg", "200,000 and space for more",
                    "laosimerah", "redd.it/2zegoe"),
                new ImageListEntry("http://i.imgur.com/TewWRrV.jpg", "Sunken Highways", "laosimerah",
                    "redd.it/30oqmh"),
                new ImageListEntry("http://i.imgur.com/uYWjck2.jpg", "Highway Service Station", "IVIaarten",
                    "redd.it/31kd5h"),
                new ImageListEntry("http://i.imgur.com/RbPjrLZ.jpg", "Low Field of View 1", "Simify",
                    "redd.it/2zan7v"),
                new ImageListEntry("http://i.imgur.com/C1LAmJE.jpg", "Low Field of View 2", "Simify",
                    "redd.it/2zan7v"),
                new ImageListEntry("http://i.imgur.com/KuHLYpC.jpg", "Welcome to Scotland", "Jonny1233",
                    "redd.it/31bcqo"),
                new ImageListEntry("http://i.imgur.com/btkOJuj.jpg", "Main train line to the city",
                    "Jonny1233", "redd.it/31bcqo"),
                new ImageListEntry("http://i.imgur.com/l005ZQa.jpg", "Anastilt", "Jonny1233", "redd.it/31bcqo"),
                new ImageListEntry("http://i.imgur.com/z3KELWU.png", "Little Ditches", "Simify",
                    "redd.it/30z571"),
                new ImageListEntry("http://i.imgur.com/BQpbKP1.jpg", "Small Town 1", "Snakorn",
                    "redd.it/31nyup"),
                new ImageListEntry("http://i.imgur.com/P6CMu1N.jpg", "Small Town 2", "Snakorn",
                    "redd.it/31nyup"),
                new ImageListEntry("http://i.imgur.com/hB846Q5.jpg", "Small Town 3", "Snakorn",
                    "redd.it/31nyup"),
                new ImageListEntry("http://i.imgur.com/Ahv4scy.jpg", "Small Town 4", "Snakorn",
                    "redd.it/31nyup"),
                new ImageListEntry("http://i.imgur.com/QI0qxyb.jpg", "Small Town 5", "Snakorn",
                    "redd.it/31nyup"),
                new ImageListEntry("http://i.imgur.com/oBihvV0.jpg", "Small Gaps", "Bonova",
                    "redd.it/2z78e7"),
                new ImageListEntry("http://i.imgur.com/RxvSCFz.jpg", "Midwesterner", "TheBlakers",
                    "redd.it/31xk40"),
                new ImageListEntry("http://i.imgur.com/EeklbxQ.jpg", "Korenth Valley 1", "OM3N1R",
                    "redd.it/2z390e"),
                new ImageListEntry("http://i.imgur.com/BgsVZEI.jpg", "Korenth Valley 2", "OM3N1R",
                    "redd.it/2z390e"),
                new ImageListEntry("http://i.imgur.com/z3xQGT9.jpg", "The Town", "wrogn", "redd.it/30pthp"),
                new ImageListEntry("http://i.imgur.com/dyavD1s.jpg", "A Neighbourhood", "wrogn",
                    "redd.it/30pthp"),
                new ImageListEntry("http://i.imgur.com/nYeGAmr.jpg", "Farms on the Outskirts", "wrogn",
                    "redd.it/30pthp"),
                new ImageListEntry("http://i.imgur.com/GYzN9fX.jpg", "Asteria capital", "Vicious713",
                    "redd.it/32hpnf"),
                new ImageListEntry("http://i.imgur.com/ZIqLrJM.jpg", "Asteria harbor", "Vicious713",
                    "redd.it/32hpnf"),
                new ImageListEntry("http://i.imgur.com/2QxzO98.jpg", "Overpass", "Vicious713",
                    "redd.it/323fmx"),
                new ImageListEntry("http://i.imgur.com/3w9TSUh.jpg", "Mountaintop Cathedral", "maledin",
                    "redd.it/30bbxf"),
                new ImageListEntry("http://i.imgur.com/khyuJxo.jpg", "Lorentum Airport", "maledin",
                    "redd.it/30bbxf"),
                new ImageListEntry("http://i.imgur.com/C3CxLlx.jpg", "Countdown", "guikolinger",
                    "redd.it/3305ce"),
                new ImageListEntry("http://i.imgur.com/plprqgC.jpg", "Fischer Heights", "mab1981",
                    "redd.it/330lkp"),
                new ImageListEntry("http://i.imgur.com/puJUL4s.jpg", "With decorative trees", "JuicyJuice23",
                    "redd.it/334ap8"),
                new ImageListEntry("http://i.imgur.com/zP5nndL.jpg", "Downtown", "JuicyJuice23",
                    "redd.it/334ap8"),
                new ImageListEntry("http://i.imgur.com/vWPw4aB.jpg", "Manhattan traffic", "zzjeffrey",
                    "redd.it/336uft"),
                new ImageListEntry("http://i.imgur.com/280KFEG.jpg", "A solar tomorrow", "zzjeffrey",
                    "redd.it/336uft"),
                new ImageListEntry("http://i.imgur.com/TwxmtYB.jpg", "Soccer", "zzjeffrey", "redd.it/336uft"),
                new ImageListEntry("http://i.imgur.com/HZ9ZUGF.jpg", "Cargo", "Novus_", "redd.it/3387bn"),
                new ImageListEntry("http://i.imgur.com/a0TeAwC.jpg", "Exports", "Novus_", "redd.it/3387bn"),
                new ImageListEntry("http://i.imgur.com/7J8nNus.jpg", "Canalville", "Starkie", "redd.it/33cp51"),
                new ImageListEntry("http://i.imgur.com/q6zzMGP.jpg", "Mountaineering", "Tassietiger1",
                    "redd.it/33hnrj"),
                new ImageListEntry("http://i.imgur.com/n90hE77.jpg", "Dosera river fork", "BirdsOfHell",
                    "redd.it/33glm6"),
                new ImageListEntry("http://i.imgur.com/rHq5lVQ.jpg", "Dosera forestry", "BirdsOfHell",
                    "redd.it/33glm6"),
                new ImageListEntry("http://i.imgur.com/zoS4RBY.jpg", "Bird's-Eye View", "BirdsOfHell",
                    "redd.it/33glm6")
            };
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vkMusicDownloader
{
    public class MusicList
    {
        public List<MusicItem> List = new List<MusicItem>();

        public MusicList(string m3u)
        {
            Load(m3u);
        }

        private void Load(string m3u)
        {
            string line;

            MusicItem item = new MusicItem();
            using (var file = new StringReader(m3u))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("#EXTINF"))
                    {
                        item = new MusicItem();
                        var headInfo = line.Split(',')[0];

                        var description = line.Replace(headInfo + ",", "");
                        item.FullSongName = description;
                       // item.Artist = description[0];

                       // item.Song = string.Join("", description.Skip(1));                       
                    }

                    if (line.StartsWith("https")) {
                        item.URL = line.Trim();
                        List.Add(item);
                    }

                   // Console.WriteLine(line);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace vkMusicDownloader
{
    class Program
    {
        private string m3uPath; 

        static void Main(string[] args)
        {


            var file = File.ReadAllText("muzon.m3u");
            var mList = new MusicList(file);
        
            DownloadP(mList);
        }

        static int n = 1;



        public static void DownloadP(MusicList muzonList)
        {
            Parallel.ForEach(muzonList.List , new ParallelOptions { MaxDegreeOfParallelism = 10 }, DownloadMusicItem);
        }



        private static void DownloadMusicItem(MusicItem mItem)
        {
            Console.WriteLine(n++ + " - " + mItem.FullSongName);
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(mItem.URL, @"K:\Google Music\temp\" + mItem.FullSongName + ".mp3");
                }
            }
            catch (Exception ex) {
                Console.WriteLine("ERROR - " + mItem.FullSongName);
            }
        }


        private static void DownloadFile(string url)
        {
            Console.WriteLine(n++);
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, @"K:\Google Music\temp\" + Guid.NewGuid() + ".mp3");
            }
        }
    }
}

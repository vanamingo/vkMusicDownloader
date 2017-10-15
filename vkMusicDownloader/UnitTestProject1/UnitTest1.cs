using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using vkMusicDownloader;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var file = File.ReadAllText("test.m3u");
            var list = new MusicList(file);
        }
    }
}

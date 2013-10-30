using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SongTagger.Hughesdon.Tests
{
    [TestFixture]
    class TrackTaggerTests
    {
        [Test]
        public void GetMp3Files_EnsureAllAreMp3s()
        {
            var files = TrackTagger.GetMp3Files(@"c:\temp\before");
            foreach (var file in files)
            {
                Assert.That(file.EndsWith(".mp3"));
            }
        }
    }
}

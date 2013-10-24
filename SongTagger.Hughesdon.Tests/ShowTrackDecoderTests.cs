using NUnit.Framework;
using SongTagger.Hughesdon.Decoders;

namespace SongTagger.Hughesdon.Tests
{
    [TestFixture]
    public class ShowTrackDecoderTests
    {
        [TestCase("Anytime You Need A Friend LR SHOW (2012-13) MP3.mp3", "Anytime You Need A Friend")]
        [TestCase("Something Inside So Strong L-R SHOW final.mp3", "Something Inside So Strong")]
        [TestCase("WHERE YOU LEAD L-R SHOW_08.mp3", "Where You Lead")]
        [TestCase("Ain't no Mountain SHOW L-R (WITH AD LIB).mp3", "Ain't No Mountain")]
        [TestCase("ANYTIME YOU NEED A FRIEND Stereo Final (2012-13).mp3", "Anytime You Need A Friend")]
        [Test]
        public void DecodeFileTitle_KnownTitles_ExtractsTitle(string filename, string title)
        {
            var parser = GetDecoder();
            var properties = parser.DecodeFileName(filename);

            Assert.AreEqual(title, properties.Title);
        }


        [TestCase("Anytime You Need A Friend LR SHOW (2012-13) MP3.mp3", "L-R Show")]
        [TestCase("Something Inside So Strong L-R SHOW final.mp3", "L-R Show")]
        [TestCase("WHERE YOU LEAD L-R SHOW_08.mp3", "L-R Show")]
        [TestCase("Ain't no Mountain SHOW L-R (WITH AD LIB).mp3", "L-R Show")]
        [TestCase("ANYTIME YOU NEED A FRIEND Stereo Final (2012-13).mp3", "Stereo")]
        [TestCase("SOMETHING INSIDE SO STRONG (Stereo Show Final).mp3", "Stereo")]
        [TestCase("HOW DEEP IS YOUR LOVE L-R Performance.mp3", "L-R Performance")]
        [Test]
        public void DecodeFileTitle_KnownTitles_ExtractsPart(string filename, string part)
        {
            var parser = GetDecoder(); 
            var properties = parser.DecodeFileName(filename);

            Assert.AreEqual(part, properties.Part);
        }

        [TestCase("ANYTIME YOU NEED A FRIEND Stereo Final (2012-13).mp3", 2012)]
        [Test]
        public void DecodeFileTitle_KnownTitles_ExtractsYear(string filename, int year)
        {
            var parser = GetDecoder();
            var properties = parser.DecodeFileName(filename);

            Assert.AreEqual(year, properties.Year);
        }

        [Test]
        public void DecodeFileTitle_KnownTitles_SetsArtist()
        {
            string knownTrackTitle = "ANYTIME YOU NEED A FRIEND Stereo Final (2012-13).mp3";
            string expectedArtist = "Rock Choir";

            var parser = GetDecoder();
            var properties = parser.DecodeFileName(knownTrackTitle);

            Assert.AreEqual(expectedArtist, properties.Artist);
        }

        private static ITrackDecoder GetDecoder()
        {
            var parser = new ShowTrackDecoder();
            return parser;
        }
    }
}

using NUnit.Framework;
using SongTagger.Hughesdon.Decoders;

namespace SongTagger.Hughesdon.Tests
{
    [TestFixture]
    public class RockieTrackDecoderTests
    {
        [TestCase("Livin' On A Prayer Full Choir.mp3", "Livin' On A Prayer")]
        [TestCase("PROUD Full Choir (2012-13 New Mix Feb 13).mp3", "Proud")]
        [TestCase("YOU'RE THE VOICE Bass (2012-13).mp3","You're The Voice")]
        [TestCase("TAKE ON ME Upper Bass (2012-13).mp3", "Take On Me")]
        [TestCase("HOW DEEP IS YOUR LOVE Alto (2012_13).mp3", "How Deep Is Your Love")]
        [TestCase("You're So Vain SOPRANO.mp3", "You're So Vain")]
        [TestCase("Livin' On A Prayer - Bass.mp3", "Livin' On A Prayer")]
        [TestCase("YOU'VE LOST THAT LOVING FEELING Medium (MEN ONLY).mp3", "You've Lost That Loving Feeling")]
        [Test]
        public void DecodeFileTitle_KnownTitles_ExtractsTitle(string filename, string title)
        {
            var parser = new RockieTrackDecoder();
            var properties = parser.DecodeFileName(filename);

            Assert.AreEqual(title, properties.Title);
        }
        

        [TestCase("Livin' On A Prayer Full Choir.mp3", "Full Choir")]
        [TestCase("PROUD Full Choir (2012-13 New Mix Feb 13).mp3", "Full Choir")]
        [TestCase("YOU'RE THE VOICE Bass (2012-13).mp3", "Bass")]
        [TestCase("TAKE ON ME Upper Bass (2012-13).mp3", "Upper Bass")]
        [TestCase("HOW DEEP IS YOUR LOVE Alto (2012_13).mp3", "Alto")]
        [TestCase("You're So Vain SOPRANO.mp3", "Soprano")]
        [TestCase("Livin' On A Prayer - Bass.mp3", "Bass")]
        [TestCase("YOU'VE LOST THAT LOVING FEELING Medium (MEN ONLY).mp3", "Middle Bass")]
        [Test]
        public void DecodeFileTitle_KnownTitles_ExtractsPart(string filename, string part)
        {
            var parser = new RockieTrackDecoder();
            var properties = parser.DecodeFileName(filename);

            Assert.AreEqual(part, properties.Part);
        }

        [TestCase("HOW DEEP IS YOUR LOVE Alto (2012_13).mp3", 2012)]
        [TestCase("Livin' On A Prayer - Bass.mp3", 2013)]
        [Test]
        public void DecodeFileTitle_KnownTitles_ExtractsYear(string filename, int year)
        {
            var parser = new RockieTrackDecoder();
            var properties = parser.DecodeFileName(filename);

            Assert.AreEqual(year, properties.Year);
        }

        [Test]
        public void DecodeFileTitle_KnownTitles_SetsArtist()
        {
            string knownTrackTitle = "Livin' On A Prayer - Bass.mp3";
            string expectedArtist = "Rock Choir";

            var parser = new RockieTrackDecoder();
            var properties = parser.DecodeFileName(knownTrackTitle);

            Assert.AreEqual(expectedArtist, properties.Artist);
        }
    }
}

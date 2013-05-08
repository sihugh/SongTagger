using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SongTagger.Hughesdon.Tests
{
    [TestFixture]
    public class TagExtractorTests
    {
        [TestCase("Livin' On A Prayer Full Choir.mp3", "Livin' On A Prayer", "Full Choir")]
        [TestCase("PROUD Full Choir (2012-13 New Mix Feb 13).mp3", "Proud", "Full Choir")]
        [TestCase("YOU'RE THE VOICE Bass (2012-13).mp3","You're The Voice", "Bass")]
        [TestCase("TAKE ON ME Upper Bass (2012-13).mp3", "Take On Me", "Upper Bass")]
        [TestCase("HOW DEEP IS YOUR LOVE Alto (2012_13).mp3", "How Deep Is Your Love", "Alto")]
        [TestCase("You're So Vain SOPRANO.mp3", "You're So Vain", "Soprano")]
        [TestCase("Livin' On A Prayer - Bass.mp3", "Livin' On A Prayer", "Bass")]
        [Test]
        public void NameParser_StandardName_ExtractsTitleAndPart(string filename, string title, string part)
        {
            var parser = new NameTagger();
            var properties = parser.DecodeSongProperties(filename);

            Assert.AreEqual(title, properties.Title);
            Assert.AreEqual(part, properties.Part);
        }
    }
}

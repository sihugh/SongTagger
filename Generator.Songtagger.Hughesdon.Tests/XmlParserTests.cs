using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Generator.SongTagger.Hughesdon;
using NUnit.Framework;

namespace Generator.Songtagger.Hughesdon.Tests
{
    [TestFixture]
    public class XmlParserTests
    {

        [Test]
        public void Stuff()
        {
            var parts = XDocument.Parse(partsXml);
            var songs = XDocument.Parse(songsXml);
            var files = XDocument.Parse(filesXml);

            var parser = new Parser();
            var song = parser.GetSong("ANYTIME YOU NEED A FRIEND Alto (2012_13).mp3", songs.Root.Descendants("song"), files.Root.Descendants("file"), parts.Root.Descendants("part"));

            Assert.AreEqual("Any Time You Need A Friend", song.Title);

        }

        string partsXml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<parts>
  <part>
    <name>Upper Soprano</name>
    <id>D00ED7A6-D6B7-4D18-BB9D-D11AC2C3111E</id>
    <synonym>Upper Sop</synonym>
  </part>
  <part>
    <name>Lower Soprano</name>
    <id>4E803FAA-0FB1-4D85-8028-E63ED36AEECA</id>
    <synonym>Lower Sop</synonym>
  </part>
  <part>
    <name>Soprano</name>
    <id>AF8C0C8A-17F2-4B9D-9EA3-8787175DA47B</id>
    <synonym>Sop</synonym>
  </part>
  <part>
    <name>Upper Alto</name>
    <id>375EF4F5-A70D-49BC-9B45-827F666D7C70</id>
  </part>
  <part>
    <name>Lower Alto</name>
    <id>5558A2D7-4BD7-4701-82EF-8094EEF612A1</id>
  </part>
  <part>
    <name>Alto</name>
    <id>05276B3A-0CD2-4010-A5CB-33D91774B095</id>
  </part>
  <part>
    <name>Upper Bass</name>
    <id>2B7B8531-2419-480D-A911-8EB68F03C70A</id>
  </part>
  <part>
    <name>Lower Bass</name>
    <id>64C511BD-4551-421D-B884-C078573C8F58</id>
  </part>
  <part>
    <name>Bass</name>
    <id>C6C87B3A-2AF2-4E26-AD12-17356074FFF1</id>
  </part>
  <part>
    <name>Backing Track</name>
    <id>4434052F-E437-4B6B-9E13-1C423F00E503</id>
  </part>
  <part>
    <name>Full Choir</name>
    <id>57599414-A5AB-4441-96EB-BF130B979A4E</id>
    <synonym>Whole Choir</synonym>
  </part>
</parts>";

        string filesXml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<files>
  <file>
    <name>AIN'T NO MOUNTAIN Alto (2012_13).mp3</name>
    <songId>AA8C97ED-4014-4EC3-927B-3E032BFB03D1</songId>
    <partId>05276B3A-0CD2-4010-A5CB-33D91774B095</partId>
  </file>
  <file>
    <name>AIN'T NO MOUNTAIN Bass (2012_13).mp3</name>
    <songId>AA8C97ED-4014-4EC3-927B-3E032BFB03D1</songId>
    <partId>C6C87B3A-2AF2-4E26-AD12-17356074FFF1</partId>
  </file>
  <file>
    <name>AIN'T NO MOUNTAIN Soprano (2012_13).mp3</name>
    <songId>AA8C97ED-4014-4EC3-927B-3E032BFB03D1</songId>
    <partId>AF8C0C8A-17F2-4B9D-9EA3-8787175DA47B</partId>
  </file>
  <file>
    <name>ANYTIME YOU NEED A FRIEND Alto (2012_13).mp3</name>
    <partId>05276B3A-0CD2-4010-A5CB-33D91774B095</partId>
    <songId>3D7898B1-603F-4DE0-A5CB-C8B7A938D68B</songId>
  </file>
  <file>
    <name>ANYTIME YOU NEED A FRIEND Bass (2012_13).mp3</name>
    <partId>C6C87B3A-2AF2-4E26-AD12-17356074FFF1</partId>
    <songId>3D7898B1-603F-4DE0-A5CB-C8B7A938D68B</songId>
  </file>
  <file>
    <name>ANYTIME YOU NEED A FRIEND Soprano (2012_13).mp3</name>
    <partId>AF8C0C8A-17F2-4B9D-9EA3-8787175DA47B</partId>
    <songId>3D7898B1-603F-4DE0-A5CB-C8B7A938D68B</songId>
  </file>
  <file>
    <name>HOW DEEP IS YOUR LOVE Alto (2012_13).mp3</name>
    <songId>8E0FABF8-1200-4AAE-ADCF-B49CF6F1A238</songId>
    <partId>05276B3A-0CD2-4010-A5CB-33D91774B095</partId>
  </file>
  <file>
    <name>HOW DEEP IS YOUR LOVE Bass (2012_13).mp3</name>
    <songId>8E0FABF8-1200-4AAE-ADCF-B49CF6F1A238</songId>
    <partId>C6C87B3A-2AF2-4E26-AD12-17356074FFF1</partId>
  </file>
  <file>
    <name>HOW DEEP IS YOUR LOVE Full Choir (2012_13).mp3</name>
    <songId>8E0FABF8-1200-4AAE-ADCF-B49CF6F1A238</songId>
    <partId>57599414-A5AB-4441-96EB-BF130B979A4E</partId>
  </file>
  <file>
    <name>HOW DEEP IS YOUR LOVE Lower Soprano (2012_13).mp3</name>
    <songId>8E0FABF8-1200-4AAE-ADCF-B49CF6F1A238</songId>
    <partId>4E803FAA-0FB1-4D85-8028-E63ED36AEECA</partId>
  </file>
  <file>
    <name>HOW DEEP IS YOUR LOVE Upper Soprano (2012_13).mp3</name>
    <songId>8E0FABF8-1200-4AAE-ADCF-B49CF6F1A238</songId>
    <partId>D00ED7A6-D6B7-4D18-BB9D-D11AC2C3111E</partId>
  </file>
  <file>
    <name>Livin' On A Prayer - Alto.mp3</name>
    <songId>0558D101-07D4-45FE-96DA-9F21F229D67B</songId>
    <partId>05276B3A-0CD2-4010-A5CB-33D91774B095</partId>
  </file>
  <file>
    <name>Livin' On A Prayer - Bass.mp3</name>
    <songId>0558D101-07D4-45FE-96DA-9F21F229D67B</songId>
    <partId>C6C87B3A-2AF2-4E26-AD12-17356074FFF1</partId>
  </file>
  <file>
    <name>Livin' On A Prayer - Full Choir.mp3</name>
    <songId>0558D101-07D4-45FE-96DA-9F21F229D67B</songId>
    <partId>57599414-A5AB-4441-96EB-BF130B979A4E</partId>
  </file>
  <file>
    <name>Livin' On A Prayer - Sop.mp3</name>
    <songId>0558D101-07D4-45FE-96DA-9F21F229D67B</songId>
    <partId>AF8C0C8A-17F2-4B9D-9EA3-8787175DA47B</partId>
  </file>
  <file>
    <name>LIVIN' ON A PRAYER Alto (2012-13).mp3</name>
    <songId>0558D101-07D4-45FE-96DA-9F21F229D67B</songId>
    <partId>05276B3A-0CD2-4010-A5CB-33D91774B095</partId>
  </file>
  <file>
    <name>LIVIN' ON A PRAYER Bass (2012-13).mp3</name>
    <songId>0558D101-07D4-45FE-96DA-9F21F229D67B</songId>
    <partId>C6C87B3A-2AF2-4E26-AD12-17356074FFF1</partId>
  </file>
  <file>
    <name>LIVIN' ON A PRAYER Full Choir (2012-13).mp3</name>
    <songId>0558D101-07D4-45FE-96DA-9F21F229D67B</songId>
    <partId>57599414-A5AB-4441-96EB-BF130B979A4E</partId>
 </file>
  <file>
    <name>LIVIN' ON A PRAYER Sop (2012-13).mp3</name>
    <songId>0558D101-07D4-45FE-96DA-9F21F229D67B</songId>
    <partId>AF8C0C8A-17F2-4B9D-9EA3-8787175DA47B</partId>
  </file>
  <file>
    <name>PROUD Full Choir (2012-13 New Mix Feb 13).mp3</name>
    <songId>7DA06607-07FC-4014-8DF3-35948A3A1E53</songId>
    <partId>57599414-A5AB-4441-96EB-BF130B979A4E</partId>
  </file>
  <file>
    <name>PROUD Lower Alto (2012-13 New Mix 14.01.13).mp3</name>
    <songId>7DA06607-07FC-4014-8DF3-35948A3A1E53</songId>
    <partId>5558A2D7-4BD7-4701-82EF-8094EEF612A1</partId>
  </file>
  <file>
    <name>PROUD Lower Bass (2012-13 New Mix 14.01.13).mp3</name>
    <songId>7DA06607-07FC-4014-8DF3-35948A3A1E53</songId>
    <partId>64C511BD-4551-421D-B884-C078573C8F58</partId>
  </file>
  <file>
    <name>PROUD Lower Sop (2012-13 New Mix 14.01.13).mp3</name>
    <songId>7DA06607-07FC-4014-8DF3-35948A3A1E53</songId>
    <partId>4E803FAA-0FB1-4D85-8028-E63ED36AEECA</partId>
  </file>
  <file>
    <name>PROUD Upper Alto (2012-13 New Mix 14.01.13).mp3</name>
    <songId>7DA06607-07FC-4014-8DF3-35948A3A1E53</songId>
    <partId>375EF4F5-A70D-49BC-9B45-827F666D7C70</partId>
  </file>
  <file>
    <name>PROUD Upper Bass (2012-13 New Mix 14.01.13).mp3</name>
    <songId>7DA06607-07FC-4014-8DF3-35948A3A1E53</songId>
    <partId>2B7B8531-2419-480D-A911-8EB68F03C70A</partId>
  </file>
  <file>
    <name>PROUD Upper Sop (2012-13 New Mix 14.01.13).mp3</name>
    <songId>7DA06607-07FC-4014-8DF3-35948A3A1E53</songId>
    <partId>D00ED7A6-D6B7-4D18-BB9D-D11AC2C3111E</partId>
  </file>
  <file>
    <name>SOMETHING INSIDE SO STRONG Alto (2012-13).mp3</name>
    <songId>CA3834DF-5B5F-483F-B498-519EED4FB7C3</songId>
    <partId>05276B3A-0CD2-4010-A5CB-33D91774B095</partId>
  </file>
  <file>
    <name>SOMETHING INSIDE SO STRONG Bass (2012-13).mp3</name>
    <songId>CA3834DF-5B5F-483F-B498-519EED4FB7C3</songId>
    <partId>C6C87B3A-2AF2-4E26-AD12-17356074FFF1</partId>
  </file>
  <file>
    <name>SOMETHING INSIDE SO STRONG Sop (2012-13).mp3</name>
    <songId>CA3834DF-5B5F-483F-B498-519EED4FB7C3</songId>
    <partId>AF8C0C8A-17F2-4B9D-9EA3-8787175DA47B</partId>
  </file>
  <file>
    <name>TAKE ON ME Full Choir (2012-13).mp3</name>
    <partId>57599414-A5AB-4441-96EB-BF130B979A4E</partId>
  </file>
  <file>
    <name>TAKE ON ME Lower Alto (2012-13).mp3</name>
    <partId>5558A2D7-4BD7-4701-82EF-8094EEF612A1</partId>
  </file>
  <file>
    <name>TAKE ON ME Lower Bass (2012-13).mp3</name>
    <partId>64C511BD-4551-421D-B884-C078573C8F58</partId>
  </file>
  <file>
    <name>TAKE ON ME Lower Soprano (2012-13).mp3</name>
    <partId>4E803FAA-0FB1-4D85-8028-E63ED36AEECA</partId>
  </file>
  <file>
    <name>TAKE ON ME Upper Alto (2012-13).mp3</name>
    <partId>375EF4F5-A70D-49BC-9B45-827F666D7C70</partId>
  </file>
  <file>
    <name>TAKE ON ME Upper Bass (2012-13).mp3</name>
    <partId>2B7B8531-2419-480D-A911-8EB68F03C70A</partId>
  </file>
  <file>
    <name>TAKE ON ME Upper Soprano (2012-13).mp3</name>
    <partId>D00ED7A6-D6B7-4D18-BB9D-D11AC2C3111E</partId>
  </file>
  <file>
    <name>Where You Lead - Whole Choir.mp3</name>
    <partId>57599414-A5AB-4441-96EB-BF130B979A4E</partId>
  </file>
  <file>
    <name>WHERE YOU LEAD Alto (2012_13).mp3</name>
    <partId>05276B3A-0CD2-4010-A5CB-33D91774B095</partId>
  </file>
  <file>
    <name>WHERE YOU LEAD Bass (2012_13).mp3</name>
    <partId>C6C87B3A-2AF2-4E26-AD12-17356074FFF1</partId>
  </file>
  <file>
    <name>WHERE YOU LEAD Full Choir (2012_13).mp3</name>
    <partId>57599414-A5AB-4441-96EB-BF130B979A4E</partId>
  </file>
  <file>
    <name>WHERE YOU LEAD Soprano (2012_13).mp3</name>
    <partId>AF8C0C8A-17F2-4B9D-9EA3-8787175DA47B</partId>
  </file>
  <file>
    <name>You're So Vain ALTO.mp3</name>
    <partId>05276B3A-0CD2-4010-A5CB-33D91774B095</partId>
  </file>
  <file>
    <name>You're So Vain BASS.mp3</name>
    <partId>C6C87B3A-2AF2-4E26-AD12-17356074FFF1</partId>
  </file>
  <file>
    <name>You're So Vain SOPRANO.mp3</name>
    <partId>AF8C0C8A-17F2-4B9D-9EA3-8787175DA47B</partId>
  </file>
  <file>
    <name>YOU'RE THE VOICE Alto (2012-13).mp3</name>
    <partId>05276B3A-0CD2-4010-A5CB-33D91774B095</partId>
  </file>
  <file>
    <name>YOU'RE THE VOICE Bass (2012-13).mp3</name>
    <partId>C6C87B3A-2AF2-4E26-AD12-17356074FFF1</partId>
  </file>
  <file>
    <name>YOU'RE THE VOICE Full Choir (2012-13).mp3</name>
    <partId>57599414-A5AB-4441-96EB-BF130B979A4E</partId>
  </file>
  <file>
    <name>YOU'RE THE VOICE Sop (2012-13).mp3</name>
    <partId>AF8C0C8A-17F2-4B9D-9EA3-8787175DA47B</partId>
  </file>
</files>";

        private string songsXml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<songs>
  <song>
    <id>AA8C97ED-4014-4EC3-927B-3E032BFB03D1</id>
    <title>Aint't No Mountain</title>
    <year>2012</year>
    <information>Year 2 track, Autumn 2012</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>6C480EC3-D781-47CC-BC69-EFA0FC1C2786</id>
    <title>All Over The World</title>
    <year>2013</year>
    <information>Year 2 track, Summer 2013</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>3D7898B1-603F-4DE0-A5CB-C8B7A938D68B</id>
    <title>Any Time You Need A Friend</title>
    <year>2012</year>
    <information>Year 2 track, Autumn 2012</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>502C0405-47F2-41D8-A93B-351AD363DD09</id>
    <title>Dancing In The Street</title>
    <year>2012</year>
    <information>Year 1 track, Spring 2012</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>D48B64F6-B1EB-4143-8D4D-C822D40F05FA</id>
    <title>Does Your Mother Know</title>
    <year>2013</year>
    <information></information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>8E0FABF8-1200-4AAE-ADCF-B49CF6F1A238</id>
    <title>How Deep Is Your Love</title>
    <year>2012</year>
    <information>Year 2 track, Autumn 2012</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>0558D101-07D4-45FE-96DA-9F21F229D67B</id>
    <title>Livin' On A Prayer</title>
    <year>2013</year>
    <information>Year 2 track, Summer 2013</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>F16524A5-A70F-4B26-8CFD-22B62F40328F</id>
    <title>Oh Happy Day</title>
    <year>2012</year>
    <information>Year 1 track, Spring 2012</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>7DA06607-07FC-4014-8DF3-35948A3A1E53</id>
    <title>Proud</title>
    <year>2013</year>
    <information>Year 2 track, Spring 2013</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>D1F6CAF2-A0F4-4CC9-94EB-B4F5C4F4A977</id>
    <title>Shoop Shoop (It's In His Kiss)</title>
    <year>2012</year>
    <information>Year 1 track, Spring 2012</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>CA3834DF-5B5F-483F-B498-519EED4FB7C3</id>
    <title>Something Inside So Strong</title>
    <year>2012</year>
    <information>Year 1 track, Summer 2012</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>B8FF1438-A50D-48B9-BE29-FBBD556A90B5</id>
    <title>Take On Me</title>
    <year>2013</year>
    <information>Year 2 track, Spring 2013</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>A204DD4D-BB51-4BF7-8EB5-9387A19D4858</id>
    <title>Try A Little Tenderness</title>
    <year>2013</year>
    <information>Year 2 track, Summer 2013</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>DB371963-DE1B-4BAA-A0EE-2E46E671A3F6</id>
    <title>Waterloo</title>
    <year>2012</year>
    <information>Year 1 track, Spring 2012</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>14A23978-8D29-4A43-9F04-1418487AE2AF</id>
    <title>When You're Gone</title>
    <year>2012</year>
    <information>Year 1 track, Summer 2012</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>62350D5A-B082-4ABD-BAC2-120B9DADF64F</id>
    <title>Where You Lead</title>
    <year>2012</year>
    <information>Year 2 track, Autumn 2012</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>9FBA7B91-EF9B-4E82-B65E-9FC077762D86</id>
    <title>You're So Vain</title>
    <year>2012</year>
    <information>Year 1 track, Summer 2012</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>3DEB7FDD-5214-471E-A844-ED4254C30287</id>
    <title>You're The Voice</title>
    <year>2013</year>
    <information>Year 2 track, Spring 2013</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
  <song>
    <id>253B074E-6CA5-495A-89A8-10FD4C9C4EC1</id>
    <title>You've Lost That Loving Feeling</title>
    <year>2013</year>
    <information>Year 2 track, Summer 2013</information>
    <album>72F45BEB-619D-45A8-B01B-F11ECB08CEFE</album>
  </song>
</songs>";
    }
}

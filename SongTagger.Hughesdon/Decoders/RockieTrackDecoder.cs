using System;
using SongTagger.Hughesdon.Constants;
using SongTagger.Hughesdon.Extensions;

namespace SongTagger.Hughesdon.Decoders
{
    public class RockieTrackDecoder
    {
        readonly string[] _voiceParts = "Full Choir With Solo,Full Choir,Upper Alto,Lower Alto,Alto,Upper Bass,Lower Bass,Bass,Upper Soprano,Lower Soprano,Soprano,Upper Sop,Lower Sop,Sop".Split(',');

        private const string ArtistName = "Rock Choir";
        private const string AlbumTitle = "Rock Choir Tracks";
  
        public SongProperties DecodeFileTitle(string filename)
        {
            foreach (string voicePart in _voiceParts)
            {
                int indexOfPart = filename.IndexOf(voicePart, StringComparison.OrdinalIgnoreCase);
                if (indexOfPart > -1)
                {
                    var title = ExtractTitle(filename, indexOfPart);

                    var songPart = ExtractSongPart(filename, indexOfPart, voicePart);

                    int year = ExtractSongYear(filename);

                    var props = new SongProperties {Part = songPart, Title = title, Year = year, AlbumTitle = AlbumTitle, Artist = ArtistName};
                    return props;
                }

            }
            return new SongProperties {Title = filename, Part = ""};
        }

        private int ExtractSongYear(string filename)
        {
            if (filename.IndexOf("2012", StringComparison.Ordinal) > 0)
            {
                return 2012;
            }
            return 2013;
        }

        private static string ExtractSongPart(string filename, int indexOfPart, string voicePart)
        {
            string songPart = filename.Substring(indexOfPart, voicePart.Length);

            return songPart.ToTitleCase();
        }

        private static string ExtractTitle(string filename, int indexOfPart)
        {
            string title = filename.Substring(0, indexOfPart);
            
            title = HandleProcessedFileName(title);

            return title.ToTitleCase();
        }

        /// <summary>
        /// Ensures that we know about the format that we return so that we don't keep transforming it
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        private static string HandleProcessedFileName(string title)
        {
            const string separator = Title.TitlePartSeparator;
            
            if (title.EndsWith(separator))
            {
                title = title.Substring(0, title.Length - separator.Length);
            }
            else
            {
                title = title.Trim();
            }

            return title;
        }
    }
}
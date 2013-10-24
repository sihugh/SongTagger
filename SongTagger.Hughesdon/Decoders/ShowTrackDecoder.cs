using System;
using SongTagger.Hughesdon.Constants;
using SongTagger.Hughesdon.Extensions;

namespace SongTagger.Hughesdon.Decoders
{
    public class ShowTrackDecoder : ITrackDecoder
    {
        readonly string[] _voiceParts = "Backing Track,L-R Performance,L R Performance,Performance,Stereo,L-R Show,LR SHOW,SHOW L-R".Split(',');

        private const string ArtistName = "Rock Choir";
        private const string AlbumTitle = "Rock Choir Tracks";
  
        public SongProperties DecodeFileName(string filename)
        {
            foreach (string voicePart in _voiceParts)
            {
                int indexOfPart = filename.IndexOf(voicePart, StringComparison.OrdinalIgnoreCase);
                if (indexOfPart > -1)
                {
                    var title = ExtractTitle(filename, indexOfPart);

                    var songPart = ExtractSongSuffix(filename, indexOfPart, voicePart);

                    int year = ExtractSongYear(filename);

                    var props = new SongProperties {Part = songPart, Title = title, Year = year, AlbumTitle = AlbumTitle, Artist = ArtistName};
                    return props;
                }

            }
            return new SongProperties {Title = filename, Part = ""};
        }

        public int ExtractSongYear(string filename)
        {
            if (filename.IndexOf("2012", StringComparison.Ordinal) > 0)
            {
                return 2012;
            }
            return 2013;
        }

        private static string ExtractSongSuffix(string filename, int indexOfPart, string voicePart)
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
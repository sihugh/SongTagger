using TagLib;

namespace SongTagger.Hughesdon.TitleFormatters
{
    public class TitleFormatter
    {
        private readonly SongProperties _properties;

        public TitleFormatter(SongProperties properties)
        {
            _properties = properties;
        }

        public TrackData GetProperties()
        {
            var data = new TrackData
                {
                    Title = GetTitle(),
                    AlbumTitle = GetAlbumTitle(),
                    Artists = GetArtists(),
                    Comment = GetComment(),
                    Genre = GetGenre(),
                    Pictures = GetPicture(),
                    Year = GetYear()
                };
            return data;
        }

        private string[] GetGenre()
        {
            return new []{"Pop, Rock, Motown"};
        }

        private IPicture[] GetPicture()
        {
            return new IPicture[]
                {
                    new Picture(@"c:\temp\pic.jpg")
                };
        }

        public string GetTitle()
        {
            return _properties.Title + " - " + _properties.Part;
        }

        public string GetAlbumTitle()
        {
            return _properties.AlbumTitle;
        }

        public string[] GetArtists()
        {
            return new[]{_properties.Artist};
        }

        public uint GetYear()
        {
            return (uint)_properties.Year;
        }

        public string GetComment()
        {
            return _properties.Description;
        }
    }
}

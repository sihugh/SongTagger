using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongTagger.Hughesdon.TitleFormatters
{
    public class TitleFormatter
    {
        private SongProperties _properties;

        public TitleFormatter(SongProperties properties)
        {
            _properties = properties;
        }

        public string GetTitle()
        {
            return _properties.Title + " - " + _properties.Part;
        }

        public string GetAlbumTitle()
        {
            return _properties.AlbumTitle;
        }

        public string GetArtist()
        {
            return _properties.Artist;
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

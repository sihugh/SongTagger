using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace SongTagger.Hughesdon
{
    public class TrackData
    {
        public string Title { get; set; }
        public string AlbumTitle { get; set; }
        public string[] Artists { get; set; }
        public uint Year { get; set; }
        public string Comment { get; set; }
        public string[] Genre { get; set; }
        public IPicture Picture { get; set; }
    }
}

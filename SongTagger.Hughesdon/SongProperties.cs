using System;

namespace SongTagger.Hughesdon
{
    public class SongProperties
    {
        public string Title { get; set; }

        private string _part;

        public string Part
        {
            get { return _part; }
            set
            {
                //if (value.Equals("sop", StringComparison.OrdinalIgnoreCase))
                //{
                //    _part = "Soprano";
                //}
                //else 

                if (value.EndsWith("sop", StringComparison.OrdinalIgnoreCase))
                {
                    _part = value.Substring(0, value.Length - 3) + "Soprano";
                }
                else if (value.Equals("medium", StringComparison.OrdinalIgnoreCase))
                {
                    _part = "Middle Bass";
                }
                else
                {
                    _part = value;
                }
            }
        }

        public int Year { get; set; }

        public string Artist { get; set; }

        public string AlbumTitle { get; set; }

        public string Description { get { return "A track for rehearsing Rockchoir songs.  Find out more at Rockchoir.com"; } }
    }
}
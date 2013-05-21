using System;
using System.IO;
using TagLib;
using TagLib.Mpeg;

namespace SongTagger.Hughesdon
{
    public class PropertyApplier
    {
        public void ApplyMetadata(FileInfo mediaFile, SongProperties properties)
        {
            var formatter = new TitleFormatters.TitleFormatter(properties);

            var trackData = formatter.GetProperties();

            using (TagLib.File file = new AudioFile(mediaFile.FullName))
            {
                
                file.Tag.Pictures = trackData.Pictures;
                file.Tag.Album = trackData.AlbumTitle;
                file.Tag.Title = trackData.Title;
                file.Tag.Year = trackData.Year;
                file.Tag.AlbumArtists = trackData.Artists;
                file.Tag.Comment = trackData.Comment;
                file.Tag.Genres = new[] {"Pop, Gospel, Motown"};
                file.Save();
            }
        }
    }
}

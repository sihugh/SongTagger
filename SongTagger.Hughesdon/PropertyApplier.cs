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
            using (TagLib.File file = new AudioFile(mediaFile.FullName))
            {
                var formatter = new TitleFormatters.TitleFormatter(properties);

                file.Tag.Pictures = new IPicture[]{new Picture(@"c:\temp\pic.jpg")};
                file.Tag.Album = formatter.GetAlbumTitle();
                file.Tag.Title = formatter.GetTitle();
                file.Tag.Year = formatter.GetYear();
                file.Tag.AlbumArtists = new[]{formatter.GetArtist()};
                file.Tag.Comment = formatter.GetComment();
                file.Tag.Genres = new[] {"Pop, Gospel, Motown"};
                file.Save();
            }
        }
    }
}

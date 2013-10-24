using System;
using System.IO;
using System.Net.Mime;
using TagLib;
using TagLib.Id3v2;
using TagLib.Mpeg;

namespace SongTagger.Hughesdon
{
    public class PropertyApplier
    {
        public void ApplyMetadata(FileInfo mediaFile, SongProperties properties)
        {
            var formatter = new TitleFormatters.TitleFormatter(properties);

            var trackData = formatter.GetProperties();

            TagLib.Id3v2.Tag.DefaultVersion = 3;
            TagLib.Id3v2.Tag.ForceDefaultVersion = true;

            using (TagLib.File file = new AudioFile(mediaFile.FullName))
            {
                var albumCover = new AttachedPictureFrame(trackData.Picture)
                    {
                        Type = PictureType.FrontCover,
                    };
                
                file.Tag.Pictures = new IPicture[1]{albumCover};
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

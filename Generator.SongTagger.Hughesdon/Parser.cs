using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Generator.SongTagger.Hughesdon
{
    public class Parser
    {
        public Song GetSong(string filename, IEnumerable<XElement> songs, IEnumerable<XElement> files, IEnumerable<XElement> parts)
        {

            var fileNameElements = GetFileNameElements(filename, files);
            
            var fileElements = GetParentElements(fileNameElements);

            var songId = GetFirstSongId(fileElements);

            Debug.WriteLine(songId);

            var songIdElements = GetMatchingSongIdElements(songs, songId);

            Debug.WriteLine(songIdElements.Count());

            var songElement = SongElement(songIdElements);

            return new Song
                {
                    Title = songElement.Elements("title").First().Value
                };
        }

        private static IEnumerable<XElement> GetParentElements(IEnumerable<XElement> elements)
        {
            var parentElements = elements.Select(el => el.Parent);
            return parentElements;
        }

        private static XElement SongElement(IEnumerable<XElement> songIdElements)
        {
            var songElement = songIdElements.First().Parent;
            return songElement;
        }

        private static IEnumerable<XElement> GetMatchingSongIdElements(IEnumerable<XElement> songs, string songId)
        {
            Debug.WriteLine(songs.Count());
            var songIdElements = songs.Elements("id");
            Debug.WriteLine("ids" + songIdElements.Count());
            var songIdElement = songIdElements.Where(el => el.Value.Equals(songId));
            return songIdElement;
        }

        private static string GetFirstSongId(IEnumerable<XElement> fileElements)
        {
            var songId = fileElements.Elements("songId").First().Value;
            return songId;
        }

        private static IEnumerable<XElement> GetFileNameElements(string filename, IEnumerable<XElement> files)
        {
            var fileNameElement = files.Elements("name").Where(el => el.Value.Equals(filename));
            return fileNameElement;
        }
    }
}

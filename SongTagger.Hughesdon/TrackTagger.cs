using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongTagger.Hughesdon.Decoders;

namespace SongTagger.Hughesdon
{
    public class TrackTagger
    {
        private const string Extension = "*.mp3";

        private Dictionary<string, SongProperties> _propertyMapper; 

        public void PrepareTrackMapping(string folderPath)
        {
            var trackNames = GetMp3Files(folderPath);
            var decoder = new ShowTrackDecoder();

            _propertyMapper = AssembleSongPropertyMap(trackNames, decoder);
            
        }

        public Dictionary<string, SongProperties> PropertyMapper
        {
            get { return _propertyMapper; }
        }

        private static Dictionary<string, SongProperties> AssembleSongPropertyMap(IEnumerable<string> trackPaths, ITrackDecoder decoder)
        {
            var propertyMapper = new Dictionary<string, SongProperties>();
            foreach (var trackPath in trackPaths)
            {
                string trackFileName = Path.GetFileName(trackPath);
                var songProperties = decoder.DecodeFileName(trackFileName);
                propertyMapper.Add(trackPath, songProperties);
            }
            return propertyMapper;
        }

        public static IEnumerable<string> GetMp3Files(string path)
        {
            return Directory.EnumerateFiles(path, Extension);
        }
    }
}

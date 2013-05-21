﻿using System;
using System.IO;
using SongTagger.Hughesdon;

namespace SongTagger
{
    class Program
    {
        private const string BeforeFolderPath = @"c:\temp\before\";
        private const string AfterFolderPath = @"c:\temp\after\";

        static void Main(string[] args)
        {
            TagTracks();

            Console.WriteLine("Finished");
            Console.Read();
        }

        private static void TagTracks()
        {
            var trackTagger = new TrackTagger();
            trackTagger.PrepareTrackMapping(BeforeFolderPath);

            var propertyApplier = new PropertyApplier();
            foreach (var songPath in trackTagger.PropertyMapper.Keys)
            {
                var songProperties = trackTagger.PropertyMapper[songPath];

                if (string.IsNullOrWhiteSpace(songProperties.Artist))
                    continue;

                Console.WriteLine("Copying {0} to {1}", songPath, AfterFolderPath);


                string afterFilePath = Path.Combine(AfterFolderPath,
                                                    songProperties.Title + " - " + songProperties.Part +
                                                    Path.GetExtension(songPath));
                File.Copy(songPath, afterFilePath, true);

                var afterFile = new FileInfo(afterFilePath);

                Console.WriteLine("Applying properties to {0}", afterFile.FullName);
                propertyApplier.ApplyMetadata(afterFile, songProperties);
            }
        }
    }
}

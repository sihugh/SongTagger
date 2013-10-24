namespace SongTagger.Hughesdon.Decoders
{
    public interface ITrackDecoder
    {
        SongProperties DecodeFileName(string filename);
    }
}
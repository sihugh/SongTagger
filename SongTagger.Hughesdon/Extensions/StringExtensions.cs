using System.Threading;

namespace SongTagger.Hughesdon.Extensions
{
    static class StringExtensions
    {
        internal static string ToTitleCase(this string title)
        {
            var culture = Thread.CurrentThread.CurrentCulture;
            title = culture.TextInfo.ToTitleCase(title.ToLower(culture));
            return title;
        }
    }
}

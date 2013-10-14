using System.Net;
namespace TKrpan.BookmarkManager.Infrastructure
{
    public class UrlValidator
    {
        public bool IsUrlValid(string url)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    var html = webClient.DownloadString(url);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

    }
}

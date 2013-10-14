using System.Diagnostics;
namespace TKrpan.BookmarkManager.Infrastructure
{
    public class Browser
    {
        public void OpenUrl(string url)
        {
            Process.Start(url);
        }
    }
}

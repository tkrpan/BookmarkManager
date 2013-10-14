using System;

namespace TKrpan.BookmarkManager.Infrastructure
{
    public class Bookmark
    {
        public Bookmark (string name, string url, DateTime timestamp){
            this.Name=name;
            this.Url=url;
            this.Timestamp=timestamp;
        
        }
    
        public string Name { get; private set; }
        public string Url { get; private set; }
        public DateTime Timestamp { get; private set; }
    }
}

using System;
using System.Collections.Generic;

namespace TKrpan.BookmarkManager.Infrastructure
{
    public class BookmarkManager
    {

        private List<Bookmark> _bookmarkList;
        private BookmarkDataAccess _bookmarkDataAccess;
        private UrlValidator _urlValidator;
        private Browser _browser;

        public BookmarkManager ()
        {

            _bookmarkList = new List<Bookmark>();
            _bookmarkDataAccess = new BookmarkDataAccess();
            _urlValidator = new UrlValidator();
            _browser = new Browser();

            var bookmarks = _bookmarkDataAccess.Load();
            foreach(var bookmark in bookmarks)
            {
                _bookmarkList.Add(bookmark);
            }

        }


        public bool Add(string name, string url) {

            if (_urlValidator.IsUrlValid(url))
            {
                _bookmarkList.Add(new Bookmark(name, url, DateTime.Now));
                _bookmarkDataAccess.Save(_bookmarkList.ToArray());
               
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Remove(int index) {

            _bookmarkList.RemoveAt(index);

            _bookmarkDataAccess.Save(_bookmarkList.ToArray());
        }

        public void Show() {

            Console.WriteLine("Lista spremljenih:");
            foreach (var bookmark in _bookmarkList)
            {
                Console.WriteLine("{0}. {1}\t{2}\t{3}", 
                    _bookmarkList.IndexOf(bookmark), 
                    bookmark.Name, bookmark.Url, 
                    bookmark.Timestamp);
            }
        }

        public List<Bookmark> GetAllBookmarks()
        {
            return _bookmarkList;
        }

        public void Run(int index)
        {
            var selectedBookmark = _bookmarkList[index];
            _browser.OpenUrl(selectedBookmark.Url);
        }
    }
}

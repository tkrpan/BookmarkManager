using System.Collections.Generic;
using System.IO;
using System;

namespace TKrpan.BookmarkManager.Infrastructure
{
    class BookmarkDataAccess
    {

        private string _fileName;

        public BookmarkDataAccess()
        {
            _fileName = "bookmarks.csv";
        }

        public void Save(Bookmark[] bookmarks)
        {
            var lines = new List<string>();

            foreach (var bookmark in bookmarks)
            {

                var line = string.Format("{0};{1};{2};", 
                    bookmark.Name, 
                    bookmark.Url, 
                    bookmark.Timestamp);

                lines.Add(line);
            }
            File.WriteAllLines(_fileName, lines);
        }

        public Bookmark[] Load()
        {
            var lines = new string[0];
            if (File.Exists(_fileName))
            {
                lines = File.ReadAllLines(_fileName);
            }

            var list = new List<Bookmark>();
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                var bookmark = new Bookmark(parts[0], 
                    parts[1], DateTime.Parse(parts[2]));
                list.Add(bookmark);
            }

            return list.ToArray();
        }
    }
}

using SQLite;
using System;
using System.IO;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using System.Linq;
using CocoMaps.Shared;

namespace CocoMaps.Shared
{
	public class BookmarksRepository
	{
		public SQLiteConnection BookmarksTable;
		private static string sqliteFileName = "SavedBookmarks.db3";

		private object locker = new object ();

		private static SQLiteConnection OpenConnection ()
		{
			try {
				#if __ANDROID__
				string libraryPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				#endif

				// Must be in /Library/ on iOS5.1 to meet Apple's iCloud terms
				#if __IOS__
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); 
				string libraryPath = Path.Combine (documentsPath, "..", "Library"); 
				#endif

				var path = Path.Combine (libraryPath, sqliteFileName);

				return new SQLiteConnection (path);

			} catch (SQLiteException ex) {
				return null;
			}
		}

		public void CreateTable ()
		{
			BookmarksTable = OpenConnection ();
			BookmarksTable.CreateTable<BookmarkItems> ();
		}

		public BookmarkItems GetBookmark (int id)
		{
			lock (locker) {
				BookmarksTable = OpenConnection ();
				return BookmarksTable.Get<BookmarkItems> (id);
			}
		}

		public IEnumerable<BookmarkItems> GetAllBookmarks ()
		{
			lock (locker) {
				BookmarksTable = OpenConnection ();

				var table = BookmarksTable.Table<BookmarkItems> ();
				foreach (var bookmark in table) {
					Console.WriteLine (bookmark.bName + " " + bookmark.bAddress);
				}

				return (from i in table
				        select i).ToList ();
			}
		}

		public void SaveBookmark (BookmarkItems bookmark)
		{
			lock (locker) {
				BookmarksTable = OpenConnection ();

				if (bookmark.ID != 0) {
					BookmarksTable.Update (bookmark);
				} else {
					BookmarksTable.Insert (bookmark);
				}
			}
		}

		/*public void UpdateBookmark (int id, BookmarkItems Bookmark)
		{
			lock (locker) {
				BookmarksTable = OpenConnection ();
				BookmarkItems savedBookmark = BookmarksTable.GetBookmark (id);
				savedBookmark = Bookmark;
				BookmarksTable.Update (bookmark);
				 bookmark.ID;
			}
		}*/

		public void DeleteBookmark (BookmarkItems bookmark)
		{
			lock (locker) {
				BookmarksTable = OpenConnection ();
				BookmarksTable.Delete<BookmarkItems> (bookmark.ID);
			}
		}

		public void DeleteAllBookmarks ()
		{
			lock (locker) {
				var table = BookmarksTable.Table<BookmarkItems> ();
				foreach (var bookmark in table) {
					BookmarksTable.Delete (bookmark);
				}
			}
		}

		public int NumberOfBookmarks ()
		{
			lock (locker) {
				try {
					BookmarksTable = OpenConnection ();
					return BookmarksTable.ExecuteScalar<int> ("SELECT Count(*) FROM BookmarkItems"); 
				} catch (SQLiteException ex) {
					return -1;
				}
			}
		}
	}
}
using System;
using System.IO;
using System.Linq;
using CocoMaps.Shared;
using SQLite;
using System.Collections.Generic;

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

		public void DeleteBookmark (BookmarkItems bookmark)
		{
			lock (locker) {
				BookmarksTable = OpenConnection ();
				BookmarksTable.Delete<BookmarkItems> (bookmark.ID);
			}
		}

		public void DeleteBookmark (int id)
		{
			lock (locker) {
				BookmarksTable = OpenConnection ();
				BookmarksTable.Delete<BookmarkItems> (id);
			}
		}

		public void DeleteAllBookmarks ()
		{
			lock (locker) {
				var table = BookmarksTable.Table<BookmarkItems> ();
				foreach (var bookmark in table) {
					BookmarksTable.Delete (bookmark);
				}
				/*//Reset primary keys
				string resetPrimaryKey1 = "delete from BookmarksTable;";   
				string resetPrimaryKey2 = "delete from sqlite_sequence where name='BookmarksTable';";
				BookmarksTable.Execute (resetPrimaryKey1, primaryKeys);
				BookmarksTable.Execute (resetPrimaryKey2, primaryKeys);*/
			}
		}

		public int NumberOfBookmarks ()
		{
			lock (locker) {
				try {
					BookmarksTable = OpenConnection ();
					return BookmarksTable.ExecuteScalar<int> ("SELECT COUNT(*) FROM BookmarksTable"); 
				} catch (SQLiteException ex) {
					return -1;
				}
			}
		}

		/*public void SearchBookmarks ()
		{
			lock (locker) {
				var table = BookmarksTable.Table<BookmarkItems> ();

				var result = from s in table
				             where s.bName.StartsWith ("A")
				             select s;
			}
		}*/
	}
}
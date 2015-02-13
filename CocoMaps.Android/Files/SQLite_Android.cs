using System;
using Xamarin.Forms;
using CocoMaps.Shared;

public class SQLite_Android
{
	public SQLite_Android ()
	{
	}

	public SQLite.Net.SQLiteConnection GetConnection ()
	{
		var sqliteFilename = "Buildings.db3";
		string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
		var path = System.IO.Path.Combine (documentsPath, sqliteFilename);
		// Create the connection
		var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid ();
		var conn = new SQLite.Net.SQLiteConnection (plat, path);
		// Return the database connection 
		return conn;
	}
}
using System.Threading.Tasks;
using Android.Graphics;
using System.Net.Http;

namespace CocoMaps.Shared
{

	public static class ImageDownload
	{

		static async Task<Bitmap> GetBitmapFromUriAsync (string uri)
		{
			var client = new HttpClient ();

			using (var data = await client.GetStreamAsync (uri)) {
				if (data != null && data.Length > 0) {
					return await BitmapFactory.DecodeStreamAsync (data);
				}
			}

			return null;
		}

	}

}
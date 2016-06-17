using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetsLibrary;
using Foundation;
using TechTalk.DataModels;
using TechTalk.Interfaces;

namespace TechTalk.iOS
{
	public class GalleryService: IGalleryService
	{
		private readonly IList<Picture> pictures;
		private TaskCompletionSource<IList<Picture>> taskCompletionSource;
		public GalleryService()
		{
			pictures = new List<Picture>();

		}

		public Task<IList<Picture>> LoadImagesAsync()
		{
			taskCompletionSource = new TaskCompletionSource<IList<Picture>>();
			//Clean the mess
			pictures.Clear();
			var library = new ALAssetsLibrary();
			library.Enumerate(ALAssetsGroupType.All, GroupEnumerator, 
			                  (NSError e) => { 
								Console.WriteLine("Could not enumerate albums: " + e.LocalizedDescription); }
			                 	);
			
			//whooo hoo
			return taskCompletionSource.Task;
		}

		private void GroupEnumerator(ALAssetsGroup group, ref bool shouldStop)
		{
			if (group == null)
			{
				shouldStop = true;
				return;
			}
			if (!shouldStop)
			{
				group.Enumerate(AssetEnumerator);
				shouldStop = false;
			}
			taskCompletionSource.TrySetResult(pictures);
		}

		private void AssetEnumerator(ALAsset asset, nint index, ref bool shouldStop)
		{
			if (asset == null)
			{
				shouldStop = true;
				return;
			}
			if (!shouldStop)
			{
				var picture = new Picture { 
					ThumbnailHandle = asset.Thumbnail.Handle, 
					Uri = asset.AssetUrl.ToString()
				};

				pictures.Add(picture);
				shouldStop = false;
			}
		}
	}
}


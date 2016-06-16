using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetsLibrary;
using TechTalk.DataModels;
using TechTalk.Interfaces;

namespace TechTalk.iOS
{
	public class GalleryService: IGalleryService
	{
		private readonly IList<Picture> pictures;
		public GalleryService()
		{
			pictures = new List<Picture>();
		}

		public Task<IList<Picture>> LoadImagesAsync()
		{
			var taskCompletionSource = new TaskCompletionSource<IList<Picture>>();

			//Clean the mess
			pictures.Clear();
			var library = new ALAssetsLibrary();
			library.Enumerate(ALAssetsGroupType.SavedPhotos, GroupEnumerator, null);

			//fingers crossed
			taskCompletionSource.TrySetResult(pictures);

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


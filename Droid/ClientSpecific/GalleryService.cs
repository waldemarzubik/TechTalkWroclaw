﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.DataModels;
using TechTalk.Interfaces;
using Android.Provider;
using Android.App;

namespace TechTalk.Droid.ClientSpecific
{
    public class GalleryService : IGalleryService
    {
        public Task<IList<Picture>> LoadImagesAsync()
        {
            var taskCompletionSource = new TaskCompletionSource<IList<Picture>>();
            Task.Run(() =>
            {
                var pictures = new List<Picture>();
                var columns = new[] { MediaStore.MediaColumns.Data, MediaStore.MediaColumns.Id };
                using (var cursor = Application.Context.ContentResolver.Query(MediaStore.Images.Media.ExternalContentUri,
                                                                 columns, null, null, MediaStore.MediaColumns.Id))
                {
                    var dataColumnIndex = cursor.GetColumnIndex(columns[0]);
                    var idColumnIndex = cursor.GetColumnIndex(columns[1]);
                    while (cursor.MoveToNext())
                    {
                        var picture = new Picture();
                        var imageId = cursor.GetLong(idColumnIndex);
                        picture.Uri = cursor.GetString(dataColumnIndex);

                        using (var thumbCursor = Application.Context.ContentResolver.Query(MediaStore.Images.Thumbnails.ExternalContentUri, new string[] { MediaStore.Images.Thumbnails.Data },
                                                                                                         string.Format("{0}={1}", MediaStore.Images.Thumbnails.ImageId, imageId), null, null, null))
                        {
                            if (thumbCursor.MoveToFirst())
                            {
                                int dataIndex = thumbCursor.GetColumnIndex(MediaStore.MediaColumns.Data);
                                picture.ThumbnailUri = thumbCursor.GetString(dataIndex);
                            }
                            thumbCursor.Close();
                        }
                        pictures.Add(picture);
                    }
                    cursor.Close();
                }
                taskCompletionSource.TrySetResult(pictures);
            });
            return taskCompletionSource.Task;
        }
    }
}
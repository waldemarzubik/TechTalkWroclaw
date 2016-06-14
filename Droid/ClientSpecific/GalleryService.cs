using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.DataModels;
using TechTalk.Interfaces;

namespace TechTalk.Droid.ClientSpecific
{
    public class GalleryService : IGalleryService
    {
        public GalleryService()
        {
        }

        public Task<List<Picture>> LoadImagesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
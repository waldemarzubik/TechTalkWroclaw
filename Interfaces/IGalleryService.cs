using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TechTalk.DataModels;

namespace TechTalk.Interfaces
{
    public interface IGalleryService
    {
        Task<List<Picture>> LoadImagesAsync();
    }
}
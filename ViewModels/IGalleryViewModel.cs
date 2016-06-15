using System;
using System.Collections.Generic;
using TechTalk.DataModels;

namespace TechTalk.ViewModels
{
    public interface IGalleryViewModel : IBaseViewModel
    {
        IList<Picture> Images { get; set; }

        Picture SelectedItem { get; set; }
    }
}
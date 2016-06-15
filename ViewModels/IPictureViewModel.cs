using System;
using TechTalk.ViewModels;

namespace TechTalk.ViewModels
{
    public interface IPictureViewModel : IBaseViewModel
    {
        string ImageUri { get; set; }
    }
}
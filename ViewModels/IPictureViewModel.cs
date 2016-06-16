using System;
using TechTalk.DataModels;

namespace TechTalk.ViewModels
{
    public interface IPictureViewModel : IBaseViewModel
    {
        Picture Picture { get; set; }
    }
}
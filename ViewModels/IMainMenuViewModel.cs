using System;
using TechTalk.ViewModels;
using System.Collections.Generic;

namespace TechTalk.ViewModel
{
    public interface IMainMenuViewModel : IBaseViewModel
    {
        List<string> Menu { get; set; }
    }
}
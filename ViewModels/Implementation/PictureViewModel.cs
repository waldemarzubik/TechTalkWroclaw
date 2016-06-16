using System;
using System.Threading.Tasks;
using TechTalk.Interfaces;
using TechTalk.DataModels;

namespace TechTalk.ViewModels.Implementation
{
    public class PictureViewModel : BaseViewModel, IPictureViewModel
    {
        private Picture _picture;

        public PictureViewModel(INavigation navigationService) : base(navigationService)
        {
        }

        public Picture Picture
        {
            get { return _picture; }
            set { SetProperty(ref _picture, value); }
        }

        public override Task OnInitialize(object parameter)
        {
            Picture = parameter as Picture;
            return base.OnInitialize(parameter);
        }
    }
}
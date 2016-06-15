using System;
using System.Threading.Tasks;
using TechTalk.Interfaces;

namespace TechTalk.ViewModels.Implementation
{
    public class PictureViewModel : BaseViewModel, IPictureViewModel
    {
        private string _imageUri;

        public PictureViewModel(INavigation navigationService) : base(navigationService)
        {
        }

        public string ImageUri
        {
            get { return _imageUri; }
            set { SetProperty(ref _imageUri, value); }
        }

        public override Task OnInitialize(object parameter)
        {
            ImageUri = parameter?.ToString();
            return base.OnInitialize(parameter);
        }

        public override void OnNavigatingFrom()
        {
            ImageUri = null;
            base.OnNavigatingFrom();
        }
    }
}
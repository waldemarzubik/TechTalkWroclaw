using TechTalk.Interfaces;

namespace TechTalk.ViewModels.Implementation
{
    public class PictureViewModel : BaseViewModel, IPictureViewModel
    {
        public PictureViewModel(INavigation navigationService) : base(navigationService)
        {
        }
    }
}
using Xamarin.Forms;
using XLabs.Forms.Mvvm;


namespace ScratchingPost.Infrastructure.Mvvm
{

    public abstract class LifeCycleView : BaseView
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<App>(this, MessageKeys.ApplicationSleep, OnApplicationSleep);
            MessagingCenter.Subscribe<App>(this, MessageKeys.ApplicationResume, OnApplicationResume);
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<App>(this, MessageKeys.ApplicationSleep);
            MessagingCenter.Unsubscribe<App>(this, MessageKeys.ApplicationResume);
            base.OnDisappearing();
        }

        private void OnApplicationSleep(App application)
        {
            var model = BindingContext as ViewModel;
            model?.OnViewDisappearing();
        }

        private void OnApplicationResume(App application)
        {
            var model = BindingContext as ViewModel;
            model?.OnViewAppearing();
        }
    }

}
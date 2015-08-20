using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using ScratchingPost.Droid.Infrastructure;
using TinyIoC;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XLabs.Ioc;
using XLabs.Ioc.TinyIOC;


namespace ScratchingPost.Droid
{

    [Activity(
        Label = "Scratching Post",
        Icon = "@drawable/icon",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation
        )]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var container = new TinyContainer(TinyIoCContainer.Current);
            var resolver = TinyIoCModule.Setup(TinyIoCContainer.Current);
            Resolver.SetResolver(resolver);

            Corcav.Behaviors.Infrastructure.Init();
            UserDialogs.Init(this);

            Forms.Init(this, bundle);
            LoadApplication(new App(container));
        }
    }

}
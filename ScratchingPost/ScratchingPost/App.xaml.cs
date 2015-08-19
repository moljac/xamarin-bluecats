using PropertyChanged;
using ScratchingPost.Features.Beacons;
using ScratchingPost.Infrastructure;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Forms.Services;
using XLabs.Ioc;
using XLabs.Platform.Services;


namespace ScratchingPost
{

    [ImplementPropertyChanged]
    public partial class App
    {
        private App()
        {
            InitializeComponent();
            Current = this;
        }

        public App(IDependencyContainer container)
            : this()
        {
            RegisterViews();
            JsonSerialiserSettings.SetupDefaultSettings();

            // Setup the navigation service and navigate to first page
            SetupNavigationService(container).NavigateTo<BeaconsViewModel>();
        }

        public new static App Current { get; private set; }

        protected override void OnStart() {}

        protected override void OnSleep()
        {
            MessagingCenter.Send(this, MessageKeys.ApplicationSleep);
        }

        protected override void OnResume()
        {
            MessagingCenter.Send(this, MessageKeys.ApplicationResume);
        }

        private NavigationService SetupNavigationService(IDependencyContainer container)
        {
            var baseNavigationPage = new NavigationPage();

            var navigation = baseNavigationPage.Navigation;
            container.Register(navigation);

            var navigationService = new NavigationService(navigation);
            container.Register<INavigationService>(navigationService);

            MainPage = baseNavigationPage;
            return navigationService;
        }

        private static void RegisterViews()
        {
            ViewFactory.Register<BeaconsView, BeaconsViewModel>();
        }
    }

}
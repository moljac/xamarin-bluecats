using Acr.UserDialogs;
using ScratchingPost.Droid.Hardware;
using ScratchingPost.Infrastructure;
using TinyIoC;
using XLabs.Ioc;
using XLabs.Ioc.TinyIOC;


namespace ScratchingPost.Droid.Infrastructure
{

    internal static class TinyIoCModule
    {
        private static bool IsSimulator => false;

        public static IResolver Setup(TinyIoCContainer container)
        {
            container.Register<IDependencyContainer>(new TinyContainer(container));
            container.Register<IUserDialogs, UserDialogsImpl>();

            if (IsSimulator)
            {
                SetupSimulatorPeripherials(container);
            }
            else
            {
                SetupDevicePeripherials(container);
            }

            var resolver = new TinyResolver(container);
            container.Register<IResolver>(resolver);

            return resolver;
        }

        private static void SetupDevicePeripherials(TinyIoCContainer container)
        {
            container.Register<IBeaconSdk, BlueCatBeaconSdk>();
        }

        private static void SetupSimulatorPeripherials(TinyIoCContainer container)
        {
            container.Register<IBeaconSdk, SimulatorBeaconSdk>();
        }
    }

}
using System;
using PropertyChanged;
using ScratchingPost.Infrastructure;
using XLabs;
using XLabs.Forms.Mvvm;


namespace ScratchingPost.Features.Beacons
{

    [ImplementPropertyChanged]
    public class BeaconsViewModel : ViewModel
    {
        public BeaconsViewModel(IBeaconSdk beacon)
        {
            _beacon = beacon;
        }

        public RelayCommand StartPurringCommand => new RelayCommand(StartPurring);

        private void StartPurring()
        {
            try
            {
                _beacon.StartPurringWithAppToken("d399c5c7-185c-40c1-a422-a97c43705c0a");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to communicate with Beacon");
            }
        }

        private readonly IBeaconSdk _beacon;
    }

}
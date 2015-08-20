using System.Collections.Generic;
using Android.Util;
using BlueCats;
using Java.Lang;
using ScratchingPost.Infrastructure;


namespace ScratchingPost.Droid.Hardware
{

    internal class BlueCatBeaconSdk : IBeaconSdk
    {
        public void StartPurringWithAppToken(string token)
        {
            var context = BlueCatsSDK.ApplicationContext;
            BlueCatsSDK.StartPurringWithAppToken(context, token);

            _microLocationManagerCallback = new MicroLocationManagerCallback();
            BCMicroLocationManager.Instance.StartUpdatingMicroLocation(_microLocationManagerCallback);
        }

        private class MicroLocationManagerCallback : Object, IBCMicroLocationManagerCallback
        {
            public void OnDidEnterSite(BCSite site)
            {
                Log.Debug("MicroLocation", "Entered {0}", site);
            }

            public void OnDidExitSite(BCSite site)
            {
                Log.Debug("MicroLocation", "Exit {0}", site);
            }

            public void OnDidRangeBeaconsForSiteID(BCSite site, IList<BCBeacon> sites)
            {
                Log.Debug("MicroLocation", "Range beacobs for {0}, found {1}", site, sites);
            }

            public void OnDidUpdateMicroLocation(IList<BCMicroLocation> microLocations)
            {
                Log.Debug("MicroLocation", "Updated Micro Locations {0}", microLocations);
            }

            public void OnDidUpdateNearbySites(IList<BCSite> sites)
            {
                Log.Debug("MicroLocation", "Updated nearby {sites}", sites);
            }
        }

        private MicroLocationManagerCallback _microLocationManagerCallback;
    }

}
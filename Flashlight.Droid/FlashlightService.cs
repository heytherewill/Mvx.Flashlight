using System;
using Android.Views;
using Android.Content.PM;
using Android.Hardware;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform.Platform;
using Android.App;

#pragma warning disable XA0001 // Find issues with Android API usage
#pragma warning disable CS0618 // Type or member is obsolete
namespace Flashlight.Droid
{
    public class FlashlightService : BaseFlashlightService
    {
        internal static void Initialize()
            => Mvx.RegisterSingleton<IFlashlightService>(new FlashlightService());

        private FlashlightService() { }

        private Camera _camera;

        private Activity Activity => Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

        protected override bool NativeDeviceHasFlashlight
            => Activity.PackageManager.HasSystemFeature(PackageManager.FeatureCameraFlash);

        protected override bool NativeEnsureFlashlightOn()
        {
            try
            {
                _camera = Camera.Open();
                _camera.SetPreviewDisplay(new SurfaceView(Activity).Holder);

                var parameters = _camera.GetParameters();
                parameters.FlashMode = Camera.Parameters.FlashModeTorch;
                _camera.SetParameters(parameters);
                _camera.StartPreview();

                return true;
            }
            catch (Exception ex)
            {
                Mvx.Trace(MvxTraceLevel.Error, ex.Message);
                return false;
            }
        }

        protected override bool NativeEnsureFlashlightOff()
        {
            try
            {
                var parameters = _camera.GetParameters();
                parameters.FlashMode = Camera.Parameters.FlashModeOff;
                _camera.SetParameters(parameters);
                _camera.StopPreview();
                _camera.Release();
                _camera = null;

                return true;
            }
            catch (Exception ex)
            {
                Mvx.Trace(MvxTraceLevel.Error, ex.Message);
                return false;
            }
        }
    }
}
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore XA0001 // Find issues with Android API usage
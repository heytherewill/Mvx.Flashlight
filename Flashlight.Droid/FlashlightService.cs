using System;
using Android.Views;
using Android.Content.PM;
using Android.Hardware;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform.Platform;
using Android.App;

namespace Flashlight.Droid
{
	public class FlashlightService : IFlashlightService
	{
		internal static void Initialize()
			=> Mvx.RegisterSingleton<IFlashlightService>(new FlashlightService());

		private FlashlightService() { }

		private Camera _camera;

		private Activity Activity => Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

		public bool DeviceHasFlashlight
			=> Activity.PackageManager.HasSystemFeature(PackageManager.FeatureCameraFlash);

		public bool IsFlashlightOn { get; set; }

		public bool EnsureFlashlightOn()
		{
			if (IsFlashlightOn) return true;

			if (!DeviceHasFlashlight) return false;

			try
			{
				_camera = Camera.Open();
				_camera.SetPreviewDisplay(new SurfaceView(Activity).Holder);

				var parameters = _camera.GetParameters();
				parameters.FlashMode = Camera.Parameters.FlashModeTorch;
				_camera.SetParameters(parameters);
				_camera.StartPreview();

				IsFlashlightOn = true;
				return true;
			}
			catch (Exception ex)
			{
				Mvx.Trace(MvxTraceLevel.Error, ex.Message);
				return false;
			}
		}

		public bool EnsureFlashlightOff()
		{
			if (!IsFlashlightOn) return true;

			try
			{
				var parameters = _camera.GetParameters();
				parameters.FlashMode = Camera.Parameters.FlashModeOff;
				_camera.SetParameters(parameters);
				_camera.StopPreview();
				_camera.Release();
				_camera = null;

				IsFlashlightOn = false;

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
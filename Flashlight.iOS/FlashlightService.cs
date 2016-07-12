using AVFoundation;
using Foundation;
using MvvmCross.Platform;

namespace Flashlight.iOS
{
	public class FlashlightService : IFlashlightService
	{
		private AVCaptureDevice _flashlight = AVCaptureDevice.DefaultDeviceWithMediaType(AVMediaType.Video);

		internal static void Initialize()
			=> Mvx.RegisterSingleton<IFlashlightService>(new FlashlightService());

		private FlashlightService() { }

		public bool DeviceHasFlashlight 
			=> _flashlight.HasTorch && _flashlight.TorchAvailable && _flashlight.IsTorchModeSupported(AVCaptureTorchMode.On);

		public bool IsFlashlightOn { get; set; }

		public bool EnsureFlashlightOn()
		{
			if (IsFlashlightOn) return true;

			if (!DeviceHasFlashlight) return false;

			return SafeSetTorchMode(AVCaptureTorchMode.On);
		}

		public bool EnsureFlashlightOff()
		{
			if (!IsFlashlightOn) return true;

			return SafeSetTorchMode(AVCaptureTorchMode.Off);
		}

		private bool SafeSetTorchMode(AVCaptureTorchMode captureTorchMode)
		{
			NSError err = null;
			var success = _flashlight.LockForConfiguration(out err);
			if (!success) return false;

			_flashlight.TorchMode = captureTorchMode;
			_flashlight.UnlockForConfiguration();

			return true;
		}
	}
}
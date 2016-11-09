using AVFoundation;
using Foundation;
using MvvmCross.Platform;

namespace Flashlight.iOS
{
	public class FlashlightService : BaseFlashlightService
	{
		private readonly AVCaptureDevice _flashlight = AVCaptureDevice.DefaultDeviceWithMediaType(AVMediaType.Video);

		internal static void Initialize()
			=> Mvx.RegisterSingleton<IFlashlightService>(new FlashlightService());

		private FlashlightService() { }

		protected override bool NativeDeviceHasFlashlight 
			=> _flashlight.HasTorch && _flashlight.TorchAvailable && _flashlight.IsTorchModeSupported(AVCaptureTorchMode.On);

		protected override bool NativeEnsureFlashlightOn()
			=> SafeSetTorchMode(AVCaptureTorchMode.On);
	
		protected override bool NativeEnsureFlashlightOff()
			=> SafeSetTorchMode(AVCaptureTorchMode.Off);

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
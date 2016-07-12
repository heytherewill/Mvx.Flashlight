namespace Flashlight
{
	public interface IFlashlightService
	{
		bool DeviceHasFlashlight { get; }

		bool IsFlashlightOn { get; }

		bool EnsureFlashlightOn();

		bool EnsureFlashlightOff();
	}
}
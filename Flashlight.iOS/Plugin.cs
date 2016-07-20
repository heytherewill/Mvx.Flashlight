using MvvmCross.Platform.Plugins;

namespace Flashlight.iOS
{
	public class Plugin : IMvxPlugin
	{
		public void Load() => FlashlightService.Initialize();
	}
}
using MvvmCross.Platform.Plugins;

namespace Flashlight.Droid
{

	public class Plugin : IMvxPlugin
	{
		public void Load() => FlashlightService.Initialize();
	}
}
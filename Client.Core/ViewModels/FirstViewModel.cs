using Flashlight;
using MvvmCross.Core.ViewModels;

namespace Client.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly IFlashlightService flashlightService;

        public FirstViewModel(IFlashlightService flashlightService)
        {
            this.flashlightService = flashlightService;
            ToggleFlashlightCommand = new MvxCommand(ToggleFlashlight);
            TurnFlashlightOnCommand = new MvxCommand(TurnFlashlightOn);
            TurnFlashlightOffCommand = new MvxCommand(TurnFlashlightOff);
        }

        public IMvxCommand TurnFlashlightOnCommand { get; }

        public IMvxCommand TurnFlashlightOffCommand { get; }

        public IMvxCommand ToggleFlashlightCommand { get; }
        
        private void TurnFlashlightOff()
            => flashlightService.EnsureFlashlightOff();
        
        private void TurnFlashlightOn()
            => flashlightService.EnsureFlashlightOn();

        private void ToggleFlashlight()
        {
            if (flashlightService.IsFlashlightOn)
            {
                flashlightService.EnsureFlashlightOff();
                return;
            }

            flashlightService.EnsureFlashlightOn();
        }
    }
}

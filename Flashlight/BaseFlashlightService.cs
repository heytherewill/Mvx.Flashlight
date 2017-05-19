namespace Flashlight
{
    public abstract class BaseFlashlightService : IFlashlightService
    {
        public bool IsFlashlightOn { get; set; }

        public virtual bool DeviceHasFlashlight => NativeDeviceHasFlashlight;

        public bool EnsureFlashlightOn()
        {
            if (!DeviceHasFlashlight) return false;

            if (IsFlashlightOn) return true;

            var result = NativeEnsureFlashlightOn();
            IsFlashlightOn = result;	

            return result;
        }

        public bool EnsureFlashlightOff()
        {
            if (!IsFlashlightOn) return true;

            var result = NativeEnsureFlashlightOff();
            IsFlashlightOn = !result;

            return result;
        }

        protected abstract bool NativeDeviceHasFlashlight { get; }

        protected abstract bool NativeEnsureFlashlightOn();

        protected abstract bool NativeEnsureFlashlightOff();
    }
}
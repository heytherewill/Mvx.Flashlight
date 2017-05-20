using Client.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;

namespace Client.iOS.Views
{
    public partial class FirstView : MvxViewController
    {
        public FirstView() : base("FirstView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(On).To(vm => vm.TurnFlashlightOnCommand);
            set.Bind(Off).To(vm => vm.TurnFlashlightOffCommand);
            set.Bind(Toggle).To(vm => vm.ToggleFlashlightCommand);
            set.Apply();
        }
    }
}


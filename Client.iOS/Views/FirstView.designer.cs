// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Client.iOS.Views
{
    [Register ("FirstView")]
    partial class FirstView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Off { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton On { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Toggle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Off != null) {
                Off.Dispose ();
                Off = null;
            }

            if (On != null) {
                On.Dispose ();
                On = null;
            }

            if (Toggle != null) {
                Toggle.Dispose ();
                Toggle = null;
            }
        }
    }
}
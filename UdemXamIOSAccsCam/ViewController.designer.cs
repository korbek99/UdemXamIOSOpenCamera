// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace UdemXamIOSAccsCam
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton BtnCargar { get; set; }

		[Outlet]
		UIKit.UIButton BtnCargarCamara { get; set; }

		[Outlet]
		UIKit.UIImageView Imagen { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BtnCargar != null) {
				BtnCargar.Dispose ();
				BtnCargar = null;
			}

			if (BtnCargarCamara != null) {
				BtnCargarCamara.Dispose ();
				BtnCargarCamara = null;
			}

			if (Imagen != null) {
				Imagen.Dispose ();
				Imagen = null;
			}
		}
	}
}

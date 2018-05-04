using System;

using UIKit;

namespace UdemXamIOSAccsCam
{
    public partial class ViewController : UIViewController
    {

        UIImagePickerController SeleccionImagen;
        UIImage Fotografia;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SeleccionImagen = new UIImagePickerController();
            SeleccionImagen.FinishedPickingMedia += FinalizandoSeleccion;
            SeleccionImagen.Canceled += CancelarSeleccion;
            BtnCargar.TouchUpInside += delegate {
                SeleccionImagen.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
                PresentViewController(SeleccionImagen,true,null);
            };

            BtnCargarCamara.TouchUpInside += delegate {
                SeleccionImagen.SourceType = UIImagePickerControllerSourceType.Camera;
                PresentViewController(SeleccionImagen, true, null);
            };
        }

        private void CancelarSeleccion(object sender , EventArgs e )
        {
            SeleccionImagen.DismissViewControllerAsync(true);

        }

        private void FinalizandoSeleccion(object sender, UIImagePickerMediaPickedEventArgs e)
        {
            Fotografia = e.Info[UIImagePickerController.OriginalImage] as UIImage;
            Imagen.Image = Fotografia;
            SeleccionImagen.DismissViewControllerAsync(true);


        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

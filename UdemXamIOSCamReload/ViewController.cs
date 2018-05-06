using System;
using System.IO;
using Foundation;
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

            if(UIImagePickerController.IsSourceTypeAvailable
               (UIImagePickerControllerSourceType.Camera)){

                SeleccionImagen.SourceType = 
                    UIImagePickerControllerSourceType.Camera;
            }else{

                SeleccionImagen.SourceType =
                    UIImagePickerControllerSourceType.PhotoLibrary;
            }

            BtnCargarCamara.TouchUpInside += delegate {
                //SeleccionImagen.SourceType = UIImagePickerControllerSourceType.Camera;
                //PresentViewController(SeleccionImagen, true, null);
                PresentViewController(SeleccionImagen,true,null);
            };

            BtnCargar.TouchUpInside += delegate {
                // SeleccionImagen.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
                // PresentViewController(SeleccionImagen,true,null);

                string rutacarpeta = Environment.GetFolderPath
                                                (Environment.SpecialFolder.Personal);
                string archivolocal = "Foto1.jpg";
                string rutacompleta = Path.Combine(rutacarpeta, archivolocal);
                NSError err = null;
                NSData img = Fotografia.AsJPEG();
                img.Save(rutacompleta, false, out err);
                Imagen.Image = UIImage.FromFile(rutacompleta);
                SeleccionImagen.DismissViewControllerAsync(true);
                

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
            //SeleccionImagen.DismissViewControllerAsync(true);

            Fotografia.SaveToPhotosAlbum(delegate(UIImage image,NSError error)
            {
                if(null != error){

                    Console.WriteLine(error.LocalizedDescription);
                }

            });

            Fotografia.AsJPEG();
            string rutacarpeta = Environment.GetFolderPath
                                               (Environment.SpecialFolder.Personal);
            string archivolocal = "Foto1.jpg";
            string rutacompleta = Path.Combine(rutacarpeta, archivolocal);
            NSError err = null;
            NSData img = Fotografia.AsJPEG();
            img.Save(rutacompleta, false, out err);
            Imagen.Image = UIImage.FromFile(rutacompleta);
            SeleccionImagen.DismissViewControllerAsync(true);


        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

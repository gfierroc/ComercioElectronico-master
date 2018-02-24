using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Web;

namespace ComercioElectronico.Models
{
    public class ComercioElectronicoInitializer : DropCreateDatabaseAlways<ComercioElectronicoContext>
    {
        //This gets a byte array for a file at the path specified
        //The path is relative to the route of the web site
        //It is used to seed images
        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }

        //This method puts sample data into the database
        protected override void Seed(ComercioElectronicoContext context)
        {
            base.Seed(context);

            var productos = new List<ProductoModel>()
            {
                new ProductoModel()
                {
                    NombreProducto = "PANTALLA LED LG 43 PULGADAS FULL HD SMART 43LJ5500"
                    ,Descripcion = "La Pantalla de la marca LG integra la tecnología Smart TV webOS 3.5, ideal para reproducir series, videos y películas en las aplicaciones Netflix, YouTube y muchas más."
                    ,PrecioUnitario = 6999.00
                    ,PhotoFile = getFileBytes("\\Imagenes\\PantallaLg43.jpg")
                    ,ImageMimeType = "image/jpeg"
                    ,FechaCreación = DateTime.Today.AddDays(-5)
                    ,FechaActualizacion = DateTime.Today.AddDays(-1)
                }
                ,new ProductoModel()
                {
                    NombreProducto = "Minicomponente LG CJ42"
                    ,Descripcion = "Podrás reproducir tu música favorita directamente desde tu USB, con una potencia de audio de 130 W"
                    ,PrecioUnitario = 1999.00
                    ,PhotoFile = getFileBytes("\\Imagenes\\MinicomponenteCJ42.jpg")
                    ,ImageMimeType = "image/jpeg"
                    ,FechaCreación = DateTime.Today.AddDays(-5)
                    ,FechaActualizacion = DateTime.Today.AddDays(-1)
                }
                ,new ProductoModel()
                {
                    NombreProducto = "Consola Xbox One S 1TB + Videojuego Forza Horizon 3"
                    ,Descripcion = "Xbox One S es la consola más reciente con tecnología 4k; podrás configurarla con tus gadgets y dejar atrás los controles remotos. Te permitirá ver películas, escuchar música, jugar y tener una experiencia personalizada"
                    ,PrecioUnitario = 6899.00
                    ,PhotoFile = getFileBytes("\\Imagenes\\xboxs.jpg")
                    ,ImageMimeType = "image/jpeg"
                    ,FechaCreación = DateTime.Today.AddDays(-5)
                    ,FechaActualizacion = DateTime.Today.AddDays(-1)
                }
                ,new ProductoModel()
                {
                    NombreProducto = "MINIDRONE PARROT MAMBO FLY"
                    ,Descripcion = "¡Aprende a volar como un profesional! Con el Drone Mambo de la marca Parrot. Es un minidrone robustos y fácil de pilotar. Considerado como uno de los minidrones más estables del mercado gracias a su pilotaje automático, te será muy fácil interactuar con tus amigos e incluso hacer fotos desde el aire."
                    ,PrecioUnitario = 3399.00
                    ,PhotoFile = getFileBytes("\\Imagenes\\MINIDRONE.jpg")
                    ,ImageMimeType = "image/jpeg"
                    ,FechaCreación = DateTime.Today.AddDays(-5)
                    ,FechaActualizacion = DateTime.Today.AddDays(-1)
                }
                ,new ProductoModel()
                {
                    NombreProducto = "ADIR TALADRO ROTOMARTILLO"
                    ,Descripcion = "Práctico rotomartillo broquero de ½ pulgada, cuenta con una potencia de 500 watts, capacidad reversible y velocidad variable."
                    ,PrecioUnitario = 699.00
                    ,PhotoFile = getFileBytes("\\Imagenes\\TALADRO.jpg")
                    ,ImageMimeType = "image/jpeg"
                    ,FechaCreación = DateTime.Today.AddDays(-5)
                    ,FechaActualizacion = DateTime.Today.AddDays(-1)
                }
            };

            productos.ForEach(s => context.Productos.Add(s));
            context.SaveChanges();
        }
    }
}
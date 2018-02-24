using ComercioElectronico.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace ComercioElectronico.Controllers
{
    public class ProductosController : Controller
    {
        private IComercioElectronicoContext context;

        public ProductosController()
        {
            context = new ComercioElectronicoContext();
        }

        //public ProductoController(IComercioElectronicoContext Context)
        //{
        //    context = Context;
        //}

        public FileContentResult GetImage(int id)
        {
            ProductoModel producto = context.FindProductoById(id);

            if (producto != null)
            {
                return File(producto.PhotoFile, producto.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        // GET: Photo
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult VerProducto(int? id)
        {
            ProductoModel producto = null;
            if (id != null)
            {
                producto = context.FindProductoById((int)id);
                if (producto == null)
                {
                    return HttpNotFound();
                }
            }

            return View("VerProducto", producto);
        }

        [ChildActionOnly]
        public ActionResult _CatalogoProducto(int number = 0)
        {
            List<ProductoModel> productos;
            if (number == 0)
            {
                productos = context.Productos.ToList();
            }
            else
            {
                productos = (from p in context.Productos
                             orderby p.FechaCreación descending
                             select p).Take(number).ToList();
            }

            return PartialView("_CatalogoProducto", productos);
        }

        public ActionResult Eliminar(int id)
        {
            ProductoModel producto = context.FindProductoById(id);

            if (producto == null)
            {
                return HttpNotFound();
            }

            return View("Eliminar", producto);
        }

        [HttpPost]
        public ActionResult AgregarProducto(int idProd, string NomProd, int cantidad, double precio)
        {
            List<CarritoModel> listaProductos = new List<CarritoModel>();
            CarritoModel nuevoArt = new Models.CarritoModel();
            string idUs = Request.LogonUserIdentity.User.AccountDomainSid.Value;

            if (Session["Carrito"] != null)
            {
                listaProductos = (List<CarritoModel>)Session["Carrito"];

                int mismoProd = (from l in listaProductos
                                 where l.IdProducto == idProd
                                 select l).Count();
                if (mismoProd > 0)
                {
                    for (int i = 0; i < listaProductos.Count; i++)
                    {
                        if (listaProductos[i].IdProducto == idProd)
                        {
                            listaProductos[i].Cantidad = cantidad;
                            listaProductos[i].PrecioXcantidad = precio * cantidad;
                            break;
                        }
                    }
                }
                else
                {
                    nuevoArt = new CarritoModel();
                    nuevoArt.IdUsuario = idUs;
                    nuevoArt.IdProducto = idProd;
                    nuevoArt.NombreProducto = NomProd;
                    nuevoArt.Cantidad = cantidad;
                    nuevoArt.PrecioXcantidad = cantidad * precio;

                    listaProductos.Add(nuevoArt);
                }
            }
            else
            {
                nuevoArt = new CarritoModel();
                nuevoArt.IdUsuario = idUs;
                nuevoArt.IdProducto = idProd;
                nuevoArt.NombreProducto = NomProd;
                nuevoArt.Cantidad = cantidad;
                nuevoArt.PrecioXcantidad = cantidad * precio;

                listaProductos.Add(nuevoArt);

                Session["Carrito"] = listaProductos;
            }

            return RedirectToAction("Index");
        }
    }
}
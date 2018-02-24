using ComercioElectronico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComercioElectronico.Controllers
{
    [Authorize]
    public class CarritoController : Controller
    {
        private IComercioElectronicoContext context;

        public CarritoController()
        {
            context = new ComercioElectronicoContext();
        }

        // GET: Carrito
        public ActionResult Index()
        {
            return View("Index");
        }

        [ChildActionOnly]
        public ActionResult _CarritoProductos(int number = 0)
        {
            decimal Total = 0;
            List<CarritoModel> listaProductos = new List<CarritoModel>();

            if (Session["Carrito"] != null)
            {
                listaProductos = (List<CarritoModel>)Session["Carrito"];

                Total = (decimal)(from l in listaProductos
                                  select l.PrecioXcantidad).Sum();
            }

            ViewBag.Total = Total;
            
            return PartialView("_CarritoProductos", listaProductos);
        }

        public ActionResult Quitar(int id)
        {
            if (Session["Carrito"] != null)
            {
                List<CarritoModel> listaProductos = new List<CarritoModel>();

                listaProductos = (List<CarritoModel>)Session["Carrito"];

                CarritoModel art = (from l in listaProductos
                                    where l.IdProducto == id
                                    select l).FirstOrDefault();
                listaProductos.Remove(art);

            }

                return View("Index");
        }

        public ActionResult AddProduct (int idProd)
        {
            List<CarritoModel> listaProductos = new List<CarritoModel>();
            int cantidad = 0;
            double precio = 0;

            if (Session["Carrito"] != null)
            {
                listaProductos = (List<CarritoModel>)Session["Carrito"];

                int mismoProd = (from l in listaProductos
                                 where l.IdProducto == idProd
                                 select l.Cantidad).FirstOrDefault();
                if(mismoProd > 0)
                {
                    for (int i = 0; i < listaProductos.Count; i++)
                    {
                        if (listaProductos[i].IdProducto == idProd)
                        {
                            cantidad = listaProductos[i].Cantidad;
                            precio = listaProductos[i].PrecioXcantidad / cantidad;
                            cantidad++;
                            listaProductos[i].Cantidad = cantidad;
                            listaProductos[i].PrecioXcantidad = precio * cantidad;
                            break;
                        }
                    }
                }
            }

            return View("Index");
        }

        public ActionResult QuitarProduct(int idProd)
        {
            List<CarritoModel> listaProductos = new List<CarritoModel>();
            int cantidad = 0;
            double precio = 0;

            if (Session["Carrito"] != null)
            {
                listaProductos = (List<CarritoModel>)Session["Carrito"];

                int mismoProd = (from l in listaProductos
                                 where l.IdProducto == idProd
                                 select l.Cantidad).FirstOrDefault();
                if (mismoProd > 1)
                {
                    for (int i = 0; i < listaProductos.Count; i++)
                    {
                        if (listaProductos[i].IdProducto == idProd)
                        {
                            cantidad = listaProductos[i].Cantidad;
                            precio = listaProductos[i].PrecioXcantidad / cantidad;
                            cantidad--;
                            listaProductos[i].Cantidad = cantidad;
                            listaProductos[i].PrecioXcantidad = precio * cantidad;
                            break;
                        }
                    }
                }
            }

            return View("Index");
        }

        public ActionResult Pagar(string cupon)
        {
            if (ModelState.IsValid)
            {

                List<CarritoModel> listaProductos = new List<CarritoModel>();

                if (Session["Carrito"] != null)
                {
                    decimal Total = 0;

                    PagoCarritoModel pago = new PagoCarritoModel();

                    listaProductos = (List<CarritoModel>)Session["Carrito"];

                    Total = (decimal)(from l in listaProductos
                                      select l.PrecioXcantidad).Sum();

                    pago.IdUsuario = Request.LogonUserIdentity.User.AccountDomainSid.Value;
                    pago.Total = (double)Total;
                    pago.FormaPago = "CUPON";
                    pago.CuponPago = cupon;
                    pago.FechaPago = DateTime.Today;

                    context.Add<PagoCarritoModel>(pago);
                    context.SaveChanges();

                    listaProductos.Clear();

                    Session["Carrito"] = listaProductos;
                }

                return View("Pago");
            }

            return View("Index");
        }
    }
}
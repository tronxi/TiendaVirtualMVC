using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual;
using TiendaVirtual.Models;

namespace TiendaVirtual.Controllers
{
    public class CarritoCompraController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: CarritoCompra
        public ActionResult Index(CarritoCompra cc)
        {
            return View(toShow(cc));
        }

        public ActionResult comprar(CarritoCompra cc)
        {
            CarritoCompra carritoToShow = toShow(cc);
            Pedido pedido = new Pedido();
            pedido.Nombre = User.Identity.Name;
            for (int i = 0; i < carritoToShow.ToList().Count; i++)
            {
                pedido.Producto.Add(carritoToShow[i]);
            }
            db.Pedidos.Add(pedido);
            db.SaveChanges();
            return View("Home");
        }

        private CarritoCompra toShow(CarritoCompra cc)
        {
            Dictionary<int, int> typeIdAmount = new Dictionary<int, int>();
            for (int i = 0; i < cc.Count; i++)
            {
                Producto producto = cc[i];
                try
                {
                    int newAmount = typeIdAmount[producto.Id] + 1;
                    typeIdAmount[producto.Id] = newAmount;
                }
                catch (Exception e)
                {
                    typeIdAmount.Add(producto.Id, 1);
                }

            }
            CarritoCompra carritoToShow = new CarritoCompra();
            foreach (KeyValuePair<int, int> idAmount in typeIdAmount)
            {
                Producto producto = db.Productos.Find(idAmount.Key);
                Producto newProducto = new Producto();
                newProducto.Id = producto.Id;
                newProducto.Descripcion = producto.Descripcion;
                newProducto.Cantidad = idAmount.Value;
                newProducto.Nombre = producto.Nombre;
                newProducto.Precio = producto.Precio;
                carritoToShow.Add(newProducto);
            }
            return carritoToShow;
        }

        // GET: CarritoCompra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: CarritoCompra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarritoCompra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedidos.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pedido);
        }

        // GET: CarritoCompra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: CarritoCompra/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pedido);
        }

        // GET: CarritoCompra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: CarritoCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidos.Find(id);
            db.Pedidos.Remove(pedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

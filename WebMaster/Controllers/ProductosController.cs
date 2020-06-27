using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMaster.Models;

namespace WebMaster.Controllers
{
    public class ProductosController : Controller
    {
        public WebMasterDBContext _context;

        public ProductosController(WebMasterDBContext master)
        {
            this._context = master;
        }

        // GET: ProductosController
        public ActionResult Index()
        {
            return View(_context.Productos.ToList());
        }

        
        // GET: ProductosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductosController/CreateProducto
        public ActionResult CreateProducto()
        {
            return View("Create");
        }

        // POST: ProductosController/CreateProducto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProducto(Productos _producto)
        {
            Productos product = new Productos
            {
                Nombre = _producto.Nombre,
                Precio = _producto.Precio,
                Cantidad = _producto.Cantidad
            };
            _context.Productos.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index","Productos");
        }

        // GET: ProductosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Productos.Where(s => s.Codigo == id).First());
        }

        // POST: ProductosController/Edit/5
        [HttpPost]
        public ActionResult EditProducto(Productos producto)
        {
            Productos p = _context.Productos.Where(s => s.Codigo == producto.Codigo).First();
            p.Nombre = producto.Nombre;
            p.Precio = producto.Precio;
            p.Cantidad = producto.Cantidad;
            _context.SaveChanges();
            return RedirectToAction("Index","Productos");
        }
        // GET: ProductosController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Productos producto = _context.Productos.Where(s => s.Codigo == id).First();
                _context.Productos.Remove(producto);
                _context.SaveChanges();
                return RedirectToAction("Index", "Productos");
            }
            catch (Exception xe)
            {
                return RedirectToAction("Index","Home");
            }
        }

        // POST: ProductosController/Delete/5
        [HttpPost]
        public ActionResult DeleteProducto(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

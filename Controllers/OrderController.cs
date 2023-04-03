using Microsoft.AspNetCore.Mvc;
using PruebaAdventureWorks.Models;
using PruebaAdventureWorks.Repositories;
using PruebaAdventureWorks.Repositories.Contracts;

namespace PruebaAdventureWorks.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductRepository _productoRepo;
        private readonly IPedidoRepository _pedidoRepo;

        public OrderController(IProductRepository productoRepo, IPedidoRepository pedidoRepo)
        {
            _productoRepo = productoRepo;
            _pedidoRepo = pedidoRepo;
        }

        [HttpGet]
        public async Task<IActionResult> RealizarPedido()
        {
            ViewBag.Productos = await _productoRepo.GetAllProducts();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RealizarPedido(WorkOrder pedido, Product product, PurchaseOrderDetail detail)
        {
            if (ModelState.IsValid)
            {
                var producto = await _productoRepo.GetProductById(pedido.ProductId);
                var costoTotal = pedido.OrderQty * product.ListPrice;

                pedido.WorkOrderId = product.ProductId;
                detail.LineTotal = costoTotal;

                _pedidoRepo.AddPedido(pedido);

                return RedirectToAction("DetallePedido", new { id = pedido.WorkOrderId });
            }

            ViewBag.Productos = await _productoRepo.GetAllProducts();
            return View(pedido);
        }

        public async Task<IActionResult> DetallePedido(int id)
        {
            var pedido = await _pedidoRepo.GetPedidoById(id);
            return View(pedido);
        }
    }
}

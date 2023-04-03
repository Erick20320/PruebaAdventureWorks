using PruebaAdventureWorks.DataContext;
using PruebaAdventureWorks.Models;
using PruebaAdventureWorks.Repositories.Contracts;

namespace PruebaAdventureWorks.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AdventureWorks2019Context _context;

        public PedidoRepository(AdventureWorks2019Context context)
        {
            _context = context;
        }

        public async Task AddPedido(WorkOrder pedido, Product product, PurchaseOrderDetail detail)
        {
            try
            {
                // Obtener el producto seleccionado
                var producto = await _context.Products.FindAsync(pedido.ProductId);

                // Asignar el nombre del producto al pedido
                pedido.WorkOrderId = product.ProductId;

                // Calcular el costo total del pedido
                detail.LineTotal = pedido.OrderQty * product.ListPrice;

                // Agregar el pedido a la base de datos y guardar los cambios
                _context.WorkOrders.Add(pedido);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public void AddPedido(WorkOrder pedido)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
                throw;
            }
        }

        public async Task<WorkOrder> GetPedidoById(int id)
        {
            try
            {
                return await _context.WorkOrders.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }
    }

}

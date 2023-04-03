using PruebaAdventureWorks.Models;

namespace PruebaAdventureWorks.Repositories.Contracts
{
    public interface IPedidoRepository
    {
        Task AddPedido(WorkOrder pedido, Product product, PurchaseOrderDetail detail);
        void AddPedido(WorkOrder pedido);
        Task<WorkOrder> GetPedidoById(int id);
    }
}

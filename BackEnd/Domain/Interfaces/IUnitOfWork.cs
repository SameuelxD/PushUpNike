using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public ICiudad Ciudades { get; }
        public ICategoria Categorias { get; }
        public ICliente Clientes { get; }
        public IColor Colores { get; }
        public IContacto Contactos { get; }
        public IDepartamento Departamentos { get; }
        public IDetallePedido DetallePedidos { get; }
        public IDireccion Direcciones { get; }
        public IEstadoPedido EstadoPedidos { get; }
        public IInventario Inventarios { get; }
        public IPais Paises { get; }
        public IPedido Pedidos { get; }
        public IProducto Productos { get; }
        public ITipoMaterial TipoMateriales { get; }
        public ITipoPago TipoPagos { get; }
        public ITipoProducto TipoProductos { get; }
        public ITransacciones Transacciones { get; }

        Task<int> SaveAsync();
    }
}
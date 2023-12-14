using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Data;
using Domain.Interfaces;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NikeContext _context;
        private CategoriaRepository _categorias;
        public CiudadRepository _ciudades;
        private ClienteRepository _clientes;
        private ColorRepository _colores;
        private ContactoRepository _contactos;
        private DepartamentoRepository _departamentos;
        private DetallePedidoRepository _detallePedidos;
        private DireccionRepository _direcciones;
        private EstadoPedidoRepository _estadoPedidos;
        private InventarioRepository _inventarios;

        private PaisRepository _paises;
        private PedidoRepository _pedidos;
        private ProductoRepository _productos;
        private TipoMaterialRepository _tipoMateriales;

        private TipoPagoRepository _tipoPagos;
        private TipoProductoRepository _tipoProductos;
        private TransaccionesRepository _transacciones;




        public ICategoria Categorias
        {
            get
            {
                if (_categorias == null)
                {
                    _categorias = new CategoriaRepository(_context);
                }
                return _categorias;
            }
        }

        public ICiudad Ciudades
        {
            get
            {
                if (_ciudades == null)
                {
                    _ciudades = new CiudadRepository(_context);
                }
                return _ciudades;
            }
        }

        public ICliente Clientes
        {
            get
            {
                if (_clientes == null)
                {
                    _clientes = new ClienteRepository(_context);
                }
                return _clientes;
            }
        }

        public IColor Colores
        {
            get
            {
                if (_colores == null)
                {
                    _colores = new ColorRepository(_context);
                }
                return _colores;
            }
        }

        public IContacto Contactos
        {
            get
            {
                if (_contactos == null)
                {
                    _contactos = new ContactoRepository(_context);
                }
                return _contactos;
            }
        }

        public IDepartamento Departamentos
        {
            get
            {
                if (_departamentos == null)
                {
                    _departamentos = new DepartamentoRepository(_context);
                }
                return _departamentos;
            }
        }

        public IDetallePedido DetallePedidos
        {
            get
            {
                if (_detallePedidos == null)
                {
                    _detallePedidos = new DetallePedidoRepository(_context);
                }
                return _detallePedidos;
            }
        }

        public IDireccion Direcciones
        {
            get
            {
                if (_direcciones == null)
                {
                    _direcciones = new DireccionRepository(_context);
                }
                return _direcciones;
            }
        }

        public IEstadoPedido EstadoPedidos
        {
            get
            {
                if (_estadoPedidos == null)
                {
                    _estadoPedidos = new EstadoPedidoRepository(_context);
                }
                return _estadoPedidos;
            }
        }
        public IInventario Inventarios
        {
            get
            {
                if (_inventarios == null)
                {
                    _inventarios = new InventarioRepository(_context);
                }
                return _inventarios;
            }
        }
        public IPais Paises
        {
            get
            {
                if (_paises == null)
                {
                    _paises = new PaisRepository(_context);
                }
                return _paises;
            }
        }
        public IPedido Pedidos
        {
            get
            {
                if (_pedidos == null)
                {
                    _pedidos = new PedidoRepository(_context);
                }
                return _pedidos;
            }
        }
        public IProducto Productos
        {
            get
            {
                if (_productos == null)
                {
                    _productos = new ProductoRepository(_context);
                }
                return _productos;
            }
        }
        public ITipoMaterial TipoMateriales
        {
            get
            {
                if (_tipoMateriales == null)
                {
                    _tipoMateriales = new TipoMaterialRepository(_context);
                }
                return _tipoMateriales;
            }
        }
        public ITipoPago TipoPagos
        {
            get
            {
                if (_tipoPagos == null)
                {
                    _tipoPagos = new TipoPagoRepository(_context);
                }
                return _tipoPagos;
            }
        }
        public ITipoProducto TipoProductos
        {
            get
            {
                if (_tipoProductos == null)
                {
                    _tipoProductos = new TipoProductoRepository(_context);
                }
                return _tipoProductos;
            }
        }
        public ITransacciones Transacciones
        {
            get
            {
                if (_transacciones == null)
                {
                    _transacciones = new TransaccionesRepository(_context);
                }
                return _transacciones;
            }
        }

        public UnitOfWork(NikeContext context)
        {
            _context = context;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
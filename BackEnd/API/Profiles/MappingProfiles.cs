using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() // Remember adding : Profile in the class
        {
            CreateMap<Categorium, CategoriaDto>().ReverseMap();

            CreateMap<Ciudad, CiudadDto>().ReverseMap();

            CreateMap<Cliente, ClienteDto>().ReverseMap();

            CreateMap<Direccion, DireccionDto>().ReverseMap();

            CreateMap<Contacto, ContactoDto>().ReverseMap();

            CreateMap<Color, ColorDto>().ReverseMap();

            CreateMap<Departamento, DepartamentoDto>().ReverseMap();

            CreateMap<Detallepedido, DetallePedidoDto>().ReverseMap();

            CreateMap<Estadopedido, EstadoPedidoDto>().ReverseMap();

            CreateMap<Inventario, InventarioDto>().ReverseMap();

            CreateMap<Pai, PaisDto>().ReverseMap();

            CreateMap<Pedido, PedidoDto>().ReverseMap();

            CreateMap<Producto, ProductoDto>().ReverseMap();

            CreateMap<Tipomaterial, TipoMaterialDto>().ReverseMap();

            CreateMap<Tipopago, TipoPagoDto>().ReverseMap();

            CreateMap<Tipoproducto, TipoProductoDto>().ReverseMap();

            CreateMap<Transaccione, TransaccionesDto>().ReverseMap();

        }
    }
}
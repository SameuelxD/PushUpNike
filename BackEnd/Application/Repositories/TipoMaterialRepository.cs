using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repositories
{
    public class TipoMaterialRepository : GenericRepository<Tipomaterial>, ITipoMaterial
    {
        private readonly NikeContext _context;

        public TipoMaterialRepository(NikeContext context) : base(context)
        {
            _context = context;
        }
    }
}
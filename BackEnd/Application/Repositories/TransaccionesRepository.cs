using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repositories
{
    public class TransaccionesRepository : GenericRepository<Transaccione>, ITransacciones
    {
        private readonly NikeContext _context;

        public TransaccionesRepository(NikeContext context) : base(context)
        {
            _context = context;
        }
    }
}
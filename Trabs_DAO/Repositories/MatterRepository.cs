using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabs_BLL.Models;
using Trabs_DAO.Interfaces;

namespace Trabs_DAO.Repositories
{
    public class MatterRepository : IMatterRepository
    {
        private readonly Context _context;

        public MatterRepository(Context context)
        {
            _context = context;
        }

        public new IQueryable<Matter> GetAll()
        {
            try
            {
               return _context.Matters.Include(m => m.Works);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

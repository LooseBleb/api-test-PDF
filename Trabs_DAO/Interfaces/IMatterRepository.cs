using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabs_BLL.Models;

namespace Trabs_DAO.Interfaces
{
    public interface IMatterRepository
    {
        new IQueryable<Matter> GetAll();
    }
}

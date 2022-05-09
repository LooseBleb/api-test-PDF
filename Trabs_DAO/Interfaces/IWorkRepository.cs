using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabs_BLL.Models;
using Trabs_DAO.Select;

namespace Trabs_DAO.Interfaces
{
    public interface IWorkRepository
    {
        new IQueryable<WorksSpefic> GetAll();

        Task<Work> GetByID(int ID);

        IQueryable<Work> FilterCategory(string workName);

        Task PostWorks(Work work);

        Task<GetPDF> GetPDF(int id);

    }
}

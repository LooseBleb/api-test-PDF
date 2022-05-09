using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabs_BLL.Models;
using Trabs_DAO.Interfaces;
using Trabs_DAO.Select;

namespace Trabs_DAO.Repositories
{
    public class WorkRepository : IWorkRepository
    {
        private readonly Context _context;

        public WorkRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<Work> FilterCategory(string workName)
        {
            try
            {
                var works = _context.Works.Include(m => m.Matter).Where(w => w.Name.Contains(workName));

                return works;
            }
            catch (Exception error)
            {

                throw error;
            }

        }

        public new IQueryable<WorksSpefic> GetAll()
        {
            try
            {
                return _context.Works.Select(w => new WorksSpefic
                {
                    Id = w.Id,
                    Name = w.Name,
                    Description = w.Description,
                    Matter = w.Matter,
                    Created = w.Created
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }   
        }

        public async Task<GetPDF> GetPDF(int Id)
        {
            try
            {
                var work = await _context.Works.Select(w => new GetPDF
                {
                    Id = w.Id,
                    PDF =  w.PDF,
                    Name = w.Name
                }).FirstOrDefaultAsync(w => w.Id == Id);

                return work;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Work> GetByID(int ID)
        {
            try
            {
                var work = await _context.Works.Include(m => m.Matter).FirstOrDefaultAsync(w => w.Id == ID);

                return work;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public async Task PostWorks(Work work)
        {
            try
            {
                _context.AddAsync(work);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

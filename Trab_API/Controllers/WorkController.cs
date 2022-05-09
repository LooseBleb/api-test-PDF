using Microsoft.AspNetCore.Mvc;
using Trabs_BLL.Models;
using Trabs_DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Trabs_DAO.Repositories;
using Trabs_DAO.Select;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trab_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkRepository _workRepository;

        public WorkController(IWorkRepository categoryRepository)
        {
            _workRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorksSpefic>>> GetWorks()
        {
            return await _workRepository.GetAll().ToListAsync();
        }

        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<Work>>> GetWorks(string name)
        {
            return await _workRepository.FilterCategory(name).ToListAsync();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Work>> GetWorksID(int id)
        {
            var work = await _workRepository.GetByID(id);

            if (work == null)
            {
                return NotFound();
            }

            return work;
        }

        [HttpGet("getPDF/{id}")]
        public async Task<ActionResult<GetPDF>> GetPDF(int id)
        {
            var work = await _workRepository.GetPDF(id);

            if (work == null)
            {
                return NotFound();
            }

            return work;
        }


        [HttpPost]
        public async Task<ActionResult<Work>> PostWorks(Work work)
        {
            if(work.Name.Length <= 3)
            {
                return NotFound(new
                {
                    message = $"Works {work.Name} Not Found"
                });
            }

            if (ModelState.IsValid)
            {


                await _workRepository.PostWorks(work);

                return Ok(new
                {
                    message = $"Work {work.Name} Create Sucess"
                });
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

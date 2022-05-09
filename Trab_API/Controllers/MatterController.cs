using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trabs_BLL.Models;
using Trabs_DAO.Interfaces;

namespace Trab_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatterController : Controller
    {
        private readonly IMatterRepository _matterRepository;

        public MatterController(IMatterRepository matterRepository)
        {
            _matterRepository = matterRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matter>>> GetMatter()
        {
            return await _matterRepository.GetAll().ToListAsync();
        }
    }
}

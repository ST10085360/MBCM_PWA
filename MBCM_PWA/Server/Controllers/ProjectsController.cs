using MBCM_PWA.Client.Shared.Models;
using MBCM_PWA.Client.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MBCM_PWA.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly MBCM_DbContext _dbContext;

        public ProjectsController(MBCM_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return _dbContext.tblProject.AsNoTracking().ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI_NFK_SQMS.DB_Context;
using DataAccessLayer.Models.MasterInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using DataAccessLayer.Models;


namespace WebAPI_NFK_SQMS.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]

    public class VwOSFinalCheckController : Controller
    {
        private readonly ApplicationDBContext _context;


        public VwOSFinalCheckController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<vw_OS_FinalCheck_Pcs>>> GetOSFinalCheck()
        {
            return await _context.vw_OS_FinalCheck_Pcs.ToListAsync();
        }


    }
}

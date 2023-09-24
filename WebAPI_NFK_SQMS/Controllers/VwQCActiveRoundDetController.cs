using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_NFK_SQMS.DB_Context;


namespace WebAPI_NFK_SQMS.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]

    public class VwQCActiveRoundDetController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public VwQCActiveRoundDetController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<vw_QC_Active_Round_Info>>> GetQCActiveRoundDet()
        {
            return await _context.vw_QC_Active_Round_Info.ToListAsync();
        }


    }
}

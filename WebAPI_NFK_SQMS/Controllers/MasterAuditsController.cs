using DataAccessLayer.Models.MasterInfo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_NFK_SQMS.DB_Context;

namespace WebAPI_NFK_SQMS.Controllers
{

    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]

    public class MasterAuditsController : ControllerBase
    {


        private readonly ApplicationDBContext _context;

        public MasterAuditsController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_Master_Audits>>> GetMasterAudits()
        {
            return await _context.tblSQMS_Master_Audits.ToListAsync();
        }
    }
}

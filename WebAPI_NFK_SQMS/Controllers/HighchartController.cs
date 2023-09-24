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

namespace WebAPI_NFK_SQMS.Controllers
{

    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]

    public class Highchart : ControllerBase 
    {
        private readonly ApplicationDBContext _context;

        public Highchart(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HighChart>>> GetHighchart()
        {
            return await _context.HighChart.ToListAsync();
        }

         

    }
}

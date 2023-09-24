using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models.Expo_NFK;
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

    public class VwStyleDetController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public VwStyleDetController(ApplicationDBContext context)
        {
            _context = context;
        }
         
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vw_Style_Master_with_layout>>> GetStyleDet()
        {
            return await _context.vw_Style_Master_with_layout.OrderBy(x=>x.StyleNo).ToListAsync();
        }

 


    }
}

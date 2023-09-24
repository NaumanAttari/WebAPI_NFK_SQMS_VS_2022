using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_NFK_SQMS.DB_Context;
using DataAccessLayer.Models.MasterInfo;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_NFK_SQMS.Controllers
{
        [EnableCors("SiteCorsPolicy")]
        [Route("api/[controller]")]
        [ApiController]

    public class AQLLotSizeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public AQLLotSizeController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_Master_AQL_Lot_Size>>> GetAQLLotSize()
        {
            return await _context.tblSQMS_Master_AQL_Lot_Size.ToListAsync();
        }

    }
}

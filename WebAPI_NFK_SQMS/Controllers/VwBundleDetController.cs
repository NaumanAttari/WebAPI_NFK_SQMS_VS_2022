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

    public class VwBundleDetController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public VwBundleDetController(ApplicationDBContext context)
        {
            _context = context;
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<vw_CB_Detail>>> GetCBDet()
        //{
        //    return await _context.vw_CB_Detail.ToListAsync();
        //}


        // GET: api/VwBundleDet/CB-10001
        [HttpGet("{CBNO}")]
        public async Task<ActionResult<IEnumerable<vw_BundleDetail>>> GetBundleDetailByID(string CBNo)
        {
            var BundleDet = await _context.vw_BundleDetail.Where(a => a.CBNo == CBNo).ToListAsync();

            if (BundleDet == null)
            {
                return NotFound();
            }

            return BundleDet;

        }


    }
}

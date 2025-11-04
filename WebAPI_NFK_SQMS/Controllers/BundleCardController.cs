using DataAccessLayer.Models.MasterInfo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WebAPI_NFK_SQMS.DB_Context;

namespace WebAPI_NFK_SQMS.Controllers
{

    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]

    public class BundleCardController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public BundleCardController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_EndLine_Bundle_Cards>>> GetBundleCard()
        {
            return await _context.tblSQMS_EndLine_Bundle_Cards.ToListAsync();
        }



        //POST: api/BundleCard
        [HttpPost]
        public async Task<ActionResult<tblSQMS_EndLine_Bundle_Cards>> CreateFaults(tblSQMS_EndLine_Bundle_Cards tblSQMSBundleCard)
        {
            try
            {

                _context.tblSQMS_EndLine_Bundle_Cards.Add(tblSQMSBundleCard);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBundleCard", new { id = tblSQMSBundleCard.Id }, tblSQMSBundleCard);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/BundleCard/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_EndLine_Bundle_Cards>> GetBundleCard(long pId)
        {
            var faults = await _context.tblSQMS_EndLine_Bundle_Cards.FirstOrDefaultAsync(a => a.Id == pId);

            if (faults == null)
            {
                return NotFound();
            }

            return faults;
        }


        // GET: api/BundleCard/StyleNo/K-87
        [HttpGet("StyleNo/{styleNo}")]
        public async Task<ActionResult<IEnumerable<tblSQMS_EndLine_Bundle_Cards>>> GetBundleCard_StyleNo(string styleNo)
        {
            var styleDet = await _context.tblSQMS_EndLine_Bundle_Cards.Where(a => a.StyleNo == styleNo).ToListAsync();

            if (styleDet == null)
            {
                return NotFound();
            }

            return styleDet;
        }


        [HttpGet("CBNo")]
        public async Task<ActionResult<IEnumerable<tblSQMS_EndLine_Bundle_Cards>>> GetBundleCardCBWise()
        {
            return await _context.tblSQMS_EndLine_Bundle_Cards.ToListAsync();
        }

        // GET: api/BundleCard/CBNo/CB-0000
        [HttpGet("CBNo/{pCBNo}")]
        public async Task<ActionResult<IEnumerable<tblSQMS_EndLine_Bundle_Cards>>> GetBundleCardCBWise(string pCBNo)
        {
            var CBDet = await _context.tblSQMS_EndLine_Bundle_Cards.Where(a => a.CBNo == pCBNo).ToListAsync();

            if (CBDet == null)
            {
                return NotFound();
            }

            return CBDet;
        }

        // PUT: api/BundleCard/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutFaults(long pId, tblSQMS_EndLine_Bundle_Cards tblSQMSBundleCard)
        {
            if (pId != tblSQMSBundleCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMSBundleCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BundleCardExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetBundleCard", tblSQMSBundleCard);
        }

        private bool BundleCardExisit(long pId)
        {
            return _context.tblSQMS_EndLine_Bundle_Cards.Any(e => e.Id == pId);
        }


        //api/BundleCard/MarkInLineInBundleCard 
        [HttpPost("MarkInLineInBundleCard")]
        public async Task<IActionResult> MarkInLineInBundleCard([FromQuery] string pCBNo, string pSize, string pBundleNo, string pFloor, string pProdLineNo)
        {
            //var CBDet = await _context.tblSQMS_EndLine_Bundle_Cards.Where(a => a.CBNo == pCBNo && a.Size == pSize && a.BundleNo == pBundleNo && a.Floor == pFloor && a.ProdLineNo == pProdLineNo).ToListAsync();
            var CBDet = await _context.tblSQMS_EndLine_Bundle_Cards.Where(a => a.CBNo == pCBNo && a.Size == pSize && a.BundleNo == pBundleNo && a.Floor == pFloor).ToListAsync();

            if (CBDet[0].InLine == null)
            {
                CBDet[0].ProdLineNo = pProdLineNo;
                CBDet[0].InLine = true;
                CBDet[0].InLineAt = DateTime.Now;
                _context.Entry(CBDet[0]).State = EntityState.Modified;
            }


            try
            {
                await _context.SaveChangesAsync();
                
                //string strQry = "";
                //strQry = $"Update tblSQMS_EndLine_Bundle_Cards " +
                //         $"    Set InLine = 1, " +
                //         $"        InLineAt = getdate() " +
                //         $" Where " +
                //         $"      CBNo = '{pCBNo}' " +
                //         $"  And Size = '{pSize}' " +
                //         $"  And BundleNo = '{pBundleNo}' " +
                //         $"  And Floor = '{pFloor}' " +
                //         $"  And ProdLineNo = '{pProdLineNo}' " +
                //         $"  And InLineAt is null ";

                //var i = _context.Database.ExecuteSqlRaw(strQry);

            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return CreatedAtAction("GetBundleCard", CBDet[0]);
        }






    }
}

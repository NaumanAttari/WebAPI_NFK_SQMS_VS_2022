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

    public class LinesController : Controller
    {

        private readonly ApplicationDBContext _context;

        public LinesController(ApplicationDBContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_Master_LineNo>>> GetLines()
        {
            return await _context.tblSQMS_Master_LineNo.OrderBy(x=>x.Floor).ThenBy(x=>x.ProdLineNo).ToListAsync();
        }



        //POST: api/Floors
        [HttpPost]
        public async Task<ActionResult<tblSQMS_Master_LineNo>> CreateLiness(tblSQMS_Master_LineNo tblSQMSLiness)
        {
            try
            {
                _context.tblSQMS_Master_LineNo.Add(tblSQMSLiness);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLines", new { id = tblSQMSLiness.Id }, tblSQMSLiness);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/Floors/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_Master_LineNo>> GetLines(long pId)
        {
            var floors = await _context.tblSQMS_Master_LineNo.FirstOrDefaultAsync(a => a.Id == pId);

            if (floors == null)
            {
                return NotFound();
            }

            return floors;
        }

        // PUT: api/Floors/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutLines(long pId, tblSQMS_Master_LineNo tblSQMSLiness)
        {
            if (pId != tblSQMSLiness.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMSLiness).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineNoExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetLines", tblSQMSLiness);
        }

        private bool LineNoExisit(long pId)
        {
            return _context.tblSQMS_Master_LineNo.Any(e => e.Id == pId);
        }



        private bool checkLineNoUses(string pFloor, string prodLineNo)
        {
            bool i = _context.tblSQMS_Fault_Gen_Categ.Any(e => e.Floor == pFloor & e.ProdLineNo == prodLineNo);
            bool j = _context.tblSQMS_Endline_Info.Any(e => e.Floor == pFloor & e.ProdLineNo == prodLineNo);
            bool k = _context.tblSQMS_EndLine_Bundle_Cards.Any(e => e.Floor == pFloor & e.ProdLineNo == prodLineNo);
            bool l = _context.tblSQMS_EndLine_Defects.Any(e => e.Floor == pFloor & e.ProdLineNo == prodLineNo);


            if (i || j || k || l)
                return false;
            else
                return true;

        }



        [HttpDelete("{lineID}")]
        public async Task<bool> DeleteFloor(long lineID)
        {
            var lineDet = await _context.tblSQMS_Master_LineNo.FindAsync(lineID);

            if (checkLineNoUses(lineDet.Floor, lineDet.ProdLineNo))
            {
                _context.tblSQMS_Master_LineNo.Remove(lineDet);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }



    }
}

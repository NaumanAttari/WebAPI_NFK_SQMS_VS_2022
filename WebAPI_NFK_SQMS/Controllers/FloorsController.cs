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


    public class FloorsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public FloorsController(ApplicationDBContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblSQMS_Master_Floor>>> GetFloors()
        {
            return await _context.tblSQMS_Master_Floor.ToListAsync();
        }



        //POST: api/Floors
        [HttpPost]
        public async Task<ActionResult<tblSQMS_Master_Floor>> CreateFloors(tblSQMS_Master_Floor tblSQMSFloors)
        {
            try
            {
                _context.tblSQMS_Master_Floor.Add(tblSQMSFloors);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFloors", new { id = tblSQMSFloors.Id }, tblSQMSFloors);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Data Creation In Database");
            }
        }

        // GET: api/Floors/5
        [HttpGet("{pId}")]
        public async Task<ActionResult<tblSQMS_Master_Floor>> GetFloors(long pId)
        {
            var floors = await _context.tblSQMS_Master_Floor.FirstOrDefaultAsync(a => a.Id == pId);

            if (floors == null)
            {
                return NotFound();
            }

            return floors;
        }

        // PUT: api/Floors/5
        [HttpPut("{pId}")]
        public async Task<IActionResult> PutFloors(long pId, tblSQMS_Master_Floor tblSQMSFloors)
        {
            if (pId != tblSQMSFloors.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSQMSFloors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FloorExisit(pId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetFloors", tblSQMSFloors);
        }

        private bool FloorExisit(long pId)
        {
            return _context.tblSQMS_Master_Floor.Any(e => e.Id == pId);
        }


        private bool checkFloorUses(string pFloor)
        {
            bool i = _context.tblSQMS_Fault_Gen_Categ.Any(e => e.Floor == pFloor);
            bool j = _context.tblSQMS_Endline_Info.Any(e => e.Floor == pFloor);
            bool k = _context.tblSQMS_EndLine_Bundle_Cards.Any(e => e.Floor == pFloor);

            if (i || j || k)
                return false;
            else
                return true;            

        }



        [HttpDelete("{floorID}")]
        public async Task<bool>  DeleteFloor(long floorID)
        {
            var floorDet = await _context.tblSQMS_Master_Floor.FindAsync(floorID);

            if (checkFloorUses(floorDet.Floor))
            {
                _context.tblSQMS_Master_Floor.Remove(floorDet);
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

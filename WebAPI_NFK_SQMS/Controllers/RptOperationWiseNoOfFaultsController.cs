using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI_NFK_SQMS.DB_Context;
using DataAccessLayer.Models.Sql_Functions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace WebAPI_NFK_SQMS.Controllers
{

    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]

    public class RptOperationWiseNoOfFaultsController : ControllerBase 

    {
        private readonly ApplicationDBContext _context;

        public RptOperationWiseNoOfFaultsController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet("{fromDate}/{toDate}")]
        public async Task<ActionResult<IEnumerable<rptOperationWiseNoOfFaults>>> GetOperationFaults(string fromDate, string toDate)
        {
            return await _context.OperationWiseNoOfFaults.FromSqlRaw("Select * from fn_OperationWiseNoOfFaults('" + fromDate + "','" + toDate + "')").ToListAsync();
        }


        [HttpGet("details")]
        public async Task<ActionResult<IEnumerable<rptOperationWiseNoOfFaults>>> Details(string fromDate, string toDate)
        {
            return await _context.OperationWiseNoOfFaults.FromSqlRaw("Select * from fn_OperationWiseNoOfFaults('" + fromDate + "','" + toDate + "',null)").ToListAsync();
        }


        [HttpGet("DetailswithFault")]
        public async Task<ActionResult<IEnumerable<rptOperationWiseNoOfFaults>>> DetailswithFault(string fromDate, string toDate, string Fault)
        {
            return await _context.OperationWiseNoOfFaults.FromSqlRaw("Select * from fn_OperationWiseNoOfFaults('" + fromDate + "','" + toDate + "','" + Fault + "')").ToListAsync();
        }



    }
}

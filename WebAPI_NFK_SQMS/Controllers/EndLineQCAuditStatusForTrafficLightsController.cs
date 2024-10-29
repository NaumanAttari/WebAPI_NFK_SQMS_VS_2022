using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI_NFK_SQMS.DB_Context;
using DataAccessLayer.Models.Sql_Functions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using DataAccessLayer.Models.TrafficLights;
using Microsoft.Data.SqlClient;

namespace WebAPI_NFK_SQMS.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EndLineQCAuditStatusForTrafficLightsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public EndLineQCAuditStatusForTrafficLightsController(ApplicationDBContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ExecuteEndLineQCAuditOQLNextRun")]
        public async Task<ActionResult<IEnumerable<FinalAuditNextRun>>> ExecuteEndLineQCAuditOQLNextRun(string Floor, string ProdLineNo)
        {
            var parameterFloor = new SqlParameter
            {
                ParameterName = "pFloor",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Value = Floor,
            };

            var parameterProdLineNo = new SqlParameter
            {
                ParameterName = "pProdLineNo",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Value = ProdLineNo,
            };

            return await _context.FinalAuditNextRun.FromSqlRaw("exec dbo.sp_TrafficLight_NextRun_LineWise @pFloor,@pProdLineNo ", parameterFloor, parameterProdLineNo).ToListAsync();

        }

        [HttpGet("GetEndLineQCAuditOQLStatus")]
        public async Task<ActionResult<IEnumerable<vw_EndLineQC_Audit_Status_For_Traffic_Lights>>> vw_EndLineQC_Audit_Status_For_Traffic_Lights(string Floor, string ProdLineNo)
        {
            var ViewEndLineQCAuditOQLDetail = await _context.vw_EndLineQC_Audit_Status_For_Traffic_Lights.Where(a => a.Floor == Floor && a.ProdLineNo == ProdLineNo).ToListAsync();

            if (ViewEndLineQCAuditOQLDetail == null)
            {
                return NotFound();
            }

            return ViewEndLineQCAuditOQLDetail;

        }



    }
}

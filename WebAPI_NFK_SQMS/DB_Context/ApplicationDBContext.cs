using DataAccessLayer.Models;
using DataAccessLayer.Models.MasterInfo;
using DataAccessLayer.Models.Transactions;
using DataAccessLayer.Models.Sql_Functions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebAPI_NFK_SQMS.DB_Context
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
            : base(options)
        {
                
        }

        public DbQuery<vw_OS_FinalCheck_Pcs> vw_OS_FinalCheck_Pcs { get; set; }
        public DbQuery<ViewCuttingDetail> View_CuttingDetail { get; set; }
        public DbQuery<vw_tblSQMS_Master_Line_Info> vw_tblSQMS_Master_Line_Info { get; set; }

        public DbQuery<vw_QC_Active_Round_Info> vw_QC_Active_Round_Info { get; set; }

        public DbQuery<vw_BundleDetail> vw_BundleDetail { get; set; }

        public DbQuery<vw_StyleLayout> vw_StyleLayout { get; set; }

        public DbQuery<vw_Style_Master_with_layout> vw_Style_Master_with_layout { get; set; }
        public DbQuery<vw_Offline_for_FinalAudit> vw_Offline_for_FinalAudit { get; set; }
        
        public DbSet<tblSQMS_Master_AQL_Lot_Size> tblSQMS_Master_AQL_Lot_Size { get; set; }
        public DbSet<tblSQMS_FinalCheck_Info> tblSQMS_FinalCheck_Info { get; set; }
        public DbSet<tblSQMS_FinalCheck_Defects> tblSQMS_FinalCheck_Defects { get; set; }
        public DbSet<tblSQMS_FinalAudit_Info> tblSQMS_FinalAudit_Info { get; set; }
        public DbSet<tblSQMS_FinalAudit_Defects> tblSQMS_FinalAudit_Defects { get; set; }
        public DbSet<tblSQMS_FinalAudit_Defect_Images> tblSQMS_FinalAudit_Defect_Images { get; set; }

        public DbSet<tblSQMS_Master_Machine_Opts> tblSQMS_Master_Machine_Opts { get; set; }

        public DbSet<tblSQMS_Master_Operation> tblSQMS_Master_Operation { get; set; }

        public DbSet<tblSQMS_Master_Faults> tblSQMS_Master_Faults { get; set; }

        public DbSet<tblSQMS_Master_QC> tblSQMS_Master_QC { get; set; }

        public DbSet<tblSQMS_Master_Locations> tblSQMS_Master_Locations { get; set; }

        public DbSet<tblSQMS_Master_Floor> tblSQMS_Master_Floor { get; set; }

        public DbSet<tblSQMS_Master_LineNo> tblSQMS_Master_LineNo { get; set; }

        public DbSet<tblSQMS_Master_Line_Info> tblSQMS_Master_Line_Info { get; set; }
        public DbSet<tblSQMS_Master_Rounds> tblSQMS_Master_Rounds { get; set; }

        public DbSet<tblSQMS_Master_Init_Faults> tblSQMS_Master_Init_Faults { get; set; }
        public DbSet<tblSQMS_Fault_Gen_Categ> tblSQMS_Fault_Gen_Categ { get; set; }

        public DbSet<tblSQMS_InLine_Defects> tblSQMS_InLine_Defects { get; set; }

        public DbSet<tblSQMS_EndLine_Bundle_Cards> tblSQMS_EndLine_Bundle_Cards { get; set; }

        public DbSet<tblSQMS_Endline_Info> tblSQMS_Endline_Info { get; set; }

        public DbSet<tblSQMS_EndLine_Defects> tblSQMS_EndLine_Defects { get; set; }

        public DbSet<HighChart> HighChart { get; set; }

        public DbSet<rptDefectAnalysis> DefectAnalysis { get; set; }

        public DbSet<rptOperationWiseNoOfFaults> OperationWiseNoOfFaults { get; set; }

        public DbSet<tblSQMS_Master_Style_Layout> tblSQMS_Master_Style_Layout { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}

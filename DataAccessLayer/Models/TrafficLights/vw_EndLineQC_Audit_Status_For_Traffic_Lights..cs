using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models.TrafficLights
{
    public class vw_EndLineQC_Audit_Status_For_Traffic_Lights
    {
        public long Id { get; set; }
        public string Floor { get; set; }
        public string ProdLineNo { get; set; }
        public string AuditDuration { get; set; }
        public decimal SelectedPcs { get; set; }
        public decimal TotMajorPcs { get; set; }
        public decimal ActualTotMinorPcs { get; set; }
        public decimal TotalDefectedPcs { get; set; }
        public decimal OQL_Per { get; set; }

    }
}

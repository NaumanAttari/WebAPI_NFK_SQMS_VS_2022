using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
   public class vw_tblSQMS_Master_Line_Info 
   {
        public long Id { get; set; }

        public string Floors { get; set; }

        public string ProdLineNo { get; set; }

        public string Operation { get; set; }

        public string CardNo { get; set; }

        public string OperatorName { get; set; }

        public string MachineNo { get; set; }

        public string Shifts { get; set; }

        public string Status { get; set; }
      

    }
}

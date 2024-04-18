using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models.MasterInfo
{
    public class tblSQMS_Master_Audits
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public string Audits { get; set; }

        
    }
}

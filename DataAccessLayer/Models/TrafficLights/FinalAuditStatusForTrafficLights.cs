using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models.TrafficLights
{
    public class FinalAuditStatusForTrafficLights
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int NoOfFail { get; set; }
        public int NoOfPass { get; set; }
        public string AuditStatus { get; set; }

    }
}

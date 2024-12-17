﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models.Transactions
{
    public class tblSQMS_Audit_Measurement_Images
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public long MasterId { get; set; }
        public string MeasurementImageLink { get; set; }

    }
}

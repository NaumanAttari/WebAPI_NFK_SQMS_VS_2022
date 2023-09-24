using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccessLayer.Models.MasterInfo
{
    public class tblSQMS_Master_Machine_Opts

    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string CardNo { get; set; }

        public string OperatorName { get; set; }

        public string Machine { get; set; }

        public string OperationName { get; set; }


    }
}

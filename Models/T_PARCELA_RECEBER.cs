using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwBoleto.Models
{
    [Table("T_PARCELA_RECEBER")]
    public class T_PARCELA_RECEBER
    {
        public string CL_COD { get; set; }
        public string CR_COD { get; set; }
        public DateTime PR_DAT_VEN {  get; set; }
        public DateTime PR_DAT_PRE { get; set; }
        public Decimal PR_VALOR_PARC { get; set; }
        public string FP_COD { get; set; }
        public Decimal? PR_VALOR_DES { get; set; }
        public Decimal? PR_VALOR_DEV { get; set; }
        public Decimal? PR_VALOR_MUL { get; set; }
        public Decimal? PR_VALOR_OUT { get; set; }
        public string PR_OBS { get; set; }

    }
}

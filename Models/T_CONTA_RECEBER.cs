using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwBoleto.Models
{
    [Table("T_CONTA_RECEBER")]
    public class T_CONTA_RECEBER
    {
        public string CL_COD { get; set; }
        public string CR_COD { get; set; }
        public DateTime CR_DAT_CAD { get; set; }
        public string CR_CONTABIL{ get; set; }
        public string CR_HISTORICO { get; set; }
        public string CG_COD { get; set; }
        public Decimal CR_VALOR_CON { get; set; }
        public string CP_COD_PAGTO { get; set; }
        public string CR_FISCAL { get; set; }
    }
}

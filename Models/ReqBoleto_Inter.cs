
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwBoleto.Models
{
    class ReqBoleto_Inter
    {
        public string seuNumero { get; set; }
        public string valorNominal { get; set; }
        public string dataVencimento { get; set; }
        public string numDiasAgenda { get; set; }
        public Pagador pagador { get; set; }
        public Multa multa { get; set; }
        public Mora mora { get; set; }
        


        public class Pagador
        {
            public string cpfCnpj { get; set; }
            public string tipoPessoa { get; set; }
            public string nome { get; set; }
            public string endereco { get; set; }
            public string cidade { get; set; }
            public string uf { get; set; }
            public string cep { get; set; }
            public string email { get; set; }            
            public string numero { get; set; }
            public string complemento { get; set; }
            public string bairro { get; set; }
        }

        public class Multa
        {
            public string codigo { get; set; }
            public string taxa { get; set; }
        }

        public class Mora
        {
            public string codigo { get; set; }
            public string taxa { get; set; }
        }

        
    }
}

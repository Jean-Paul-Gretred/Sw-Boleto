using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwBoleto.Models
{
    internal class ReqBoleto
    {

        
            public int numeroConvenio { get; set; }
        //public int numeroCarteira { get; set; }
        //public int numeroVariacaoCarteira { get; set; }

        public string dataVencimento { get; set; }
            public Decimal? valorOriginal { get; set; }
            
            public int quantidadeDiasProtesto { get; set; }         
            
           public string? numeroTituloBeneficiario { get; set; }
            public string numeroTituloCliente { get; set; }
            
            
            public Jurosmora jurosMora { get; set; }
            public Multa multa { get; set; }
            public Pagador pagador { get; set; }
            
            public string indicadorPix { get; set; }
        }

        

        public class Jurosmora
        {
            public int? tipo { get; set; }
            public Decimal? porcentagem { get; set; }
            
        }

        public class Multa
        {
            public int? tipo { get; set; }
            public string data { get; set; }
            public Decimal? porcentagem { get; set; }
            
        }

        public class Pagador
        {
            public int tipoInscricao { get; set; }
            public long numeroInscricao { get; set; }
            public string nome { get; set; }
            public string endereco { get; set; }
            public int cep { get; set; }
            public string cidade { get; set; }
            public string bairro { get; set; }
            public string uf { get; set; }
            
        }

        

    
}

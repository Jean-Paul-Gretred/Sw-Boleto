using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SwBoleto
{
    public class ConexaoSQL
    {
        SqlConnection con = new SqlConnection();
        static public string gsServidorBD = "";
        static public string gsNomeBD = "";
        static public string gsUsuarioBD = "";
        static public string gsSenhaBD = "";
        static public string stringCon;

        public ConexaoSQL()
        {
            gsServidorBD = Properties.Settings.Default.Servidor_BD;
            gsNomeBD = Properties.Settings.Default.Nome_BD_PRODUÇÃO;
            gsUsuarioBD = Properties.Settings.Default.Usuario_BD;
            gsSenhaBD = Properties.Settings.Default.Senha_BD;
            stringCon = "server=" + gsServidorBD + "; Database=" + gsNomeBD + "; User ID=" + gsUsuarioBD + "; pwd=" + gsSenhaBD + "; Encrypt=False";
            con.ConnectionString = stringCon;
        }
        public SqlConnection conectar()
        {
            try
            {

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                return con;
            }
            catch (Exception ex) { return null; }
        }
        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}

using Microsoft.Data.SqlClient;
using SwBoleto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwBoleto
{
    public class SwUtil
    {
        public static string LerPS(string sPS_COD)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            string sSql;

            ConexaoSQL SqlCon = new ConexaoSQL();

            string sRetorno = "";
            // Pegar PS_VALOR na tabela T_PARAMENTROS DO SISTEMA
            ////////////////////////////////////////////////////////////////
            sSql = "SELECT PS_VALOR = ISNULL(PS_VALOR,'')"
                 + " FROM T_PARAMETROS_SISTEMA"
                 + $" WHERE PS_COD = '{sPS_COD}'";
            cmd.CommandText = sSql;
            cmd.Connection = SqlCon.conectar();
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                sRetorno = (string)dr[0];
            }
            dr.Close();
            SqlCon.desconectar();

            return sRetorno;
            ////////////////////////////////////////////////////////////////
        }
        public static void InserirBoleto(T_BOLETO_PR boleto)
        {
            ConexaoSQL SqlCon = new ConexaoSQL();
            using (var connection = SqlCon.conectar())
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Open();
                try
                {
                    if (boleto.BO_NUM_TITULO_CLIENTE != null)
                    {

                        string query = "IF EXISTS (SELECT 1 FROM T_BOLETO_PR WHERE BO_NUM_TITULO_CLIENTE = @BO_NUM_TITULO_CLIENTE) UPDATE T_BOLETO_PR  SET CL_COD = @CL_COD,  CR_COD = @CR_COD,   PR_DAT_VEN = @PR_DAT_VEN,   CC_NUMERO = @CC_NUMERO,    PR_VALOR_PARC = @PR_VALOR_PARC,   BO_STATUS = @BO_STATUS,  BO_DAT_HORA = @BO_DAT_HORA WHERE BO_NUM_TITULO_CLIENTE = @BO_NUM_TITULO_CLIENTE ELSE   INSERT INTO T_BOLETO_PR (CL_COD, CR_COD, PR_DAT_VEN, CC_NUMERO, PR_VALOR_PARC, BO_NUM_TITULO_CLIENTE, BO_STATUS, BO_DAT_HORA, BO_COD_SOLICITAÇÃO)  VALUES (@CL_COD, @CR_COD, @PR_DAT_VEN, @CC_NUMERO, @PR_VALOR_PARC, @BO_NUM_TITULO_CLIENTE, @BO_STATUS, @BO_DAT_HORA, @BO_COD_SOLICITAÇÃO)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CL_COD", boleto.CL_COD);
                            command.Parameters.AddWithValue("@CR_COD", boleto.CR_COD);
                            command.Parameters.AddWithValue("@PR_DAT_VEN", boleto.PR_DAT_VEN);
                            command.Parameters.AddWithValue("@CC_NUMERO", boleto.CC_NUMERO);
                            command.Parameters.AddWithValue("@PR_VALOR_PARC", boleto.PR_VALOR_PARC);
                            command.Parameters.AddWithValue("@BO_NUM_TITULO_CLIENTE", boleto.BO_NUM_TITULO_CLIENTE);
                            command.Parameters.AddWithValue("@BO_STATUS", boleto.BO_STATUS);
                            command.Parameters.AddWithValue("@BO_DAT_HORA", boleto.BO_DAT_HORA);
                            command.Parameters.AddWithValue("@BO_COD_SOLICITAÇÃO", boleto.BO_COD_SOLICITAÇÃO ?? string.Empty);
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string query = "IF EXISTS (SELECT 1 FROM T_BOLETO_PR WHERE BO_COD_SOLICITAÇÃO = @BO_COD_SOLICITAÇÃO) UPDATE T_BOLETO_PR  SET CL_COD = @CL_COD,  CR_COD = @CR_COD,   PR_DAT_VEN = @PR_DAT_VEN,   CC_NUMERO = @CC_NUMERO,    PR_VALOR_PARC = @PR_VALOR_PARC,   BO_STATUS = @BO_STATUS,  BO_DAT_HORA = @BO_DAT_HORA WHERE BO_COD_SOLICITAÇÃO = @BO_COD_SOLICITAÇÃO ELSE   INSERT INTO T_BOLETO_PR (CL_COD, CR_COD, PR_DAT_VEN, CC_NUMERO, PR_VALOR_PARC, BO_NUM_TITULO_CLIENTE, BO_STATUS, BO_DAT_HORA, BO_COD_SOLICITAÇÃO)  VALUES (@CL_COD, @CR_COD, @PR_DAT_VEN, @CC_NUMERO, @PR_VALOR_PARC, @BO_NUM_TITULO_CLIENTE, @BO_STATUS, @BO_DAT_HORA, @BO_COD_SOLICITAÇÃO)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CL_COD", boleto.CL_COD);
                            command.Parameters.AddWithValue("@CR_COD", boleto.CR_COD);
                            command.Parameters.AddWithValue("@PR_DAT_VEN", boleto.PR_DAT_VEN);
                            command.Parameters.AddWithValue("@CC_NUMERO", boleto.CC_NUMERO);
                            command.Parameters.AddWithValue("@PR_VALOR_PARC", boleto.PR_VALOR_PARC);
                            command.Parameters.AddWithValue("@BO_NUM_TITULO_CLIENTE", boleto.BO_NUM_TITULO_CLIENTE ?? string.Empty);
                            command.Parameters.AddWithValue("@BO_STATUS", boleto.BO_STATUS);
                            command.Parameters.AddWithValue("@BO_DAT_HORA", boleto.BO_DAT_HORA);
                            command.Parameters.AddWithValue("@BO_COD_SOLICITAÇÃO", boleto.BO_COD_SOLICITAÇÃO);
                            command.ExecuteNonQuery();
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                }
            }
        }



        public static string LerSql(string sSql)
        {
            string sRet = "";

            ConexaoSQL SqlCon = new ConexaoSQL();

            using (var connection = SqlCon.conectar())
            {
                connection.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sSql;

                    var dr = cmd.ExecuteReader();

                    dr.Read();
                    if (dr.HasRows)
                    {
                        if (dr.IsDBNull(0))
                        {
                            sRet = " ";
                        }
                        else if (dr.GetFieldType(0).ToString() == "System.Int32")
                        {
                            sRet = dr.GetInt32(0).ToString();
                        }
                        else if (dr.GetFieldType(0).ToString() == "System.DateTime")
                        {
                            sRet = dr.GetDateTime(0).ToString();
                        }
                        else if (dr.GetFieldType(0).ToString() == "System.Decimal")
                        {
                            sRet = dr.GetDecimal(0).ToString();
                        }
                        else
                        {
                            sRet = dr.GetString(0).ToString();
                        }
                    }
                    dr.Close();

                }
                connection.Close();
            }
            return sRet;
        }

        public static bool PermitirAcesso(string pr_nome, string us_nome)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            string sSql;
            string Retorno = "";

            //---- INSERIR NA TABELA T_PROGRAMA
            sSql = $"IF NOT EXISTS(SELECT PR_NOME FROM T_PROGRAMA WHERE PR_NOME = '{pr_nome}')"
                 + $"   INSERT T_PROGRAMA VALUES('{pr_nome}', '');"
                 + $"SELECT RETORNO = dbo.fn_PermitirAcesso('{pr_nome}','{us_nome}')";
            cmd.CommandText = sSql;
            cmd.Connection = Program.SqlConnection;
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                Retorno = (string)dr[0];
            }
            dr.Close();

            if (Retorno == "S")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

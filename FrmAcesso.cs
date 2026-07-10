using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace SwBoleto
{
    public partial class FrmAcesso : Form
    {

        //private SqlConnection sqlConn = new SqlConnection(Program.gsStringConexao);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        string sSql;
        bool blnValidar = true;
        bool blnVoltar = false;

        string sUS_NOME = ""
              , sUS_SENHA = "";

        int iSenhaInvalida = 0;

        public FrmAcesso()
        {
            InitializeComponent();
        }

        private void FrmMotivoCancelamentoNFe_Load(object sender, EventArgs e)
        {


        }

        private void txtUS_NOME_Leave(object sender, EventArgs e)
        {
            if (txtUS_NOME.Text != "")
            {
                sUS_NOME = txtUS_NOME.Text;
            }

        }

        private void txtUS_NOME_Validating(object sender, CancelEventArgs e)
        {
            if (!blnValidar)
            {
                return;
            }

            if (txtUS_NOME.Text == "")
            {
                MessageBox.Show("Dado Obrigatório");
                e.Cancel = true;
            }
            else
            {

                ////////////////////////////////////////////////////////////////
                sSql = "SELECT US_NOME, US_SENHA = ISNULL(US_SENHA,'')";
                sSql += " FROM V_USUARIO"; // MLUCIO 21 12 2022
                sSql += " WHERE US_NOME = '" + txtUS_NOME.Text + "'";
                cmd.CommandText = sSql;
                cmd.Connection = Program.SqlConnection;
                dr = cmd.ExecuteReader();
                dr.Read();
                txtUS_SENHA.Text = "";
                if (dr.HasRows)
                {
                    txtUS_NOME.Text = (string)dr[0]; // Para ficar igual ao banco de dados se entrar com Maisculo ou minusculo
                    sUS_SENHA = (string)dr[1];
                }
                else
                {
                    MessageBox.Show("Usuario não Cadastrado");

                    e.Cancel = true;
                }
                dr.Close();
                ////////////////////////////////////////////////////////////////

            }
        }

        private void ENTER_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                blnVoltar = true;
            }
            else
            {
                blnVoltar = false;
            }


            if (e.KeyCode == Keys.Enter) //SendKeys.Send("{TAB}");
            {
                SendKeys.Send((e.Shift ? "+" : "") + "{TAB}");
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.F1)
            {
                btnHelp_Click(sender, e);
                e.SuppressKeyPress = true;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Program.gsUsuario = txtUS_NOME.Text;

            this.Close();
            this.Dispose();

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (txtUS_NOME.Text != "")
            {
                blnValidar = false;
                txtUS_NOME.Text = "";
                txtUS_SENHA.Text = "";
                txtUS_NOME.Focus();
                blnValidar = true;
            }
            else
            {
                this.Close();
                this.Dispose();
            }
        }

        private void txtUS_SENHA_Validating(object sender, CancelEventArgs e)
        {
            if (blnVoltar && txtUS_SENHA.Text == "")
            {
                blnVoltar = false;
                return;
            }

            if (!blnValidar)
            {
                return;
            }

            if (txtUS_SENHA.Text == "")
            {
                MessageBox.Show("Dado Obrigatório");
                e.Cancel = true;
            }
            else
            {
                if (txtUS_SENHA.Text != sUS_SENHA)
                {
                    MessageBox.Show("Senha Inválida");
                    iSenhaInvalida += 1;
                    if (iSenhaInvalida >= 3)
                    {
                        //System.Threading.Thread.CurrentThread.Abort();
                        Application.Exit();
                    }
                    txtUS_SENHA.Text = "";
                    e.Cancel = true;
                }
            }
        }


        private void btnHelp_Click(object sender, EventArgs e)
        {
            txtUS_NOME.Text = "";
            txtUS_SENHA.Text = "";
            ////////////////////////////////////////////////////////////////
            sSql = "SELECT US_NOME"
                 + " FROM V_USUARIO" // MLUCIO 21 12 2022
                 + " ORDER BY US_NOME"; // MLUCIO 10 01 2023
            cmd.CommandText = sSql;
            cmd.Connection = Program.SqlConnection;
            dr = cmd.ExecuteReader();

            FrmMostraGrid fmg = new FrmMostraGrid();

            fmg.MostraGrid(dr);
            fmg.Width = 250;
            fmg.dataGridView1.RowHeadersWidth = 20;
            fmg.dataGridView1.Columns[0].Width = 200;
            fmg.ShowDialog();
            dr.Close();
            txtUS_NOME.Text = fmg.sDadoSel;
            txtUS_NOME.Focus();
            ///////////////////////////////////////////////////////////////

        }

        private void ESCAPE_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            blnValidar = true;
            if (e.KeyCode == Keys.Escape)
            {
                blnValidar = false;
            }
        }

        private void FrmAcesso_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.gsUsuario == "")
            {
                Application.Exit();
            }
        }

        private void btnSairFrm_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}

using SwBoleto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SwBoleto
{
    public partial class FrmSitBoletos : Form
    {
        public FrmSitBoletos()
        {
            InitializeComponent();
            List<string> opcoes = new List<string> { "Em Aberto", "Baixados" };

            cbx_situacao.Items.AddRange(opcoes.ToArray());
            cbx_situacao.SelectedIndex = 0;
        }

        private async void btn_pesquisar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            if (txt_data_ini == null || txt_data_ini.Text == "" || txt_data_ini.Text == " ")
            {
                MessageBox.Show("Preencha a data de inicio");
            }
            else if (txt_data_fim == null || txt_data_fim.Text == "" || txt_data_fim.Text == " ")
            {
                MessageBox.Show("Preencha a data de fim");
            }
            else
            {
                string dat_ini = txt_data_ini.Text.Replace("/", ".");
                string dat_fim = txt_data_fim.Text.Replace("/", ".");
                Token token = new Token();
                token = await API.BoletoAPIBB.GerarToken();
                //RespListBoleto respListBoleto = await API.BoletoAPI.ConsultarListaBoleto(dat_ini, dat_fim, cbx_situacao.Text, token);

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 15);
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;
                dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 15);
                //dataGridView1.DataSource = respListBoleto.boletos;

            }
        }
    }

}

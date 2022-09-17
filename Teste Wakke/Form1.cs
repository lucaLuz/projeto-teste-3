using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Teste_Wakke.Models;

namespace Teste_Wakke
{
    public partial class frm_inicio : Form
    {

        public frm_inicio()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(cl_id);
            Banco.Delete(codigo);
        }

        private void btn_cadastro_Click(object sender, EventArgs e)
        {
            frm_cadastro cadastro = new frm_cadastro();
            cadastro.ShowDialog();
        }
        private void Lbl_titulo_Click(object sender, EventArgs e)
        {

        }


        /*rivate void dt_formulario_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
             RowIndex >= 0 && !dt_formulario.Rows[e.RowIndex].IsNewRow)
               {
                   Usuario usuario = new Usuario();
                   DataGridViewRow row = this.dt_formulario.Rows[e.RowIndex];

                   usuario.Txdcid = row.Cells[0].Value.GetHashCode();
                   usuario.Rbativo = row.Cells[2].Value.Equals();
                   usuario.Txtnome = row.Cells[2].Value.ToString();
                   usuario.Txtsobrenome = row.Cells[3].Value.ToString();
                   usuario.Txtdata = row.Cells[4].Value.ToString();
                   usuario.Txtaltura = row.Cells[5].Value.ToString();


                   if (usuario.ShowDialog() == DialogResult.OK)
                   {
                       EditRow(e.RowIndex, usuario.Txdcid, usuario.Rbativo, usuario.Txtnome, usuario.Txtsobrenome, usuario.Txtdata, usuario.Txtaltura);
                   }
         }
         }*/

        private void btn_editar_Click(object sender, EventArgs e)
        {
            frm_cadastro cadastro = new frm_cadastro();
            cadastro.ShowDialog();
        }

        private void dt_formulario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dt_formulario.Rows[e.RowIndex].IsNewRow)
            {
                Usuario usuario = new Usuario();
                DataGridViewRow row = this.dt_formulario.Rows[e.RowIndex];

                usuario.Rbativo = Convert.ToString(row.Cells[1]);
                usuario.Txtnome = row.Cells[2].Value.ToString();
                usuario.Txtsobrenome = row.Cells[3].Value.ToString();
                usuario.Txtdata = Convert.ToString(row.Cells[4]);
                usuario.Txtaltura = Convert.ToString(row.Cells[5]);
            }
        }
    }
}

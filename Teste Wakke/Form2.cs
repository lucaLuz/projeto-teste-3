using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teste_Wakke.Models;

namespace Teste_Wakke
{
    public partial class frm_cadastro : Form
    {

        public frm_cadastro()
        {
            InitializeComponent();
        }
            
        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_cnome_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_salvar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Rbativo = rb_inativo.Text;
            usuario.Rbativo = rb_ativo.Text;
            usuario.Txtnome = Txt_nome.Text;
            usuario.Txtsobrenome = Txt_sobrenome.Text;
            usuario.Txtdata = txd_cdata.Text;
            usuario.Txtaltura = Txt_altura.Text;
            Banco.Add(usuario);
            this.Close();
        }

        private void Frm_cadastro_Load(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            rb_inativo.Text = usuario.Rbativo;
            rb_ativo.Text = usuario.Rbativo;
            Txt_nome.Text = usuario.Txtnome;
            Txt_sobrenome.Text = usuario.Txtsobrenome;
            txd_cdata.Text = usuario.Txtdata;
            Txt_altura.Text = usuario.Txtaltura;

        }

        private void Txd_cid_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void Txt_nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txd_cdata_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Txt_sobrenome_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_altura_TextChanged(object sender, EventArgs e)
        {

        }

        private void Rb_ativo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Rb_inativo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

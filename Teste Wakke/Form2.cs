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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Teste_Wakke
{
    public partial class frm_cadastro : Form
    {
        public virtual int RowIndex { get; }
        public string Txdcid { get; set; }
        public bool Rbativo { get; set; }
        public string Txtnome { get; set; }
        public string Txtsobrenome { get; set; }
        public string Txtdata { get; set; }
        public string Txtaltura{ get; set; }

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

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            this.Txdcid = txd_cid.Text;
            this.Rbativo = rb_inativo.Checked;
            this.Rbativo = rb_ativo.Checked;
            this.Txtnome = Txt_nome.Text;
            this.Txtsobrenome = Txt_sobrenome.Text;
            this.Txtdata = txd_cdata.Text;
            this.Txtaltura = Txt_altura.Text;
            this.DialogResult = DialogResult.OK;


            this.Close();
        }

        private void frm_cadastro_Load(object sender, EventArgs e)
        {
            txd_cid.Text = this.Txdcid;
            rb_inativo.Checked = this.Rbativo;
            rb_ativo.Checked = this.Rbativo;
            Txt_nome.Text = this.Txtnome;
            Txt_sobrenome.Text = this.Txtsobrenome;
            txd_cdata.Text = this.Txtdata;
            Txt_altura.Text = this.Txtaltura;
           
        }

        private void txd_cid_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void Txt_nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txd_cdata_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Txt_sobrenome_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_altura_TextChanged(object sender, EventArgs e)
        {

        }

        private void rb_ativo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rb_inativo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

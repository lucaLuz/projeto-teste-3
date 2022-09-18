using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Teste_Wakke.Models
{
    public class Banco
    {
        string path = "BancoWakke.db";
        string cs = @"URI=file:" + Application.StartupPath + "\\BancoWakke.db"; 

        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;

        public void data_show(frm_inicio inicio)
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM usuario";
            var cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();

           /* while (dr.Read())
            {
                dataGridView1.Rows.Insert(0, dr.GetString(0), dr.GetString(1));
            }*/
        }

        public void Create_db()
        {
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
                {
                    sqlite.Open();
                    string sql = "CREATE TABLE IF NOT EXISTS usuario (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, ativo BOOLEAN NOT NULL CHECK (true || false), nome STRING NOT NULL, sobrenome STRING NOT NULL, \"data de nascimento\" DATETIME NOT NULL, altura DECIMAL NOT NULL))";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                Console.WriteLine("Database cannot create");
                return;
            }
        }

        public void Add()
        {
            var con = new SQLiteConnection(cs);
            con.Open();
            var cmd = new SQLiteCommand(con);

            try
            {
                cmd.CommandText = "INSERT INTO usuario(ID, ativo, nome, sobrenome, data de nascimento, altura) values (@ID, @ativo, @nome, @sobrenome, @data de nascimento)";

                frm_cadastro cadastro = new frm_cadastro();

                /*string NAME = name_txt.Text;
                string ID = usuario.id_txt.Text;

                cmd.Parameters.AddWithValue("@name", NAME);
                cmd.Parameters.AddWithValue("@id", ID);*/
                cmd.Parameters.AddWithValue("@ID", cadastro.Txdcid);
                cmd.Parameters.AddWithValue("@ativo", cadastro.Rbativo);
                cmd.Parameters.AddWithValue("@nome", cadastro.Txtnome);
                cmd.Parameters.AddWithValue("@sobrenome", cadastro.Txtsobrenome);
                cmd.Parameters.AddWithValue("@data de nascimento", cadastro.Txtdata);
                cmd.Parameters.AddWithValue("@altura", cadastro.Txtaltura);

               /* dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].Name = "Name";
                dataGridView1.Columns[1].Name = "Id";
                string[] row = new string[] { NAME, ID };
                dataGridView1.Rows.Add(row);*/

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                Console.WriteLine("Cadastro concluido");
                return;
            }

        }

        public void Update()
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            var cmd = new SQLiteCommand(con);

            try
            {
                frm_cadastro cadastro = new frm_cadastro();

                cmd.CommandText = "UPDATE usuario SET ativo=@ativo, nome=@nome, sobrenome=@sobrenome, data de nascimento=@data de nascimento, altura=@altura WHERE ID =@ID";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ID", cadastro.Txdcid);
                cmd.Parameters.AddWithValue("@ativo", cadastro.Rbativo);
                cmd.Parameters.AddWithValue("@nome", cadastro.Txtnome);
                cmd.Parameters.AddWithValue("@sobrenome", cadastro.Txtsobrenome);
                cmd.Parameters.AddWithValue("@data de nascimento", cadastro.Txtdata);
                cmd.Parameters.AddWithValue("@altura", cadastro.Txtaltura);

                cmd.ExecuteNonQuery();
                /*dataGridView1.Rows.Clear();
                data_show();*/

            }
            catch (Exception)
            {
                Console.WriteLine("Atualização concluida");
                return;
            }
        }


        private void delete_btn_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            var cmd = new SQLiteCommand(con);
            frm_cadastro cadastro = new frm_cadastro();

            try
            {
                cmd.CommandText = "DELETE usuario FROM ID=ID, ativo=@ativo, nome=@nome, sobrenome=@sobrenome, data de nascimento=@data de nascimento, altura=@altura";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ID", cadastro.Txdcid);
                cmd.Parameters.AddWithValue("@ativo", cadastro.Rbativo);
                cmd.Parameters.AddWithValue("@nome", cadastro.Txtnome);
                cmd.Parameters.AddWithValue("@sobrenome", cadastro.Txtsobrenome);
                cmd.Parameters.AddWithValue("@data de nascimento", cadastro.Txtdata);
                cmd.Parameters.AddWithValue("@altura", cadastro.Txtaltura);
                cmd.ExecuteNonQuery();
               /*
                dataGridView1.Rows.Clear();
                data_show();*/
            }
            catch (Exception)
            {
                Console.WriteLine("Exluido");
                return;
            }
        }

    }
}

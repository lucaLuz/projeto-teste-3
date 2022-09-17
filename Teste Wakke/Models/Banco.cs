using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Wakke.Models
{
    public class Banco
    {

        private static SQLiteConnection sqliteConnection;

        public Banco()
        { }

        private static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=c:\\BancoWakke.db; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public static void CriarBancoSQLite()
        {
            try
            {
                SQLiteConnection.CreateFile(@"c:\BancoWakke.db");
            }
            catch
            {
                throw;
            }
        }

        public static DataTable GetUsuarios()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM usuario";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Add(Usuario usuario)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO usuario(ID, ativo, nome, sobrenome, data de nascimento, altura) values (@ID, @ativo, @nome, @sobrenome, @data de nascimento)";
                    cmd.Parameters.AddWithValue("@ID", usuario.Txdcid);
                    cmd.Parameters.AddWithValue("@ativo", usuario.Rbativo);
                    cmd.Parameters.AddWithValue("@nome", usuario.Txtnome);
                    cmd.Parameters.AddWithValue("@sobrenome", usuario.Txtsobrenome);
                    cmd.Parameters.AddWithValue("@data de nascimento", usuario.Txtdata);
                    cmd.Parameters.AddWithValue("@altura", usuario.Txtaltura);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Update(Usuario usuario)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "UPDATE usuario SET ativo=@ativo, nome=@nome, sobrenome=@sobrenome, data de nascimento=@data de nascimento, altura=@altura WHERE ID=@ID";
                    cmd.Parameters.AddWithValue("@ID", usuario.Txdcid);
                    cmd.Parameters.AddWithValue("@ativo", usuario.Rbativo);
                    cmd.Parameters.AddWithValue("@nome", usuario.Txtnome);
                    cmd.Parameters.AddWithValue("@sobrenome", usuario.Txtsobrenome);
                    cmd.Parameters.AddWithValue("@data", usuario.Txtdata);
                    cmd.Parameters.AddWithValue("@altura", usuario.Txtaltura);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Delete(Usuario usuario)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "DELETE usuario SET ID=ID, ativo=@ativo, nome=@nome, sobrenome=@sobrenome, data de nascimento=@data de nascimento, altura=@altura";
                    cmd.Parameters.AddWithValue("@ID", usuario.Txdcid);
                    cmd.Parameters.AddWithValue("@ativo", usuario.Rbativo);
                    cmd.Parameters.AddWithValue("@nome", usuario.Txtnome);
                    cmd.Parameters.AddWithValue("@sobrenome", usuario.Txtsobrenome);
                    cmd.Parameters.AddWithValue("@data", usuario.Txtdata);
                    cmd.Parameters.AddWithValue("@altura", usuario.Txtaltura);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

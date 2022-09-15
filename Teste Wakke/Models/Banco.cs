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
            sqliteConnection = new SQLiteConnection("Data Source=c:\\dados\\BancoWakke.db; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public static void CriarBancoSQLite()
        {
            try
            {
                SQLiteConnection.CreateFile(@"c:\dados\BancoWakke.db");
            }
            catch
            {
                throw;
            }
        }

        public static void CriarTabelaSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS usuario(id int, Nome Varchar(50), email VarChar(80))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                    cmd.CommandText = "INSERT INTO usuario(id, Nome, email ) values (@id, @nome, @email)";
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

        public static void Update(Usuario usuario)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "UPDATE usuario SET Nome=@Nome, Email=@Email WHERE Id=@Id";
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
                    cmd.CommandText = "DELETE usuario SET Nome=@Nome, Email=@Email WHERE Id=@Id";
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

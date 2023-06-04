using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola_SQL_coneccion
{
    internal class MetodosCRUD
    {
        private int opcion;

        public int Opcion { get; set; }

        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\edwar\source\repos\Consola-SQL-coneccion\Consola-SQL-coneccion\Base de Datos\MyDatos.mdf;Integrated Security=True";
        ClaseConecctionDB conecctionDB = new ClaseConecctionDB(connectionString);
        
        //
        // para crear un registro en la tabla nombres
        public void CrearRegistro(string name)
        {
            SqlConnection connection = conecctionDB.GetConnection();
            connection.Open();
            using (SqlCommand command = new SqlCommand("INSERT INTO MyTable_Nombres (Name) VALUES (@Name)", connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        //
        // para leer lo que contiene la tabla nombres
        public void leerRegistro()
        {
            string name;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM MyTable_Nombres", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            name = reader.GetString(1);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"\t| ID: {id} | Nombre: {name}");
                        }
                    }
                }
                connection.Close ();
            }
        }
        //
        // para cambiar una fila de la tabla
        public void actualizarRegistro(int id, string newName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE MyTable_Nombres SET Name = @NewName WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@NewName", newName);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close() ;
            }
        }
        //
        // para eliminar un nombre de la tabla con el id
        public void eliminarRegisgtro(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM MyTable_Nombres WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close(); 
            }
        }
    }
}

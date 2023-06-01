using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\edwar\source\repos\Consola-SQL-coneccion\Consola-SQL-coneccion\Base de Datos\MyDatos.mdf;Integrated Security=True";

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t---------------------------------\n\t|\tBase de Datos-Consola\t|\n\t---------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Elige una opción:" +
                "\n1. Crear registro" +
                "\n2. Leer registros" +
                "\n3. Actualizar registro" +
                "\n4. Eliminar registro");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("5. Salir\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("►►► ");
            Console.ForegroundColor = ConsoleColor.White;
            string option = Console.ReadLine();

            if (option == "1")//Crear registro
            {
                Console.Write("Ingresa el nombre: ");
                string name = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO MyTable_Nombres (Name) VALUES (@Name)", connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.ExecuteNonQuery();
                    }
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Registro creado.");
            }
            else if (option == "2")// leer los registros
            {
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
                                string name = reader.GetString(1);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"\t| ID: {id} | Nombre: {name}");
                            }
                        }
                    }
                }
            }
            else if (option == "3")// actualizar el registro
            {
                Console.Write("Ingresa el ID del registro a actualizar: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Ingresa el nuevo nombre: ");
                string newName = Console.ReadLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("UPDATE MyTable_Nombres SET Name = @NewName WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@NewName", newName);
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Registro actualizado.");
            }
            else if (option == "4")//eliminar un registro
            {
                Console.Write("Ingresa el ID del registro a eliminar: ");
                int id = int.Parse(Console.ReadLine());

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM MyTable_Nombres WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Registro eliminado.");
            }
            else if (option == "5")// salir del programa
            {
                break;
            }
        }
    }
}
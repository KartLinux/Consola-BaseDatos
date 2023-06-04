using System;
using System.Data;
using Consola_SQL_coneccion;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        MetodosCRUD objetoMetodosCRUD = new MetodosCRUD();
        string name = "null";
        int id = 0;
        while (true)
        {
            try
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
                switch (option)
                {
                    case "1": //para Crear un registro
                        Console.Write("Ingresa el nombre: ");
                        name = Console.ReadLine();
                        // objeto de la clase Metodos CRUD
                        objetoMetodosCRUD.CrearRegistro(name);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Registro creado.");
                        break;
                    case "2": // para listar los registros
                        objetoMetodosCRUD.leerRegistro();
                        break;
                    case "3": //actualizar un registro existente
                        Console.Write("Ingresa el ID del registro a actualizar: ");
                        id = int.Parse(Console.ReadLine());
                        Console.Write("Ingresa el nuevo nombre: ");
                        string newName = Console.ReadLine();
                        objetoMetodosCRUD.actualizarRegistro(id, newName);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Registro actualizado.");
                        break;
                    case "4":// para eliminar un fila del registro con el id
                        Console.Write("Ingresa el ID del registro a eliminar: ");
                        id = int.Parse(Console.ReadLine());
                        objetoMetodosCRUD.eliminarRegisgtro(id);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Registro eliminado.");
                        break;
                    case "5":
                        Console.WriteLine("Presiona cualquier tecla para salir...");
                        Console.ReadKey();
                        return;
                        break;
                }
            }
            catch (Exception ex) 
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
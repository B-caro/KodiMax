using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Data;
using Newtonsoft.Json.Linq;

namespace KodiMax
{
    class Program
    {
        static int pos = 0, count = 0, id = 0;

        static ArrayList UsuariosReg = new ArrayList();
        static ArrayList EmpleadosReg = new ArrayList();
        static ArrayList Peliculas = new ArrayList();
        static ArrayList KodiAlimentos = new ArrayList();

        private static readonly string _pathPeliculas = @"C:\Users\Bucaro\Documents\GitHub\KodiMax\KodiMax\KodiMax\Json\Peliculas.json";
        private static readonly string _pathGolosinas = @"C:\Users\Bucaro\Documents\GitHub\KodiMax\KodiMax\KodiMax\Json\Golsinas.json";
        private static readonly string _pathEmpleados = @"C:\Users\Bucaro\Documents\GitHub\KodiMax\KodiMax\KodiMax\Json\Empleados.json";
        private static readonly string _pathUsuarios = @"C:\Users\Bucaro\Documents\GitHub\KodiMax\KodiMax\KodiMax\Json\Usuarios.json";

        static void Main(string[] args)
        {
            CargarJson();
            Menu_Principal();
            //Pruebas();
            Console.ReadKey();
        }

        static void RegresarMenu()
        {
            int op = 0;
            Console.Write("Desea continuar? (1 - Si / 2 - N0): ");
            op = int.Parse(Console.ReadLine());
            if (op == 1)
            {
                Login();
            }
            else
            {
                Menu_Principal();
            }
        }

        static void Login()
        {
            string user, pass;
            Console.Clear();
            Console.WriteLine("A continuacion ingrese sus datos de inicio de sesion!");
            Console.Write("\n Usuario: ");
            user = Console.ReadLine();
            Console.Write("\n Contraseña: ");
            pass = Console.ReadLine();
            if (UsuariosReg.Count == 0)
            {
                Console.WriteLine("\n El usuario no existe!");
                RegresarMenu();
            }
            else
            {
                for (int i = 0; i < UsuariosReg.Count;)
                {
                    string parse = "";

                    Clases.Usuarios us = new Clases.Usuarios();
                    parse = UsuariosReg[i].ToString();
                    us = JsonConvert.DeserializeObject<Clases.Usuarios>(parse);

                    if (us.NombreUsuario == user)
                    {
                        if (us.Password == pass)
                        {
                            pos = i;
                            Menu_cartelera();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Contraseña incorrecta!");
                            Console.ReadKey();
                            Login();
                        }
                    }
                    else if(us.NombreUsuario != user)
                    {
                        Console.WriteLine("El usuario no existe!");
                    }
                    i++;
                }
            }
        }

        static void Registro()
        {
            string nombres, apellidos, email, usuario, pass, fecha;
            Console.Clear();
            try
            {
                DateTime nacimiento;
                Console.WriteLine("A continuacion debera de proporcionar algunos datos para realizar su registro!");
                Console.Write("\n Nombres: ");
                nombres = Console.ReadLine();
                Console.Write("\n Apellidos: ");
                apellidos = Console.ReadLine();
                Console.Write("\n Correo: ");
                email = Console.ReadLine();
                Console.WriteLine("\n A continuacion agregue su fecha de nacimiento en este formato: '9/7/1999'");
                Console.Write("\n Fecha de nacimiento: ");
                fecha = Console.ReadLine();
                nacimiento = DateTime.Parse(fecha);
                Console.Write("\n Usuario: ");
                usuario = Console.ReadLine();
                Console.Write("\n Contraseña: ");
                pass = Console.ReadLine();
                if (string.IsNullOrEmpty(nombres) && string.IsNullOrEmpty(apellidos) && string.IsNullOrEmpty(email)
                    && string.IsNullOrEmpty(usuario) && string.IsNullOrEmpty(pass) && string.IsNullOrEmpty(fecha))
                {
                    Console.WriteLine("\n Lo sentimos, no ingresaste todos los datos!");
                    Console.ReadKey();
                    Registro();
                }
                else
                {
                    Clases.Usuarios User = new Clases.Usuarios(nombres, apellidos, email, nacimiento, usuario, pass);
                    UsuariosReg.Add(User);
                    EscribirJSon(_pathUsuarios, User);
                    Console.WriteLine("\n Usuario registrado exitosamente, presione una tecla para continuar...");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n Error en el formato de la fecha: " + ex);
                Console.ReadKey();
                Registro();
            }
        }

        static void Menu_Principal()
        {
            int op = 0;
            try
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine("Bienvenidos a KodiMax");
                    Console.Clear();
                    Console.WriteLine("\t    ╔════════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t    ║                       Opciones                         ║");
                    Console.WriteLine("\t    ╠════════════════════════════════════════════════════════╣");
                    Console.WriteLine("\t    ║         1)          Iniciar Sesion                     ║");
                    Console.WriteLine("\t    ║         2)          Registrarse                        ║");
                    Console.WriteLine("\t    ║         3)          Salir                              ║");
                    Console.WriteLine("\t    ╚════════════════════════════════════════════════════════╝\n");
                    Console.Write("\n Seleccione una opcion: ");
                    op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            Login();
                            Console.ReadKey();
                            break;
                        case 2:
                            Registro();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("\t ERROR: NO DISPONEMOS DE MAS OPCIONES");
                            Console.ReadKey();
                            Menu_Principal();
                            break;
                    }
                }
            }
            catch (Exception)
            {
                Menu_Principal();
            }
        }

        static void Menu_cartelera()
        {
            int op = 0;
            Boolean Ext = true;
            while (Ext)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Bienvenidos a KodiMax");
                    Console.Clear();
                    Console.WriteLine("\t    ╔════════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t    ║                       Opciones                         ║");
                    Console.WriteLine("\t    ║                                                        ║");
                    Console.WriteLine("\t    ║         Salas       Peliculas disponibles              ║");
                    Console.WriteLine("\t    ╠════════════════════════════════════════════════════════╣");
                    Console.WriteLine("\t    ║                                                        ║");
                    Console.WriteLine("\t    ║           1      Trabaja con nosotros!                 ║");
                    Console.WriteLine("\t    ║           2      Comprar tus entradas aca!             ║");
                    Console.WriteLine("\t    ║           3      Cartelera                             ║");
                    Console.WriteLine("\t    ║           4      KodiAlimentos                         ║");
                    Console.WriteLine("\t    ║                                                        ║");
                    Console.WriteLine("\t    ╠════════════════════════════════════════════════════════╣");
                    Console.WriteLine("\t    ║                    Otras opciones                      ║");
                    Console.WriteLine("\t    ║                                                        ║");
                    Console.WriteLine("\t    ║           5      Salir                                 ║");
                    Console.WriteLine("\t    ║           6      Administracion                        ║");
                    Console.WriteLine("\t    ╚════════════════════════════════════════════════════════╝");
                    Console.WriteLine("\n");
                    Console.Write("Selecciona una opcion: ");
                    op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            Clases.Usuarios temp = (Clases.Usuarios)UsuariosReg[pos];
                            if (temp.State())
                            {
                                Console.Clear();
                                Console.WriteLine("Buenos dias {0}, tu ya trabajas con nosotros\n\n Tus datos son: \n");
                                temp.ShowData();
                            }
                            else
                            {
                                NuevoEmpleado();
                            }                            
                            break;
                        case 2:

                            break;
                        case 3:
                            MostrarJSon(_pathPeliculas);
                            break;
                        case 4:
                            MostrarJSon(_pathGolosinas);
                            break;
                        case 5:
                            Menu_Principal();
                            break;
                        case 6:
                            MenuAdministracion();
                            break;
                        default:
                            Console.WriteLine("\t ERROR: NO DISPONEMOS DE MAS OPCIONES");
                            Console.ReadKey();
                            Menu_cartelera();
                            break;
                    }
                    Console.ReadKey();
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Ha ocurrido un error: " + Ex.Message);
                    Console.ReadKey();
                    Menu_cartelera();
                }
            }
        }

        static void MenuAdministracion()
        {
            int op = 0;
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Bienvenidos a KodiMax");
                    Console.Clear();
                    Console.WriteLine("\t    ╔════════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t    ║                Opciones administrativas                ║");
                    Console.WriteLine("\t    ╠════════════════════════════════════════════════════════╣");
                    Console.WriteLine("\t    ║                                                        ║");
                    Console.WriteLine("\t    ║           1      Agregar peliculas                     ║");
                    Console.WriteLine("\t    ║           2      Agregar Alimentos/Bebidas             ║");
                    Console.WriteLine("\t    ║           3      Mostrar Peliculas                     ║");
                    Console.WriteLine("\t    ║           4      Mostrar Alimentos/Bebidas             ║");
                    Console.WriteLine("\t    ║           5      Mostrar Empleados                     ║");
                    Console.WriteLine("\t    ║           6      Mostrar Tickets                       ║");
                    Console.WriteLine("\t    ║           7      Mostrar Usuarios                      ║");
                    Console.WriteLine("\t    ║                                                        ║");
                    Console.WriteLine("\t    ╠════════════════════════════════════════════════════════╣");
                    Console.WriteLine("\t    ║                    Otras opciones                      ║");
                    Console.WriteLine("\t    ║                                                        ║");
                    Console.WriteLine("\t    ║           8      Regresar al menu anterior             ║");
                    Console.WriteLine("\t    ╚════════════════════════════════════════════════════════╝");
                    Console.WriteLine("\n");
                    Console.Write("Selecciona una opcion: ");
                    op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            AgregarPeliculas();
                            break;
                        case 2:
                            AgregarGolosinas();
                            break;
                        case 3:
                            MostrarJSon(_pathPeliculas);
                            break;
                        case 4:
                            MostrarJSon(_pathGolosinas);
                            break;
                        case 5:
                            MostrarJSon(_pathEmpleados);
                            break;
                        case 6:
                            MostrarJSon("Tickets");
                            break;
                        case 7:
                            MostrarJSon(_pathEmpleados);
                            break;
                        case 8:
                            Menu_cartelera();
                            break;
                        default:
                            Console.WriteLine("\t ERROR: NO DISPONEMOS DE MAS OPCIONES");
                            Console.ReadKey();
                            Menu_cartelera();
                            break;
                    }
                    Console.ReadKey();
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Ha ocurrido un error: " + Ex.Message);
                    Console.ReadKey();
                    Menu_cartelera();
                }
            }
        }

        private static void MostrarJSon(string path)
        {
            string JsonFile = File.ReadAllText(path);
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(JsonFile, typeof(DataTable));

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                Console.WriteLine("═══════════════════════════════════════════════════");
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    Console.Write(dt.Columns[i].ColumnName + ":                   ");
                    Console.WriteLine(dt.Rows[j].ItemArray[i]);
                }
                Console.WriteLine("═══════════════════════════════════════════════════");
            }
        }

        static void NuevoEmpleado()
        {
            string Dui, Nit, Telefono, Cargo;
            int temp = 0;
            Random random = new Random();
            Clases.Usuarios us = (Clases.Usuarios)UsuariosReg[pos];
            Console.Clear();
            Console.WriteLine("Bienvenido a la ventana de registro {0}, sera un honor trabajar contigo! \n " +
                " A continuacion ingresa los datos solicitados (DUI, NIT y numero de telefono) para aplicar" +
                "a una plaza con nosotros! \n", us.Nombres);
            Console.Write("DUI: ");
            Dui = Console.ReadLine();
            Console.Write("NIT: ");
            Nit = Console.ReadLine();
            Console.Write("Telefono: ");
            Telefono = Console.ReadLine();
            Console.WriteLine("Seleciona el cargo a aplicar: \n 1 - Cajero de Tickets \n 2 - Cajero de tienda de golosinas");
            temp = int.Parse(Console.ReadLine());
            if (temp == 1)
            {
                Cargo = "Cajero de Tickets";
            }
            else
            {
                Cargo = "Cajero de tienda de golosinas";
            }
            temp = random.Next(0, 2);
            if (temp == 1)
            {
                UsuariosReg.RemoveAt(pos);
                Clases.Empleados Emp = new Clases.Empleados(id, us.Nombres, us.Apellidos, us.Email, us.FechaNacimiento, us.NombreUsuario,
                us.Password, Telefono, Dui, Nit, Cargo);
                UsuariosReg.Add(Emp);
                EscribirJSon(_pathEmpleados, Emp);
                Console.WriteLine("Felicidades fuiste contratado! Ahora formas parte de nuestro grandioso equipo!!");
            }
            else
            {
                Console.WriteLine("Lo sentimos, no fuiste seleccionado :( \n Pero puedes intentarlo de nuevo!");
            }
            Console.WriteLine();
        }

        static void AgregarPeliculas()
        {
            int n = 3, id;
            string nombre, duracion, clasificacion;
            ArrayList actores = new ArrayList();

            Console.Clear();

            Console.WriteLine("Para ingresar una nueva pelicula deberas de ingresas los siguentes datos! \n");
            Console.Write("Ingrese el ID de la pelicula: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el nombre de la pelicula: ");
            nombre = Console.ReadLine();
            Console.Write("Ingresa la duracion en minutos de la pelicula: ");
            duracion = Console.ReadLine();
            Console.Write("Ingrese la clasificacion de la pelicula: ");
            clasificacion = Console.ReadLine();
            Console.WriteLine("\n A continuacion agregue actores principales (3 max)");

            for (int i = 0; i < n; i++)
            {
                int op = 0;
                Console.Write("\n Desea agregar un actor? (1 - Si/ 2 - No):");
                op = int.Parse(Console.ReadLine());
                if (op == 1)
                {
                    Console.Write("\n Ingrese el nombre del {0} actor: ", (i + 1));
                    actores.Add(Console.ReadLine());
                }
                else
                {
                    i = n;
                }
            }

            Clases.Peliculas Peli = new Clases.Peliculas(id, nombre, duracion, actores, clasificacion);

            EscribirJSon(_pathPeliculas, Peli);
            Console.WriteLine("Pelicula almacenada exitosamente!");
        }

        static void AgregarGolosinas()
        {
            int cant = 0;
            float precio = 0;
            string nombre, descripcion;

            Console.Clear();

            Console.WriteLine("Para ingresar una nueva golosina deberas de ingresas los siguentes datos! \n");
            Console.Write("Ingrese el nombre del alimento/bebida: ");
            nombre = Console.ReadLine();
            Console.Write("Ingresa una descripcion (opcional): ");
            descripcion = Console.ReadLine();
            Console.Write("Ingrese la cantidad disponible: ");
            cant = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el precio unitario: ");
            precio = float.Parse(Console.ReadLine());

            Clases.Golosinas Al = new Clases.Golosinas(nombre, descripcion, precio, cant);

            EscribirJSon(_pathGolosinas, Al);
            Console.WriteLine("Alimento/Bebida almacenada exitosamente!");
        }

        static void EscribirJSon(string path, Clases.Golosinas Obj)
        {
            string json = JsonConvert.SerializeObject(Obj);
            string text = File.ReadAllText(path);
            if (text == "")
            {
                File.WriteAllText(path, "[" + json + "]");
                count++;
            }
            else
            {
                text = text.Remove(text.Length - 1);
                string temp = text + "," + json + "]";
                File.WriteAllText(path, text + "," + json + "]");
            }
        }

        static void EscribirJSon(string path, Clases.Usuarios Obj)
        {
            string json = JsonConvert.SerializeObject(Obj);
            string text = File.ReadAllText(path);
            if (text == "")
            {
                File.WriteAllText(path, "[" + json + "]");
                count++;
            }
            else
            {
                text = text.Remove(text.Length - 1);
                string temp = text + "," + json + "]";
                File.WriteAllText(path, text + "," + json + "]");
            }
        }

        static void EscribirJSon(string path, Clases.Empleados Obj)
        {
            string json = JsonConvert.SerializeObject(Obj);
            string text = File.ReadAllText(path);
            if (text == "")
            {
                File.WriteAllText(path, "[" + json + "]");
                count++;
            }
            else
            {
                text = text.Remove(text.Length - 1);
                string temp = text + "," + json + "]";
                File.WriteAllText(path, text + "," + json + "]");
            }
        }

        static void EscribirJSon(string path, Clases.Ticket Obj)
        {
            string json = JsonConvert.SerializeObject(Obj);
            string text = File.ReadAllText(path);
            if (text == "")
            {
                File.WriteAllText(path, "[" + json + "]");
                count++;
            }
            else
            {
                text = text.Remove(text.Length - 1);
                string temp = text + "," + json + "]";
                File.WriteAllText(path, text + "," + json + "]");
            }
        }

        static void EscribirJSon(string path, Clases.Peliculas Obj)
        {
            string json = JsonConvert.SerializeObject(Obj);
            string text = File.ReadAllText(path);
            if (text == "")
            {
                File.WriteAllText(path, "[" + json + "]");
                count++;
            }
            else
            {
                text = text.Remove(text.Length - 1);
                string temp = text + "," + json + "]";
                File.WriteAllText(path, text + "," + json + "]");
            }
        }

        public static void CargarJson()
        {
            Peliculas = JsonConvert.DeserializeObject<ArrayList>(_pathPeliculas);            
            KodiAlimentos = JsonConvert.DeserializeObject<ArrayList>(_pathGolosinas);
            EmpleadosReg = JsonConvert.DeserializeObject<ArrayList>(_pathEmpleados);
            UsuariosReg = JsonConvert.DeserializeObject<ArrayList>(_pathUsuarios);
        }

        static void Pruebas()
        {
            
        }
    }
}

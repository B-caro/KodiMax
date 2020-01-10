using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace KodiMax
{
    class Program
    {
        static int pos = 0, count = 0, id = 0;
        static ArrayList UsuariosReg = new ArrayList();
        static ArrayList EmpleadosReg = new ArrayList();
        static ArrayList Peliculas = new ArrayList();
        static ArrayList KodiAlimentos = new ArrayList();

        static void Main(string[] args)
        {
            Menu_Principal();
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
                    Clases.Usuarios us = (Clases.Usuarios)UsuariosReg[i];
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
                    Clases.Usuarios prb = new Clases.Usuarios(nombres, apellidos, email, nacimiento, usuario, pass);
                    UsuariosReg.Add(prb);                                    
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

                            break;
                        case 4:

                            break;
                        case 5:
                            Menu_Principal();
                            break;
                        case 6:

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
                UsuariosReg.Add(new Clases.Empleados(id, us.Nombres, us.Apellidos, us.Email, us.FechaNacimiento, us.NombreUsuario,
                us.Password, Telefono, Dui, Nit, Cargo));
                Console.WriteLine("Felicidades fuiste contratado! Ahora formas parte de nuestro grandioso equipo!!");
            }
            else
            {
                Console.WriteLine("Lo sentimos, no fuiste seleccionado :( \n Pero puedes intentarlo de nuevo!");
            }
            Console.WriteLine();
        }

        static void GuardarJson()
        {
            Clases.Usuarios prb = new Clases.Usuarios("Jonathan", "Bucaro", "", new DateTime(99, 7, 13), "1", "1");
            string json = JsonConvert.SerializeObject(prb);
            string path = @"C:\Users\Bucaro\Documents\GitHub\KodiMax\KodiMax\KodiMax\Json\Empleados.json";
            if (count == 0)
            {
                File.WriteAllText(path, "[" + json + "]");
                count++;
            }
            else
            {
                string text = File.ReadAllText(path);
                text = text.Remove(text.Length - 1);
                string temp = text + "," + json + "]";
                File.WriteAllText(path, text + "," + json + "]");
            }
        }

        static void GolosinasJson(Clases.Golosinas Gl)
        {
            string json = JsonConvert.SerializeObject(Gl);
            string path = @"C:\Users\Bucaro\Documents\GitHub\KodiMax\KodiMax\KodiMax\Json\Golsinas.json";
            if (count == 0)
            {
                File.WriteAllText(path, "[" + json + "]");
                count++;
            }
            else
            {
                string text = File.ReadAllText(path);
                text = text.Remove(text.Length - 1);
                string temp = text + "," + json + "]";
                File.WriteAllText(path, text + "," + json + "]");
            }
        }

        static void EmpleadosJson(Clases.Empleados Em)
        {
            string json = JsonConvert.SerializeObject(Em);
            string path = @"C:\Users\Bucaro\Documents\GitHub\KodiMax\KodiMax\KodiMax\Json\Empleados.json";
            if (count == 0)
            {
                File.WriteAllText(path, "[" + json + "]");
                count++;
            }
            else
            {
                string text = File.ReadAllText(path);
                text = text.Remove(text.Length - 1);
                string temp = text + "," + json + "]";
                File.WriteAllText(path, text + "," + json + "]");
            }
        }

        static void PeliculasJson(Clases.Peliculas Pl)
        {
            string json = JsonConvert.SerializeObject(Pl);
            string path = @"C:\Users\Bucaro\Documents\GitHub\KodiMax\KodiMax\KodiMax\Json\Peliculas.json";
            if (count == 0)
            {
                File.WriteAllText(path, "[" + json + "]");
                count++;
            }
            else
            {
                string text = File.ReadAllText(path);
                text = text.Remove(text.Length - 1);
                string temp = text + "," + json + "]";
                File.WriteAllText(path, text + "," + json + "]");
            }
        }

        static void Pruebas()
        {
            Clases.Usuarios prb = new Clases.Usuarios("Jonathan", "Bucaro", "", new DateTime(99,7,13), "1", "1");
            
        }
    }
}

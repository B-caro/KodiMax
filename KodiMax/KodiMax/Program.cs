﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiMax
{
    class Program
    {
        static ArrayList UsuariosReg = new ArrayList();
        static ArrayList EmpleadosReg = new ArrayList();
        static ArrayList Peliculas = new ArrayList();
        static ArrayList KodiAlimentos = new ArrayList();

        static void Main(string[] args)
        {
            Menu_Principal();
            Console.ReadKey();
        }

        static void Login()
        {
            //string user, pass;
            //Console.WriteLine("A continuacion ingrese sus datos de inicio de sesion!");
            //Console.Write("\n Usuario: ");
            //user = Console.ReadLine();
            //Console.Write("\n Contraseña: ");
            //pass = Console.ReadLine();
            for (int i = 0; i < UsuariosReg.Count; i++)
            {
                Clases.Usuarios user = (Clases.Usuarios)UsuariosReg[i];
                Console.WriteLine(user.Nombres);
                Console.WriteLine(user.Apellidos);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.FechaNacimiento);
                Console.WriteLine(user.NombreUsuario);
                Console.WriteLine(user.Password);
            }
        }

        static void Registro()
        {
            string nombres, apellidos, email, usuario, pass;
            DateTime nacimiento;
            Console.WriteLine("A continuacion debera de proporcionar algunos datos para realizar su registro!");
            Console.Write("\n Nombres: ");
            nombres = Console.ReadLine();
            Console.Write("\n Apellidos: ");
            apellidos = Console.ReadLine();
            Console.Write("\n Correo: ");
            email = Console.ReadLine();
            Console.WriteLine("\n A continuacion agregue su fecha de nacimiento ene ste formato: '9/7/1999'");
            Console.Write("\n Fecha de nacimiento: ");
            nacimiento = DateTime.Parse(Console.ReadLine());
            Console.Write("\n Usuario: ");
            usuario = Console.ReadLine();
            Console.Write("\n Contraseña: ");
            pass = Console.ReadLine();
            UsuariosReg.Add(new Clases.Usuarios(nombres, apellidos, email, nacimiento, usuario, pass));
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
                    Console.WriteLine("\t    ║                       Cartelera                        ║");
                    Console.WriteLine("\t    ║                                                        ║");
                    Console.WriteLine("\t    ║         Salas       Peliculas disponibles              ║");
                    Console.WriteLine("\t    ╠════════════════════════════════════════════════════════╣");
                    Console.WriteLine("\t    ║                                                        ║");
                    Console.WriteLine("\t    ║           1      El Robo Perfecto                      ║");
                    Console.WriteLine("\t    ║           2      Operación Red Sparrow                 ║");
                    Console.WriteLine("\t    ║           3      3 Anuncios por un crimen              ║");
                    Console.WriteLine("\t    ║           4      Pantera Negra                         ║");
                    Console.WriteLine("\t    ║                                                        ║");
                    Console.WriteLine("\t    ╠════════════════════════════════════════════════════════╣");
                    Console.WriteLine("\t    ║                    Otras opciones                      ║");
                    Console.WriteLine("\t    ║                                                        ║");
                    Console.WriteLine("\t    ║           5      Salir                                 ║");
                    Console.WriteLine("\t    ║           6      Administracion                        ║");
                    Console.WriteLine("\t    ╚════════════════════════════════════════════════════════╝");
                    Console.WriteLine("\n");
                    Console.Write("Selecciona la pelicula que deseas ver: ");
                    op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:

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
    }
}
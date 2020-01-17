using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiMax.Clases
{
    class Salas
    {
        private string nombrePelicula;
        private string tipoSala;
        private static int[,] asiento;
        private static int filas;
        private static int columnas;

        public Salas() { }
        
        public Salas(string name, int f, int c, string tipo)
        {
            this.nombrePelicula = name;
            this.tipoSala = tipo;
            asiento = new int[f, c];
            filas = f;
            columnas = c;
        }

        public string NombrePelicula { get => nombrePelicula; set => nombrePelicula = value; }
        public static int[,] Asiento { get => asiento; set => asiento = value; }
        public string TipoSala { get => tipoSala; set => tipoSala = value; }
        public int Filas { get => filas; set => filas = value; }
        public int Columnas { get => columnas; set => columnas = value; }

        public int Entradas()
        {
            int c = 1, fila = 0, entradas = 0;
            Console.Write("Cuantas entradas desea comprar: ");
            entradas = int.Parse(Console.ReadLine());
            try
            {
                if (entradas >= 15 || entradas < 0)
                {
                    Console.WriteLine("Solo puede comprar de [1] hasta [15] entradas por persona\n");
                    Entradas();
                }
                else
                {
                    Console.WriteLine();
                    if (entradas > 0)
                    {
                        Console.WriteLine("\tReservar asientos\n\n");
                        while (c <= entradas)
                        {
                            Console.WriteLine("\tAsientos disponibles\n");
                            matriz();
                            Boolean val1 = true;
                            String numero = "";
                            while (val1)
                            {
                                Console.Write("Ingresar el numero de asiento: ");

                                numero = Console.ReadLine();
                                if (numero.Length == 1 || numero.Length == 2)
                                {
                                    fila = int.Parse(numero);
                                    if (fila >= 1 || fila <= (filas * columnas))
                                    {
                                        val1 = false;
                                    }
                                }
                            }
                            int[] hail = getPositionByNumber(Convert.ToInt32(numero));

                            if (asiento[hail[0], hail[1]] == 0)
                            {
                                asiento[hail[0], hail[1]] = 1;
                                c = c + 1;
                                Console.WriteLine();
                                Console.WriteLine("\tReserva exitosa\n");
                                Console.WriteLine();
                                matriz();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Asiento ocupado, por favor eliga otro...\n");
                            }
                        }
                    }
                }                
            }
            catch (Exception e)
            {
                entradas = 0;
                Console.WriteLine("Ha ocurrido un error: " + e.Message + "\n");
                Entradas();
            }
            return entradas;
        }

        public void matriz()
        {
            int identificador = 1;
            String espacio = " ";
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (identificador < 10)
                    {
                        espacio = " 0";
                    }
                    else
                    {
                        espacio = " ";
                    }
                    if (asiento[i, j] == 0)
                    {
                        Console.Write(espacio + identificador++);
                    }
                    else if (asiento[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(espacio + identificador++);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.Clear();
        }

        public int[] getPositionByNumber(int number)
        {
            int[] position = new int[2];
            int bandera = 0;
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    bandera++;
                    if (bandera == number)
                    {
                        position[0] = i;
                        position[1] = j;
                    }
                }
            }
            return position;
        }
    }
}

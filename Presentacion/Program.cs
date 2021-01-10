using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class Program
    {
        static string[,] ventas = new string[100,3];
        static int numeroVentas=1;
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            ventas[0, 0] = "numero tienda";
            ventas[0, 1] = "numero del articulo";
            ventas[0, 2] = "numero de articulos";
            int opc;
            do
            {
                Console.Clear();
                Console.WriteLine("----------MENU------------");
                Console.WriteLine("digite una opcion y presione enter");
                Console.WriteLine("1. registrar venta");
                Console.WriteLine("2. visualizar");
                Console.WriteLine("3. calcular resultados");
                Console.WriteLine("4. salir");
                opc = Convert.ToInt32(Console.ReadLine());
                if ((opc>3)||(opc<1))
                {
                    Console.WriteLine("digite una opcion valida (presione cualquier tecla para volver a intentar)");
                    Console.ReadKey();
                }else if(opc==1)
                {
                    Registrar();
                }else if (opc==2)
                {
                    Visualizar();
                }else if (opc == 3)
                {
                    CalcularResultados();
                }else if (opc==4)
                {
                    Console.WriteLine("fin de la ejecucion (presione tecla para salir)");
                    Console.ReadKey();
                }
            } while (opc!=4);
        }
        static void Registrar()
        {
            char opc;
            string temp1, temp2, temp3;
            do
            {
                Console.Clear();
                Console.WriteLine("------registro de ventas-------");
                Console.Write("digite el numero de la tienda: ");
                temp1=Console.ReadLine();
                Console.Write("digite el numero del articulo deportivo: ");
                temp2 = Console.ReadLine();
                Console.Write("digite el numero de articulos: ");
                temp3 = Console.ReadLine();
                ventas[numeroVentas, 0] = temp1;
                ventas[numeroVentas, 1] = temp2;
                ventas[numeroVentas, 2] = temp3;
                numeroVentas=numeroVentas+1;
                Console.Write("desea continuar? (S/N): ");
                opc=Convert.ToChar(Console.ReadLine().ToUpper());
            } while (opc=='S');
        }
        static void Visualizar()
        {
            for (int i = 0; i < numeroVentas; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(ventas[i,j]+"|");
                }
                Console.Write("\n");
            }
            Console.WriteLine("presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        static void CalcularResultados()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("-------informe--------");
                string[,] tiendas = new string[11, 2];
                string[,] porcentajesVentas = new string[9, 2];
                int ventasTotales = 0;
                ////////////////////////
                for (int i = 0; i < 11; i++)
                {
                    tiendas[i, 0] = Convert.ToString(i);
                }
                for (int i = 1; i < numeroVentas; i++)
                {
                    tiendas[Convert.ToInt32(ventas[i, 0]), 1] = Convert.ToString(Convert.ToInt32(tiendas[Convert.ToInt32(ventas[i, 0]), 1]) + Convert.ToInt32(ventas[i, 2]));
                    ventasTotales = Convert.ToInt32(ventas[i, 2]) + ventasTotales;
                }
                ////////////////////////
                for (int i = 0; i < 9; i++)
                {
                    porcentajesVentas[i, 0] = Convert.ToString(i);
                }
                for (int i = 1; i < numeroVentas; i++)
                {
                    porcentajesVentas[Convert.ToInt32(ventas[i, 1]), 1] = Convert.ToString(Convert.ToDouble(porcentajesVentas[Convert.ToInt32(ventas[i, 1]), 1]) + Convert.ToDouble(ventas[i, 2]));
                }
                for (int i = 1; i < 9; i++)
                {
                    porcentajesVentas[i, 1] = Convert.ToString(Convert.ToDouble(porcentajesVentas[i, 1]) / ventasTotales * 100);
                }
                Console.WriteLine("-------ventas totales de cada tienda:\n");
                for (int i = 1; i < 11; i++)
                {
                    Console.Write("tienda " + tiendas[i, 0] + " vendio: " + tiendas[i, 1] + " productos\n");
                }
                Console.WriteLine("\n-------ventas totales en todas las tiendas: \n");
                Console.WriteLine("total de ventas fueron: " + ventasTotales + "\n");
                Console.WriteLine("--------Procentaje de ventas totales para cada uno de los artículos deportivos:\n");
                for (int i = 1; i < 9; i++)
                {
                    Console.WriteLine("articulo " + porcentajesVentas[i, 0] + " fue un " + porcentajesVentas[i, 1] + "% de las ventas totales");
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("error: "+e.Message);
                Console.ReadKey();
            }
            
        }
    }
}

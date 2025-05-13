using System;
using System.Collections.Generic;
using System.Linq;

namespace ListaLigada
{
    class Program
    {
        static void Main()
        {
            var lista = new ListaDoble<string>();
            int opcion;
            do
            {
                Console.WriteLine("\n1. Adicionar\n2. Mostrar adelante\n3. Mostrar atrás\n4. Ordenar descendente\n5. Mostrar moda(s)\n6. Mostrar gráfico\n7. Existe\n8. Eliminar una ocurrencia\n9. Eliminar todas las ocurrencias\n0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    
                    case 1:
                        Console.Write("Ingrese datos separados por espacios: ");
                        var entrada = Console.ReadLine();
                        var datos = entrada.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        foreach (var dato in datos)
                        {
                            lista.Adicionar(dato);
                        }
                        break;

                    case 2:
                        lista.MostrarAdelante();
                        break;
                    case 3:
                        lista.MostrarAtras();
                        break;
                    case 4:
                        lista.OrdenarDescendente();
                        break;
                    case 5:
                        var modas = lista.ObtenerModas();
                        Console.WriteLine("Moda(s): " + string.Join(", ", modas));
                        break;
                    case 6:
                        lista.MostrarGrafico();
                        break;
                    case 7:
                        Console.Write("Buscar dato: ");
                        Console.WriteLine(lista.Existe(Console.ReadLine()) ? "Existe" : "No existe");
                        break;
                    case 8:
                        Console.Write("Eliminar una: ");
                        lista.EliminarUna(Console.ReadLine());
                        break;
                    case 9:
                        Console.Write("Eliminar todas: ");
                        lista.EliminarTodas(Console.ReadLine());
                        break;
                }

            } while (opcion != 0);
        }
    }
}
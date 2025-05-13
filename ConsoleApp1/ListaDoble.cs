using System;
using System.Collections.Generic;
using System.Linq;

namespace ListaLigada
{
    public class ListaDoble<T> where T : IComparable<T>
    {
        private Nodo<T> cabeza;
        private Nodo<T> cola;

        public void Adicionar(T dato)
        {
            var nuevo = new Nodo<T>(dato);
            if (cabeza == null)
            {
                cabeza = cola = nuevo;
                return;
            }

            Nodo<T> actual = cabeza;
            while (actual != null && actual.Dato.CompareTo(dato) < 0)
            {
                actual = actual.Siguiente;
            }

            if (actual == cabeza)
            {
                nuevo.Siguiente = cabeza;
                cabeza.Anterior = nuevo;
                cabeza = nuevo;
            }
            else if (actual == null)
            {
                cola.Siguiente = nuevo;
                nuevo.Anterior = cola;
                cola = nuevo;
            }
            else
            {
                nuevo.Anterior = actual.Anterior;
                nuevo.Siguiente = actual;
                actual.Anterior.Siguiente = nuevo;
                actual.Anterior = nuevo;
            }
        }

        public void MostrarAdelante()
        {
            var actual = cabeza;
            while (actual != null)
            {
                Console.Write(actual.Dato + " ");
                actual = actual.Siguiente;
            }
            Console.WriteLine();
        }

        public void MostrarAtras()
        {
            var actual = cola;
            while (actual != null)
            {
                Console.Write(actual.Dato + " ");
                actual = actual.Anterior;
            }
            Console.WriteLine();
        }

        /* public void OrdenarDescendente()
         {
             List<T> datos = new List<T>();
             var actual = cabeza;
             while (actual != null)
             {
                 datos.Add(actual.Dato);
                 actual = actual.Siguiente;
             }

             datos.Sort((a, b) => b.CompareTo(a));

             cabeza = cola = null;
             foreach (var dato in datos)
             {
                 AdicionarFin(dato);
             }
         }
        */
        public void OrdenarDescendente()
        {
            List<T> datos = new List<T>();
            var actual = cabeza;
            while (actual != null)
            {
                datos.Add(actual.Dato);
                actual = actual.Siguiente;
            }

            
            datos.Sort((a, b) => b.CompareTo(a));

            cabeza = null;
            cola = null;

            foreach (var dato in datos)
            {
                var nuevo = new Nodo<T>(dato);
                if (cabeza == null)
                {
                    cabeza = cola = nuevo;
                }
                else
                {
                    cola.Siguiente = nuevo;
                    nuevo.Anterior = cola;
                    cola = nuevo;
                }
            }
        }

        private void AdicionarFin(T dato)
        {
            var nuevo = new Nodo<T>(dato);
            if (cabeza == null)
            {
                cabeza = cola = nuevo;
            }
            else
            {
                cola.Siguiente = nuevo;
                nuevo.Anterior = cola;
                cola = nuevo;
            }
        }

        public List<T> ObtenerModas()
        {
            var frecuencia = new Dictionary<T, int>();
            var actual = cabeza;
            while (actual != null)
            {
                if (!frecuencia.ContainsKey(actual.Dato))
                    frecuencia[actual.Dato] = 0;
                frecuencia[actual.Dato]++;
                actual = actual.Siguiente;
            }

            int max = frecuencia.Values.Max();
            return frecuencia.Where(p => p.Value == max).Select(p => p.Key).ToList();
        }

        public void MostrarGrafico()
        {
            var frecuencia = new Dictionary<T, int>();
            var actual = cabeza;
            while (actual != null)
            {
                if (!frecuencia.ContainsKey(actual.Dato))
                    frecuencia[actual.Dato] = 0;
                frecuencia[actual.Dato]++;
                actual = actual.Siguiente;
            }

            foreach (var par in frecuencia)
            {
                Console.Write(par.Key + " ");
                for (int i = 0; i < par.Value; i++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }

        public bool Existe(T dato)
        {
            var actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato.Equals(dato))
                    return true;
                actual = actual.Siguiente;
            }
            return false;
        }

        public void EliminarUna(T dato)
        {
            var actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato.Equals(dato))
                {
                    if (actual == cabeza)
                        cabeza = actual.Siguiente;
                    if (actual == cola)
                        cola = actual.Anterior;
                    if (actual.Anterior != null)
                        actual.Anterior.Siguiente = actual.Siguiente;
                    if (actual.Siguiente != null)
                        actual.Siguiente.Anterior = actual.Anterior;
                    break;
                }
                actual = actual.Siguiente;
            }
        }

        public void EliminarTodas(T dato)
        {
            var actual = cabeza;
            while (actual != null)
            {
                var siguiente = actual.Siguiente;
                if (actual.Dato.Equals(dato))
                {
                    if (actual == cabeza)
                        cabeza = actual.Siguiente;
                    if (actual == cola)
                        cola = actual.Anterior;
                    if (actual.Anterior != null)
                        actual.Anterior.Siguiente = actual.Siguiente;
                    if (actual.Siguiente != null)
                        actual.Siguiente.Anterior = actual.Anterior;
                }
                actual = siguiente;
            }
        }
    }
}

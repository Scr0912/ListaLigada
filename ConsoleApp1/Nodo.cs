using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaLigada
{
    public class Nodo<T>
    {
        public T Dato { get; set; }
        public Nodo<T> Anterior { get; set; }
        public Nodo<T> Siguiente { get; set; }

        public Nodo(T dato)
        {
            Dato = dato;
            Anterior = null;
            Siguiente = null;
        }
    }
}
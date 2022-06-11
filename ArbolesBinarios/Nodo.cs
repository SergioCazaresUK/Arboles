using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesBinarios
{
    public class Nodo
    {
        public int Dato { get; set; }
        public Nodo SubArbolIzq { get; set; }
        public Nodo SubArbolDer { get; set; }

        public Nodo(int dato, Nodo subArbolIzq = null, Nodo subArbolDer = null)
        {
            Dato = dato;
            SubArbolIzq = subArbolIzq;
            SubArbolDer = subArbolDer;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesBinarios
{
    public class ArbolBinario
    {
        private readonly Nodo raiz;
        public Nodo Raiz { get { return raiz; } }
        public ArbolBinario(string dato)
        {
            raiz = new Nodo(dato);
        }

        public enum TipoRecorrido
        {
            Preorden,
            Inorden,
            Posorden
        }

        public void Insertar (int dato, Nodo nodo = null)
        {
            if(nodo == null)
            {
                nodo = this.raiz;
            }

            if(dato < nodo.Dato)
            {
                if(nodo.SubArbolIzq == null)
                {
                    nodo.SubArbolIzq = new Nodo(dato);
                }  
                Insertar(dato, nodo.SubArbolIzq);
            }

            else if(dato > nodo.Dato)
            {
                if(nodo.SubArbolDer == null)
                {
                    nodo.SubArbolDer = new Nodo(dato);
                }
                Insertar(dato, nodo.SubArbolDer);
            }

        }
    }
}

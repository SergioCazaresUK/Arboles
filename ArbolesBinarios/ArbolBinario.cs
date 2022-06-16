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
        public ArbolBinario(int dato)
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

        public void RecorrerArbol(Nodo nodo, ref string recorrer)
        {
            if(nodo != null)
            {
                string raiz = string.Empty;
                if (recorrer == string.Empty)
                {
                    raiz = "Raiz";
                }

                recorrer += $"{raiz}{nodo.Dato,5}\n";

                if (nodo.SubArbolIzq != null)
                {
                    recorrer += $"{nodo.Dato,-5}<- ";
                    RecorrerArbol(nodo.SubArbolIzq, ref recorrer);
                }

                if (nodo.SubArbolDer != null)
                {
                    recorrer += $"{nodo.Dato,-5}-> ";
                    RecorrerArbol(nodo.SubArbolDer, ref recorrer);
                }
            }
        }

        public string ObtenerArbol(Nodo nodo = null)
        {
            if (nodo == null)
            {
                nodo = this.raiz;
            }

            string recorrido = string.Empty;
            RecorrerArbol(nodo, ref recorrido);
            return recorrido;
        }

    }
}

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

            string recorrer = string.Empty;
            RecorrerArbol(nodo, ref recorrer);
            return recorrer;
        }

        private void AgregarDato(Nodo nodo, ref string recorrer)
        {
            string coma = (recorrer == string.Empty) ? string.Empty : ",";
            recorrer += $"{coma}{nodo.Dato}";
        }
        public string Recorrido(Nodo nodo = null,
           TipoRecorrido tipoRecorrido = TipoRecorrido.Preorden)
        {
            if (nodo == null)
            {
                nodo = this.raiz;
            }

            string recorrido = string.Empty;

            switch (tipoRecorrido)
            {
                case TipoRecorrido.Preorden:
                    RecorridoPreorden(nodo, ref recorrido);
                    break;

                case TipoRecorrido.Inorden:
                    RecorridoInorden(nodo, ref recorrido);
                    break;

                case TipoRecorrido.Posorden:
                    RecorridoPosorden(nodo, ref recorrido);
                    break;

                default: throw new Exception("Recorrido incorrecto");
            }

            return $"Tipo recorrido: {tipoRecorrido}: {recorrido}";
        }
        private void RecorridoPreorden(Nodo nodo, ref string recorrido)
        {
            if (nodo != null)
            {
                AgregarDato(nodo, ref recorrido);

                if (nodo.SubArbolIzq != null)
                {
                    RecorridoPreorden(nodo.SubArbolIzq, ref recorrido);
                }

                if (nodo.SubArbolDer != null)
                {
                    RecorridoPreorden(nodo.SubArbolDer, ref recorrido);
                }
            }
        }

    }
}

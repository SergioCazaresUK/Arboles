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

            string recorrer = string.Empty;

            switch (tipoRecorrido)
            {
                case TipoRecorrido.Preorden:
                    RecorridoPreorden(nodo, ref recorrer);
                    break;

                case TipoRecorrido.Inorden:
                    RecorridoInorden(nodo, ref recorrer);
                    break;

                case TipoRecorrido.Posorden:
                    RecorridoPosorden(nodo, ref recorrer);
                    break;

                default: throw new Exception("Recorrido incorrecto");
            }

            return $"Tipo recorrido: {tipoRecorrido}: {recorrer}";
        }
        private void RecorridoPreorden(Nodo nodo, ref string recorrer)
        {
            if (nodo != null)
            {
                AgregarDato(nodo, ref recorrer);

                if (nodo.SubArbolIzq != null)
                {
                    RecorridoPreorden(nodo.SubArbolIzq, ref recorrer);
                }

                if (nodo.SubArbolDer != null)
                {
                    RecorridoPreorden(nodo.SubArbolDer, ref recorrer);
                }
            }
        }
        private void RecorridoInorden(Nodo nodo, ref string recorrer)
        {
            if (nodo != null)
            {
                if (nodo.SubArbolIzq != null)
                {
                    RecorridoInorden(nodo.SubArbolIzq, ref recorrer);
                }

                AgregarDato(nodo, ref recorrer);

                if (nodo.SubArbolDer != null)
                {
                    RecorridoInorden(nodo.SubArbolDer, ref recorrer);
                }
            }
        }
        private void RecorridoPosorden(Nodo nodo, ref string recorrer)
        {
            if (nodo != null)
            {
                if (nodo.SubArbolIzq != null)
                {
                    RecorridoPosorden(nodo.SubArbolIzq, ref recorrer);
                }

                if (nodo.SubArbolDer != null)
                {
                    RecorridoPosorden(nodo.SubArbolDer, ref recorrer);
                }

                AgregarDato(nodo, ref recorrer);
            }
        }

    }
}

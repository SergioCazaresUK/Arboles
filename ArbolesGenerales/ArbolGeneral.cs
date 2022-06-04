using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesGenerales
{
    public class ArbolGeneral
    {
        private readonly Nodo raiz;

        //public Nodo Raiz => raiz;
        public Nodo Raiz { get { return raiz; } }

        public ArbolGeneral(string dato)
        {
            raiz = new Nodo(dato);
        }

        public Nodo InsertarHijo(Nodo padre, string dato)
        {
            if (string.IsNullOrWhiteSpace(dato))
            {
                throw new Exception("El Dato esta Vacio");
            }

            if(padre is null)
            {
                throw new Exception("El padre no puede ser nulo");
            }

            if(padre.Hijo is null)
            {
                padre.Hijo = new Nodo(dato);
                return padre.Hijo;
            }
            else
            {
                Nodo hijoactual = padre.Hijo;
                while (hijoactual.Hermano != null){
                    hijoactual = hijoactual.Hermano;
                }
                hijoactual.Hermano = new Nodo(dato);
                return hijoactual.Hermano;
            }
        }
        // investigar inmutabilidad
        private void Recorrer(Nodo nodo, ref int posicion, ref string datos) 
        { 
            if(nodo != null)
            {
                string dato = nodo.Dato;
                int cantidadGuiones = dato.Length + posicion;
                string datoGuiones = dato.PadLeft(cantidadGuiones, '-');
                datos += $"{datoGuiones}\n";

                if(nodo.Hijo != null)
                {
                    posicion++;
                    Recorrer(nodo.Hijo, ref posicion, ref datos);
                    posicion--;
                }
                
                if(nodo.Hermano != null && posicion != 0)
                {
                    Recorrer(nodo.Hermano, ref posicion, ref datos);
                }
            }
        }

        public string ObtenerArbol(Nodo nodo = null)
        {
            if(nodo is null)
            {
                nodo = raiz;
            }
            int posicion = 0;
            string datos = string.Empty;

            Recorrer(nodo, ref posicion, ref datos);
            return datos;
        }

        public Nodo Buscar(string dato, Nodo nodoBusqueda)
        {
            if(nodoBusqueda is null)
            {
                nodoBusqueda = raiz;
            }
            
            if(nodoBusqueda.Dato.ToUpper() == dato.ToUpper())
            {
                return nodoBusqueda;
            }

            if(nodoBusqueda.Hijo != null)
            {
                Nodo nodoEncontrado = Buscar(dato, nodoBusqueda.Hijo);
                if(nodoEncontrado is null)
                {
                    return nodoEncontrado;
                }
            }

            if(nodoBusqueda.Hermano != null)
            {
                Nodo nodoEncontrado = Buscar(dato, nodoBusqueda.Hermano);
                if(nodoEncontrado is null)
                {
                    return nodoEncontrado;
                }
            }
            return null;
        }
    }
}
using ArbolesGenerales;

ArbolGeneral arbol = new ArbolGeneral("A");

Nodo nodoB = arbol.InsertarHijo(arbol.Raiz, "B");
Nodo nodoC = arbol.InsertarHijo(arbol.Raiz, "C");
Nodo nodoD = arbol.InsertarHijo(nodoB, "D");
Nodo nodoE = arbol.InsertarHijo(nodoD, "E");
Nodo nodoF = arbol.InsertarHijo(nodoD, "F");
Nodo nodoG = arbol.Buscar("D", nodoB);

string arbolCompleto = arbol.ObtenerArbol();
Console.WriteLine(arbolCompleto);
using System;
using System.Collections.Generic;

namespace grafos
{
	/// <summary>
	/// Description of Ejercicio_5.
	/// </summary>
	public class Ejercicio_5<T>
	{
		public Ejercicio_5()
		{
		}
		// creo que de esa forma se sacan todos los caminos y su tiempo total de recorrido
		// DFS para buscar el camino que dure mas limitando la busqueda a 180
		
		
		public List<Vertice<T>> ejerciocio5(Grafo<T> grafo, Vertice<T> inicio, Vertice<T> fin){
			
			bool[] visitados = new bool[grafo.getVertices().Count];
			
			List<Vertice<T>> camino = new List<Vertice<T>>();
			
			List<Vertice<T>> mejor_camino = new List<Vertice<T>>();
			
			_ejercicio5(grafo, inicio, fin, camino, visitados, mejor_camino, 0, 180);
			
//			foreach(Vertice<T> vertice in mejor_camino){
//				Console.WriteLine(vertice.getDato().ToString());
//			}
			return mejor_camino;
		}
		
		public List<Vertice<T>> _ejercicio5(Grafo<T> grafo, 
		                                Vertice<T> inicio, 
		                                Vertice<T> fin, 
		                                List<Vertice<T>> camino, 
		                                bool[] visitados, 
		                                List<Vertice<T>> mejor_camino, 
		                                int tiempo, 
		                                int mejor_tiempo){
			// agregamos origen al camino
			camino.Add(inicio);
			// marco origen como visitado
			visitados[inicio.getPosicion() - 1] = true;
			// si llegamos al fin y si su longitud y su tiempo es menor la mejor, copiamos camino a mejor_camino
			// para este caso es la mayor cantidad de salas y tiempo inferior a 2hs = 180 min
			if(inicio == fin){
				if(tiempo < mejor_tiempo){
					if(camino.Count > mejor_camino.Count){
						mejor_tiempo = tiempo;
						mejor_camino.Clear();
						foreach(Vertice<T> vertice in camino){
							mejor_camino.Add(vertice);
						}
						//mejor_camino.AddRange(camino);
						
					}
				}
			}
			// sino recorremos sus aristas 
			else{
				// verificamos que tenga adyacentes
				if(inicio.getAdyacentes().Count > 0){
					foreach(Arista<T> adyacente in inicio.getAdyacentes()){
						// si adyacente no esta visitado
						if(visitados[adyacente.getDestino().getPosicion() - 1] == false){
							// sumamos el tiempo (que seria el peso de la arista)
							tiempo +=  Convert.ToInt32(adyacente.getPeso());
							// llamaos a recursion con el vertice siguiente
							mejor_camino = _ejercicio5(grafo, adyacente.getDestino(), fin, camino, visitados, mejor_camino, tiempo, mejor_tiempo);
							// restamos el tiempo de adyacente
							tiempo -= adyacente.getPeso();
							// desmarcamos adyacente como visitado
							visitados[adyacente.getDestino().getPosicion() - 1] = false;
							//quitamos adyacente de camino
							camino.RemoveAt(camino.Count - 1);
						}
					}
				}
			}
			return mejor_camino;
		}
	}
}

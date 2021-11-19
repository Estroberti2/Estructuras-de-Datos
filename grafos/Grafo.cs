using System;
using System.Collections.Generic;

namespace tp7
{
	/// <summary>
	/// Description of Grafo.
	/// </summary>
	public class Grafo<T>
	{
		private List<Vertice<T>> vertices = new List<Vertice<T>>();
	
		public Grafo()
		{
		}
		
		public void agregarVertice(Vertice<T> v) {
			v.setPosicion(vertices.Count + 1);
			vertices.Add(v);
		}

		public void eliminarVertice(Vertice<T> v) {
			vertices.Remove(v);
		}

		public void conectar(Vertice<T> origen, Vertice<T> destino, int peso) {
			origen.getAdyacentes().Add(new Arista<T>(destino,peso));
		}

		public void desConectar(Vertice<T> origen, Vertice<T> destino) {
			Arista<T> arista = origen.getAdyacentes().Find(a => a.getDestino().Equals(destino));
			origen.getAdyacentes().Remove(arista);// fat arrow, delegado 
		}

		// public void desConectar(Vertice<T> origen, Vertice<T> destino) {
			// Arista<T> arista;
			// foreach(var a in origen.getAdyacentes()){
				// if(a.getDestino().Equals(destino))
					// arista = a;
			// }
			// origen.getAdyacentes().Remove(arista);			
		// }
		
		public List<Vertice<T>> getVertices() {
			return vertices;
		}

	
		public Vertice<T> vertice(int idx) {
			return this.vertices[idx];
		}
	

		public void DFS(Vertice<T> origen){
			// creamos arreglo de visitados
			bool[] visitados = new bool[this.getVertices().Count];
			// llamamos a _DFS
			this._DFS(origen, visitados);
		}
		
		private void _DFS(Vertice<T> origen, bool[] visitados){
			// marcamos origen como vistado
			visitados[origen.getPosicion() - 1] = true;
			
			// procesamos origen
			Console.Write(origen.getDato().ToString() + " ");
			
			// llamada recursiva en adyacentes no visitados
			foreach(var adyacente in origen.getAdyacentes())
				if(!visitados[adyacente.getDestino().getPosicion() - 1])
					this._DFS(adyacente.getDestino(), visitados);
		}
		
		public void BFS(Vertice<T> origen) {
			Cola<Vertice<T>> c = new Cola<Vertice<T>>();
			Vertice<T> verticeAux;
			bool[] visitados = new bool[this.getVertices().Count];
			
			// encolamos origen
			c.encolar(origen);
			// marcamos origen como visitado
			visitados[origen.getPosicion() - 1] = true;
			
			// procesamos cola
			while(!c.esVacia()){
				// desencolamos
				verticeAux = c.desencolar();
				
				// procesamos dato desencolado
				Console.Write(verticeAux.getDato().ToString() + " ");
				
				// encolamos adyacentes no visitados
				foreach(var adyacente in verticeAux.getAdyacentes()){
					if(!visitados[adyacente.getDestino().getPosicion() - 1]){
						c.encolar(adyacente.getDestino());
						// marcar a los elementos encolados como visitados
						visitados[adyacente.getDestino().getPosicion() - 1] = true;
					}
				}
			}				
		}
		
		
	}
}

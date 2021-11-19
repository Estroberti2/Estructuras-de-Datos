using System;
using System.Collections.Generic;

namespace Dijktra
{
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
		
		public void _menor_distaciia(Vertice<T> inicio){
			
			// tabla de arrays
			
			Vertice<T>[] vertices_previos = new Vertice<T>[this.getVertices().Count];
			int[] distancias = new int[this.getVertices().Count];
			bool[] visitados = new bool[this.getVertices().Count];
			
			// iniciamos distancia y previos
			
			for(int i=0 ; i < this.getVertices().Count; i++){
				distancias[i] = int.MaxValue;
				vertices_previos[i] = null;
			}
			
			// iniciamos distancia de origen
			
			int origen_indice = inicio.getPosicion() -1;
			distancias[origen_indice] = 0;
			int indice_menor_costo = origen_indice;
			
			// iteramos una vez por vertice
			
			for(int j=0 ; j < this.getVertices().Count; j++){
				
				// buscamos un vertice no conocido de menor costo
				
				int menor_costo = int.MaxValue;
				Vertice<T> vertice_menor_costo = null;
				
				for(int k=0 ; k < this.getVertices().Count; k++){
					if(!visitados[k]){
						if(distancias[k] < menor_costo){
							// si lo encontramos reemplazamos
							indice_menor_costo = k;
							menor_costo = distancias[k];
							vertice_menor_costo = this.getVertices()[k];
						}
					}
				}
				if(vertice_menor_costo != null){
					//marcamos al vertice de menor costo como conocido
					visitados[indice_menor_costo] = true;
					
					// actualizamos adyacentes no conocidos
					foreach(var adyacente in vertice_menor_costo.getAdyacentes()){
						int adyacente_posicion = adyacente.getDestino().getPosicion() -1;
						if(!visitados[adyacente_posicion]){
							int costo_adyacente = distancias[indice_menor_costo] + adyacente.getPeso();
							if(costo_adyacente < distancias[adyacente_posicion]){
								distancias[adyacente_posicion] = costo_adyacente;
								vertices_previos[adyacente_posicion] = vertice_menor_costo;
							}
						}
					}
				}
			}
			// imprimimos tablas
			// this.imprimirTabla(this.getVertices(), vertices_previos, distancias)
			Console.WriteLine("Vertices\t Costo Distancia\t Costo Precio\t\t Conocido");
			int c = 0;
			foreach (Vertice<T> ver in vertices_previos){
				if(ver == null){
					Console.WriteLine("{0} \t\t {1} \t\t\t {2} \t\t\t {3}", this.getVertices()[c].getDato(), 0, "-", inicio.getDato());
				}
				else{
					Console.WriteLine("{0} \t\t {1} \t\t\t {2} \t\t\t {3}", this.getVertices()[c].getDato(), distancias[c], ver.getDato(), inicio.getDato());
				}
				c++;
				
			}
			
			// imprimimos mejor camino
			// this.imprimirMejoresCaminos(this.getVertices(), vertices_previos, distancias, inicio)
		}
	}
}

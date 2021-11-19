using System;

namespace Dijktra
{
	/// <summary>
	/// Description of Arista.
	/// </summary>
	public class Arista<T>
	{
		private Vertice<T> destino;
		private int peso;
	
		public Arista(Vertice<T> dest, int p){
				destino = dest;
				peso = p;
		}
		
		public void setDestino(Vertice<T> destino) {
			this.destino = destino;
		}
		
		public Vertice<T> getDestino() {
			return destino;
		}
		
		public void setPeso(int peso) {
			this.peso = peso;
		}
		
		public int getPeso() {
			return peso;
		}
	}
}

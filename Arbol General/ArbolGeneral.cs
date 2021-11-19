using System;
using System.Collections;
using System.Collections.Generic;

namespace arbol_general
{
	public class ArbolGeneral<T> where T: IComparable
	{
		
		private T dato;
		private List<ArbolGeneral<T>> hijos = new List<ArbolGeneral<T>>();

		public ArbolGeneral(T dato) {
			this.dato = dato;
		}
	
		public T getDatoRaiz() {
			return this.dato;
		}
	
		public List<ArbolGeneral<T>> getHijos() {
			return hijos;
		}
	
		public void agregarHijo(ArbolGeneral<T> hijo) {
			this.getHijos().Add(hijo);
		}
	
		public void eliminarHijo(ArbolGeneral<T> hijo) {
			this.getHijos().Remove(hijo);
		}
	
		public bool esHoja() {
			return this.getHijos().Count == 0;
		}
		
		// Listo y funcional		
		public int altura() {
			int alto = 0;
			int altoMax = 1;
			if(!this.esHoja()){
				alto++;
				for(int i = 0; i < this.getHijos().Count ;i++){
					alto += this.getHijos()[i].altura();
					if(altoMax < alto){
						altoMax = alto;
					}
					alto = 0;
				}
			}
			return altoMax;
		}
	
		// nivel sin terminar
		public int nivel(T dato) {
			int lvl = 0;
			if(!this.esHoja()){
				foreach(var hijo in this.hijos){
					if(dato.Equals(hijo.getDatoRaiz())){
						return lvl++;
					}
					lvl += hijo.nivel(dato);
					lvl = 0;
				}
			}
			return lvl;
		}
		
		// Listo y Funcional
		public int ancho(){
			var anchoMax = 0;
			if(!this.esHoja()){
				anchoMax = this.getHijos().Count;
				for(int i = 0; i < this.getHijos().Count ;i++){
					if(this.getHijos()[i].ancho()> anchoMax){
						anchoMax = this.getHijos()[i].ancho();
					}
				}
			}
			return anchoMax;
		}

		// Listo y Funcional
		public void ejercicio5(double caudalInicial){			
			int c = 1;
			List<double> caudalNodos = new List<double>();
			
			if(!this.esHoja()){
				
				double nodo = caudalInicial / this.getHijos().Count;
				
				foreach(var hijo in this.getHijos()){
					
					if(!caudalNodos.Contains(nodo)){
						
						caudalNodos.Add(nodo);
						Console.WriteLine("En profundidad {0} el caudal es: {1}", c, nodo);
						c++;
						hijo.ejercicio5(nodo);
					}
					c = 1;
				}
			}
		}
		
		// Listo y Funcional
		public int quadTree(){
			int negro = 0;
			if(this.esHoja() == true){
				if(this.getDatoRaiz().Equals(1)){
					negro++;
				}
			}
			if(this.esHoja() == false){
				foreach(ArbolGeneral<T> hijo in this.getHijos()){
					negro += hijo.quadTree();
				}
			}
			return negro;
		}
		
		public int CompareTo(ArbolGeneral<T> otro){
			return this.dato.CompareTo(otro.getDatoRaiz());
		}
	}
}

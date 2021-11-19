using System;
using System.Collections;
using System.Collections.Generic;

namespace arbol_general
{
	public class ArbolGeneral2<Int16>
	{
		
		private Int16 dato;
		private List<ArbolGeneral2<Int16>> hijos = new List<ArbolGeneral2<Int16>>();

		public ArbolGeneral2(Int16 dato) {
			this.dato = dato;
		}
	
		public Int16 getDatoRaiz() {
			return this.dato;
		}
	
		public List<ArbolGeneral2<Int16>> getHijos() {
			return hijos;
		}
	
		public void agregarHijo(ArbolGeneral2<Int16> hijo) {
			this.getHijos().Add(hijo);
		}
	
		public void eliminarHijo(ArbolGeneral2<Int16> hijo) {
			this.getHijos().Remove(hijo);
		}
	
		public bool esHoja() {
			return this.getHijos().Count == 0;
		}
		
		// altura terminado		
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
	
		// nivel sin terminar / me sigue dando que el dato se encuentra en raiz
		public int nivel(ArbolGeneral2<Int16> dato) {
			int lvl = 0;
			int lvl2 = 1;
			if(!this.esHoja()){
				foreach(var hijo in this.hijos){
					lvl += hijo.nivel(dato);
					if(hijo.getDatoRaiz().Equals(dato.getDatoRaiz())){
						lvl2 = lvl;
					}
					lvl = 0;
				}
			}
			return lvl2;
		}
		
		// ancho terminado
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
		
		
		// ejercicio 5 practica 1
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
		
		
		public int quadTree(){
			int negro = 0;
			if(this.esHoja() == true){
				if(this.getDatoRaiz().Equals(1)){
					negro++;
				}
			}
			if(this.esHoja() == false){
				foreach(ArbolGeneral2<Int16> hijo in this.getHijos()){
					negro += hijo.quadTree();
				}
			}
			return negro;
		}
		
		
	}
}

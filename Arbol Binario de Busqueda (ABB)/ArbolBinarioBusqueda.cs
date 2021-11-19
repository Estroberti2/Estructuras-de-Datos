using System;

namespace Arbol_Binario_de_Busqueda__ABB_
{

	public class ArbolBinarioBusqueda{
		
		private IComparable dato;
		private ArbolBinarioBusqueda hijoIzquierdo;
		private ArbolBinarioBusqueda hijoDerecho;
		
		
		public ArbolBinarioBusqueda(IComparable dato){
			this.dato = dato;
		}
		
		
		public IComparable getDatoRaiz(){
			return this.dato;
		}
		
		public ArbolBinarioBusqueda getHijoIzquierdo(){
			return this.hijoIzquierdo;
		}
		
		public ArbolBinarioBusqueda getHijoDerecho(){
			return this.hijoDerecho;
		}
		
		public void agregarHijoIzquierdo(ArbolBinarioBusqueda hijo){
			this.hijoIzquierdo=hijo;
		}

		public void agregarHijoDerecho(ArbolBinarioBusqueda hijo){
			this.hijoDerecho=hijo;
		}
		
		public void eliminarHijoIzquierdo(){
			this.hijoIzquierdo=null;
		}
		
		public void eliminarHijoDerecho(){
			this.hijoDerecho=null;
		}
		
		public void agregar(IComparable elem) {
			
			// si el elemento es menor al dato raiz
			if(elem.CompareTo(this.dato) < 0){
				// si hijo izquierdo de raiz es null, inserto
				if(this.hijoIzquierdo == null){
					this.agregarHijoIzquierdo(new ArbolBinarioBusqueda(elem));
				}
				// si no, llamada recursiva
				else{
					this.hijoIzquierdo.agregar(elem);
				}
			}
			// si es mayor o igual al dato raiz
			else{
				// si hijo derecho de raiz es null, inserto
				if(this.hijoDerecho == null){
					this.agregarHijoDerecho(new ArbolBinarioBusqueda(elem));
				}
				// si no, llamada recursiva
				else{
					this.hijoDerecho.agregar(elem);	
				}
			}
		}
		
		
		public bool incluye(IComparable elem) {
			if(elem.CompareTo(this.dato) == 0){
				return true;
			}
			if(elem.CompareTo(this.dato) < 0){
				// si hijo izquierdo de raiz es null, inserto
				if(this.hijoIzquierdo != null){
					return this.hijoIzquierdo.incluye(elem);
				}
			}
			if(elem.CompareTo(this.dato) > 0){
				if(this.hijoDerecho != null){
					return this.hijoDerecho.incluye(elem);
				}
			}
			return false;
		}


		public void preorden() {
			Console.Write(this.dato + " ");
			
			if(this.hijoIzquierdo != null){
				this.hijoIzquierdo.preorden();
			}
			if(this.hijoDerecho != null){
				this.hijoDerecho.preorden();
			}
		}
		
		public void inorden() {
			
			if(this.hijoIzquierdo != null){
				this.hijoIzquierdo.inorden();
			}
			Console.Write(this.getDatoRaiz() + " ");
			if(this.hijoDerecho != null){
				this.hijoDerecho.inorden();
			}
		}
		
		public void postorden() {
			if(this.hijoIzquierdo != null){
				this.hijoIzquierdo.postorden();
			}
			if(this.hijoDerecho != null){
				this.hijoDerecho.postorden();
			}
			Console.Write(this.dato + " ");
		}
	}
}
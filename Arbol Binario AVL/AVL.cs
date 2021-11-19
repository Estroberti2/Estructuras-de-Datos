using System;

namespace Arbol_Binario_AVL
{
	public class AVL{
		
		private IComparable dato;
		private AVL hijoIzquierdo;
		private AVL hijoDerecho;
		private int altura = 0;
		
		public AVL(IComparable dato){
			this.dato = dato;
		}
		
		public IComparable getDatoRaiz(){
			return this.dato;
		}
		
		public AVL getHijoIzquierdo(){
			return this.hijoIzquierdo;
		}
		
		public AVL getHijoDerecho(){
			return this.hijoDerecho;
		}
		
		public int getAltura(){
			return this.altura;
		}
	
		public void agregarHijoIzquierdo(AVL hijo){
			this.hijoIzquierdo = hijo;
		}

		public void agregarHijoDerecho(AVL hijo){
			this.hijoDerecho = hijo;
		}
		
		public void eliminarHijoIzquierdo(){
			this.hijoIzquierdo = null;
		}
		
		public void eliminarHijoDerecho(){
			this.hijoDerecho = null;
		}
		
		public void agregar(IComparable elem) {
			
			// si es menor, consulto si hijo izquierdo de raiz es null
			if(elem.CompareTo(this.dato) < 0){
				// si HI de raiz es null, inserto
				if(this.hijoIzquierdo == null)
					this.agregarHijoIzquierdo(new AVL(elem));
				// si no, llamada recursiva
				else
					this.hijoIzquierdo.agregar(elem);
			}
			// si es mayor o igual a la raiz
			else{
				if(this.hijoDerecho == null)
					this.agregarHijoDerecho(new AVL(elem));
				else
					this.hijoDerecho.agregar(elem);				
			}
			// actualizar altura
			this.actualizarAltura();
			
			
			// chequear desbalance
			// en caso de desbalance llamar a la rotacion correcta
		}
		
		
		// rotacion simple con hoja derecho (rota en sentido antiorario)
		// La hoja insertado es mayor que el hijo derecho del nodo principal

		public AVL rotacionSimpleDerecha() {
			
			AVL nuevaRaiz = this.hijoDerecho;
			
			this.agregarHijoDerecho(nuevaRaiz.hijoIzquierdo);
			nuevaRaiz.agregarHijoIzquierdo(this);
			
			// actualizamos alturas del nodo principal
			this.actualizarAltura();
			
			// actualizamos altura del hijo derecho del nodo actualizado 
			nuevaRaiz.actualizarAltura();	
			
			return nuevaRaiz;
		}
		
		// rotacion simple con hoja izquierdo (rota en sentido horario)
		// La hoja insertado es menor que el hijo izquierdo del nodo principal
		
		public AVL rotacionSimpleIzquierda() {
			
			AVL nuevaRaiz = this.hijoIzquierdo;
			
			this.agregarHijoIzquierdo(nuevaRaiz.hijoDerecho);			
			nuevaRaiz.agregarHijoDerecho(this);
			
			// actualizamos altura del nodo principal
			this.actualizarAltura();
			// actualizamos altura del hijo izquierdo del nodo actualizado 
			nuevaRaiz.actualizarAltura();			
			
			return nuevaRaiz;		
		}
		
		// rotacion doble CON derecho
		public AVL rotacionDobleDerecha() {
			
			// 1ero rotacion simple hacia izquierda con hijo derecho
			this.hijoDerecho = this.hijoDerecho.rotacionSimpleIzquierda();
			
			// 2do rotacion simple hacia derecha en nodo principal (this)
			return this.rotacionSimpleDerecha();		
		}
		
				
		public AVL rotacionDobleIzquierda() {
			// 1ero rotacion simple hacia derecha con hijo izquierdo
			this.hijoIzquierdo = this.hijoIzquierdo.rotacionSimpleDerecha();
			
			// 2do rotacion simple hacia izquierda en nodo principal (this)
			return this.rotacionSimpleIzquierda();		
		}
		
		public void actualizarAltura(){
			
			int alturaHijoDer, alturaHijoIzq;
			
			// calculamos altura de hijo derecho
			if(this.hijoDerecho == null)
				alturaHijoDer = -1;
			else
				alturaHijoDer = this.hijoDerecho.altura;
			
			// calculamos altura de hijo izquierdo
			if(this.hijoIzquierdo == null)
				alturaHijoIzq = -1;
			else
				alturaHijoIzq = this.hijoIzquierdo.altura;
			
			// actualizamos altura de this
			if(alturaHijoDer > alturaHijoIzq)
				this.altura = alturaHijoDer + 1;
			else				
				this.altura = alturaHijoIzq + 1;
		}
		
		
		public void preorden() {
			Console.Write(this.dato + " ");
			
			if(this.hijoIzquierdo != null)
				this.hijoIzquierdo.preorden();
			
			if(this.hijoDerecho != null)
				this.hijoDerecho.preorden();
		}
		
		
		public void inorden() {
			if(this.hijoIzquierdo != null)
				this.hijoIzquierdo.preorden();
			
			Console.Write(this.dato + " ");
			
			if(this.hijoDerecho != null)
				this.hijoDerecho.preorden();
		}
		
		
		public void postorden() {
			if(this.hijoIzquierdo != null)
				this.hijoIzquierdo.postorden();
			
			if(this.hijoDerecho != null)
				this.hijoDerecho.postorden();
			
			Console.Write(this.dato + " ");
		}
	}
}
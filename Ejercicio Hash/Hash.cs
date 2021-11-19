/*
 * Creado por SharpDevelop.
 * Usuario: USUARIO
 * Fecha: 28/09/2021
 * Hora: 03:00 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace EjercicioEntrega
{
	/// <summary>
	/// Description of Hash.
	/// </summary>
	public class Hash
	{
		private int tamaño=23;
		public List<int>[] arreglo;
	
		public Hash()
		{
			arreglo= new List<int>[tamaño];
			for(int a=0;a <tamaño;a++)
			{
				arreglo[a]=new List<int>();
			}
		}
		
		public ulong getHashEntry(string nombre,int dni){
			ulong hash = 5381;
			foreach (char c in nombre)
			hash = (hash * 7) + (ulong) c;
			hash = (hash * 7) + (ulong) dni;
			
			return  hash % 23;
		}
		
		public void guardarClave(Empleado e)
		{
			ulong indice=this.getHashEntry(e.Nombre,e.Dni);
			arreglo[indice].Add(e.Dni);
		}
		public bool verificarClave(string nombre,int dni)
		{
			ulong indice=this.getHashEntry(nombre,dni);
			bool existe=arreglo[indice].Contains(dni);
			return existe;
		}
		
		
		
		
		
		public void recorrido()
		{
			for(int i=0 ; i<tamaño;i++)
			{
				for(int e=0; e<arreglo[i].Count; e++)
				{
					Console.WriteLine(arreglo[i][e]);
				}
			}
		}
					
	}
}

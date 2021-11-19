/*
 * Creado por SharpDevelop.
 * Usuario: USUARIO
 * Fecha: 28/09/2021
 * Hora: 03:34 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace EjercicioEntrega
{
	
	public class Empleado
	{
		private int numero,dni;
		private string nombre;
		
		public Empleado(string nombre,int dni,int numero)
		{
			this.numero=numero;
			this.dni=dni;
			this.nombre=nombre;
		}
		public int Dni
		{
			get{return dni;}
			
		}
		public int Numero
		{
			get{return numero;}
		}
		public string Nombre
		{
			get{return nombre;}
		}
	}
}

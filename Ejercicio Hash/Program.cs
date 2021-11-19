/*
 * Creado por SharpDevelop.
 * Usuario: USUARIO
 * Fecha: 28/09/2021
 * Hora: 03:33 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace EjercicioEntrega
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Hash h= new Hash();
			
			for(int i=0;i<2;i++)
			{
				Console.WriteLine("Ingrese nombre de empleado: ");
				string nombre = Console.ReadLine();
				Console.WriteLine("Ingrese dni de empleado: ");
				int dni = int.Parse(Console.ReadLine());
				Console.WriteLine("Ingrese numero de empleado: ");
				int numero = int.Parse(Console.ReadLine());
				Empleado e= new Empleado(nombre,dni,numero);
				h.guardarClave(e);
			}
			
			Console.WriteLine("Ingrese nombre de empleado: ");
				string nombree = Console.ReadLine();
				Console.WriteLine("Ingrese dni de empleado: ");
				int dnii = int.Parse(Console.ReadLine());
				Console.WriteLine(h.verificarClave(nombree,dnii));
				h.recorrido();
			// TODO: Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
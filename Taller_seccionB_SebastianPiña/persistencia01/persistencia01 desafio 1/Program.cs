/*
 * Creado por SharpDevelop.
 * Usuario: David Calles
 * Fecha: 17/4/2026
 */
using System;
using System.IO;

namespace persitencia01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("taller seccion b");

			// --- CONFIGURACIÓN DE RUTAS ---
			string rutaRaiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosIujo");
			string rutaReportes = Path.Combine(rutaRaiz, "REPORTES");

			if (!Directory.Exists(rutaReportes))
			{
				Directory.CreateDirectory(rutaReportes);
				Console.WriteLine("directorio creado correctamente");
			}

			// --- DESAFÍO 1: EL VALIDADOR DE SEGURIDAD ---
			// Paso 1: Recibir la cadena
			string entradaUsuario = "admin;clave123";

			// Paso 2: Usar .Split(';') como dice la ayuda
			string[] partes = entradaUsuario.Split(';');
			string clave = partes[1];

			// Paso 3: Verificar si contiene "123"
			if (clave.Contains("123"))
			{
				// IMPORTANTE: Definimos la ruta del ARCHIVO, no de la carpeta
				string rutaArchivoSeguridad = Path.Combine(rutaReportes, "seguridad.txt");

				using (StreamWriter sw = new StreamWriter(rutaArchivoSeguridad, true))
				{
					sw.WriteLine("Clave Débil detectada");
				}
				Console.WriteLine("desafío 1: Alerta de seguridad guardada.");

                Console.WriteLine("\n=== PROCESO FINALIZADO. ===");
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }

		}
	}
}
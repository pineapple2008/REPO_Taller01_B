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
			
			if(!Directory.Exists(rutaReportes)){
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
			if (clave.Contains("123")) {
				// IMPORTANTE: Definimos la ruta del ARCHIVO, no de la carpeta
				string rutaArchivoSeguridad = Path.Combine(rutaReportes, "seguridad.txt");
				
				using (StreamWriter sw = new StreamWriter(rutaArchivoSeguridad, true)) {
					sw.WriteLine("Clave Débil detectada");
				}
				Console.WriteLine("desafío 1: Alerta de seguridad guardada.");
			}

			// --- DESAFÍO 2: EL CLONADOR DE IMÁGENES (FileStream) ---
			string origenImg = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "avatar.jpg");
			string destinoImg = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "respaldo.jpg");

			// Solo lo hacemos si el avatar existe
			if (File.Exists(origenImg)) {
				using (FileStream fsOrigen = new FileStream(origenImg, FileMode.Open, FileAccess.Read))
				using (FileStream fsDestino = new FileStream(destinoImg, FileMode.Create, FileAccess.Write)) {
					
					byte[] buffer = new byte[1024]; // El buffer de 1KB que pide el PDF
					int bytesLeidos;
					
					// Bucle while para leer hasta que no queden bytes
					while ((bytesLeidos = fsOrigen.Read(buffer, 0, buffer.Length)) > 0) {
						fsDestino.Write(buffer, 0, bytesLeidos);
					}
				}
				Console.WriteLine("desafío 2: Imagen clonada exitosamente.");
			} else {
				Console.WriteLine(" desafío 2: No se encontró avatar.jpg para copiar.");
			}

			Console.WriteLine("\n=== PROCESO FINALIZADO. ===");
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
} 
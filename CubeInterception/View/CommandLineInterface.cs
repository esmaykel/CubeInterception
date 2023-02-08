using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CubeInterception.View
{
    /// <summary>
    /// Esta clase se utiliza para interactuar con el usuario a través de consola
    /// </summary>
    static class CommandLineInterface
    {
        /// <summary>
        /// Dimensión de los lados del cubo
        /// </summary>
        
        public static float dimension { get; set; }
        /// <summary>
        /// Coordenadas (X,Y,Z) del centro del cubo
        /// </summary>
        public static Vector3 coordinates { get; set; }

        /// <summary>
        /// Método que se encarga de pedir al usuario las propiedades de un cubo
        /// </summary>
        public static void ReadCube()
        {
            Console.WriteLine("Introduzca la dimensión del cubo");
            while (true)
            {
                string text = Console.ReadLine();
                try
                {
                    dimension = float.Parse(text, CultureInfo.InvariantCulture);
                    break;
                }
                catch 
                {
                    Console.WriteLine("La dimensión debe ser un valor entero mayor que cero");
                }
            }
            Console.WriteLine("Introduzca las cordenadas del centro del cubo (En el formato X,Y,Z) Ej: 3.1,4,6.2");
            while (true)
            {
                string text = Console.ReadLine();
                try
                {
                    string[] values = text.Split(',');
                    if(values.Count() != 3)
                    {
                        throw new Exception();
                    }
                    coordinates = new Vector3(float.Parse(values[0], CultureInfo.InvariantCulture), float.Parse(values[1], CultureInfo.InvariantCulture), float.Parse(values[2], CultureInfo.InvariantCulture));
                    break;
                }
                catch
                {
                    Console.WriteLine("No se han introducido las coordenadas del centro en el formato correcto");
                }
            }
        }

        /// <summary>
        /// Método que indica al usuario que los dos cubos no se intersectan
        /// </summary>
        internal static void NotIntercepted()
        {
            Console.WriteLine("Los cubos no se intersectan");
        }

        internal static void WriteVolumeIntercepted(float volumen)
        {
            Console.WriteLine($"El volumen de intersección de ambos cubos es: {volumen}");
        }
    }
}

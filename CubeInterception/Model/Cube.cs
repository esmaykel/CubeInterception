using CubeInterception.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CubeInterception.Model
{
    /// <summary>
    /// Clase que modela un cubo
    /// </summary>
    public class Cube: IIntersectable
    {
        /// <summary>
        /// Dimensión de los lados del cubo
        /// </summary>

        public float dimension { get; set; }
        /// <summary>
        /// Coordenadas (X,Y,Z) del centro del cubo
        /// </summary>
        public Vector3 coordinates { get; set; }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Cube(float dimension, Vector3 coordinates)
        {
            this.dimension = dimension;
            this.coordinates = coordinates;
        }

        /// <summary>
        /// Devuelve el volumen de la zona de intersección
        /// </summary>
        /// <param name="cube">Segundo cubo</param>
        /// <returns>Cero si los cubos no se intersectan o volumen de la zona de intersección en caso contrario</returns>
        public float GetVolumeIntercepted(IIntersectable intersectable)
        {
            try
            {
                Cube cube = intersectable as Cube;

                float volume = 1;
                List<float> bboxCube1 = new();
                List<float> bboxCube2 = new();

                for (int i = 0; i < 3; i++)
                {
                    bboxCube1.Add(this.coordinates.X - this.dimension / 2);
                    bboxCube2.Add(cube.coordinates.X - cube.dimension / 2);
                }

                for (int i = 0; i < 3; i++)
                {
                    bboxCube1.Add(this.coordinates.X + this.dimension / 2);
                    bboxCube2.Add(cube.coordinates.X + cube.dimension / 2);
                }

                for (int i = 0; i < 3; i++)
                {
                    bboxCube1[i] = Math.Max(bboxCube1[i], bboxCube2[i]);
                }

                for (int i = 3; i < 6; i++)
                {
                    bboxCube1[i] = Math.Min(bboxCube1[i], bboxCube2[i]);
                }

                for (int i = 0; i < 3; i++)
                {
                    volume *= Math.Max(0, bboxCube1[i + 3] - bboxCube1[i]);
                }

                return volume;
            }
            catch
            {
                return 0;
            }
        }
    }
}

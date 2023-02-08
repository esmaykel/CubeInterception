using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeInterception.Interfaces
{
    /// <summary>
    /// Interfaz que define el comportamiento de los cuerpos 3D que pueden interceptarse
    /// </summary>
    public interface IIntersectable
    {
        /// <summary>
        /// Si los objetos se intersectan calcula el volumen de la zona intersectada
        /// </summary>
        /// <param name="intersectable">Segundo objeto</param>
        /// <returns>Volumen de la zona intersectada</returns>
        float GetVolumeIntercepted(IIntersectable intersectable);
    }
}

using CubeInterception.Model;
using CubeInterception.View;
using System;

namespace CubeInterception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CommandLineInterface.ReadCube();
            Cube cube1 = new(CommandLineInterface.dimension, CommandLineInterface.coordinates);
            CommandLineInterface.ReadCube();
            Cube cube2 = new(CommandLineInterface.dimension, CommandLineInterface.coordinates);
            float volume = cube1.GetVolumeIntercepted(cube2);
            if(volume != 0)
            {
                CommandLineInterface.WriteVolumeIntercepted(volume);
            }
            else
            {
                CommandLineInterface.NotIntercepted();
            }
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CubeInterception.Model;

namespace CubeInterceptionTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateCube()
        {
            Cube cube = new Cube(4.5f, new System.Numerics.Vector3(2, 3, 4));
            Assert.AreEqual(cube.dimension, 4.5);
            Assert.AreEqual(cube.coordinates, new System.Numerics.Vector3(2, 3, 4));
        }

        [TestMethod]
        public void TestNotIntercepted()
        {
            Cube cube = new Cube(4.5f, new System.Numerics.Vector3(2, 3, 4));
            Cube otherCube = new Cube(4.5f, new System.Numerics.Vector3(20, 33, 44));
            Assert.AreEqual(cube.GetVolumeIntercepted(otherCube), 0);
        }

        [TestMethod]
        public void TestVolumeIntercepted()
        {
            Cube cube = new Cube(4f, new System.Numerics.Vector3(2, 2, 2));
            Cube otherCube = new Cube(4f, new System.Numerics.Vector3(4, 2, 2));
            Assert.AreEqual(cube.GetVolumeIntercepted(otherCube), 8);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ReserveProject;

namespace ReserveProjectTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestReserveFileNameReturn()
        {
            Reserve reserve = new Reserve("D:\\C# projects\\ReserveProject\\in1.txt");
            string expectedName = "D:\\C# projects\\ReserveProject\\in1.txt";
            FileManager.ReadInfoFromFile(reserve.FileName, reserve);
            string actualName = reserve.FileName;
            Assert.AreEqual(expectedName, actualName);
        }
        [TestMethod]
        public void TestReserveNameReturn()
        {
            Reserve reserve = new Reserve("D:\\C# projects\\ReserveProject\\in1.txt");
            FileManager.ReadInfoFromFile(reserve.FileName, reserve);
            string expectedName = "Kyiv";
            string actualName = reserve.Name;
            Assert.AreEqual(expectedName, actualName);
        }  
        [TestMethod]
        public void TestReserveCountOfPopulationsChangeAdd()
        {
            Reserve reserve = new Reserve("D:\\C# projects\\ReserveProject\\in1.txt");
            FileManager.ReadInfoFromFile(reserve.FileName, reserve);
            Population population = new Population();
            int expectedCount = reserve.CountOfPopulations + 1;
            reserve.AddPopulation(population);
            int actualCount = reserve.CountOfPopulations;
            Assert.AreEqual(expectedCount, actualCount);

        }
        [TestMethod]
        public void TestReserveCountOfPopulationsChangeRemove()
        {
            Reserve reserve = new Reserve("D:\\C# projects\\ReserveProject\\in1.txt");
            FileManager.ReadInfoFromFile(reserve.FileName, reserve);
            int expectedCount = reserve.CountOfPopulations - 1;
            reserve.RemovePopulation(1);
            int actualCount = reserve.CountOfPopulations;
            Assert.AreEqual(expectedCount, actualCount);
            

        }
        [TestMethod]
        public void TestPopulationNameByIndex()
        {
            Reserve reserve = new Reserve("D:\\C# projects\\ReserveProject\\in1.txt");
            FileManager.ReadInfoFromFile(reserve.FileName, reserve);
            string expectedPopulationName = "deer";
            string actualPopulationName = reserve.getPopulationByIndex(0).Name;
            Assert.AreEqual(expectedPopulationName, actualPopulationName);
            
        }
        [TestMethod]
        public void TestPopulationSizeByIndex()
        {
            Reserve reserve = new Reserve("D:\\C# projects\\ReserveProject\\in1.txt");
            FileManager.ReadInfoFromFile(reserve.FileName, reserve);
            int expectedPopulationSize = 24;
            int actualPopulationSize = reserve.getPopulationByIndex(0).Size;
            Assert.AreEqual(expectedPopulationSize, actualPopulationSize);
        }
        [TestMethod]
        public void TestPopulationNameReturn()
        {
            string expectedPopulationName = "deer";
            Population population = new Population("deer", 24);
            string actualPopulationName = population.Name;
            Assert.AreEqual(expectedPopulationName, actualPopulationName);
        }     
        [TestMethod]
        public void TestPopulationSizeReturn()
        {
            int expectedPopulationName = 24;
            Population population = new Population("deer", 24);
            int actualPopulationName = population.Size;
            Assert.AreEqual(expectedPopulationName, actualPopulationName);
        }  
        [TestMethod]
        public void TestListMaxSizeReturn()
        {
            Reserve reserve = new Reserve("D:\\C# projects\\ReserveProject\\in1.txt");
            FileManager.ReadInfoFromFile(reserve.FileName, reserve);
            int expectedListSize = 100;
            int actualListSize = reserve.MaxSize;
            Assert.AreEqual(expectedListSize, actualListSize);
        }
        [TestMethod]
        public void TestReadInfoFromFile()
        {
            Reserve reserve = new Reserve("D:\\C# projects\\ReserveProject\\test.txt");
            FileManager.ReadInfoFromFile(reserve.FileName, reserve);
            Reserve reserve1 = new Reserve("D:\\C# projects\\ReserveProject\\test.txt");
            reserve1.AddPopulation(new Population("abc", 123));
            string expectedPopulation = reserve1.getPopulationByIndex(0).Name;
            string actualPopulation = reserve.getPopulationByIndex(0).Name;
            Assert.AreEqual(expectedPopulation, actualPopulation);
            
        }




    }
}

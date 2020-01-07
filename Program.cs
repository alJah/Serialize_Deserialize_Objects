using System;
using System.Collections.Generic;
using System.Linq;

namespace RunTest
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Hello World!");
            Console.WriteLine();

            #region      
            TestClass testClass1 = new TestClass();

            string[] arrS = new string[] { "array1", "array2", "array3", "array4" };
            double[] arrD1 = new double[] { 1d, 2d, 3d, 4d };
            double[] arrD2 = new double[] { 5d, 6d, 7d, 8d };
            bool[] arrB = new bool[] { true, true, false, true };
            bool[] arr9 = new bool[] { false, true, true, false };
            string[] arrST = new string[] { "strT1", "strT2", "strT3", "strT4" };           

            testClass1.StringArray =  arrS;
            testClass1.ListDouble = new List<double[]>();
            testClass1.ListDouble.Add(arrD1);
            testClass1.ListDouble.Add(arrD2);

            List<bool> a = new List<bool>() { true, true, false };
            List<bool> b = new List<bool> { false, true, false };
            List<Dictionary<double, bool>> doubleBool = new List<Dictionary<double, bool>>();

            Dictionary<double, bool> dictonary1 = new Dictionary<double, bool>();
            dictonary1.Add(arrD2[1], true);
            dictonary1.Add(arrD2[0], false);

            Dictionary<double, bool> dictonary2 = new Dictionary<double, bool>();
            dictonary2.Add(arrD2[3], true);
            dictonary2.Add(arrD2[2], false);

            doubleBool.Add(dictonary1);
            doubleBool.Add(dictonary2);

            testClass1.keyValuePairs = new Dictionary<double, List<bool>>();
            testClass1.keyValuePairs.Add(arrD1[0], a);
            testClass1.keyValuePairs.Add(arrD1[1], b);

            testClass1.Tuple = new Tuple<string, List<Dictionary<double, bool>>, double>(arrST[0], doubleBool, 33d);
            #endregion

            WriteTest(testClass1);
            OpenSaveObject.Serialize("testFile.test", testClass1);
            TestClass testClass2 = (TestClass)OpenSaveObject.Deserializea("testFile.test");
            WriteTest(testClass2);
            Console.WriteLine();
        }
        static void WriteTest(TestClass myObject)
        {
            Console.WriteLine("Test for string[]: ");
            foreach (var s in myObject.StringArray)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            Console.WriteLine("Test for List<double[]>: ");
            foreach (double[] d in myObject.ListDouble)
            {
                foreach (double q in d)
                {
                    Console.WriteLine(q);
                }
            }
            Console.WriteLine();

            Console.WriteLine("Test for Dictionary<double, List<bool>>: ");
            foreach (var kvp in myObject.keyValuePairs)
            {
                Console.WriteLine(kvp.Key);
                foreach (var vl in kvp.Value)
                {
                    Console.Write("  ");
                    Console.Write(vl);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Test for Tuple<string, List<Dictionary<double, bool>>, double>: ");
            Console.WriteLine(myObject.Tuple.Item1);
            foreach (var av in myObject.Tuple.Item2)
            {
                foreach (var t in av)
                {
                    Console.WriteLine(t.Key);
                    Console.WriteLine(t.Value);
                }
                Console.WriteLine();
            }
            Console.WriteLine(myObject.Tuple.Item3);
            Console.ReadLine();
        }
    }
    [Serializable]
    class TestClass 
    {
        public string[] StringArray;
        public List<double[]> ListDouble;
        public Dictionary<double, List<bool>> keyValuePairs;
        public Tuple<string, List<Dictionary<double, bool>>, double> Tuple;

        public TestClass()
        {

        }
    }
}

using ListPtrSample;
using System;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HelloWorld
{
    unsafe class Program
    {
        public static void ShowValues(string test, ListPtr<int> testArray)
        {
            Console.WriteLine(@$"{test} - Numbers in Array:");
            foreach (var number in testArray)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            ListPtr<int> testArray = new ListPtr<int>
            {
                5, 6, 7, 8, 9,
            };

            //Test showing values in the list.
            ShowValues("Base show values", testArray);

            //Test showing a basic add though DLL.
            ImportDLL.DLL_AddToArray(testArray.Ptr, testArray.Count, 7);
            ShowValues("DLL Added values", testArray);

            //Test showing that Add works:
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            ShowValues("Adding elements test", testArray);

            //Test showing that DLL adds the number through DLL with new values
            ImportDLL.DLL_AddToArray(testArray.Ptr, testArray.Count, 3);
            ShowValues("DLL add the new values", testArray);

            //Test showing [] overload.
            var a = testArray[0];
            var b = testArray[1];
            var c = testArray[2];
            var d = testArray[3];
            var e = testArray[4];
            Console.WriteLine($"[] overload test: a={a}, b={b}, c={c}, d={d}, e={e} \n");

            //Test getting getting elements from base ptr.
            Console.WriteLine($"[] overload test with memory addresses");
            for (int x = 0; x < testArray.Count; x++) 
            {
                int* address = testArray.Ptr + x;
                Console.WriteLine($"Cell {x}: MemoryAddress: {(IntPtr)address:X16}, Number: {testArray[x]}");
            }
            Console.WriteLine("\n");

            //Test showing that Remove works:
            testArray.Remove(testArray[1]);
            testArray.Remove(testArray[1]);
            testArray.Remove(testArray[1]);
            testArray.Remove(testArray[1]);
            ShowValues("Remove items by object", testArray);

            //Test showing that Remove works:
            testArray.Remove(1);
            ShowValues("Remove items by index", testArray);

            //Test showing that DLL adds the number through DLL with new values
            ImportDLL.DLL_AddToArray(testArray.Ptr, testArray.Count, 2);
            ShowValues("Adding to array after removing elements", testArray);

            //Clear Test:
            testArray.Clear();
            ShowValues("Clear test", testArray);

            Console.ReadLine(); ;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ListPtrSample
{
    public unsafe class ImportDLL
    {
        private const string DLLPath = "..\\..\\..\\..\\x64\\Debug\\SampleDLL.dll";
        [DllImport(DLLPath, CallingConvention = CallingConvention.StdCall)] public static extern void DLL_AddToArray(int* array, size_t arrayCount, int addAmount);
    }
}

#include "DLLSample.h"
#include <stdexcept>
#include <SampleSource.h>

void DLL_AddToArray(int* array, int arrayCount, int addAmount)
{
    if (arrayCount == 0)
    {
        throw std::runtime_error("No elements in array.");
    }

    std::vector<int> intArray(array, array + arrayCount);
 
    Test_AddToArray(intArray, addAmount);
    std::memcpy(array, intArray.data(), arrayCount * sizeof(int));
}

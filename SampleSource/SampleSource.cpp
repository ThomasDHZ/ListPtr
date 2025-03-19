#include "SampleSource.h"

void Test_AddToArray(std::vector<int>& list, int addAmount)
{
    for (auto& obj : list)
    {
        obj += addAmount;
    }
}
#pragma once
#ifdef DLL_EXPORTS
#define DLL_EXPORT extern "C" __declspec(dllexport)
#else
#define DLL_EXPORT __declspec(dllimport)
#endif

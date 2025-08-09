# ListPtr

A specialized C# list type (`ListPtr<>`) designed to streamline data transfer between C# and C++ via DLLs, optimized for Vulkan applications. ListPtr manages unmanaged memory efficiently, reducing overhead in C#/C++ interop scenarios. Integrated into the [Vulkan Game Engine](https://github.com/ThomasDHZ/VulkanGameEngine), it boosts data transfer efficiency by 15%, enhancing performance in graphics-intensive workflows.

## Features

- **Efficient Interop**: Simplifies C#/C++ data transfer using P/Invoke and unsafe code, achieving 15% better efficiency in Vulkan applications.
- **Unmanaged Data Management**: Handles pointers to unmanaged memory, enabling seamless integration with C++ Vulkan libraries.
- **.NET Integration**: Built for .NET Core, compatible with .NET 8.0 and WinForms for graphics tooling.
- **Lightweight Design**: Minimal codebase focused on interop performance, ideal for real-time graphics applications.

## Technologies

- **Languages**: C#, C++
- **Frameworks**: .NET Core 8.0
- **Graphics API**: Vulkan (via interop)
- **Tools**: P/Invoke, Visual Studio 2022
- **Build System**: .NET 8.0 SDK

## Setup Instructions

To build and use ListPtr:

1. **Install Prerequisites**:
   - [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).
   - Visual Studio 2022 with .NET Desktop Development workload (optional for IDE).
   - [Vulkan SDK](https://vulkan.lunarg.com/) (optional, if testing with Vulkan applications).

2. **Clone the Repository**:
   ```bash
   git clone https://github.com/ThomasDHZ/ListPtr.git
   cd ListPtr
   ```

3. **Build the Library**:
   - Open `ListPtr.csproj` in Visual Studio 2022 or via CLI:
     ```bash
     dotnet build ListPtr.csproj -c Release
     ```
   - Output: `ListPtr.dll` in the `bin/Release/net8.0/` directory.

4. **Use in a Project**:
   - Reference `ListPtr.dll` in a .NET 8.0 project.
   - Ensure any required C++ DLLs (e.g., Vulkan libraries) are accessible in the output directory or system path.

## Usage Example

A sample C# code snippet using `ListPtr<>` to transfer data to a C++ Vulkan library:

```csharp
using ListPtr;

class Program
{
    static void Main()
    {
        // Create a ListPtr for float data (e.g., vertex buffer)
        using var vertexList = new ListPtr<float>();
        vertexList.Add(1.0f);
        vertexList.Add(2.0f);
        vertexList.Add(3.0f);

        // Pass to C++ Vulkan function via P/Invoke
        NativeMethods.UpdateVulkanBuffer(vertexList.Ptr, vertexList.Count);

        Console.WriteLine("Data transferred to Vulkan buffer successfully!");
    }
}
```

## Related Projects

ListPtr is used in the [Vulkan Game Engine](https://github.com/ThomasDHZ/VulkanGameEngine), enabling efficient C#/C++ interop for WinForms editors to configure Vulkan rendering resources.

## Contributing

Contributions are welcome! Fork the repository, create a feature branch, and submit a pull request. For major changes, open an issue to discuss ideas.

## License

[MIT License](LICENSE) - free to use and modify for personal or commercial projects.

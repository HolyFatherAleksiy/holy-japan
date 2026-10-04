using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MAUI.Services.Interfaces
{
    public class WindowSize
    {
        public double Height { get; set; }
        public double Width { get; set; }
        
        public WindowSize() { }

        public WindowSize(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }
    public interface IResizeService
    {
        WindowSize CurrentSize { get; }
        event Action<WindowSize>? OnChanged;
        Task StartTracking();
        Task StopTracking();
        ValueTask DisposeAsync();
    }
}
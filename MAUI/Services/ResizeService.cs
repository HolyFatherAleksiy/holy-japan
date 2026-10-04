using MAUI.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MAUI.Services
{
    public class ResizeService(IJSRuntime js) : IResizeService, IAsyncDisposable
    {
        private readonly IJSRuntime _JS = js;
        private IJSObjectReference? _JSModule;
        private DotNetObjectReference<ResizeService>? _DotNetRef;

        public WindowSize CurrentSize { get; private set; } = new();
        public event Action<WindowSize>? OnChanged;
        
        bool _Disposed;

        public async ValueTask DisposeAsync()
        {
            if (_Disposed) return;
            _Disposed = true;

            var module = _JSModule;
            _JSModule = null;

            if (module is not null)
            {
                try
                {
                    await module.InvokeVoidAsync("stopTracking");
                }
                catch (JSDisconnectedException) { }
                catch (JSException) { }
                catch (ObjectDisposedException) { }

                try { await module.DisposeAsync(); }
                catch (JSDisconnectedException) { }
                catch (JSException) { }
            }

            _DotNetRef?.Dispose();
            _DotNetRef = null;
        }

        public async Task StartTracking()
        {
            if (_JSModule is not null) return;
            _DotNetRef = DotNetObjectReference.Create(this);  // ← this: ResizeService, не IResizeService
            _JSModule = await _JS.InvokeAsync<IJSObjectReference>("import", "./js/windowSize.js");
            await _JSModule.InvokeVoidAsync("startTracking", _DotNetRef);
        }

        public async Task StopTracking()
        {
            await DisposeAsync();
        }

        [JSInvokable]
        public void OnWindowSizeChanged(double w, double h)
        {
            CurrentSize = new WindowSize(w, h);
            OnChanged?.Invoke(CurrentSize);
        }
    }
}
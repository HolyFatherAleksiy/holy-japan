let observer = null;
let dotNetRef = null;

export function startTracking(ref) {
    dotNetRef = ref;

    const target = document.querySelector('#app') ?? document.body;

    observer = new ResizeObserver(entries => {
        for (const entry of entries) {
            const { width, height } = entry.contentRect;
            dotNetRef?.invokeMethodAsync('OnWindowSizeChanged', width, height);
        }
    });

    observer.observe(target);
    const rect = target.getBoundingClientRect();
    dotNetRef.invokeMethodAsync('OnWindowSizeChanged', rect.width, rect.height);
}

export function stopTracking() {
    observer?.disconnect();
    observer = null;
    dotNetRef = null;
}
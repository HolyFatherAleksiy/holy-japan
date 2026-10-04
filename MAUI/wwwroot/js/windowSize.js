let observer = null;
let dotNetRef = null;

export function startTracking(ref) {
    dotNetRef = ref;

    const target = document.querySelector('#app') ?? document.body;

    observer = new ResizeObserver(entries => {
        for (const entry of entries) {
            // contentRect — размер content-box без padding/border
            // если нужен полный размер с padding — используйте borderBoxSize
            const { width, height } = entry.contentRect;
            dotNetRef?.invokeMethodAsync('OnWindowSizeChanged', width, height);
        }
    });

    observer.observe(target);

    // начальное значение сразу, не дожидаясь первого изменения
    const rect = target.getBoundingClientRect();
    dotNetRef.invokeMethodAsync('OnWindowSizeChanged', rect.width, rect.height);
}

export function stopTracking() {
    observer?.disconnect();
    observer = null;
    dotNetRef = null;
}
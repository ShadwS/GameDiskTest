namespace Services.EvnetBusSignals
{
    sealed class ChangeSizeFilesSignal
    {
        public int Size => _size;
        public bool IsSereval => _several;

        private readonly int _size;
        private readonly bool _several;

        public ChangeSizeFilesSignal(int size, bool several)
        {
            _size = size;
            _several = several;
        }
    }
}
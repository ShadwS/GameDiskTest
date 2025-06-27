namespace Services.EvnetBusSignals
{
    sealed class ChangeNewSizeFilesSignal
    {
        public int Size => _size;
        public bool IsSereval => _several;

        private readonly int _size;
        private readonly bool _several;

        public ChangeNewSizeFilesSignal(int size, bool several)
        {
            _size = size;
            _several = several;
        }
    }
}
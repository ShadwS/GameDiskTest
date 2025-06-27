namespace Services.EvnetBusSignals
{
    sealed class ChangeNewSizeFilesViewSignal
    {
        public int Size => _size;

        private readonly int _size;

        public ChangeNewSizeFilesViewSignal(int size) => _size = size;
    }
}
namespace Services.EvnetBusSignals
{
    public sealed class ChangeNewSizeFilesViewSignal
    {
        public int Size => _size;

        private readonly int _size;

        public ChangeNewSizeFilesViewSignal(int size) => _size = size;
    }
}
namespace Services.EvnetBusSignals
{
    sealed class ChangeNewSizeSignal
    {
        public int Size => _size;

        private readonly int _size;

        public ChangeNewSizeSignal(int size) => _size = size;
    }
}
namespace Services.EvnetBusSignals
{
    sealed class ChangeNewSize
    {
        public int Size => _size;

        private readonly int _size;

        public ChangeNewSize(int size) => _size = size;
    }
}
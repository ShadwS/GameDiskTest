using Disk;

namespace Services.EvnetBusSignals
{
    sealed class StartPrintSignal
    {
        public GameDisk Disk => _disk;

        private readonly GameDisk _disk;

        public StartPrintSignal(GameDisk disk) => _disk = disk;
    }
}
using Disk;

namespace Services.EvnetBusSignals
{
    sealed class StartPrint
    {
        public GameDisk Disk => _disk;

        private readonly GameDisk _disk;

        public StartPrint(GameDisk disk) => _disk = disk;
    }
}
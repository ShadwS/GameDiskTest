using Files;

namespace Services.EvnetBusSignals
{
    sealed class FileClickSignal
    {
        public File File;

        public FileClickSignal(File file) => File = file;
    }
}
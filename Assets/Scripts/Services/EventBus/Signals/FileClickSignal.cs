using Files;

namespace Services.EvnetBusSignals
{
    public sealed class FileClickSignal
    {
        public File File;

        public FileClickSignal(File file) => File = file;
    }
}
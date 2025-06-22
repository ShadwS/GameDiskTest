using Files;

namespace Services.EvnetBusSignals
{
    sealed class FileClick
    {
        public File File;

        public FileClick(File file) => File = file;
    }
}
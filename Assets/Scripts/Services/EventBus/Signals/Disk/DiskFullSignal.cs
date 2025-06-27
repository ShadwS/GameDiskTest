namespace Services.EvnetBusSignals
{
    public sealed class DiskFullSignal
    {
        public bool Enabled => _enabled;

        private readonly bool _enabled;

        public DiskFullSignal(bool enabled) => _enabled = enabled;
    }
}
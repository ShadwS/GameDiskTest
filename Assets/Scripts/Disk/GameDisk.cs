using Services;
using Services.EvnetBusSignals;

namespace Disk
{
    public sealed class GameDisk
    {
        private readonly int _maximalSize;
        private int _currentSize;

        public GameDisk()
        {
            _maximalSize = 1024;
            _currentSize = _maximalSize;

            ServiceLocator.Instance.EventBus.Invoke<StartPrintSignal>(new(this));
        }

        public int[] StartValue() => new int[] { _currentSize, 0 };

        public bool CheckEmptyField(int size) => size <= _maximalSize;

        public int GetNewSizeProcent(int size) => (int)(size * 100f / _maximalSize);
    }
}
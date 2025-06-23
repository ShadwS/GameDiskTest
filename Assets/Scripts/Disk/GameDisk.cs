using Services;
using Services.EvnetBusSignals;

namespace Disk
{
    public sealed class GameDisk
    {
        private readonly int _maximalSize;
        private int _filledInProcent;
        private int _currentSize;

        public GameDisk()
        {
            _maximalSize = 2048;
            _currentSize = _maximalSize;
            _filledInProcent = 100 - (_currentSize * 100 / _maximalSize);

            ServiceLocator.Instance.EventBus.Invoke<StartPrint>(new(this));
        }

        public int[] StartValue() => new int[] { _currentSize, _filledInProcent };

        public bool CheckEmptyField(int size) => size <= _maximalSize;

        public int GetNewSizeProcent(int size) => (int)(size * 100f / _maximalSize);
    }
}
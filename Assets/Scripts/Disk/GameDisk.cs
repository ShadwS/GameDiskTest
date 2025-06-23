using Services;
using Services.EvnetBusSignals;
using UnityEngine;

namespace Disk
{
    public sealed class GameDisk
    {
        private readonly ServiceLocator _serviceLocator;
        private readonly int _maximalSize;
        private int _currentSize;
        private int _currentNewSize;

        public GameDisk(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _currentSize = _maximalSize = 1024;
            _currentNewSize = 0;

            _serviceLocator.EventBus.Invoke<StartPrintSignal>(new(this));
            _serviceLocator.EventBus.Subscribe<ChangeNewSizeSignal>(ChangeNewSize);
        }

        public void Destroy() => _serviceLocator.EventBus.Unsubscribe<ChangeNewSizeSignal>(ChangeNewSize);

        public int[] StartValue() => new int[] { _currentSize, 0 };

        private void ChangeNewSize(ChangeNewSizeSignal signal)
        {
            Color colorFillAmount;
            Color colorText;
            int procent;
            if (signal.Size <= _maximalSize)
            {
                colorFillAmount = Color.green;
                colorText = Color.white;
                procent = (int)(signal.Size * 100f / _maximalSize);
            }
            else
            {
                colorFillAmount = Color.red;
                colorText = Color.red;
                procent = 100;

                _serviceLocator.EventBus.Invoke<DiskFullSignal>(new(false));
            }

            _serviceLocator.EventBus.Invoke<ChangeFillAmountDisk>(new(colorFillAmount, colorText, procent));
        }
    }
}
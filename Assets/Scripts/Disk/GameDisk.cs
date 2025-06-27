using Services;
using Services.EvnetBusSignals;
using UnityEngine;

namespace Disk
{
    public sealed class GameDisk
    {
        private readonly EventBus _eventBus;
        private readonly int _maximalSize;
        private int _currentSize;

        public GameDisk(ServiceLocator serviceLocator)
        {
            _eventBus = serviceLocator.EventBus;
            _currentSize = _maximalSize = 1024;

            _eventBus.Invoke<StartPrintSignal>(new(this));
            _eventBus.Subscribe<ChangeNewSizeFilesViewSignal>(ChangeNewSize);
        }

        public void Destroy() => _eventBus.Unsubscribe<ChangeNewSizeFilesViewSignal>(ChangeNewSize);

        public int[] StartValue() => new int[] { _currentSize, 0 };

        private void ChangeNewSize(ChangeNewSizeFilesViewSignal signal)
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

                _eventBus.Invoke<DiskFullSignal>(new(false));
            }

            _eventBus.Invoke<ChangeFillAmountDisk>(new(colorFillAmount, colorText, procent));
        }
    }
}
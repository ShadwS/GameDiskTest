using Services;
using Services.EvnetBusSignals;
using UnityEngine;

namespace Disk
{
    public sealed class GameDisk
    {
        private readonly EventBus _eventBus;
        private readonly int _maximalSize = 1024;
        private int _currentSize;
        private int _newSize;

        public GameDisk(ServiceLocator serviceLocator)
        {
            _eventBus = serviceLocator.EventBus;
            _currentSize = _maximalSize;

            _eventBus.Invoke<StartPrintSignal>(new(this));
            _eventBus.Subscribe<ChangeNewSizeFilesViewSignal>(ChangeNewSize);
        }

        public void Destroy() => _eventBus.Unsubscribe<ChangeNewSizeFilesViewSignal>(ChangeNewSize);

        public int[] StartValue() => new int[] { _currentSize, 0 };

        public void ChangeCurrentSize()
        {
            _currentSize -= _newSize;
            float fillAmount = (float)_newSize / _maximalSize;
            _eventBus.Invoke<RecordingFiles>(new(fillAmount, _currentSize));
        }

        private void ChangeNewSize(ChangeNewSizeFilesViewSignal signal)
        {
            Color colorFillAmount;
            Color colorText;
            int procent;
            _newSize = signal.Size;
            if (_newSize <= _maximalSize)
            {
                colorFillAmount = Color.green;
                colorText = Color.white;
                procent = (int)(_newSize * 100f / _maximalSize);
            }
            else
            {
                colorFillAmount = Color.red;
                colorText = Color.red;
                procent = 100;

                _eventBus.Invoke<DiskFullSignal>(new(false));
            }

            _eventBus.Invoke<ChangeFillAmountDiskNewSize>(new(colorFillAmount, colorText, procent));
        }
    }
}
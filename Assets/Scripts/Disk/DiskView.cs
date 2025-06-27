using Services;
using Services.EvnetBusSignals;
using UnityEngine;
using UnityEngine.UI;

namespace Disk
{
    public sealed class DiskView : MonoBehaviour
    {
        [SerializeField] private Text _textMaximalSize;
        [SerializeField] private Text _textSizeFiles;
        [SerializeField] private Text _textFilledInProcent;
        [SerializeField] private Image _imageCurrentSize;
        [SerializeField] private Image _imageNewSize;

        private ServiceLocator _serviceLocator;
        private EventBus _eventBus;

        private void Start()
        {
            _serviceLocator = ServiceLocator.Instance;
            _eventBus = _serviceLocator.EventBus;

            _eventBus.Subscribe<StartPrintSignal>(StartPrint);
            _eventBus.Subscribe<ChangeFillAmountDiskNewSize>(ChangeFillAmount);
            _eventBus.Subscribe<RecordingFiles>(RecordingFiles);
            _eventBus.Subscribe<ChangeNewSizeFilesSignal>(ChangeSize);

            _textSizeFiles.text = $"вес файла: 0";

            _serviceLocator.InitDisk();
        }

        private void OnDestroy()
        {
            _eventBus.Unsubscribe<StartPrintSignal>(StartPrint);
            _eventBus.Unsubscribe<ChangeFillAmountDiskNewSize>(ChangeFillAmount);
            _eventBus.Unsubscribe<ChangeNewSizeFilesSignal>(ChangeSize);
            _eventBus.Unsubscribe<RecordingFiles>(RecordingFiles);
        }

        private void StartPrint(StartPrintSignal signal)
        {
            _textMaximalSize.text = $"место на диске: {signal.Disk.StartValue()[0]}";
            _textFilledInProcent.text = $"заполнено на {signal.Disk.StartValue()[1]}%";
            _imageCurrentSize.fillAmount = signal.Disk.StartValue()[1] / 100f;
            _imageNewSize.fillAmount = _imageCurrentSize.fillAmount;
        }

        private void ChangeSize(ChangeNewSizeFilesSignal signal)
        {
            int size = signal.Size;
            _textSizeFiles.text = signal.IsSereval ? $"вес файлов: {size}" : $"вес файла: {size}";
            _eventBus.Invoke<ChangeNewSizeFilesViewSignal>(new(size));
        }

        private void ChangeFillAmount(ChangeFillAmountDiskNewSize signal)
        {
            _imageNewSize.color = signal.ColorFillAmount;
            _textFilledInProcent.color = signal.ColorText;
            _textFilledInProcent.text = $"заполнено на {signal.Procent}%";
            _imageNewSize.fillAmount = signal.Procent / 100f;

            if (_imageNewSize.color == Color.green)
            {
                if (_imageNewSize.fillAmount > 0)
                {
                    _eventBus.Invoke<DiskFullSignal>(new(true));
                }
                else
                {
                    _eventBus.Invoke<DiskFullSignal>(new(false));
                }
            }
        }

        private void RecordingFiles(RecordingFiles signal)
        {
            _imageCurrentSize.fillAmount = signal.FillAmount;
            _textMaximalSize.text = $"место на диске: {signal.NewSize}";
        }
    }
}
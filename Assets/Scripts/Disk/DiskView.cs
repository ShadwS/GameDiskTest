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

        private void Start()
        {
            _serviceLocator = ServiceLocator.Instance;

            _serviceLocator.EventBus.Subscribe<StartPrintSignal>(StartPrint);
            _serviceLocator.EventBus.Subscribe<ChangeNewSizeSignal>(ChangeNewSize);

            _serviceLocator.InitDisk();
        }

        private void OnDestroy()
        {
            _serviceLocator.EventBus.Unsubscribe<StartPrintSignal>(StartPrint);
            _serviceLocator.EventBus.Unsubscribe<ChangeNewSizeSignal>(ChangeNewSize);
        }

        private void StartPrint(StartPrintSignal signal)
        {
            _textMaximalSize.text = $"место на диске: {signal.Disk.StartValue()[0]}";
            _textFilledInProcent.text = $"заполнено на {signal.Disk.StartValue()[1]}%";
            _imageCurrentSize.fillAmount = signal.Disk.StartValue()[1] / 100f;
            _imageNewSize.fillAmount = _imageCurrentSize.fillAmount;
        }

        private void ChangeNewSize(ChangeNewSizeSignal signal)
        {
            if (_serviceLocator.Disk.CheckEmptyField(signal.Size))
            {
                _imageNewSize.color = Color.green;
                _textFilledInProcent.color = Color.white;

                int procent = _serviceLocator.Disk.GetNewSizeProcent(signal.Size);
                _textFilledInProcent.text = $"заполнено на {procent}%";
                _imageNewSize.fillAmount = procent / 100f;


                if (_imageNewSize.fillAmount > 0)
                {
                    _serviceLocator.EventBus.Invoke<DiskFullSignal>(new(true));
                }
                else
                {
                    _serviceLocator.EventBus.Invoke<DiskFullSignal>(new(false));
                }
            }
            else
            {
                _imageNewSize.fillAmount = 1;
                _imageNewSize.color = Color.red;

                _textFilledInProcent.text = "заполнено на 100%";
                _textFilledInProcent.color = Color.red;

                _serviceLocator.EventBus.Invoke<DiskFullSignal>(new(false));
            }
        }
    }
}
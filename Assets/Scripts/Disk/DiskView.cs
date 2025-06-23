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

            _serviceLocator.EventBus.Subscribe<StartPrint>(StartPrint);
            _serviceLocator.EventBus.Subscribe<ChangeNewSize>(ChangeNewSize);

            _serviceLocator.InitDisk();
        }

        private void OnDestroy()
        {
            _serviceLocator.EventBus.Unsubscribe<StartPrint>(StartPrint);
            _serviceLocator.EventBus.Unsubscribe<ChangeNewSize>(ChangeNewSize);
        }

        private void StartPrint(StartPrint view)
        {
            _textMaximalSize.text = $"место на диске: {view.Disk.StartValue()[0]}";
            _textFilledInProcent.text = $"заполнено на {view.Disk.StartValue()[1]}%";
            _imageCurrentSize.fillAmount = view.Disk.StartValue()[1] / 100f;
            _imageNewSize.fillAmount = _imageCurrentSize.fillAmount;
        }

        private void ChangeNewSize(ChangeNewSize newSize)
        {
            if (_serviceLocator.Disk.CheckEmptyField(newSize.Size))
            {
                _imageNewSize.color = Color.green;
                _textFilledInProcent.color = Color.white;

                int procent = _serviceLocator.Disk.GetNewSizeProcent(newSize.Size);
                _textFilledInProcent.text = $"заполнено на {procent}%";
                _imageNewSize.fillAmount = procent / 100f;
            }
            else
            {
                _imageNewSize.fillAmount = 1;
                _imageNewSize.color = Color.red;

                _textFilledInProcent.text = "заполнено на 100%";
                _textFilledInProcent.color = Color.red;
            }
        }
    }
}
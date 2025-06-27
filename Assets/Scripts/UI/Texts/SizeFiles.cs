using Services;
using Services.EvnetBusSignals;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class SizeFiles : MonoBehaviour
    {
        [SerializeField] private Text _text;

        private ServiceLocator _serviceLocator;

        private void Start()
        {
            _serviceLocator = ServiceLocator.Instance;
            _serviceLocator.EventBus.Subscribe<ChangeNewSizeFilesSignal>(ChangeSize);

            _text.text = $"גוס פאיכא: 0";
        }

        private void OnDestroy() => _serviceLocator.EventBus.Unsubscribe<ChangeNewSizeFilesSignal>(ChangeSize);

        private void ChangeSize(ChangeNewSizeFilesSignal signal)
        {
            int size = signal.Size;
            _text.text = signal.IsSereval ? $"גוס פאיכמג: {size}" : $"גוס פאיכא: {size}";
            _serviceLocator.EventBus.Invoke<ChangeNewSizeFilesViewSignal>(new(size));
        }
    }
}
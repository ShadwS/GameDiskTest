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
            _serviceLocator.EventBus.Subscribe<ChangeSizeFiles>(ChangeSize);

            _text.text = $"גוס פאיכא: 0";
        }

        private void OnDestroy() => _serviceLocator.EventBus.Unsubscribe<ChangeSizeFiles>(ChangeSize);

        private void ChangeSize(ChangeSizeFiles file)
        {
            int size = file.Size;
            _text.text = file.IsSereval ? $"גוס פאיכמג: {size}" : $"גוס פאיכא: {size}";
            _serviceLocator.EventBus.Invoke<ChangeNewSize>(new(size));
        }
    }
}
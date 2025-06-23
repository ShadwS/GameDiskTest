using UnityEngine;
using Services;
using Services.EvnetBusSignals;

namespace UI
{
    public sealed class ButtonRecording : MyButton
    {
        [SerializeField] private ButtonCompress _buttonCompress;

        private ServiceLocator _serviceLocator;

        private void Start()
        {
            _button.onClick.AddListener(Click);

            _serviceLocator = ServiceLocator.Instance;
            _serviceLocator.EventBus.Subscribe<DiskFullSignal>(Enabled);
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            _serviceLocator.EventBus.Unsubscribe<DiskFullSignal>(Enabled);
        }

        protected override void Click()
        {
        }

        private void Enabled(DiskFullSignal signal)
        {
            if(_button.interactable != signal.Enabled)
                _button.interactable = signal.Enabled;
        }
    }
}
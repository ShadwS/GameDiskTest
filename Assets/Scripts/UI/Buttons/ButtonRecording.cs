using UnityEngine;
using Services;
using Services.EvnetBusSignals;

namespace UI
{
    public sealed class ButtonRecording : MyButton
    {
        [SerializeField] private ButtonCompress _buttonCompress;

        protected override void Start()
        {
            base.Start();

            _button.onClick.AddListener(Click);
           _eventBus.Subscribe<DiskFullSignal>(Enabled);
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            _eventBus.Unsubscribe<DiskFullSignal>(Enabled);
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
using UnityEngine;
using Services;
using Services.EvnetBusSignals;
using Disk;

namespace UI
{
    public sealed class ButtonRecording : MyButton
    {
        [SerializeField] private ButtonCompress _buttonCompress;
        private GameDisk _disk;

        protected override void Start()
        {
            base.Start();

            _disk = ServiceLocator.Instance.Disk;
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
            _buttonCompress.HideAllFilesForRecording();
            _disk.ChangeCurrentSize();
        }

        private void Enabled(DiskFullSignal signal)
        {
            if(_button.interactable != signal.Enabled)
                _button.interactable = signal.Enabled;
        }
    }
}
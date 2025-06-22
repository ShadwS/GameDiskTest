using System.Collections.Generic;
using Services;
using Services.EvnetBusSignals;
using Files;

namespace UI
{
    public sealed class ButtonCompress : MyButton
    {
        private ServiceLocator _serviceLocator;
        private List<File> _filesMaximalCompress;
        private List<File> _filesNotMaximalCompress;

        private void Start()
        {
            _serviceLocator = ServiceLocator.Instance;
            _filesMaximalCompress = new();
            _filesNotMaximalCompress = new();
            _serviceLocator.EventBus.Subscribe<FileClick>(FileClick);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _serviceLocator.EventBus.Unsubscribe<FileClick>(FileClick);
        }

        protected override void Click()
        {
        }

        private void FileClick(FileClick file)
        {
            if (file.File.Enabled)
            {
                AddFile(file.File);
            }
            else
            {
                RemoveFile(file.File);
            }
        }

        private void AddFile(File file)
        {
            if (file.IsMaximalCompress)
            {
                _filesMaximalCompress.Add(file);
            }
            else
            {
                _filesNotMaximalCompress.Add(file);
                if (_filesNotMaximalCompress.Count <= 1)
                {
                    _button.interactable = true;
                }
            }
        }

        private void RemoveFile(File file)
        {
            if (file.IsMaximalCompress)
            {
                _filesMaximalCompress.Remove(file);
            }
            else
            {
                _filesNotMaximalCompress.Remove(file);
                if (_filesNotMaximalCompress.Count <= 0)
                {
                    _button.interactable = false;
                }
            }
        }
    }
}
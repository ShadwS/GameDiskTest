using System.Collections.Generic;
using Services.EvnetBusSignals;
using Files;

namespace UI
{
    public sealed class ButtonCompress : MyButton
    {
        public int FilesCounter => _filesMaximalCompress.Count + _filesNotMaximalCompress.Count;

        private int ChangeSize
        {
            set
            {
                _currentSizeFiles += value;
                _eventBus.Invoke<ChangeNewSizeFilesSignal>(new(_currentSizeFiles, _countFiles > 1));
            }
        }

        private List<File> _filesMaximalCompress;
        private List<File> _filesNotMaximalCompress;
        private int _currentSizeFiles;
        private int _countFiles;

        protected override void Start()
        {
            base.Start();

            _filesMaximalCompress = new();
            _filesNotMaximalCompress = new();
            _currentSizeFiles = 0;
            _countFiles = 0;
            _eventBus.Subscribe<FileClickSignal>(FileClick);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _eventBus.Unsubscribe<FileClickSignal>(FileClick);
        }

        protected override void Click()
        {
        }

        public List<File> GetAllFiles()
        {
            var files = _filesNotMaximalCompress;
            foreach (var file in _filesMaximalCompress)
            {
                files.Add(file);
            }
            return files;
        }

        private void FileClick(FileClickSignal file)
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

            _countFiles++;
            ChangeSize = file.Size;
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

            _countFiles--;
            ChangeSize = -file.Size;
        }
    }
}
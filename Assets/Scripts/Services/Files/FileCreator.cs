using Files;
using UnityEngine;

namespace Services.Files
{
    public sealed class FileCreator
    {
        public bool IsMaximalCompress => _compressLevel == _maximalComprress;
        public string Name => $"Τΰιλ {_number}";
        public int CompressLevel => _compressLevel;
        public int Size => _size;
        public Color EnableColor => _enableColor;
        public Color DisableColor => _disableColor;

        private readonly int _compressLevel;
        private readonly int _number;
        private readonly int _size;
        private readonly Color _enableColor;
        private readonly Color _disableColor;
        private readonly int _maximalComprress;

        public FileCreator(int number, FileSettings fileSettings)
        {
            _number = number + 1;
            _maximalComprress = fileSettings.MaximalCompress - 1;
            _compressLevel = Random.Range(fileSettings.MinimalCompress - 1, fileSettings.MaximalCompress);
            _size = fileSettings.Size;
            _enableColor = fileSettings.EnableColor;
            _disableColor = fileSettings.DisableColor;
        }
    }
}
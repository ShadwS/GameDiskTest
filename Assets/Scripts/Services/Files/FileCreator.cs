using Files;
using UnityEngine;
using static UnityEngine.Experimental.Rendering.Universal.RenderObjects;

namespace Services.Files
{
    public sealed class FileCreator
    {
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

        public FileCreator(int number, FileSettings fileSettings)
        {
            _number = number + 1;
            _compressLevel = Random.Range(0, 4);
            _size = fileSettings.Size;
            _enableColor = fileSettings.EnableColor;
            _disableColor = fileSettings.DisableColor;
        }
    }
}
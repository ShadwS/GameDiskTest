using UnityEngine;

namespace Services.Files
{
    public sealed class FileCreator
    {
        readonly int _compressValue;
        readonly int _number;
        readonly int _size;

        public FileCreator(int number, int size)
        {
            _number = number + 1;
            _compressValue = Random.Range(0, 4);
            _size = size;
        }

        public string GetName() => $"Τΰιλ {_number}";

        public int GetCompressLevelInValue() => _compressValue;

        public int GetSize() => _size;
    }
}
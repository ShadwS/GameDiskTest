using UnityEngine;

namespace Services.Files
{
    public sealed class FileCreator
    {
        readonly int _compressValue;
        readonly int _number;

        public FileCreator(int number)
        {
            _number = number + 1;
            _compressValue = Random.Range(0, 4);
        }

        public string GetName() => $"Ôàéë {_number}";

        public int GetCompressLevelInValue() => _compressValue;

        public int GetSize() => Random.Range(100, 1025);
    }
}
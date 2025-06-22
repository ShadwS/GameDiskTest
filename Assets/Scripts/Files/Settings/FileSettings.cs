using UnityEngine;

namespace Files
{
    [CreateAssetMenu(menuName = "File/Settings")]
    public sealed class FileSettings : ScriptableObject
    {
        public int Size
        {
            get
            {
                if (_randomSize)
                {
                    return Random.Range(_minSize, _maxSize + 1);
                }
                else
                {
                    return _staticSize;
                }
            }
        }

        [SerializeField] private bool _randomSize;
        [SerializeField] private int _minSize;
        [SerializeField] private int _maxSize;
        [SerializeField] private int _staticSize;

        public void CorrectValue()
        {
            if (_maxSize == 0 && _minSize == 0)
            {
                Debug.LogError("Minimal size not set. Minimal size = 50 \n" +
                    "Maximal size not set. Maximal size = 1024");
                _minSize = 50;
                _maxSize = 1024;
            }
            else if (_minSize == 0)
            {
                Debug.LogError("Minimal size not set. Minimal size = 50");
                _minSize = 50;
            }
            else if (_maxSize == 0)
            {
                Debug.LogError("Maximal size not set. Maximal size = 1024");
                _maxSize = 1024;
            }
        }
    }
}
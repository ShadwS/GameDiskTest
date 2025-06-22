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
        public Color EnableColor => _enableColor;
        public Color DisableColor => _disableColor;

        [SerializeField] private bool _randomSize;
        [SerializeField] private int _minSize;
        [SerializeField] private int _maxSize;
        [SerializeField] private int _staticSize;
        [SerializeField] private Color _enableColor;
        [SerializeField] private Color _disableColor;

        public void CorrectValue()
        {
            if (_randomSize)
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
            else
            {
                if (_staticSize == 0)
                {
                    Debug.LogError("Static size not set. Static size = 1024");
                    _staticSize = 1024;
                }
            }

            if (_enableColor.a == 0 && _disableColor.a == 0)
            {
                Debug.LogError("Enable color not set. Enable color = Green \n" +
                    "Disable color not set. Disable color = Yellow");
                _enableColor = new(0.2264136f, 0.7529412f, 0.1019608f, 1);
                _disableColor = new(0.7529412f, 0.6470588f, 0.1019608f, 1);
            }
            else if (_enableColor.a == 0)
            {
                Debug.LogError("Enable color not set. Enable color = Green");
                _enableColor = new(0.2264136f, 0.7529412f, 0.1019608f, 1);
            }
            else if (_disableColor.a == 0)
            {
                Debug.LogError("Disable color not set. Disable color = Yellow");
                _disableColor = new(0.7529412f, 0.6470588f, 0.1019608f, 1);
            }
        }
    }
}
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
                    return Random.Range(_minimalSize, _maximalSize + 1);
                }
                else
                {
                    return _staticSize;
                }
            }
        }
        public Color EnableColor => _enableColor;
        public Color DisableColor => _disableColor;
        public int MaximalCompress => _maximalCompress;
        public int MinimalCompress => _minimalCompress;

        [Header("Size")]
        [SerializeField] private bool _randomSize;
        [SerializeField] private int _minimalSize;
        [SerializeField] private int _maximalSize;
        [SerializeField] private int _staticSize;
        [Space]
        [Header("Color")]
        [SerializeField] private Color _enableColor;
        [SerializeField] private Color _disableColor;

        private readonly int _minimalCompress = 1;
        private readonly int _maximalCompress = 4;

        public void CorrectValue()
        {
            CorrectSize();
            CorrectColor();
        }

        private void CorrectSize()
        {
            if (_randomSize)
            {
                if (_maximalSize == 0 && _minimalSize == 0)
                {
                    Debug.LogError("Minimal size not set. Minimal size = 50 \n" +
                        "Maximal size not set. Maximal size = 1024");
                    _minimalSize = 50;
                    _maximalSize = 1024;
                }
                else if (_minimalSize == 0)
                {
                    Debug.LogError("Minimal size not set. Minimal size = 50");
                    _minimalSize = 50;
                }
                else if (_maximalSize == 0)
                {
                    Debug.LogError("Maximal size not set. Maximal size = 1024");
                    _maximalSize = 1024;
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
        }

        private void CorrectColor()
        {
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
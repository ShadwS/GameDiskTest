using UnityEngine;
using UnityEngine.UI;
using Services.Files;
using UI;
using Services;
using Services.EvnetBusSignals;

namespace Files
{
    [RequireComponent(typeof(Image))]
    public sealed class File : MyButton
    {
        public bool IsMaximalCompress => _isMaximalCompress;
        public bool Enabled => _enabled;
        public int Size => _size;

        [SerializeField] private Text _textName;
        [SerializeField] private Image[] _imagesCompress;

        private string _name;
        private int _levelCompress;
        private int _size;
        [SerializeField] private int _compressInProcent;
        private bool _isMaximalCompress;

        private ServiceLocator _serviceLocator;
        private Image _image;
        private Color _disableColor;
        private Color _enableColor;
        private bool _enabled;

        protected override void Awake()
        {
            base.Awake();
            _image = gameObject.GetComponent<Image>();
        }

        private void Start() => _serviceLocator = ServiceLocator.Instance;

        public void Init(FileCreator file)
        {
            _button.onClick.AddListener(Click);

            _disableColor = file.DisableColor;
            _enableColor = file.EnableColor;
            _name = file.Name;
            _levelCompress = file.CompressLevel;
            _isMaximalCompress = file.IsMaximalCompress;

            _image.color = _disableColor;
            _enabled = false;
            _compressInProcent = _levelCompress * 25;

            var compressValueInProcent = 100 - _compressInProcent;
            var size = file.Size;
            _size = _compressInProcent == 0 ? size : size * compressValueInProcent / 100;
            _textName.text = _name;

            for (int i = 0; i < _levelCompress; i++)
            {
                _imagesCompress[i].color = Color.green;
            }
            for (int i = _levelCompress; i < _imagesCompress.Length; i++)
            {
                _imagesCompress[i].color = Color.white;
            }
        }

        protected override void Click()
        {
            _enabled = !_enabled;
            if (_enabled)
            {
                _image.color = _enableColor;
            }
            else
            {
                _image.color= _disableColor;
            }

            _serviceLocator.EventBus.Invoke<FileClick>(new(this));
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace Files
{
    public sealed class File : MonoBehaviour
    {
        [SerializeField] private Text _textName;
        [SerializeField] private Image[] _imagesCompress;

        private string _name;
        [SerializeField] private int _size;
        private int _levelCompress;
        [SerializeField] private int _compressInProcent;

        public void Init(string name, int size, int levelCompress)
        {
            _name = name;
            _size = size;
            _levelCompress = levelCompress;
            _compressInProcent = _levelCompress * 25;

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
    }
}
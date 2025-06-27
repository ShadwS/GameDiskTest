using Files;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace Boot
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameObject[] _canvases;
        [SerializeField] private FilesFactory _filesFactory;
        [SerializeField] private Button[] _buttons;
        [SerializeField] private ServiceLocator _serviceLocator;

        private void Awake()
        {
            foreach (var canvas in _canvases)
            {
                canvas.SetActive(false);
            }

            _filesFactory.gameObject.SetActive(false);
            _serviceLocator.gameObject.SetActive(false);

            foreach (var button in _buttons)
            {
                button.interactable = false;
            }
        }

        private void Start()
        {
            _canvases[0].SetActive(true);
            _canvases[1].SetActive(true);
            _filesFactory.gameObject.SetActive(true);
            _serviceLocator.gameObject.SetActive(true);
        }
    }
}
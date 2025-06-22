using Files;
using UnityEngine;
using UnityEngine.UI;

namespace Boot
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameObject _canvasDisk;
        [SerializeField] private GameObject _canvasGame;
        [SerializeField] private FilesFactory _filesFactory;
        [SerializeField] private Button[] _buttons;

        private void Awake()
        {
            _canvasDisk.SetActive(false);
            _canvasGame.SetActive(false);
            _filesFactory.gameObject.SetActive(false);

            foreach (var button in _buttons)
            {
                button.interactable = false;
            }
        }

        private void Start()
        {
            _canvasDisk.SetActive(true);
            _filesFactory.gameObject.SetActive(true);
        }
    }
}
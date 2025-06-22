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

        private void OnEnable()
        {
            _canvasDisk.SetActive(true);
            _canvasGame.SetActive(false);

            _filesFactory.gameObject.SetActive(true);

            foreach (var button in _buttons)
            {
                button.interactable = false;
            }
        }
    }
}
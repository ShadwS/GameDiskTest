using UnityEngine;

namespace Boot
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameObject _canvasDisk;
        [SerializeField] private GameObject _canvasGame;

        private void OnEnable()
        {
            _canvasDisk.SetActive(true);
            _canvasGame.SetActive(false);
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace MyUI
{
    [RequireComponent(typeof(Button))]
    public sealed class ButtonCompress : MonoBehaviour
    {
        private Button _button;

        private void Awake() => _button = gameObject.GetComponent<Button>();

        private void Start() => _button.onClick.AddListener(Click);

        private void OnDestroy() => _button.onClick.RemoveAllListeners();

        private void Click()
        {

        }
    }
}
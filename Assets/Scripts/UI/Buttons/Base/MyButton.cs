using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public abstract class MyButton : MonoBehaviour
    {
        protected Button _button;

        protected virtual void Awake() => _button = gameObject.GetComponent<Button>();

        protected virtual void OnDestroy() => _button.onClick.RemoveAllListeners();

        protected virtual void Click()
        {
        }
    }
}
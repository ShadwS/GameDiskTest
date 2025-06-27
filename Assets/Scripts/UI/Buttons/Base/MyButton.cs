using Services;
using Services.EvnetBusSignals;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public abstract class MyButton : MonoBehaviour
    {
        protected Button _button;
        protected EventBus _eventBus;

        protected virtual void Awake() => _button = gameObject.GetComponent<Button>();

        protected virtual void Start() => _eventBus = ServiceLocator.Instance.EventBus;

        protected virtual void OnDestroy() => _button.onClick.RemoveAllListeners();

        protected virtual void Click()
        {
        }
    }
}
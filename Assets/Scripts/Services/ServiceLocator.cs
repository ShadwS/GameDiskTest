using UnityEngine;
using Services.EvnetBusSignals;

namespace Services
{
    public sealed class ServiceLocator : MonoBehaviour
    {
        public static ServiceLocator Instance;

        public EventBus EventBus => _eventBus;

        private EventBus _eventBus;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            _eventBus = new();

            DontDestroyOnLoad(gameObject);
        }
    }
}
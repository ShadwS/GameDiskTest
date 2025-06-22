using UnityEngine;
using Services.EvnetBusSignals;
using Disk;

namespace Services
{
    public sealed class ServiceLocator : MonoBehaviour
    {
        public static ServiceLocator Instance;

        public EventBus EventBus => _eventBus;
        public GameDisk Disk => _disk;

        private EventBus _eventBus;
        private GameDisk _disk;

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

        public void InitDisk() => _disk = new();
    }
}
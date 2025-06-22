using UnityEngine;

namespace Files
{
    public sealed class FilesFactory : MonoBehaviour
    {
        [SerializeField] private File[] _files;
        [SerializeField] private Transform _parent;
        [SerializeField] private FileSettings _fileSettings;

        private void OnEnable()
        {
            int randomCount = Random.Range(10, _files.Length + 1);
            _fileSettings.CorrectValue();
            for (int i = 0; i < randomCount; i++)
            {
                var file = _files[i];
                file.gameObject.SetActive(true);
                file.transform.parent = _parent;
                file.Init(new(i, _fileSettings));
            }
            for (int i = randomCount; i < _files.Length; i++)
            {
                _files[i].gameObject.SetActive(false);
            }
        }
    }
}
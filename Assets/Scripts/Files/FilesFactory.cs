using UnityEngine;

namespace Files
{
    public sealed class FilesFactory : MonoBehaviour
    {
        [SerializeField] private Transform _parentFiles;
        [SerializeField] private FileSettings _fileSettings;
        private File[] _files;

        private void OnEnable()
        {
            _files = _parentFiles.gameObject.GetComponentsInChildren<File>();

            int randomCount = Random.Range(10, _files.Length + 1);
            _fileSettings.CorrectValue();

            for (int i = 0; i < randomCount; i++)
            {
                var file = _files[i];
                file.gameObject.SetActive(true);
                file.Init(new(i, _fileSettings));
            }
            for (int i = randomCount; i < _files.Length; i++)
            {
                _files[i].gameObject.SetActive(false);
            }
        }
    }
}
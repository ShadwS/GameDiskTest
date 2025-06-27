namespace Services.EvnetBusSignals
{
    public sealed class RecordingFiles
    {
        public float FillAmount => _fillAmount;
        public int NewSize => _newSize;

        private readonly float _fillAmount;
        private readonly int _newSize;

        public RecordingFiles(float fillAmount, int newSize)
        {
            _fillAmount = fillAmount;
            _newSize = newSize;
        }
    }
}
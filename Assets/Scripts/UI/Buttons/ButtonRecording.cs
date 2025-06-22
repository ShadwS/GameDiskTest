namespace UI
{
    public sealed class ButtonRecording : MyButton
    {
        private void Start() => _button.onClick.AddListener(Click);

        protected override void Click()
        {
        }
    }
}
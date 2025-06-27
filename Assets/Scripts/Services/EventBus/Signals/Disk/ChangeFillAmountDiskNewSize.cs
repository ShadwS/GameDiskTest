using UnityEngine;

namespace Services.EvnetBusSignals
{
    public sealed class ChangeFillAmountDiskNewSize
    {
        public int Procent => _procent;
        public Color ColorFillAmount => _colorFillAmount;
        public Color ColorText => _colorText;

        private readonly Color _colorFillAmount;
        private readonly Color _colorText;
        private readonly int _procent;

        public ChangeFillAmountDiskNewSize(Color colorFillAmount, Color colorText, int procent)
        {
            _colorFillAmount = colorFillAmount;
            _colorText = colorText;
            _procent = procent;
        }
    }
}
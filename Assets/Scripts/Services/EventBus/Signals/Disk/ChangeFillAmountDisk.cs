using UnityEngine;

namespace Services.EvnetBusSignals
{
    sealed class ChangeFillAmountDisk
    {
        public int Procent => _procent;
        public Color ColorFillAmount => _colorFillAmount;
        public Color ColorText => _colorText;

        private readonly Color _colorFillAmount;
        private readonly Color _colorText;
        private readonly int _procent;

        public ChangeFillAmountDisk(Color colorFillAmount, Color colorText, int procent)
        {
            _colorFillAmount = colorFillAmount;
            _colorText = colorText;
            _procent = procent;
        }
    }
}
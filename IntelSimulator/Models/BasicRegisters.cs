using System;
using System.ComponentModel.DataAnnotations;

namespace IntelSimulator.Models
{
    public class BasicRegisters
    {
        public int AX { get; set; }
        public int BX { get; set; }
        public int CX { get; set; }
        public int DX { get; set; }

        public string AX_HEX => Convert.ToString(AX, 16).PadLeft(4, '0');
        public string BX_HEX => Convert.ToString(BX, 16).PadLeft(4, '0');
        public string CX_HEX => Convert.ToString(CX, 16).PadLeft(4, '0');
        public string DX_HEX => Convert.ToString(DX, 16).PadLeft(4, '0');

        public FormInputs Inputs { get; set; } = new FormInputs();

        public void Reset()
        {
            AX = BX = CX = DX = default;
        }

        public void Randomize()
        {
            var r = new Random();
            AX = r.Next(0, 65536);
            BX = r.Next(0, 65536);
            CX = r.Next(0, 65536);
            DX = r.Next(0, 65536);
        }

        public void ApplyInputs()
        {
            AX = ParseIfNotEmpty(Inputs.AX) ?? AX;
            BX = ParseIfNotEmpty(Inputs.BX) ?? BX;
            CX = ParseIfNotEmpty(Inputs.CX) ?? CX;
            DX = ParseIfNotEmpty(Inputs.DX) ?? DX;

            Inputs.Clear();
        }

        private int? ParseIfNotEmpty(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                return int.Parse(input, System.Globalization.NumberStyles.HexNumber);
            }

            return null;
        }

        public class FormInputs
        {
            [RegularExpression("[0-9a-fA-F]{4}")]
            public string AX { get; set; }
            [RegularExpression("[0-9a-fA-F]{4}")]
            public string BX { get; set; }
            [RegularExpression("[0-9a-fA-F]{4}")]
            public string CX { get; set; }
            [RegularExpression("[0-9a-fA-F]{4}")]
            public string DX { get; set; }

            public void Clear()
            {
                AX = BX = CX = DX = string.Empty;
            }

            public bool Any() =>
                !string.IsNullOrWhiteSpace(AX) ||
                !string.IsNullOrWhiteSpace(BX) ||
                !string.IsNullOrWhiteSpace(CX) ||
                !string.IsNullOrWhiteSpace(DX);
        }
    }
}

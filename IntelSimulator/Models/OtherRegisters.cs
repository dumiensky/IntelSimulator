using System;
using System.ComponentModel.DataAnnotations;

namespace IntelSimulator.Models
{
    public class OtherRegisters
    {
        public int SI { get; set; }
        public int DI { get; set; }
        public int BP { get; set; }
        public int SP { get; set; }
        public int DISP { get; set; }

        public string SI_HEX => Convert.ToString(SI, 16).PadLeft(4, '0');
        public string DI_HEX => Convert.ToString(DI, 16).PadLeft(4, '0');
        public string BP_HEX => Convert.ToString(BP, 16).PadLeft(4, '0');
        public string SP_HEX => Convert.ToString(SP, 16).PadLeft(4, '0');
        public string DISP_HEX => Convert.ToString(DISP, 16).PadLeft(4, '0');

        public FormInputs Inputs { get; set; } = new FormInputs();

        public void Reset()
        {
            SI = DI = BP = SP = DISP = default;
        }

        public void Randomize()
        {
            var r = new Random();
            SI = r.Next(0, 65536);
            DI = r.Next(0, 65536);
            BP = r.Next(0, 65536);
            SP = r.Next(0, 65536);
            DISP = r.Next(0, 65536);
        }

        public void ApplyInputs()
        {
            SI = ParseIfNotEmpty(Inputs.SI) ?? SI;
            DI = ParseIfNotEmpty(Inputs.DI) ?? DI;
            BP = ParseIfNotEmpty(Inputs.BP) ?? BP;
            SP = ParseIfNotEmpty(Inputs.SP) ?? SP;
            DISP = ParseIfNotEmpty(Inputs.DISP) ?? DISP;

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
            public string SI { get; set; }
            [RegularExpression("[0-9a-fA-F]{4}")]
            public string DI { get; set; }
            [RegularExpression("[0-9a-fA-F]{4}")]
            public string BP { get; set; }
            [RegularExpression("[0-9a-fA-F]{4}")]
            public string SP { get; set; }
            [RegularExpression("[0-9a-fA-F]{4}")]
            public string DISP { get; set; }

            public void Clear()
            {
                SI = DI = BP = SP = DISP = string.Empty;
            }

            public bool Any() =>
                !string.IsNullOrWhiteSpace(SI) ||
                !string.IsNullOrWhiteSpace(DI) ||
                !string.IsNullOrWhiteSpace(BP) ||
                !string.IsNullOrWhiteSpace(SP) ||
                !string.IsNullOrWhiteSpace(DISP);
        }
    }
}
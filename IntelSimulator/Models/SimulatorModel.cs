using System;
using System.ComponentModel.DataAnnotations;

namespace IntelSimulator.Models
{
    public class SimulatorModel
    {
        public int AX { get; set; } = 10;
        public int BX { get; set; } = 11;
        public int CX { get; set; }
        public int DX { get; set; }

        public string AX_HEX => Convert.ToString(AX, 16);
        public string BX_HEX => Convert.ToString(BX, 16);
        public string CX_HEX => Convert.ToString(CX, 16);
        public string DX_HEX => Convert.ToString(DX, 16);

        public Inputs Inputs { get; set; } = new Inputs();

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
    }

    public class Inputs
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

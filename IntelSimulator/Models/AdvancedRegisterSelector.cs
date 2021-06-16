namespace IntelSimulator.Models
{
    public class AdvancedRegisterSelector
    {
        public FlowType Flow { get; set; } = FlowType.FromRegisterToMemory;
        public AddressType AddressType { get; set; } = AddressType.Index;
        public IndexMode IndexMode { get; set; } = IndexMode.SI;
        public BaseMode BaseMode { get; set; } = BaseMode.BX;
        public Register Register { get; set; } = Register.AX;
    }
}
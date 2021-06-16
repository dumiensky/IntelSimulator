namespace IntelSimulator.Models
{
    public class AdvancedRegisterOperator
    {
        readonly int[] _memory;
        readonly MainRegisters _registers;
        readonly OtherRegisters _otherRegisters;
        readonly AdvancedRegisterSelector _registerSelector;

        public AdvancedRegisterOperator(
            MainRegisters registers, 
            OtherRegisters otherRegisters,
            AdvancedRegisterSelector advancedRegisterSelector,
            int[] memory)
        {
            _registers = registers;
            _otherRegisters = otherRegisters;
            _registerSelector = advancedRegisterSelector;
            _memory = memory;
        }

        public void MOV()
        {
            int address = GetMemoryAddress();
            if(_registerSelector.Flow == FlowType.FromRegisterToMemory)
            {
                _memory[address] = _registers.GetRegisterValue(_registerSelector.Register);
            }
            if(_registerSelector.Flow == FlowType.FromMemoryToRegister)
            {
                _registers.SetRegisterValue(_registerSelector.Register, _memory[address]);
            }
        }

        public void XCHG()
        {
            var address = GetMemoryAddress();
            var registerValue = _registers.GetRegisterValue(_registerSelector.Register);
            var memoryValue = _memory[address];

            _memory[address] = registerValue;
            _registers.SetRegisterValue(_registerSelector.Register, _memory[address]);
        }

        private int GetMemoryAddress()
        {
            var indexVal = _registerSelector.IndexMode switch
            {
                IndexMode.DI => _otherRegisters.DI,
                IndexMode.SI => _otherRegisters.SI,
                _ => 0
            };

            var baseVal = _registerSelector.BaseMode switch
            {
                BaseMode.BP => _otherRegisters.BP,
                BaseMode.BX => _registers.BX,
                _ => 0
            };

            var dispVal = _otherRegisters.DISP;

            return _registerSelector.AddressType switch
            {
                AddressType.Base => baseVal + dispVal,
                AddressType.Index => indexVal + dispVal,
                AddressType.IndexBase => baseVal + indexVal + dispVal,
                _ => 0
            };
        }
    }
}
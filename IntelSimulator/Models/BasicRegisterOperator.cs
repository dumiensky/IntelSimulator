using System;
namespace IntelSimulator.Models
{
    public class BasicRegisterOperator
    {
        readonly MainRegisters _registers;
        readonly BasicRegisterSelector _registerSelector;

        public BasicRegisterOperator(MainRegisters registers, BasicRegisterSelector registerSelector)
        {
            _registers = registers;
            _registerSelector = registerSelector;
        }

        public void MOV()
        {
            _registers.SetRegisterValue(
                _registerSelector.Destination, 
                _registers.GetRegisterValue(_registerSelector.Source));
        }

        public void XCHG()
        {
            var val1 = _registers.GetRegisterValue(_registerSelector.Source);
            var val2 = _registers.GetRegisterValue(_registerSelector.Destination);

            _registers.SetRegisterValue(_registerSelector.Source, val2);
            _registers.SetRegisterValue(_registerSelector.Destination, val1);
        }
    }
}

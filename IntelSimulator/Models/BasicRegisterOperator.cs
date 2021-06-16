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
            SetRegister(_registerSelector.Destination, GetRegisterValue(_registerSelector.Source));
        }

        public void XCHG()
        {
            var val1 = GetRegisterValue(_registerSelector.Source);
            var val2 = GetRegisterValue(_registerSelector.Destination);

            SetRegister(_registerSelector.Source, val2);
            SetRegister(_registerSelector.Destination, val1);
        }

        private void SetRegister(Register which, int value)
        {
            switch (which)
            {
                case Register.AX:
                    _registers.AX = value;
                    break;
                case Register.BX:
                    _registers.BX = value;
                    break;
                case Register.CX:
                    _registers.CX = value;
                    break;
                case Register.DX:
                    _registers.DX = value;
                    break;
            }
        }

        private int GetRegisterValue(Register which)
        {
            switch (which)
            {
                case Register.AX:
                    return _registers.AX;
                case Register.BX:
                    return _registers.BX;
                case Register.CX:
                    return _registers.CX;
                case Register.DX:
                    return _registers.DX;
                default:
                    return 0;
            }
        }
    }
}

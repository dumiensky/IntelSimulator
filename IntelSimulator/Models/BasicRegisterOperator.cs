using System;
namespace IntelSimulator.Models
{
    public class BasicRegisterOperator
    {
        readonly BasicRegisters _basicRegisters;
        readonly RegisterSelector _registerSelector;

        public BasicRegisterOperator(BasicRegisters basicRegisters, RegisterSelector registerSelector)
        {
            _basicRegisters = basicRegisters;
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
                    _basicRegisters.AX = value;
                    break;
                case Register.BX:
                    _basicRegisters.BX = value;
                    break;
                case Register.CX:
                    _basicRegisters.CX = value;
                    break;
                case Register.DX:
                    _basicRegisters.DX = value;
                    break;
            }
        }

        private int GetRegisterValue(Register which)
        {
            switch (which)
            {
                case Register.AX:
                    return _basicRegisters.AX;
                case Register.BX:
                    return _basicRegisters.BX;
                case Register.CX:
                    return _basicRegisters.CX;
                case Register.DX:
                    return _basicRegisters.DX;
                default:
                    return 0;
            }
        }
    }
}

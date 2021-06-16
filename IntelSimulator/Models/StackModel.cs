namespace IntelSimulator.Models
{
    public class StackModel
    {
        public Register Register { get; set; } = Register.AX;

        readonly MainRegisters _mainRegisters;
        readonly OtherRegisters _otherRegisters;
        readonly int[] _stack;

        public StackModel(
            MainRegisters mainRegisters,
            OtherRegisters otherRegisters, 
            int[] stack)
        {
            _mainRegisters = mainRegisters;
            _otherRegisters = otherRegisters;
            _stack = stack;
        }

        public void Push()
        {
            _stack[_otherRegisters.SP] = _mainRegisters.GetRegisterValue(Register);

            _otherRegisters.SP += 2;
        }

        public void Pop()
        {
            _otherRegisters.SP -= 2;

            if(_otherRegisters.SP < 0)
                _otherRegisters.SP = 0;

            _mainRegisters.SetRegisterValue(Register, _stack[_otherRegisters.SP]);
            _stack[_otherRegisters.SP] = 0;
        }
    }
}
namespace IntelSimulator.Models
{
    public class AdvancedRegisterOperator
    {
        readonly MainRegisters _registers;
        readonly AdvancedRegisterSelector _registerSelector;

        public AdvancedRegisterOperator(MainRegisters registers, AdvancedRegisterSelector advancedRegisterSelector)
        {
            _registers = registers;
            _registerSelector = advancedRegisterSelector;
        }
    }
}
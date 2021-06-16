namespace IntelSimulator.Models
{
    public class AdvancedRegisterOperator
    {
        readonly Registers _registers;
        readonly AdvancedRegisterSelector _registerSelector;

        public AdvancedRegisterOperator(Registers registers, AdvancedRegisterSelector advancedRegisterSelector)
        {
            _registers = registers;
            _registerSelector = advancedRegisterSelector;
        }
    }
}
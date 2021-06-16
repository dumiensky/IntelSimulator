using System;
namespace IntelSimulator.Models
{
    [FlagsAttribute]
    public enum AddressType
    {
        Index = 1,
        Base = 2,
        IndexBase = Index | Base
    }
}
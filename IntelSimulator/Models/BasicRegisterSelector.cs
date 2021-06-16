using System;
namespace IntelSimulator.Models
{
    public class BasicRegisterSelector
    {
        private Register source = Register.AX;
        private Register destination = Register.BX;

        public Register Source
        {
            get => source;
            set
            {
                source = value;
                CheckForConflict(nameof(source));
            }
        }

        public Register Destination
        {
            get => destination;
            set
            {
                destination = value;
                CheckForConflict(nameof(destination));
            }
        }

        private void CheckForConflict(string caller)
        {
            if(source == destination)
            {
                if(caller == nameof(source))
                {
                    if (destination == Register.DX)
                        destination = Register.AX;
                    else
                        destination++;
                }
                else
                {
                    if (source == Register.DX)
                        source = Register.AX;
                    else
                        source++;
                }
            }
        }
    }
}

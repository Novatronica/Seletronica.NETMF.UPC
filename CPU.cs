using Microsoft.SPOT.Hardware;
using Seletronica.NETMF.UPC.Enums;

namespace Seletronica.NETMF.UPC
{
    public class CPU_Output : OutputPort
    {
        public CPU_Output(CpuRes res)
            : base((Cpu.Pin)res, false)
        {
        }

        public void On()
        {
            Write(true);
        }

        public void Off()
        {
            Write(false);
        }

    }

    public class CPU_Input : InputPort
    {
        public CPU_Input(CpuRes res)
            : base((Cpu.Pin)res, true, Port.ResistorMode.Disabled)
        {
        }

    }
}

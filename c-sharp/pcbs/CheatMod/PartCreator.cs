using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBMod
{
    class PartCreator
    {

        public void OnInit()
        {
            // FIRST CPU CUSTOM
            PartDescCPU cpu = new PartDescCPU();
            cpu.m_cores = 6;
            cpu.m_numberDies = 2;
            cpu.m_freqMhz = 2200;
            cpu.m_maxFreqMhz = 3600;
            cpu.m_socket = CpuSocket.AM4;
            cpu.m_wattage = 45;
            cpu.m_defaultMemorySpeed = 2200;
            cpu.m_voltage = 1.20f;
            cpu.m_maxVoltage = 2f;
            cpu.m_maxMemoryChannels = 4;
            cpu.m_thermalLimit = 105;
            cpu.m_canOverclock = true;
            cpu.m_multiplierStep = 1.5f;

            // PART NAME
            cpu.m_partName = "Ryzen 5 1600U";
            cpu.m_chipSet = "Ryzen 5 1600U";
            cpu.m_type = PartDesc.Type.CPU;


        }

    }

    
   
}

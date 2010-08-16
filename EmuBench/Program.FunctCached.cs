using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmuBench
{
    partial class Program
    {
        static Opcode[] functBuffer = new Opcode[bufferSize];

        static void functCachedExecute(ref CPU cpu, byte[] buff, uint size)
        {
            if (functBuffer[0] == null)
            { // Fill Function Buffer Cache
                for (uint i = 0; i < size; i++)
                {
                    functBuffer[i] = optTable[buff[i] & 0x3f];
                }
            }
            for (uint i = 0; i < size; i++)
            {
                functBuffer[i](ref cpu);
            }
        }
    }
}

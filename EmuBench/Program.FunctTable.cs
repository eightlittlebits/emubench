﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmuBench
{
    partial class Program
    {
        delegate void Opcode(ref CPU cpu);

        static Opcode[] optTable = {  
	        test00, test01, test02, test03, test04, test05, test06, test07,
	        test08, test09, test10, test11, test12, test13, test14, test15,
	        test16, test17, test18, test19, test20, test21, test22, test23,
	        test24, test25, test26, test27, test28, test29, test30, test31,
	        test32, test33, test34, test35, test36, test37, test38, test39,
	        test40, test41, test42, test43, test44, test45, test46, test47,
	        test48, test49, test50, test51, test52, test53, test54, test55,
	        test56, test57, test58, test59, test60, test61, test62, test63
        };

        static void functTable(ref CPU cpu, byte opcode)
        {
            optTable[opcode & 0x3f](ref cpu);
        }

        static void functTableExecute(ref CPU cpu, byte[] buff, uint size)
        {
            for (uint i = 0; i < size; i++)
            {
                functTable(ref cpu, buff[i]);
            }
        }
    }
}

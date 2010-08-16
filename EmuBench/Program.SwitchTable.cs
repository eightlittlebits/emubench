using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmuBench
{
    partial class Program
    {
        static void switchTable(ref CPU cpu, byte opcode)
        {
            switch (opcode)
            {
                case 0: test00(ref cpu); break;
                case 1: test01(ref cpu); break;
                case 2: test02(ref cpu); break;
                case 3: test03(ref cpu); break;
                case 4: test04(ref cpu); break;
                case 5: test05(ref cpu); break;
                case 6: test06(ref cpu); break;
                case 7: test07(ref cpu); break;
                case 8: test08(ref cpu); break;
                case 9: test09(ref cpu); break;
                case 10: test10(ref cpu); break;
                case 11: test11(ref cpu); break;
                case 12: test12(ref cpu); break;
                case 13: test13(ref cpu); break;
                case 14: test14(ref cpu); break;
                case 15: test15(ref cpu); break;
                case 16: test16(ref cpu); break;
                case 17: test17(ref cpu); break;
                case 18: test18(ref cpu); break;
                case 19: test19(ref cpu); break;
                case 20: test20(ref cpu); break;
                case 21: test21(ref cpu); break;
                case 22: test22(ref cpu); break;
                case 23: test23(ref cpu); break;
                case 24: test24(ref cpu); break;
                case 25: test25(ref cpu); break;
                case 26: test26(ref cpu); break;
                case 27: test27(ref cpu); break;
                case 28: test28(ref cpu); break;
                case 29: test29(ref cpu); break;
                case 30: test30(ref cpu); break;
                case 31: test31(ref cpu); break;
                case 32: test32(ref cpu); break;
                case 33: test33(ref cpu); break;
                case 34: test34(ref cpu); break;
                case 35: test35(ref cpu); break;
                case 36: test36(ref cpu); break;
                case 37: test37(ref cpu); break;
                case 38: test38(ref cpu); break;
                case 39: test39(ref cpu); break;
                case 40: test40(ref cpu); break;
                case 41: test41(ref cpu); break;
                case 42: test42(ref cpu); break;
                case 43: test43(ref cpu); break;
                case 44: test44(ref cpu); break;
                case 45: test45(ref cpu); break;
                case 46: test46(ref cpu); break;
                case 47: test47(ref cpu); break;
                case 48: test48(ref cpu); break;
                case 49: test49(ref cpu); break;
                case 50: test50(ref cpu); break;
                case 51: test51(ref cpu); break;
                case 52: test52(ref cpu); break;
                case 53: test53(ref cpu); break;
                case 54: test54(ref cpu); break;
                case 55: test55(ref cpu); break;
                case 56: test56(ref cpu); break;
                case 57: test57(ref cpu); break;
                case 58: test58(ref cpu); break;
                case 59: test59(ref cpu); break;
                case 60: test60(ref cpu); break;
                case 61: test61(ref cpu); break;
                case 62: test62(ref cpu); break;
                case 63: test63(ref cpu); break;
                default: break;
            }
        }

        static void switchTableExecute(ref CPU cpu, byte[] buff, uint size)
        {
            for (uint i = 0; i < size; i++)
            {
                switchTable(ref cpu, buff[i]);
            }
        }
    }
}

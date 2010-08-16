using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmuBench
{
    partial class Program
    {
        public static void test00(ref CPU cpu)
        {
            cpu.reg[1] += cpu.reg[1];
            cpu.reg[0] |= 1;
            cpu.cycles += 2;
        }
        public static void test01(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[1];
            cpu.reg[0] |= 0x10;
            cpu.cycles += 1;
        }
        public static void test02(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[1];
            cpu.reg[1] |= 0x11;
            cpu.cycles += 5;
        }
        public static void test03(ref CPU cpu)
        {
            cpu.reg[3] += cpu.reg[1];
            cpu.reg[2] |= 0x100;
            cpu.cycles += 3;
        }
        public static void test04(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[1];
            cpu.reg[2] |= 0x101;
            cpu.cycles += 2;
        }
        public static void test05(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[1];
            cpu.reg[1] |= 0x110;
            cpu.cycles += 3;
        }
        public static void test06(ref CPU cpu)
        {
            cpu.reg[1] += cpu.reg[1];
            cpu.reg[1] |= 0x111;
            cpu.cycles += 2;
        }
        public static void test07(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[1];
            cpu.reg[0] |= 0x1000;
            cpu.cycles += 4;
        }
        public static void test08(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[1];
            cpu.reg[1] |= 0x1001;
            cpu.cycles += 6;
        }
        public static void test09(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[1];
            cpu.reg[0] |= 0x1010;
            cpu.cycles += 2;
        }
        public static void test10(ref CPU cpu)
        {
            cpu.reg[3] += cpu.reg[1];
            cpu.reg[3] |= 0x1011;
            cpu.cycles += 1;
        }
        public static void test11(ref CPU cpu)
        {
            cpu.reg[1] += cpu.reg[1];
            cpu.reg[3] |= 0x1100;
            cpu.cycles += 2;
        }
        public static void test12(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[1];
            cpu.reg[0] |= 0x1101;
            cpu.cycles += 1;
        }
        public static void test13(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[2];
            cpu.reg[2] |= 0x1105;
            cpu.cycles += 1;
        }
        public static void test14(ref CPU cpu)
        {
            cpu.reg[2] += cpu.reg[2];
            cpu.reg[2] |= 2;
            cpu.cycles += 3;
        }

        public static void test15(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[2];
            cpu.reg[0] |= 4;
            cpu.cycles += 6;
        }
        public static void test16(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[2];
            cpu.reg[0] |= 8;
            cpu.cycles += 5;
        }
        public static void test17(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[2];
            cpu.reg[2] |= 16;
            cpu.cycles += 2;
        }
        public static void test18(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[2];
            cpu.reg[3] |= 32;
            cpu.cycles += 6;
        }
        public static void test19(ref CPU cpu)
        {
            cpu.reg[1] += cpu.reg[2];
            cpu.reg[2] |= 64;
            cpu.cycles += 4;
        }
        public static void test20(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[2];
            cpu.reg[0] |= 128;
            cpu.cycles += 2;
        }
        public static void test21(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[2];
            cpu.reg[0] |= 256;
            cpu.cycles += 2;
        }
        public static void test22(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[2];
            cpu.reg[0] ^= 512;
            cpu.cycles += 2;
        }

        public static void test23(ref CPU cpu)
        {
            cpu.reg[2] += cpu.reg[2];
            cpu.reg[1] -= 1025;
            cpu.cycles += 6;
        }
        public static void test24(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[3];
            cpu.reg[2] |= 3;
            cpu.cycles += 5;
        }
        public static void test25(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[3];
            cpu.reg[2] -= 5;
            cpu.cycles += 3;
        }
        public static void test26(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[3];
            cpu.reg[0] |= 6;
            cpu.cycles += 4;
        }
        public static void test27(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[3];
            cpu.reg[0] -= 7;
            cpu.cycles += 2;
        }
        public static void test28(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[3];
            cpu.reg[0] |= 9;
            cpu.cycles += 2;
            cpu.cycles += 2;
        }
        public static void test29(ref CPU cpu)
        {
            cpu.reg[2] += cpu.reg[3];
            cpu.reg[0] -= 10;
            cpu.cycles += 2;
        }
        public static void test30(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[3];
            cpu.reg[3] |= 11;
            cpu.cycles += 8;
        }

        public static void test31(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[3];
            cpu.reg[0] -= 12;
            cpu.cycles += 6;
        }
        public static void test32(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[3];
            cpu.reg[2] |= 13;
            cpu.cycles += 4;
        }
        public static void test33(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[3];
            cpu.reg[0] |= 14;
            cpu.cycles += 5;
        }
        public static void test34(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[3];
            cpu.reg[0] |= 15;
            cpu.cycles += 9;
        }
        public static void test35(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[3];
            cpu.reg[0] |= 17;
            cpu.cycles += 4;
        }
        public static void test36(ref CPU cpu)
        {
            cpu.reg[1] += cpu.reg[3];
            cpu.reg[3] /= 18;
            cpu.cycles += 8;
        }
        public static void test37(ref CPU cpu)
        {
            cpu.reg[2] += cpu.reg[3];
            cpu.reg[3] /= 19;
            cpu.cycles += 8;
        }
        public static void test38(ref CPU cpu)
        {
            cpu.reg[3] += cpu.reg[3];
            cpu.reg[0] /= 20;
            cpu.cycles += 7;
        }

        public static void test39(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[3];
            cpu.reg[0] |= 21;
            cpu.cycles += 6;
        }
        public static void test40(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[3];
            cpu.reg[0] |= 22;
            cpu.cycles += 5;
        }
        public static void test41(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[3];
            cpu.reg[0] |= 23;
            cpu.cycles += 2;
        }
        public static void test42(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[2];
            cpu.reg[0] |= 24;
            cpu.cycles += 4;
        }
        public static void test43(ref CPU cpu)
        {
            cpu.reg[1] += cpu.reg[2];
            cpu.reg[2] |= 25;
            cpu.cycles += 3;
        }
        public static void test44(ref CPU cpu)
        {
            cpu.reg[3] += cpu.reg[2];
            cpu.reg[2] *= 26;
            cpu.cycles += 2;
        }
        public static void test45(ref CPU cpu)
        {
            cpu.reg[1] += cpu.reg[2];
            cpu.reg[2] |= 27;
            cpu.cycles += 6;
        }
        public static void test46(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[2];
            cpu.reg[1] |= 28;
            cpu.cycles += 2;
        }

        public static void test47(ref CPU cpu)
        {
            cpu.reg[2] += cpu.reg[2];
            cpu.reg[3] *= 29;
            cpu.cycles += 2;
        }
        public static void test48(ref CPU cpu)
        {
            cpu.reg[1] += cpu.reg[2];
            cpu.reg[0] |= 30;
            cpu.cycles += 6;
        }
        public static void test49(ref CPU cpu)
        {
            cpu.reg[2] += cpu.reg[2];
            cpu.reg[2] |= 31;
            cpu.cycles += 7;
        }
        public static void test50(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[2];
            cpu.reg[0] |= 33;
            cpu.cycles += 5;
        }
        public static void test51(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[2];
            cpu.reg[0] *= 34;
            cpu.cycles += 2;
        }
        public static void test52(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[2];
            cpu.reg[0] |= 35;
            cpu.cycles += 3;
        }
        public static void test53(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[2];
            cpu.reg[0] |= 36;
            cpu.cycles += 4;
        }
        public static void test54(ref CPU cpu)
        {
            cpu.reg[2] += cpu.reg[1];
            cpu.reg[3] |= 37;
            cpu.cycles += 2;
        }

        public static void test55(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[1];
            cpu.reg[1] += 3835;
            cpu.cycles += 5;
        }
        public static void test56(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[1];
            cpu.reg[1] |= 39;
            cpu.cycles += 4;
        }
        public static void test57(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[1];
            cpu.reg[2] |= 40;
            cpu.cycles += 2;
        }
        public static void test58(ref CPU cpu)
        {
            cpu.reg[2] += cpu.reg[1];
            cpu.reg[0] |= 41;
            cpu.cycles += 7;
        }
        public static void test59(ref CPU cpu)
        {
            cpu.reg[0] += cpu.reg[1];
            cpu.reg[1] ^= 3245;
            cpu.cycles += 4;
        }
        public static void test60(ref CPU cpu)
        {
            cpu.reg[1] += cpu.reg[1];
            cpu.reg[3] |= 4233;
            cpu.cycles += 3;
        }
        public static void test61(ref CPU cpu)
        {
            cpu.reg[2] += cpu.reg[1];
            cpu.reg[0] ^= 3115;
            cpu.cycles += 2;
        }
        public static void test62(ref CPU cpu)
        {
            cpu.reg[3] += cpu.reg[1];
            cpu.reg[0] |= 45;
            cpu.cycles += 4;
        }
        public static void test63(ref CPU cpu)
        {
            cpu.reg[1] += cpu.reg[0];
            cpu.reg[0] ^= 3425;
            cpu.cycles += 2;
        }
    }
}

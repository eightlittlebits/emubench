using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;

namespace EmuBench
{
    partial class Program
    {
        static Dictionary<int, OpCode> loadOps = new Dictionary<int, OpCode>();
        static Dictionary<int, OpCode> storeOps = new Dictionary<int, OpCode>();

        public enum Op
        {
            Or,
            Xor,
            Sub,
            Mul,
            Add
        }

        public static void buildOpDictionaries()
        {
            loadOps.Add(0, OpCodes.Ldloc_0);
            loadOps.Add(1, OpCodes.Ldloc_1);
            loadOps.Add(2, OpCodes.Ldloc_2);
            loadOps.Add(3, OpCodes.Ldloc_3);

            storeOps.Add(0, OpCodes.Stloc_0);
            storeOps.Add(1, OpCodes.Stloc_1);
            storeOps.Add(2, OpCodes.Stloc_2);
            storeOps.Add(3, OpCodes.Stloc_3);
        }

        public static void emitAddRegToReg(ILGenerator ilg, int lh, int rh)
        {
            ilg.Emit(loadOps[lh]);
            ilg.Emit(loadOps[rh]);
            ilg.Emit(OpCodes.Add);
            ilg.Emit(storeOps[lh]);
        }

        public static void emitAddCycles(ILGenerator ilg, int cycles)
        {
            ilg.Emit(OpCodes.Ldloc_S, 4);

            switch (cycles)
            {
                case 0: ilg.Emit(OpCodes.Ldc_I4_0); break;
                case 1: ilg.Emit(OpCodes.Ldc_I4_1); break;
                case 2: ilg.Emit(OpCodes.Ldc_I4_2); break;
                case 3: ilg.Emit(OpCodes.Ldc_I4_3); break;
                case 4: ilg.Emit(OpCodes.Ldc_I4_4); break;
                case 5: ilg.Emit(OpCodes.Ldc_I4_5); break;
                case 6: ilg.Emit(OpCodes.Ldc_I4_6); break;
                case 7: ilg.Emit(OpCodes.Ldc_I4_7); break;
                case 8: ilg.Emit(OpCodes.Ldc_I4_8); break;
                default: ilg.Emit(OpCodes.Ldc_I4_S, cycles); break;
            }

            ilg.Emit(OpCodes.Add);
            ilg.Emit(OpCodes.Stloc_S, 4);
        }

        public static void emitOpRegWithImmed(ILGenerator ilg, int reg, Op op, int value)
        {
            ilg.Emit(loadOps[reg]);
            ilg.Emit(OpCodes.Ldc_I4, value);

            switch (op)
            {
                case Op.Or: ilg.Emit(OpCodes.Or); break;
                case Op.Xor: ilg.Emit(OpCodes.Xor); break;
                case Op.Sub: ilg.Emit(OpCodes.Sub); break;
                case Op.Mul: ilg.Emit(OpCodes.Mul); break;
                case Op.Add: ilg.Emit(OpCodes.Add); break;
                default:
                    throw new NotImplementedException();
            }

            ilg.Emit(storeOps[reg]);
        }

        public static void emit00(ILGenerator ilg)
        {
            //cpu.reg[1] += cpu.reg[1];
            //cpu.reg[0] |= 1;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 1, 1);
            emitOpRegWithImmed(ilg, 0, Op.Or, 1);
            emitAddCycles(ilg, 2);
        }
        public static void emit01(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[1];
            //cpu.reg[0] |= 0x10;
            //cpu.cycles += 1;

            emitAddRegToReg(ilg, 0, 1);
            emitOpRegWithImmed(ilg, 0, Op.Or, 0x10);
            emitAddCycles(ilg, 1);
        }
        public static void emit02(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[1];
            //cpu.reg[1] |= 0x11;
            //cpu.cycles += 5;

            emitAddRegToReg(ilg, 0, 1);
            emitOpRegWithImmed(ilg, 1, Op.Or, 0x11);
            emitAddCycles(ilg, 5);
        }
        public static void emit03(ILGenerator ilg)
        {
            //cpu.reg[3] += cpu.reg[1];
            //cpu.reg[2] |= 0x100;
            //cpu.cycles += 3;

            emitAddRegToReg(ilg, 3, 1);
            emitOpRegWithImmed(ilg, 2, Op.Or, 0x100);
            emitAddCycles(ilg, 3);
        }
        public static void emit04(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[1];
            //cpu.reg[2] |= 0x101;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 0, 1);
            emitOpRegWithImmed(ilg, 2, Op.Or, 0x101);
            emitAddCycles(ilg, 2);
        }
        public static void emit05(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[1];
            //cpu.reg[1] |= 0x110;
            //cpu.cycles += 3;

            emitAddRegToReg(ilg, 0, 1);
            emitOpRegWithImmed(ilg, 1, Op.Or, 0x110);
            emitAddCycles(ilg, 3);
        }
        public static void emit06(ILGenerator ilg)
        {
            //cpu.reg[1] += cpu.reg[1];
            //cpu.reg[1] |= 0x111;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 1, 1);
            emitOpRegWithImmed(ilg, 1, Op.Or, 0x111);
            emitAddCycles(ilg, 2);
        }
        public static void emit07(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[1];
            //cpu.reg[0] |= 0x1000;
            //cpu.cycles += 4;

            emitAddRegToReg(ilg, 0, 1);
            emitOpRegWithImmed(ilg, 0, Op.Or, 0x1000);
            emitAddCycles(ilg, 4);
        }
        public static void emit08(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[1];
            //cpu.reg[1] |= 0x1001;
            //cpu.cycles += 6;

            emitAddRegToReg(ilg, 0, 1);
            emitOpRegWithImmed(ilg, 1, Op.Or, 0x1001);
            emitAddCycles(ilg, 6);
        }
        public static void emit09(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[1];
            //cpu.reg[0] |= 0x1010;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 0, 1);
            emitOpRegWithImmed(ilg, 0, Op.Or, 0x1010);
            emitAddCycles(ilg, 2);
        }
        public static void emit10(ILGenerator ilg)
        {
            //cpu.reg[3] += cpu.reg[1];
            //cpu.reg[3] |= 0x1011;
            //cpu.cycles += 1;

            emitAddRegToReg(ilg, 3, 1);
            emitOpRegWithImmed(ilg, 3, Op.Or, 0x1011);
            emitAddCycles(ilg, 1);
        }
        public static void emit11(ILGenerator ilg)
        {
            //cpu.reg[1] += cpu.reg[1];
            //cpu.reg[3] |= 0x1100;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 1, 1);
            emitOpRegWithImmed(ilg, 3, Op.Or, 0x1100);
            emitAddCycles(ilg, 2);
        }
        public static void emit12(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[1];
            //cpu.reg[0] |= 0x1101;
            //cpu.cycles += 1;

            emitAddRegToReg(ilg, 0, 1);
            emitOpRegWithImmed(ilg, 0, Op.Or, 0x1101);
            emitAddCycles(ilg, 1);
        }
        public static void emit13(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[2];
            //cpu.reg[2] |= 0x1105;
            //cpu.cycles += 1;

            emitAddRegToReg(ilg, 0, 2);
            emitOpRegWithImmed(ilg, 2, Op.Or, 0x1105);
            emitAddCycles(ilg, 1);
        }
        public static void emit14(ILGenerator ilg)
        {
            //cpu.reg[2] += cpu.reg[2];
            //cpu.reg[2] |= 2;
            //cpu.cycles += 3;

            emitAddRegToReg(ilg, 2, 2);
            emitOpRegWithImmed(ilg, 2, Op.Or, 2);
            emitAddCycles(ilg, 3);
        }

        public static void emit15(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[2];
            //cpu.reg[0] |= 4;
            //cpu.cycles += 6;

            emitAddRegToReg(ilg, 0, 2);
            emitOpRegWithImmed(ilg, 0, Op.Or, 4);
            emitAddCycles(ilg, 6);
        }
        public static void emit16(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[2];
            //cpu.reg[0] |= 8;
            //cpu.cycles += 5;

            emitAddRegToReg(ilg, 0, 2);
            emitOpRegWithImmed(ilg, 0, Op.Or, 8);
            emitAddCycles(ilg, 5);
        }
        public static void emit17(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[2];
            //cpu.reg[2] |= 16;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 0, 2);
            emitOpRegWithImmed(ilg, 2, Op.Or, 16);
            emitAddCycles(ilg, 2);
        }
        public static void emit18(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[2];
            //cpu.reg[3] |= 32;
            //cpu.cycles += 6;

            emitAddRegToReg(ilg, 0, 2);
            emitOpRegWithImmed(ilg, 3, Op.Or, 32);
            emitAddCycles(ilg, 6);
        }
        public static void emit19(ILGenerator ilg)
        {
            //cpu.reg[1] += cpu.reg[2];
            //cpu.reg[2] |= 64;
            //cpu.cycles += 4;

            emitAddRegToReg(ilg, 1, 2);
            emitOpRegWithImmed(ilg, 2, Op.Or, 64);
            emitAddCycles(ilg, 4);
        }
        public static void emit20(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[2];
            //cpu.reg[0] |= 128;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 0, 2);
            emitOpRegWithImmed(ilg, 0, Op.Or, 128);
            emitAddCycles(ilg, 2);
        }
        public static void emit21(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[2];
            //cpu.reg[0] |= 256;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 0, 2);
            emitOpRegWithImmed(ilg, 0, Op.Or, 256);
            emitAddCycles(ilg, 2);
        }
        public static void emit22(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[2];
            //cpu.reg[0] ^= 512;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 0, 2);
            emitOpRegWithImmed(ilg, 0, Op.Xor, 512);
            emitAddCycles(ilg, 2);
        }

        public static void emit23(ILGenerator ilg)
        {
            //cpu.reg[2] += cpu.reg[2];
            //cpu.reg[1] -= 1025;
            //cpu.cycles += 6;

            emitAddRegToReg(ilg, 2, 2);
            emitOpRegWithImmed(ilg, 1, Op.Sub, 1025);
            emitAddCycles(ilg, 6);
        }
        public static void emit24(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[3];
            //cpu.reg[2] |= 3;
            //cpu.cycles += 5;

            emitAddRegToReg(ilg, 0, 3);
            emitOpRegWithImmed(ilg, 2, Op.Or, 3);
            emitAddCycles(ilg, 5);
        }
        public static void emit25(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[3];
            //cpu.reg[2] -= 5;
            //cpu.cycles += 3;

            emitAddRegToReg(ilg, 0, 3);
            emitOpRegWithImmed(ilg, 2, Op.Sub, 5);
            emitAddCycles(ilg, 3);
        }
        public static void emit26(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[3];
            //cpu.reg[0] |= 6;
            //cpu.cycles += 4;

            emitAddRegToReg(ilg, 0, 3);
            emitOpRegWithImmed(ilg, 0, Op.Or, 6);
            emitAddCycles(ilg, 4);
        }
        public static void emit27(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[3];
            //cpu.reg[0] -= 7;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 0, 3);
            emitOpRegWithImmed(ilg, 0, Op.Sub, 7);
            emitAddCycles(ilg, 2);
        }
        public static void emit28(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[3];
            //cpu.reg[0] |= 9;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 0, 3);
            emitOpRegWithImmed(ilg, 0, Op.Or, 9);
            emitAddCycles(ilg, 2);
        }
        public static void emit29(ILGenerator ilg)
        {
            //cpu.reg[2] += cpu.reg[3];
            //cpu.reg[0] -= 10;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 2, 3);
            emitOpRegWithImmed(ilg, 0, Op.Sub, 10);
            emitAddCycles(ilg, 2);
        }
        public static void emit30(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[3];
            //cpu.reg[3] |= 11;
            //cpu.cycles += 8;

            emitAddRegToReg(ilg, 0, 3);
            emitOpRegWithImmed(ilg, 3, Op.Or, 11);
            emitAddCycles(ilg, 8);
        }

        public static void emit31(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[3];
            //cpu.reg[0] -= 12;
            //cpu.cycles += 6;

            emitAddRegToReg(ilg, 0, 3);
            emitOpRegWithImmed(ilg, 0, Op.Sub, 12);
            emitAddCycles(ilg, 6);
        }
        public static void emit32(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[3];
            //cpu.reg[2] |= 13;
            //cpu.cycles += 4;

            emitAddRegToReg(ilg, 0, 3);
            emitOpRegWithImmed(ilg, 2, Op.Or, 13);
            emitAddCycles(ilg, 4);
        }
        public static void emit33(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[3];
            //cpu.reg[0] |= 14;
            //cpu.cycles += 5;

            emitAddRegToReg(ilg, 0, 3);
            emitOpRegWithImmed(ilg, 0, Op.Or, 14);
            emitAddCycles(ilg, 5);
        }
        public static void emit34(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[3];
            //cpu.reg[0] |= 15;
            //cpu.cycles += 9;

            emitAddRegToReg(ilg, 0, 3);
            emitOpRegWithImmed(ilg, 0, Op.Or, 15);
            emitAddCycles(ilg, 9);
        }
        public static void emit35(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[3];
            //cpu.reg[0] |= 17;
            //cpu.cycles += 4;

            emitAddRegToReg(ilg, 0, 3);
            emitOpRegWithImmed(ilg, 0, Op.Or, 17);
            emitAddCycles(ilg, 4);
        }
        public static void emit36(ILGenerator ilg)
        {
            //cpu.reg[1] += cpu.reg[3];
            //cpu.reg[3] -= 18;
            //cpu.cycles += 8;

            emitAddRegToReg(ilg, 1, 3);
            emitOpRegWithImmed(ilg, 3, Op.Sub, 18);
            emitAddCycles(ilg, 8);
        }
        public static void emit37(ILGenerator ilg)
        {
            //cpu.reg[2] += cpu.reg[3];
            //cpu.reg[3] ^= 19;
            //cpu.cycles += 8;

            emitAddRegToReg(ilg, 2, 3);
            emitOpRegWithImmed(ilg, 3, Op.Xor, 19);
            emitAddCycles(ilg, 8);
        }
        public static void emit38(ILGenerator ilg)
        {
            //cpu.reg[3] += cpu.reg[3];
            //cpu.reg[0] ^= 20;
            //cpu.cycles += 7;

            emitAddRegToReg(ilg, 3, 3);
            emitOpRegWithImmed(ilg, 0, Op.Xor, 20);
            emitAddCycles(ilg, 7);
        }

        public static void emit39(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[3];
            //cpu.reg[0] |= 21;
            //cpu.cycles += 6;

            emitAddRegToReg(ilg, 0, 3);
            emitOpRegWithImmed(ilg, 0, Op.Or, 21);
            emitAddCycles(ilg, 6);
        }
        public static void emit40(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[3];
            //cpu.reg[0] |= 22;
            //cpu.cycles += 5;

            emitAddRegToReg(ilg, 0, 3);
            emitOpRegWithImmed(ilg, 0, Op.Or, 22);
            emitAddCycles(ilg, 5);
        }
        public static void emit41(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[3];
            //cpu.reg[0] |= 23;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 0, 3);
            emitOpRegWithImmed(ilg, 0, Op.Or, 23);
            emitAddCycles(ilg, 2);
        }
        public static void emit42(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[2];
            //cpu.reg[0] |= 24;
            //cpu.cycles += 4;

            emitAddRegToReg(ilg, 0, 2);
            emitOpRegWithImmed(ilg, 0, Op.Or, 24);
            emitAddCycles(ilg, 4);
        }
        public static void emit43(ILGenerator ilg)
        {
            //cpu.reg[1] += cpu.reg[2];
            //cpu.reg[2] |= 25;
            //cpu.cycles += 3;

            emitAddRegToReg(ilg, 1, 2);
            emitOpRegWithImmed(ilg, 2, Op.Or, 25);
            emitAddCycles(ilg, 3);
        }
        public static void emit44(ILGenerator ilg)
        {
            //cpu.reg[3] += cpu.reg[2];
            //cpu.reg[2] *= 26;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 3, 2);
            emitOpRegWithImmed(ilg, 2, Op.Mul, 26);
            emitAddCycles(ilg, 2);
        }
        public static void emit45(ILGenerator ilg)
        {
            //cpu.reg[1] += cpu.reg[2];
            //cpu.reg[2] |= 27;
            //cpu.cycles += 6;

            emitAddRegToReg(ilg, 1, 2);
            emitOpRegWithImmed(ilg, 2, Op.Or, 27);
            emitAddCycles(ilg, 6);
        }
        public static void emit46(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[2];
            //cpu.reg[1] |= 28;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 0, 2);
            emitOpRegWithImmed(ilg, 1, Op.Or, 28);
            emitAddCycles(ilg, 2);
        }

        public static void emit47(ILGenerator ilg)
        {
            //cpu.reg[2] += cpu.reg[2];
            //cpu.reg[3] *= 29;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 2, 2);
            emitOpRegWithImmed(ilg, 3, Op.Mul, 29);
            emitAddCycles(ilg, 2);
        }
        public static void emit48(ILGenerator ilg)
        {
            //cpu.reg[1] += cpu.reg[2];
            //cpu.reg[0] |= 30;
            //cpu.cycles += 6;

            emitAddRegToReg(ilg, 1, 2);
            emitOpRegWithImmed(ilg, 0, Op.Or, 30);
            emitAddCycles(ilg, 6);
        }
        public static void emit49(ILGenerator ilg)
        {
            //cpu.reg[2] += cpu.reg[2];
            //cpu.reg[2] |= 31;
            //cpu.cycles += 7;

            emitAddRegToReg(ilg, 2, 2);
            emitOpRegWithImmed(ilg, 2, Op.Or, 31);
            emitAddCycles(ilg, 7);
        }
        public static void emit50(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[2];
            //cpu.reg[0] |= 33;
            //cpu.cycles += 5;

            emitAddRegToReg(ilg, 0, 2);
            emitOpRegWithImmed(ilg, 0, Op.Or, 33);
            emitAddCycles(ilg, 5);
        }
        public static void emit51(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[2];
            //cpu.reg[0] *= 34;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 0, 2);
            emitOpRegWithImmed(ilg, 0, Op.Mul, 34);
            emitAddCycles(ilg, 2);
        }
        public static void emit52(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[2];
            //cpu.reg[0] |= 35;
            //cpu.cycles += 3;

            emitAddRegToReg(ilg, 0, 2);
            emitOpRegWithImmed(ilg, 0, Op.Or, 35);
            emitAddCycles(ilg, 3);
        }
        public static void emit53(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[2];
            //cpu.reg[0] |= 36;
            //cpu.cycles += 4;

            emitAddRegToReg(ilg, 0, 2);
            emitOpRegWithImmed(ilg, 0, Op.Or, 36);
            emitAddCycles(ilg, 4);
        }
        public static void emit54(ILGenerator ilg)
        {
            //cpu.reg[2] += cpu.reg[1];
            //cpu.reg[3] |= 37;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 2, 1);
            emitOpRegWithImmed(ilg, 3, Op.Or, 37);
            emitAddCycles(ilg, 2);
        }

        public static void emit55(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[1];
            //cpu.reg[1] += 3835;
            //cpu.cycles += 5;

            emitAddRegToReg(ilg, 0, 1);
            emitOpRegWithImmed(ilg, 1, Op.Add, 3835);
            emitAddCycles(ilg, 5);
        }
        public static void emit56(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[1];
            //cpu.reg[1] |= 39;
            //cpu.cycles += 4;

            emitAddRegToReg(ilg, 0, 1);
            emitOpRegWithImmed(ilg, 1, Op.Or, 39);
            emitAddCycles(ilg, 4);
        }
        public static void emit57(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[1];
            //cpu.reg[2] |= 40;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 0, 1);
            emitOpRegWithImmed(ilg, 2, Op.Or, 40);
            emitAddCycles(ilg, 2);
        }
        public static void emit58(ILGenerator ilg)
        {
            //cpu.reg[2] += cpu.reg[1];
            //cpu.reg[0] |= 41;
            //cpu.cycles += 7;

            emitAddRegToReg(ilg, 2, 1);
            emitOpRegWithImmed(ilg, 0, Op.Or, 41);
            emitAddCycles(ilg, 7);
        }
        public static void emit59(ILGenerator ilg)
        {
            //cpu.reg[0] += cpu.reg[1];
            //cpu.reg[1] ^= 3245;
            //cpu.cycles += 4;

            emitAddRegToReg(ilg, 0, 1);
            emitOpRegWithImmed(ilg, 1, Op.Xor, 3245);
            emitAddCycles(ilg, 4);
        }
        public static void emit60(ILGenerator ilg)
        {
            //cpu.reg[1] += cpu.reg[1];
            //cpu.reg[3] |= 4233;
            //cpu.cycles += 3;

            emitAddRegToReg(ilg, 1, 1);
            emitOpRegWithImmed(ilg, 3, Op.Or, 4233);
            emitAddCycles(ilg, 3);
        }
        public static void emit61(ILGenerator ilg)
        {
            //cpu.reg[2] += cpu.reg[1];
            //cpu.reg[0] ^= 3115;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 2, 1);
            emitOpRegWithImmed(ilg, 0, Op.Xor, 3115);
            emitAddCycles(ilg, 2);
        }
        public static void emit62(ILGenerator ilg)
        {
            //cpu.reg[3] += cpu.reg[1];
            //cpu.reg[0] |= 45;
            //cpu.cycles += 4;

            emitAddRegToReg(ilg, 3, 1);
            emitOpRegWithImmed(ilg, 0, Op.Or, 45);
            emitAddCycles(ilg, 4);
        }
        public static void emit63(ILGenerator ilg)
        {
            //cpu.reg[1] += cpu.reg[0];
            //cpu.reg[0] ^= 3425;
            //cpu.cycles += 2;

            emitAddRegToReg(ilg, 1, 0);
            emitOpRegWithImmed(ilg, 0, Op.Xor, 3425);
            emitAddCycles(ilg, 2);
        }
    }
}

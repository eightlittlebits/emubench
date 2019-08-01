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
        static bool oInited = false;
        static Opcode oCache;

        delegate void EmitOpcode(ILGenerator ilg);

        static EmitOpcode[] emitTable = {  
	        emit00, emit01, emit02, emit03, emit04, emit05, emit06, emit07,
	        emit08, emit09, emit10, emit11, emit12, emit13, emit14, emit15,
	        emit16, emit17, emit18, emit19, emit20, emit21, emit22, emit23,
	        emit24, emit25, emit26, emit27, emit28, emit29, emit30, emit31,
	        emit32, emit33, emit34, emit35, emit36, emit37, emit38, emit39,
	        emit40, emit41, emit42, emit43, emit44, emit45, emit46, emit47,
	        emit48, emit49, emit50, emit51, emit52, emit53, emit54, emit55,
	        emit56, emit57, emit58, emit59, emit60, emit61, emit62, emit63
        };

        static void optimisedExecute(ref CPU cpu, byte[] buff, uint size)
        {
            if (!oInited)
            {
                buildOpDictionaries();

                DynamicMethod optiRec = new DynamicMethod("optiRec", null, new Type[] { typeof(CPU).MakeByRefType() }, typeof(Program), true);

                ILGenerator ilg = optiRec.GetILGenerator();

                ilg.DeclareLocal(typeof(uint)); // r0
                ilg.DeclareLocal(typeof(uint)); // r1
                ilg.DeclareLocal(typeof(uint)); // r2
                ilg.DeclareLocal(typeof(uint)); // r3
                ilg.DeclareLocal(typeof(uint)); // cycles

                // load cpu values into locals
                ilg.Emit(OpCodes.Ldarg_0);
                ilg.Emit(OpCodes.Dup);

                ilg.Emit(OpCodes.Ldfld, typeof(CPU).GetField("reg"));

                ilg.Emit(OpCodes.Dup);
                ilg.Emit(OpCodes.Ldc_I4_0);
                ilg.Emit(OpCodes.Ldelem_U4);
                ilg.Emit(OpCodes.Stloc_0);

                ilg.Emit(OpCodes.Dup);
                ilg.Emit(OpCodes.Ldc_I4_1);
                ilg.Emit(OpCodes.Ldelem_U4);
                ilg.Emit(OpCodes.Stloc_1);

                ilg.Emit(OpCodes.Dup);
                ilg.Emit(OpCodes.Ldc_I4_2);
                ilg.Emit(OpCodes.Ldelem_U4);
                ilg.Emit(OpCodes.Stloc_2);

                ilg.Emit(OpCodes.Ldc_I4_3);
                ilg.Emit(OpCodes.Ldelem_U4);
                ilg.Emit(OpCodes.Stloc_3);

                ilg.Emit(OpCodes.Ldfld, typeof(CPU).GetField("cycles"));
                ilg.Emit(OpCodes.Stloc_S, 4);

                // generate methods
                for (int i = 0; i < size; i++)
                {
                    emitTable[buff[i] & 0x3f](ilg);
                }

                // save registers and cycles back to cpu
                ilg.Emit(OpCodes.Ldarg_0);
                ilg.Emit(OpCodes.Dup);

                ilg.Emit(OpCodes.Ldfld, typeof(CPU).GetField("reg"));

                ilg.Emit(OpCodes.Dup);
                ilg.Emit(OpCodes.Ldc_I4_0);
                ilg.Emit(OpCodes.Ldloc_0);
                ilg.Emit(OpCodes.Stelem_I4);

                ilg.Emit(OpCodes.Dup);
                ilg.Emit(OpCodes.Ldc_I4_1);
                ilg.Emit(OpCodes.Ldloc_1);
                ilg.Emit(OpCodes.Stelem_I4);

                ilg.Emit(OpCodes.Dup);
                ilg.Emit(OpCodes.Ldc_I4_2);
                ilg.Emit(OpCodes.Ldloc_2);
                ilg.Emit(OpCodes.Stelem_I4);

                ilg.Emit(OpCodes.Ldc_I4_3);
                ilg.Emit(OpCodes.Ldloc_3);
                ilg.Emit(OpCodes.Stelem_I4);

                ilg.Emit(OpCodes.Ldloc_S, 4);
                ilg.Emit(OpCodes.Stfld, typeof(CPU).GetField("cycles"));

                ilg.Emit(OpCodes.Ret);

                oCache = (Opcode)optiRec.CreateDelegate(typeof(Opcode));

                oInited = true;
            }

            oCache(ref cpu);
        }
    }
}

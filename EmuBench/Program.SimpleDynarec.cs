using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;

namespace EmuBench
{
    partial class Program
    {
        static bool dInited = false;
        static Opcode dCache;

        static void dynarecExecute(ref CPU cpu, byte[] buff, uint size)
        {
            if (!dInited)
            {
                DynamicMethod dynaRec = new DynamicMethod("dynaRec", null, new Type[] { typeof(CPU).MakeByRefType() }, typeof(Program), true);

                ILGenerator ilg = dynaRec.GetILGenerator();
                ilg.Emit(OpCodes.Ldarg_0);

                for (int i = 0; i < size; i++)
                {
                    ilg.Emit(OpCodes.Dup);
                    MethodInfo meth = typeof(Program).GetMethod("test" + (buff[i] & 0x3f).ToString("00"), BindingFlags.Static | BindingFlags.Public);
                    ilg.Emit(OpCodes.Call, meth);
                }

                ilg.Emit(OpCodes.Pop);
                ilg.Emit(OpCodes.Ret);

                dCache = (Opcode)dynaRec.CreateDelegate(typeof(Opcode));

                dInited = true;
            }

            dCache(ref cpu);
        }
    }
}

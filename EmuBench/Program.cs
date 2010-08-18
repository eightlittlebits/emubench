using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EmuBench
{
    public struct CPU
    {
        const uint regs = 4;

        public CPU(string name)
        {
            this.name = name;

            reg = new uint[regs];

            for (int i = 0; i < regs; i++)
            {
                reg[i] = 0;
            }

            cycles = 0;
        }

        public void print()
        {
            Console.WriteLine("{0} CPU values:", name);
            for (int i = 0; i < regs; i++)
            {
                Console.WriteLine("Reg{0} = {1}", i, reg[i]);
            }
            Console.WriteLine("Clock cycles = {0}", cycles);
        }

        public uint[] reg;
        public uint cycles;
        public string name;
    }

    public partial class Program
    {
        const uint repeat = 1024 * 128;
        const uint bufferSize = 1024 * 2;

        static CPU CPU0 = new CPU("Switch Case");
        static CPU CPU1 = new CPU("Function Table");
        static CPU CPU2 = new CPU("Function Caching");
        static CPU CPU3 = new CPU("Simple Dynarec");
        static CPU CPU4 = new CPU("Optimised Dynarec");

        static bool loadBufferRand(out byte[] buffer, uint size)
        {
            Random rnd = new Random();

            buffer = new byte[size];

            rnd.NextBytes(buffer);

            for (int i = 0; i < size; i++)
            {
                buffer[i] &= 0x3f;
            }

            return true;
        }

        static void Main(string[] args)
        {
            byte[] buffer;

            if (!loadBufferRand(out buffer, bufferSize))
            {
                return;
            }

            Console.WriteLine("--------------------");
            Console.WriteLine("Performance Test");
            Console.WriteLine("--------------------");

            Console.WriteLine("\nInstruction count: {0}\t Repeat: {1}\n", bufferSize, repeat);

            // switch/case test
            Console.Write("Testing switch/case statement...");

            Stopwatch scMS = new Stopwatch();
            scMS.Start();

            for (int i = 0; i < repeat; i++)
            {
                switchTableExecute(ref CPU0, buffer, bufferSize);
            }

            scMS.Stop();
            Console.WriteLine("Done.");

            // function pointer test
            Console.Write("Testing function pointer table...");

            Stopwatch ftMS = new Stopwatch();
            ftMS.Start();

            for (int i = 0; i < repeat; i++)
            {
                functTableExecute(ref CPU1, buffer, bufferSize);
            }

            ftMS.Stop();
            Console.WriteLine("Done.");

            // function cache test
            Console.Write("Testing function caching...");

            Stopwatch fcMS = new Stopwatch();
            fcMS.Start();

            for (int i = 0; i < repeat; i++)
            {
                functCachedExecute(ref CPU2, buffer, bufferSize);
            }

            fcMS.Stop();
            Console.WriteLine("Done.");

            // simple dynarec test
            Console.Write("Testing simple dynarec...");

            Stopwatch sdMS = new Stopwatch();
            sdMS.Start();

            for (int i = 0; i < repeat; i++)
            {
                dynarecExecute(ref CPU3, buffer, bufferSize);
            }

            sdMS.Stop();
            Console.WriteLine("Done.");

            // optimised dynarec test
            Console.Write("Testing optimised dynarec...");

            Stopwatch odMS = new Stopwatch();
            odMS.Start();

            for (int i = 0; i < repeat; i++)
            {
                optimisedExecute(ref CPU4, buffer, bufferSize);
            }

            odMS.Stop();
            Console.WriteLine("Done.\n");

            // Performance Analysis
            Console.WriteLine("--------------------");
            Console.WriteLine("Performance Analysis");
            Console.WriteLine("--------------------");
            Console.Write("Switch Statement:  "); printTime(scMS.ElapsedMilliseconds);
            Console.Write("Function Table:    "); printTime(ftMS.ElapsedMilliseconds);
            Console.Write("Function Caching:  "); printTime(fcMS.ElapsedMilliseconds);
            Console.Write("Simple Dynarec:    "); printTime(sdMS.ElapsedMilliseconds);
            Console.Write("Optimised Dynarec: "); printTime(odMS.ElapsedMilliseconds);

            long d0 = scMS.ElapsedMilliseconds;
            long d1 = ftMS.ElapsedMilliseconds;
            long d2 = fcMS.ElapsedMilliseconds;
            long d3 = sdMS.ElapsedMilliseconds;
            long d4 = odMS.ElapsedMilliseconds;

            long m = Math.Min(Math.Min(Math.Min(d0, d1), Math.Min(d2, d3)), d4);

            if (m == d0)
            {
                Console.WriteLine("\nSwitch Statement was {0:G5} times faster than Function Table...", (double)d1 / d0);
                Console.WriteLine("Switch Statement was {0:G5} times faster than Function Caching...", (double)d2 / d0);
                Console.WriteLine("Switch statement was {0:G5} times faster than Simple Dynarec...", (double)d3 / d0);
                Console.WriteLine("Switch statement was {0:G5} times faster than Optimised Dynarec...\n", (double)d4 / d0);
            }
            else if (m == d1)
            {
                Console.WriteLine("\nFunction Table was {0:G5} times faster than Switch Statement...", (double)d0 / d1);
                Console.WriteLine("Function Table was {0:G5} times faster than Function Caching...", (double)d2 / d1);
                Console.WriteLine("Function Table was {0:G5} times faster than Simple Dynarec...", (double)d3 / d1);
                Console.WriteLine("Function Table was {0:G5} times faster than Optimised Dynarec...\n", (double)d4 / d1);
            }
            else if (m == d2)
            {
                Console.WriteLine("\nFunction Caching was {0:G5} times faster than Switch Statement...", (double)d0 / d2);
                Console.WriteLine("Function Caching was {0:G5} times faster than Function Caching...", (double)d1 / d2);
                Console.WriteLine("Function Caching was {0:G5} times faster than Simple Dynarec...", (double)d3 / d2);
                Console.WriteLine("Function Caching was {0:G5} times faster than Optimised Dynarec...\n", (double)d4 / d2);
            }
            else if (m == d3)
            {
                Console.WriteLine("\nSimple Dynarec was {0:G5} times faster than Switch Statement...", (double)d0 / d3);
                Console.WriteLine("Simple Dynarec was {0:G5} times faster than Function Table...", (double)d1 / d3);
                Console.WriteLine("Simple Dynarec was {0:G5} times faster than Function Caching...", (double)d2 / d3);
                Console.WriteLine("Simple Dynarec was {0:G5} times faster than Optimised Dynarec...\n", (double)d4 / d3);
            }
            else if (m == d4)
            {
                Console.WriteLine("\nOptimised Dynarec was {0:G5} times faster than Switch Statement...", (double)d0 / d4);
                Console.WriteLine("Optimised Dynarec was {0:G5} times faster than Function Table...", (double)d1 / d4);
                Console.WriteLine("Optimised Dynarec was {0:G5} times faster than Function Caching...", (double)d2 / d4);
                Console.WriteLine("Optimised Dynarec was {0:G5} times faster than Simple Dynarec...\n", (double)d3 / d4);
            }

            // Reg Results
            Console.WriteLine("--------------------");
            Console.WriteLine("Results Analysis");
            Console.WriteLine("--------------------");

            CPU0.print(); Console.WriteLine();
            CPU1.print(); Console.WriteLine();
            CPU2.print(); Console.WriteLine();
            CPU3.print(); Console.WriteLine();
            CPU4.print(); Console.WriteLine();

            // Finished
            Console.WriteLine("Testing Completed!");
            Console.ReadLine();
        }

        static void printTime(long ms)
        {
            long msSec = ms / 1000;
            long msDot = ms % 1000;
            Console.WriteLine("{0}.{1:000} seconds", msSec, msDot);
        }
    }
}

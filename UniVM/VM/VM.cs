﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM.VM
{
    class VM
    {
        //private List<Program> programs = new List<Program>();
        //private Storage storage = new Storage("HDD.txt", 1024);
        //private Memory memory;
        //private VirtualMemory virtualMemory;
        //private Eval eval;

        //public RealMachine()
        //{
        //    this.memory = new Memory(Constants.BLOCKS_AMOUNT, Constants.BLOCK_SIZE);
        //    this.eval = new Eval(this.storage);
        //    this.virtualMemory = new VirtualMemory(eval.registers.PTR, memory);
        //}

        //public void addProgramFromFile(string fileName)
        //{
        //    var codeStorage = new Storage(fileName);

        //    byte[] altcode = Util.getCode("MOVA 1\nMOVB 2\nADD\nSUB\nHALT\n");
        //    byte[] altdata = Util.getData("FFFFFFFFAAAABBBB");
        //    Util.saveCodeToHdd(codeStorage, 10, new VMInfo { code = altcode, data = altdata });
        //    //uint rowCount = (uint)(codeStorage.getBytes().Length / Constants.BLOCK_SIZE);
        //    uint rowCount = 10;
        //    MemAccesser memAccesser = virtualMemory.reserveMemory(fileName, rowCount);
        //    Program program = new Program(memAccesser, fileName, codeStorage);
        //    programs.Add(program);
        //}

        //public void start()
        //{
        //    var regs = new Registers();
        //    regs.PTR = 0;
        //    eval.registers = regs;

        //    while (true)
        //    {
        //        bool ranAnything = false;
        //        foreach (var program in programs)
        //        {
        //            if (program.completed)
        //                continue;

        //            ranAnything = true;
        //            program.registers.TIMER = Constants.TIMER_VALUE;
        //            eval.registers = program.registers;
        //            while (eval.registers.TIMER > 0 && eval.registers.SI == 0 && eval.registers.PI == 0)
        //            {
        //                eval.run(program);
        //            }


        //            if (eval.registers.SI > 0)
        //                handleSiInt(program, eval.registers.SI);
        //            if (eval.registers.PI > 0)
        //                handlePiInt(program, eval.registers.PI);

        //            program.registers = eval.registers;
        //        }

        //        if (!ranAnything) break;
        //    }

        //}
    }
}

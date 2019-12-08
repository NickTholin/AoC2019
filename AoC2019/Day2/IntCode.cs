using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2019.Day2
{
    public class IntCode
    {

        public (List<int> Memory, int Noun, int Verb) FindIntCodeFromGoal(List<int> memory, int goal)
        {
            var temporaryMemory = new List<int>(memory);
            var runResult = temporaryMemory;
            int noun = 0;
            int verb = 0;

            for (noun = 0; noun < 100; noun++)
            {
                for (verb = 0; verb < 100; verb++)
                {
                    temporaryMemory[1] = noun;
                    temporaryMemory[2] = verb;
                    runResult = Run(temporaryMemory);
                    if (runResult[0] == goal) break;
                }
                if (runResult[0] == goal) break;
            }

            return (runResult, noun, verb);
        }

        public List<int> Run(List<int> memory)
        {
            var address = 0;
            var temporaryMemory = new List<int>(memory);

            while (address < temporaryMemory.Count())
            {
                var instruction = temporaryMemory[address];

                //The value at position address + 1, address + 2 denote the location of in memory of the value we actually want to use.
                var parameter1 = temporaryMemory[temporaryMemory[address + 1]];
                var parameter2 = temporaryMemory[temporaryMemory[address + 2]];

                int newValue;
                if (instruction == 1)
                    newValue = parameter1 + parameter2;
                else if (instruction == 2)
                    newValue = parameter1 * parameter2;
                else
                    break;

                //Value at address + 3 denotes the position we should store the new value at.
                temporaryMemory[temporaryMemory[address + 3]] = newValue;

                //Iterating over blocks of 4 numbers at a time.
                address += 4;
            }

            return temporaryMemory;
        }
    }
}

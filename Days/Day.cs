using AoCHelper;
using System;
using System.IO;

namespace AdventOfCode.Days
{
    public abstract class Day : BaseDay
    {
        public string InputText { get; }

        public Day()
        {
            InputText = File.ReadAllText(InputFilePath);
        }

        public string[] SplitInput(string seperator = "\r\n")
        {
            return InputText.Split(new[] { seperator }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

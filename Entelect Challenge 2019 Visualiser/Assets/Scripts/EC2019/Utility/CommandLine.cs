using System;
using System.Collections.Generic;

namespace EC2019.Utility {
    public class CommandLine {
        private const string RoundStep = "-round-step";

        private const float DefaultRoundStep = 1f;

        private Dictionary<string, string> argumentDictionary;

        public CommandLine() {
            ProcessCommandLineArguments(Environment.GetCommandLineArgs());
        }

        private void ProcessCommandLineArguments(string[] arguments) {
            for (var i = 0; i < arguments.Length; i++) {
                if (arguments[i] == RoundStep) {
                    argumentDictionary.Add(RoundStep, arguments[i + 1]);
                }
            }
        }
        
        public float GetRoundStep() {
            return float.Parse(argumentDictionary[RoundStep]);
        }
    }
}
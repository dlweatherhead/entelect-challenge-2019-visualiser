using System;
using System.Collections.Generic;

namespace EC2019.Utility {
    public class CommandLine {
        private const string RoundStep = "--round-step";
        private const string StepTime = "--step-time";
        private const string ReplayMatch = "--replay-match";

        private readonly Dictionary<string, string> argumentDictionary;

        public CommandLine() {
            argumentDictionary = new Dictionary<string, string>();
            ProcessCommandLineArguments(Environment.GetCommandLineArgs());
        }

        private void ProcessCommandLineArguments(string[] arguments) {
            for (var i = 0; i < arguments.Length; i++) {
                if (arguments[i] == RoundStep) {
                    argumentDictionary.Add(RoundStep, arguments[i + 1]);
                } else if (arguments[i] == StepTime) {
                    argumentDictionary.Add(StepTime, arguments[i + 1]);
                } else if (arguments[i] == ReplayMatch) {
                    argumentDictionary.Add(ReplayMatch, arguments[i + 1]);
                }
            }
        }
        
        public int GetRoundStep() {
            return int.Parse(argumentDictionary[RoundStep]);
        }
        
        public float GetStepTime() {
            return float.Parse(argumentDictionary[StepTime]);
        }
        
        public string GetMatchRound() {
            return argumentDictionary[ReplayMatch];
        }
    }
}
using System;
using System.Collections.Generic;

namespace EC2019.Utility {
    public class CommandLine {
        private const string RoundStep = "--round-step";
        private const string StepTime = "--step-time";
        private const string ReplayMatch = "--replay-match";

        private const string CameraMaxZoom = "--max-zoom";
        private const string CameraSensitivity = "--camera-sensitivity";

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
                } else if (arguments[i] == CameraMaxZoom) {
                    argumentDictionary.Add(CameraMaxZoom, arguments[i + 1]);
                } else if (arguments[i] == CameraSensitivity) {
                    argumentDictionary.Add(CameraSensitivity, arguments[i + 1]);
                }
            }
        }
        
        public int GetRoundStep() {
            return argumentDictionary.ContainsKey(RoundStep) ? int.Parse(argumentDictionary[RoundStep]) : 1;
        }
        
        public float GetStepTime() {
            return argumentDictionary.ContainsKey(StepTime) ? float.Parse(argumentDictionary[StepTime]) : 0.25f;
        }
        
        public float GetCameraMaxZoom() {
            return argumentDictionary.ContainsKey(CameraMaxZoom) ? float.Parse(argumentDictionary[CameraMaxZoom]) : 7f;
        }
        
        public float GetCameraSensitivity() {
            return argumentDictionary.ContainsKey(CameraSensitivity) ? float.Parse(argumentDictionary[CameraSensitivity]) : 0.6f;
        }
        
        public string GetMatchRound() {
            return argumentDictionary[ReplayMatch];
        }
    }
}
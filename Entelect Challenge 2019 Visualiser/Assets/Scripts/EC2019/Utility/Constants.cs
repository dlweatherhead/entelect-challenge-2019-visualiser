// <summary>
// Static store for Constants.
// Tags, etc.
// </summary>

using UnityEngine;

namespace EC2019.Utility {
    public static class Constants {
        public static class Tags {
            public const string Worm = "Worm";
        }

        public static class Worm {
            public static class Profession {
                public const string Commando = "Commando";
                public const string Agent = "Agent";
                public const string Technologist = "Technologist";
            }
        }

        public static class ParentNames {
            public const string PlayerAHolder = "Player A Holder";
            public const string PlayerBHolder = "Player B Holder";
            public const string TilesHolder = "Tiles Holder";
        }

        public static class PlayerA {
            public const int Number = 1;
            public const string Name = "A";
            public const string FolderPrepend = "A - ";
        }
        
        public static class PlayerB {
            public const int Number = 2;
            public const string Name = "B";
            public const string FolderPrepend = "B - ";
        }

        public static class PlayerPrefKeys {
            public const string SelectedReplay = "SelectedReplay";
            public const string StepTime = "StepTime";
            public const string RoundStep = "RoundStep";
            public const string PlayerAName = "PlayerAName";
            public const string PlayerBName = "PlayerBName";
            public const string WinningScore = "WinningScore";
            public const string WinningName = "WinningName";
            public const string WinningPlayer = "WinningPlayer";
            public const string MaxCameraZoom = "MaxCameraZoom";
            public const string CameraSensitivity = "CameraSensitivity";
        }

        public static class Paths {
            public const string GlobalStateFilename = "/GlobalState.json";
        }
    }
}
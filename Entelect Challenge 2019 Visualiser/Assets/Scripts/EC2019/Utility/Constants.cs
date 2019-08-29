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
        }

        public static class UI {
            public const string Play = "Play";
            public const string Pause = "Pause";
        }

        public static class Paths {
            public const string GlobalStateFilename = "/GlobalState.json";
            public const string ExampleReplays = "/Resources/matches";
            public const string DeployedReplays = "/matches";
            public const string MapName = "/JsonMap.json";
            public const string RoundFolderNamePrefix = "Round ";
            public const string EndGameStateFileName = "endGameState.txt";
        }
    }
}
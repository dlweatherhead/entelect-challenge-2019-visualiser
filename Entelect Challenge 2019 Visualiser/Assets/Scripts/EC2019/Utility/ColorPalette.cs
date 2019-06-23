using UnityEngine;

namespace EC2019.Utility {
    public static class ColorPalette {
        // Entelect colours     - Hex   - RGB       - RBG_norm
        // Blue     - #2196f3   -  33, 150, 243     - 0.13, 0.59, 0.95
        // Red      - #f44336   - 244,  67,  54     - 0.96, 0.26, 0.21
        // Yellow   - #fee50e   - 254, 229,  14     - 1   , 0.9 , 0.05
        // Orange   - #ff9800   - 255, 152,   0     - 1   , 0.6 , 0

        public static class Entelect {
            public static Color Blue = new Color(0.13f, 0.59f, 0.95f);
            public static Color Red = new Color(0.96f, 0.26f, 0.21f);
            public static Color Yellow = new Color(1f, 0.9f, 0.05f);
            public static Color Orange = new Color(1f, 0.6f, 0f);
        }

        public static Color PlayerA = Entelect.Blue;
        public static Color PlayerB = Entelect.Red;
        public static Color Yellow = Entelect.Yellow;
        public static Color Orange = Entelect.Orange;
        public static Color LightGrey = 1.5f * Color.gray;
        public static Color Grey = Color.gray;
        public static Color DarkGray = 0.5f * Color.gray;
        public static Color White = Color.white;
    }
}
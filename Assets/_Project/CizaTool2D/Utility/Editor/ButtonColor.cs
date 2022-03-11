using UnityEngine;

namespace CizaTool2D.Utility.Editor
{
    public class ButtonColor 
    {
        public static Color GetNormalColor() => new Color(0.95f, 0.95f, 0.95f, 1);

        public static Color GetPlayColor() => new Color(1f, 0.686f, 0.306f, 1);

        public static Color GetPauseColor() => new Color(0.306f, 0.722f, 1f, 1);

        public static Color GetUpdateSettingsColor() => new Color(1f, 0.306f, 0.847f, 1);
    }
}

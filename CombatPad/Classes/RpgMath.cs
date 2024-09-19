namespace CombatPad.Classes
{
    public static class RpgMath
    {
        public static int Modifier(int score) => (int)Math.Floor(((double)score - 10) / 2);
    }
}

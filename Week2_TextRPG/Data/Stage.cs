namespace Week2_TextRPG.Data
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    public class Stage
    {
        public string name;
        public int requiredDefense;
        public int baseReward;
        public Difficulty difficulty;
        public string description;
        public int rewardExp;
    }
}
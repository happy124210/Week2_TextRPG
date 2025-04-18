namespace Week2_TextRPG.Data
{
    public static class StageDatabase
    {
        public static List<Stage> AllStages { get; } = new List<Stage>
        {
            new Stage
            {
                name = "침묵의 평야",
                description = "바람조차 숨을 죽인 고요한 들판",
                difficulty = Difficulty.Easy,
                requiredDefense = 5,
                baseReward = 1000,              
                rewardExp = 10
            },
            new Stage
            {
                name = "망각의 동굴",
                description = "빛이 닿지 않는 깊은 어둠의 틈",
                difficulty = Difficulty.Normal,
                requiredDefense = 10,
                baseReward = 1700,
                rewardExp = 25
            },
            new Stage
            {
                name = "심연의 문",
                description = "기록되지 않은 너머의 문턱",
                difficulty = Difficulty.Hard,
                requiredDefense = 15,
                baseReward = 2500,
                rewardExp = 45
            }
        };
    }
}

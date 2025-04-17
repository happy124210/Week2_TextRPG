using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_TextRPG.Data
{
    internal static class StageDatabase
    {
        public static List<Stage> AllStages { get; } = new List<Stage>
        {
            new Stage
            {
                name = "침묵의 평야",
                description = "바람조차 숨을 죽인 고요한 들판",
                requiredDefense = 5,
                baseReward = 1000,
                rewardExp = 1
            },
            new Stage
            {
                name = "망각의 동굴",
                description = "빛이 닿지 않는 깊은 어둠의 틈",
                requiredDefense = 10,
                baseReward = 1700,
                rewardExp = 1
            },
            new Stage
            {
                name = "심연의 문",
                description = "기록되지 않은 너머의 문턱",
                requiredDefense = 15,
                baseReward = 2500,
                rewardExp = 1
            }
        };
    }
}

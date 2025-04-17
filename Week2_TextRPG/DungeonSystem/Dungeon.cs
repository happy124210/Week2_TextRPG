using Week2_TextRPG.PlayerSystem;
using Week2_TextRPG.Data;
using Week2_TextRPG.Core;
using System.Xml.Serialization;
using System;

namespace Week2_TextRPG.DungeonSystem
{
    public class Dungeon(Player player)
    {

        private List<Stage> stages = StageDatabase.AllStages;
        private Random random = new Random();

        private string title;
        private string menuMessage1;
        private string quitMessage;
        private string infoMessage;

        private Stage stage;

        enum DungeonState
        {
            Viewing,
            Preparing
        }

        public void DungeonMenu()
        {
            DungeonState state = DungeonState.Viewing;

            while (true)
            {
                Console.Clear();

                // Viewing 상태
                if (state == DungeonState.Viewing)
                {
                    title = "[ 던전 ]";
                    menuMessage1 = "";
                    quitMessage = "[0] 메인 메뉴로 돌아가기";
                    infoMessage = "도전할 던전을 선택하세요.";
                }

                else if (state == DungeonState.Preparing)
                {
                    title = $"[ {stage.name} ]";
                    menuMessage1 = "[1] 도전하기";
                    quitMessage = "[0] 취소하기";
                    infoMessage = "던전에 들어갑니다.";
                }


                // 메뉴 출력
                Console.WriteLine(title);
                Console.WriteLine("");

                if (state == DungeonState.Viewing)
                {
                    ShowStageList(); // 던전 목록 출력
                    Console.WriteLine("");
                }
                else if (state == DungeonState.Preparing)
                {
                    ShowStageInfo(stage); // 선택한 스테이지 정보 출력
                }

                Console.WriteLine(menuMessage1);
                Console.WriteLine(quitMessage);
                Console.WriteLine("────────────────────────────────");
                Console.WriteLine(infoMessage);
                Console.Write(">> ");

                string input = Console.ReadLine();

                // 던전 보기 상태 상호작용
                if (state == DungeonState.Viewing)
                {

                    switch (input)
                    {
                        case "1":
                            stage = stages[0];
                            state = DungeonState.Preparing;
                            break;

                        case "2":
                            stage = stages[1];
                            state = DungeonState.Preparing;
                            break;

                        case "3":
                            stage = stages[2];
                            state = DungeonState.Preparing;
                            break;

                        case "0":
                            return;

                        default:
                            break;
                    }
                }

                else if (state == DungeonState.Preparing)
                {
                    if (input == "0")
                    {
                        state = DungeonState.Viewing;
                    }
                    else
                    {
                        if (player.hp < 20)
                        {
                            Console.WriteLine("체력이 부족하여 던전에 입장할 수 없습니다.");
                            Console.WriteLine("회복 후 다시 도전해 주세요.");
                            Console.ReadKey();
                            state = DungeonState.Viewing;
                            return;
                        }

                        Enter(stage);
                    }
                }
            }
        }


        private void ShowStageList()
        {
            for (int i = 0; i < stages.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {stages[i].name} | 방어력 {stages[i].requiredDefense} 이상 권장");
            }
        }


        private void ShowStageInfo(Stage stage)
        {
            Console.WriteLine($"{stage.description}\n");
            Console.WriteLine("▶ 보상 정보");
            Console.WriteLine($"획득 골드: {stage.baseReward}G + 추가 골드");
            Console.WriteLine($"경험치 {stage.rewardExp}\n");
        }
        private void Enter(Stage stage)
        {

            Console.Clear();
            Console.WriteLine($"[ {stage.name} 도전 결과 ]\n");

            

            // 방어력이 부족할 경우 → 40% 확률로 실패
            if (player.defense < stage.requiredDefense && random.Next(100) < 40)
            {
                Console.WriteLine("당신은 적의 거센 공격을 견디지 못하고 물러섰습니다.\n");
                player.hp /= 2;
                Console.WriteLine($"체력이 절반으로 감소했습니다. (현재 HP: {player.hp})");
            }
            else
            {
                Console.WriteLine("한 줄기 빛이 길을 비춥니다. 당신은 무사히 돌아왔습니다.\n");

                // 체력 소모 계산
                int baseDamage = random.Next(20, 36); // 20~35
                int diff = stage.requiredDefense - player.defense;
                int finalDamage = Math.Max(1, baseDamage + diff); // 최소 1

                player.hp -= finalDamage;
                if (player.hp < 0) player.hp = 0;

                Console.WriteLine($"체력 -{finalDamage} (현재 HP: {player.hp})");

                int totalReward = CalculateReward(stage);

                player.gold += totalReward;
                player.exp += stage.rewardExp;

                Console.WriteLine($"골드 +{totalReward} ({stage.baseReward} + 추가 {totalReward - stage.baseReward})");
                Console.WriteLine($"경험치 +{stage.rewardExp}");
            }

            Console.Write("\n계속하려면 아무 키나 누르세요.");
            Console.ReadKey();
        }

        private int CalculateReward(Stage stage)
        {
            int baseGold = stage.baseReward;
            int bonusMin = 0;
            int bonusMax = 0;

            switch (stage.difficulty)
            {
                case Difficulty.Easy:
                    bonusMin = (int)(player.attack * 0.10f);
                    bonusMax = (int)(player.attack * 0.20f);
                    break;
                case Difficulty.Normal:
                    bonusMin = (int)(player.attack * 0.10f);
                    bonusMax = (int)(player.attack * 0.25f);
                    break;
                case Difficulty.Hard:
                    bonusMin = (int)(player.attack * 0.15f);
                    bonusMax = (int)(player.attack * 0.30f);
                    break;
            }

            int bonus = new Random().Next(bonusMin, bonusMax + 1);
            return baseGold + bonus;
        }
    }   
}

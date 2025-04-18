using Week2_TextRPG.PlayerSystem;
using Week2_TextRPG.Data;
using Week2_TextRPG.Core;

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
                    quitMessage = "메인 메뉴로 돌아가기";
                    infoMessage = "도전할 던전을 선택하세요.";
                }

                else if (state == DungeonState.Preparing)
                {
                    title = $"[ 던전 입장: {stage.name} ]";
                    menuMessage1 = "도전하기";
                    quitMessage = "취소하기";
                    infoMessage = "던전에 들어갑니다.";
                }


                // 메뉴 출력
                Utils.ColoredText($"{title}\n\n", ConsoleColor.DarkCyan);

                if (state == DungeonState.Viewing)
                {
                    ShowStageList(); // 던전 목록 출력
                    Console.WriteLine("");
                }
                else if (state == DungeonState.Preparing)
                {
                    ShowStageInfo(stage); // 선택한 스테이지 정보 출력
                }

                if (menuMessage1 != "") Utils.MenuOption("1", $"{menuMessage1}");
                Utils.MenuOption("0", $"{quitMessage}\n");
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
                            Utils.ColoredText("체력이 부족하여 던전에 입장할 수 없습니다.\n", ConsoleColor.DarkRed);
                            Utils.ColoredText("회복", ConsoleColor.DarkGreen);
                            Console.WriteLine("후 다시 도전해 주세요.");
                            Console.ReadKey();
                            state = DungeonState.Viewing;
                            return;
                        }

                        Enter(stage);
                        state = DungeonState.Viewing;
                    }
                }
            }
        }


        private void ShowStageList()
        {
            for (int i = 0; i < stages.Count; i++)
            {
                Utils.MenuOption($"{i+ 1}", $"{stages[i].name}");
                Console.Write("    방어력");
                Utils.ColoredText($"{stages[i].requiredDefense}", ConsoleColor.DarkRed);
                Console.WriteLine("이상 권장\n");
            }
        }


        private void ShowStageInfo(Stage stage)
        {
            // 입장 전 정보 출력
            Console.WriteLine($"{stage.description}\n");
            Console.Write($"▶ 도전자 ");
            Utils.ColoredText($"{player.name} ", ConsoleColor.Magenta);
            Console.WriteLine($"정보");
            Console.WriteLine("=======================\n");
            Console.WriteLine($"Lv.      : {player.level}");
            Console.Write($"체력     : ");
            Utils.ColoredText($"{player.hp}\n", ConsoleColor.Green);
            Console.Write($"골드     : ");
            Utils.ColoredText($"{player.gold}", ConsoleColor.DarkYellow);
            Console.WriteLine("G");
            Console.Write($"공격력   : {player.attack}");
            Utils.ColoredText($" {player.bonusAttack}\n", ConsoleColor.DarkRed);
            Console.Write($"방어력   : {player.attack}");
            Utils.ColoredText($" {player.bonusDefense}\n", ConsoleColor.DarkRed);
            Console.WriteLine("\n=======================\n");
            Console.Write("▶ ");
            Utils.ColoredText($"{stage.name} ", ConsoleColor.Green);
            Console.WriteLine($"클리어 보상");
            Console.WriteLine("=======================\n");
            Console.Write($"기본 골드 : ");
            Utils.ColoredText($"{stage.baseReward}", ConsoleColor.DarkYellow);
            Console.Write("G + ");
            Utils.ColoredText("추가 골드\n", ConsoleColor.DarkYellow);
            Console.Write($"경험치   : ");
            Utils.ColoredText($"{stage.rewardExp}", ConsoleColor.Cyan);
            Console.WriteLine("xp");
            Console.WriteLine("\n=======================\n");
        }
        private void Enter(Stage stage)
        {

            Console.Clear();
            Console.Write("[ ");
            Utils.ColoredText($"{stage.name}", ConsoleColor.Green);
            Console.WriteLine(" 도전 결과 ]");


            // 방어력이 부족할 경우 → 80% 확률로 실패
            if (player.defense < stage.requiredDefense && random.Next(100) < 80)
            {
                Utils.TypeEffect("......");
                Utils.TypeEffect("당신은 적의 거센 공격을 견디지 못하고 물러섰습니다.\n");
                Utils.ColoredText("결과 보기", ConsoleColor.DarkRed);
                Console.ReadKey();
                Console.Clear();

                player.hp /= 2;
                Console.Write("[ ");
                Utils.ColoredText($"{stage.name} ", ConsoleColor.Green);
                Console.WriteLine("도전 결과 ]\n");
                Console.Write("▶ ");
                Utils.ColoredText($"{stage.name} ", ConsoleColor.Green);
                Console.WriteLine($"실패..");
                Console.WriteLine("=======================\n");
                Console.Write($"체력       : ");
                Utils.ColoredText($"{player.hp} ", ConsoleColor.Green);
                Console.Write($"(");
                Utils.ColoredText($"체력 절반 감소", ConsoleColor.Magenta);
                Console.WriteLine(")");
                Console.WriteLine("\n=======================\n");

            }
            // 성공
            else
            {
                Utils.TypeEffect("......");
                Utils.TypeEffect("한 줄기 빛이 길을 비춥니다. 당신은 무사히 돌아왔습니다.\n");
                Utils.ColoredText("상자 열기", ConsoleColor.DarkYellow);
                Console.ReadKey();
                Console.Clear();

                // 방어력 비례 체력 소모 계산
                int baseDamage = random.Next(20, 36);
                int diff = stage.requiredDefense - player.defense;
                int finalDamage = Math.Max(1, baseDamage + diff); // 최소 1

                player.hp -= finalDamage;
                if (player.hp < 0) player.hp = 0; // 0 이하 방지

                

                // 공격력 비례 전리품 계산
                int totalReward = CalculateReward(stage);

                player.gold += totalReward;

                // 클리어 메세지 출력
                Console.Write("[");
                Utils.ColoredText($"{stage.name} ", ConsoleColor.Green);
                Console.WriteLine("도전 결과 ]\n");
                Console.Write("▶ ");
                Utils.ColoredText($"{stage.name} ", ConsoleColor.Green);
                Console.WriteLine($"클리어!");
                Console.WriteLine("=======================\n");
                Console.Write($"체력        : ");
                Utils.ColoredText($"{player.hp} ", ConsoleColor.Green);
                Console.Write($"(");
                Utils.ColoredText($"-{finalDamage}", ConsoleColor.Magenta);
                Console.WriteLine(")");
                Console.Write($"골드        : ");
                Utils.ColoredText($"{player.gold} ", ConsoleColor.DarkYellow);
                Console.Write("G (");
                Console.Write($"클리어 보상 ");
                Utils.ColoredText($"+{totalReward}", ConsoleColor.DarkYellow);
                Console.WriteLine("G)");
                Console.Write($"획득 경험치 : ");
                Utils.ColoredText($"+{stage.rewardExp}", ConsoleColor.Cyan);
                Console.WriteLine("xp");
                Console.WriteLine("\n=======================\n");

                player.GainExp(stage.rewardExp);
            }

            Console.Write("\n던전을 나갑니다.");
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

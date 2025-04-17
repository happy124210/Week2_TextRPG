using Week2_TextRPG.PlayerSystem;

namespace Week2_TextRPG.InnSysytem
{
    internal class Inn(Player player)
    {
        private static int InnFee = 500;

        private string title;
        private string menuMessage1;
        private string quitMessage;
        private string infoMessage;


        enum InnState
        {
            Viewing, // 여관 메뉴 보기
            Sleeping // 잠자기 모드
        }

        public void InnMenu()
        {
            InnState state = InnState.Viewing;

            while (true)
            {
                Console.Clear();

                // Viewing 상태
                if (state == InnState.Viewing)
                {
                    title = "[ 여관 ]";
                    menuMessage1 = "[1] 잠자기";
                    quitMessage = "[0] 메인 메뉴로 돌아가기";
                    infoMessage = "";
                }
                // Sleeping 상태
                else if (state == InnState.Sleeping)
                {
                    title = "[ 잠자기 ]";
                    menuMessage1 = "[1] 확인하기";
                    quitMessage = "[0] 취소하기";
                    infoMessage = "잠을 자고 체력을 회복합니다.";
                }  

                // 메뉴 출력
                Console.WriteLine(title);
                Console.WriteLine("");
                Console.WriteLine($"보유 골드: {player.gold}원");
                Console.WriteLine("");
                Console.WriteLine(menuMessage1);
                Console.WriteLine("");
                Console.WriteLine(quitMessage);
                Console.WriteLine("");
                Console.WriteLine(infoMessage);
                Console.Write(">> ");

                string input = Console.ReadLine();

                // 여관 보기 상태 상호작용
                if (state == InnState.Viewing)
                {

                    switch (input)
                    {
                        case "1":
                            state = InnState.Sleeping;
                            break;

                        case "0":
                            return;

                        default:
                            break;
                    }

                }

                // 잠자기 상태 상호작용
                else if (state == InnState.Sleeping)
                {
                    switch (input)
                    {
                        case "1":
                            Sleep();
                            break;

                        case "0":
                            state = InnState.Viewing;
                            break;

                        default:
                            break;
                    }
                }

            }
        }

        private void Sleep()
        {
            if (player.gold < InnFee)
            {
                Console.WriteLine("돈이 부족합니다.");
                Console.ReadKey();
                return;
            }
            else if (player.hp == 100)
            {
                Console.WriteLine("이미 체력이 100입니다.");
                Console.ReadKey();
                return;
            }
            else
            {
                player.gold -= InnFee;
                player.hp = 100;
                Console.WriteLine("회복을 완료했습니다.");
                Console.ReadKey();
                return;
            }
        }
    }
}

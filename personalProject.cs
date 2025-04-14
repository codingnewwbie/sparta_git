using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace ConsoleApp1
    {
    internal class personalProject
    {
        static void Main(string[] args)
        {


            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다. + \n");
            Console.WriteLine("1.상태보기 \n2.인벤토리 \n3.상점");
            Console.Write("원하시는 행동을 입력해주세요. \n>>");

            string str = Console.ReadLine();

            Status status = new Status();

            switch (str)
            {
                case "1":
                    MyStatus(status);

                    break;
                case "2":
                    Inventory(status);
                    break;
                case "3":
                    Shop(status);
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }

        }



        static void MyStatus(Status status)
            {
                Console.WriteLine("상태 보기 \n캐릭터의 정보가 표시됩니다.\n");
                Console.WriteLine($"Lv. {status.level} \nChad ( {status.className} )\n공격력 : {status.attackPoint}\n방어력 : {status.defensePoint}\n체 력 : {status.healthPoint}\nGold : {status.gold} G\n");

                Console.WriteLine("0. 나가기\n");

                Console.Write("원하시는 행동을 입력해주세요. \n>>");

            }

        static void Inventory(Status status)
          {
                Console.WriteLine("인벤토리 \n보유 중인 아이템을 관리할 수 있습니다.\n [아이템 목록] \n1. 장착 관리\n0.나가기\n");

                Console.Write("원하시는 행동을 입력해주세요. \n>>");
           }

        static void Shop(Status status)
        {
            Console.WriteLine($"상점 \n필요한 아이템을 얻을 수 있는 상점입니다.\n [보유 골드]\n{status.gold} G \n");

            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("- 수련자 갑옷 | 방어력 + 5 | 수련에 도움을 주는 갑옷입니다. | 1000 G");
            Console.WriteLine("- 무쇠갑옷 | 방어력 + 9 | 무쇠로 만들어져 튼튼한 갑옷입니다. | 2000 G");
            Console.WriteLine("- 스파르타의 갑옷 | 방어력 + 15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.| 3500 G");
            Console.WriteLine("- 낡은 검 | 공격력 + 2 | 쉽게 볼 수 있는 낡은 검 입니다. | 600 G");
            Console.WriteLine("- 청동 도끼 | 공격력 + 5 | 어디선가 사용됐던거 같은 도끼입니다. | 1500 G");
            Console.WriteLine("- 스파르타의 창 | 공격력 + 7 | 스파르타의 전사들이 사용했다는 전설의 창입니다. | 3500 G");
            Console.WriteLine("1.아이템 구매\n2.나가기");
            Console.Write("원하시는 행동을 입력해주세요. \n>>");
        }




        struct Status()
        {
            public string level = "01";
            public string name = "Jone";
            public string className = "전사";
            public int attackPoint = 10;
            public int defensePoint = 5;
            public int healthPoint = 100;
            public int gold = 1500;
        }
    }
}
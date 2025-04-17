using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections.Generic;
using static ConsoleApp1.personalProject;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class personalProject
    {

        static void Main(string[] args)
        {

            Status status = new Status();

            CreateItem createItem = new CreateItem();

            PlayerActive playerActive = new PlayerActive();

            StartGame startGame = new StartGame();

            ShowStatus showStatus;

            ShowInventory showInventory;

            ShowShop showShop;

            Rest rest;

            Dungeon dungeon;


            // 값 제대로 담겼는지 확인용
            //foreach (Item item in createItem.itemList)
            //{
            //    Console.WriteLine("Name" + item.Name);
            //    Console.WriteLine("Desc" + item.Desc);
            //    Console.WriteLine("장비여부" + item.IsEuipmented);
            //    Console.WriteLine("구매여부" + item.IsPurchased);
            //    Console.WriteLine("장비포인트" + item.StatPoint);
            //    Console.WriteLine("장비타입" + item.StatType);
            //    Console.WriteLine("HowMuch" + item.HowMuch);
            //}

            // items.Count(item => item.isEquipped)

            // List담긴 값 불러오기
            //for (int i = 0; i < itemList.Count; i++) {
            //        Console.WriteLine($"{itemList[i].Name} \t| {itemList[i].Desc} \t| {ConvertType(itemList[i].StatType)} +{itemList[i].StatPoint}");
            //}


            bool isPlaying = true;
            int equipAtk = 0;
            int equipDef = 0;

            // 레벨업 테스트
            //for (int i = 0; i < 12; i++)
            //{
            //    status.LevelUp(status);
            //    Console.WriteLine($"레벨: {status.Level}, 경험치: {status.Exp}");
            //}

            while (isPlaying)
            {
                startGame.startGame();

                switch (int.Parse(startGame.mainActive))
                {
                    case (int)PlayerActive.ShowStatus:
                        {
                            showStatus = new ShowStatus(status, equipAtk, equipDef);
                            showStatus.DisplayStatus();
                            break;
                        }

                    case (int)PlayerActive.ShowInventory:
                        {
                            showInventory = new ShowInventory();
                            showInventory.DisplayInventory(createItem.itemList, ref equipAtk, ref equipDef);
                            break;
                        }

                    case (int)PlayerActive.ShowShop:
                        {
                            showShop = new ShowShop();
                            showShop.DisplayShop(createItem.itemList, status, ref equipAtk, ref equipDef);
                            break;
                        }
                    case (int)PlayerActive.BeforeMenu:
                        {
                            Console.WriteLine("게임을 종료합니다.");
                            isPlaying = false;
                            break;
                        }
                    case (int)PlayerActive.EnterDungeon:
                        {
                            dungeon = new Dungeon();
                            dungeon.DisplayDungeon(status, equipAtk, equipDef);
                            break;
                        }
                    case (int)PlayerActive.Rest:
                        {
                            rest = new Rest();
                            rest.getRest(status);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                        }       
                }
            }
        }


        public class Status
        {
            public String Level { get; set; }
            public String Name { get; set; }
            public String ClassName { get; set; }
            public int AttackPoint { get; set; }
            public int DefensePoint { get; set; }
            public int HealthPoint { get; set; }

            public int MaxHealthPoint { get; set; }
            public int Gold { get; set; }
            public int Exp { get; set; }

            public Status() {
                Level = "01";
                Name = "John Doe";
                ClassName = "전사";
                AttackPoint = 10;
                DefensePoint = 5;
                HealthPoint = 100;
                MaxHealthPoint = HealthPoint;
                Gold = 50000;
                Exp = 0;
            }

            public void LevelUp(Status status)
            {
                Console.WriteLine("던전 클리어");

                int numLev = int.Parse(status.Level);
                status.Exp++;
                if (status.Exp == numLev)
                {
                    numLev++;
                    if (numLev % 2 != 0) status.AttackPoint += 1;
                    status.DefensePoint += 1;
                    status.Level = numLev.ToString("D2");
                    status.Exp = 0;
                }
            }
        }

        enum PlayerActive
        {
            BeforeMenu = 0,
            ShowStatus = 1,
            ShowInventory = 2,
            ShowShop = 3,
            EnterDungeon = 4,
            Rest = 5
        }


        public class Item
        {
            public String Name { get; set; }
            public String Desc { get; set; }
            public Boolean IsPurchased { get; set; }
            public Boolean IsEuipmented { get; set; }
            public String StatType { get; set; }
            public int StatPoint { get; set; }
            public int HowMuch { get; set; }

            public Item(string name, string desc, string statType, int statPoint, int howMuch)
            {
                Name = name;
                Desc = desc;
                IsPurchased = false;
                IsEuipmented = false;
                StatType = statType;
                StatPoint = statPoint;
                HowMuch = howMuch;
            }
        }

        static string ConvertType(string type)
        {
            if (type == "def") return "방어력";
            return "공격력";
        }



        public class CreateItem {
            public List<Item> itemList;

            public CreateItem() {
                itemList = new List<Item>();
                itemList.Add(new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", "def", 5, 1000));
                itemList.Add(new Item("무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", "def", 9, 2000));
                itemList.Add(new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", "def", 15, 3500));
                itemList.Add(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", "atk", 2, 600));
                itemList.Add(new Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", "atk", 5, 1500));
                itemList.Add(new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", "atk", 7, 3500));
                itemList.Add(new Item("헬블레이드", "갓오워에서 가져온 헬블레이드입니다. 어케함?", "atk", 10, 35000));
            }
        }


        public class ShowStatus
        {
            Status status;
            int equipAtk, equipDef;

            public ShowStatus(Status status, int equipAtk, int equipDef)
            {
                this.status = status;
                this.equipAtk = equipAtk;
                this.equipDef = equipDef;

            }

            public void DisplayStatus()
            {
                Console.WriteLine("상태 보기 \n캐릭터의 정보가 표시됩니다.\n");
                Console.WriteLine($"Lv. {status.Level} \nChad ( {status.ClassName} )\n공격력 : {status.AttackPoint} {(equipAtk > 0 ? $"(+{equipAtk})" : "")}\n방어력 : {status.DefensePoint} {(equipDef > 0 ? $"(+{equipDef})" : "")}\n체 력 : {status.HealthPoint}\nGold : {status.Gold} G\n");
                Console.WriteLine("0. 나가기\n");
                Console.Write("원하시는 행동을 입력해주세요. \n>>");

                string statusActive = Console.ReadLine();

                if (statusActive == "0") { return; } else { Console.WriteLine("잘못 입력하셨습니다."); DisplayStatus(); }
            }
        }


        public class StartGame
        {
            public string mainActive;
            public int equipDef, equipAtk;

            public void startGame()
            {
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
                Console.WriteLine("1.상태보기\n2.인벤토리\n3.상점\n4.던전입장\n5.휴식하기\n0.게임종료");
                Console.Write("원하시는 행동을 입력해주세요. \n>>");

                mainActive = Console.ReadLine();
            }
        }


        public class ShowInventory
        {
            public string inventoryActive;

            // 인벤토리 입장 시 기본 화면
            public void DisplayInventory(List<Item> itemList, ref int equipAtk, ref int equipDef)
            {

                Console.WriteLine("인벤토리 \n보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]\n");

                for (int i = 0; i < itemList.Count; i++)
                {
                    if (itemList[i].IsPurchased == true)
                    {
                        Console.WriteLine($"- {(itemList[i].IsEuipmented ? "[E]" : "")}{itemList[i].Name} \t| {itemList[i].Desc} \t| {ConvertType(itemList[i].StatType)} +{itemList[i].StatPoint}");

                    }
                }

                Console.WriteLine("\n1.장착 관리\n0.나가기\n");
                Console.Write("원하시는 행동을 입력해주세요. \n>>");
                inventoryActive = Console.ReadLine();

                if (inventoryActive == "0")
                {
                    return;
                }
                else if (inventoryActive == "1")
                {
                    DisplayInventoryManager(itemList, ref equipAtk, ref equipDef);
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    DisplayInventory(itemList, ref equipAtk, ref equipDef);
                }
            }

            // 인벤토리 --> 장착 시 화면
            public void DisplayInventoryManager(List<Item> itemList, ref int equipAtk, ref int equipDef)
            {
                {
                    bool isKeepingEquipment = true;
                    int hasEquipCount = 1;

                    while (isKeepingEquipment)
                    {

                        Console.WriteLine("인벤토리 - 장착 관리\n보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]");

                        int count1 = hasEquipCount;

                        for (int i = 0; i < itemList.Count; i++)
                        {
                            if (itemList[i].IsPurchased == true)
                            {
                                Console.WriteLine($"- {(itemList[i].IsEuipmented ? "[E]" : "")}{count1} {itemList[i].Name} \t| {itemList[i].Desc} \t| {ConvertType(itemList[i].StatType)} +{itemList[i].StatPoint}");
                                count1++;

                            }
                        }

                        Console.WriteLine("0.나가기");
                        Console.Write("원하시는 행동을 입력해주세요. \n>>");

                        string equipmentActive = Console.ReadLine();
                        int intEquipmentActive = int.Parse(equipmentActive);

                        if (equipmentActive == "0")
                        {
                            isKeepingEquipment = false;
                        }
                        else if (intEquipmentActive >= 1 && intEquipmentActive <= itemList.Count(i => i.IsPurchased))
                        {
                            var purchasedItems = itemList.Where(item => item.IsPurchased).ToList();

                            // 선택 장비가 장착되어 있을 때 해제하고 값 빼기
                            if (purchasedItems[intEquipmentActive - 1].IsEuipmented)
                            {
                                purchasedItems[intEquipmentActive - 1].IsEuipmented = !purchasedItems[intEquipmentActive - 1].IsEuipmented;
                                if (purchasedItems[intEquipmentActive - 1].StatType == "def") { equipDef -= purchasedItems[intEquipmentActive - 1].StatPoint; } else { equipAtk -= purchasedItems[intEquipmentActive - 1].StatPoint; }
                            }

                            // 선택 장비가 장착되어 있지 않을 때, 1. 해당 statType과 같은 모든 purchasedItems의 isEuipmented false로, 2. equipDef랑 equipAtk 전부 빼기 or 0으로 초기화.
                            else
                            {
                                foreach (var item in purchasedItems) {
                                    if (item.IsEuipmented && item.StatType == purchasedItems[intEquipmentActive - 1].StatType) {
                                        item.IsEuipmented = false;

                                        if (item.StatType == "def")
                                        {
                                            equipDef -= item.StatPoint;
                                        }
                                        else
                                        {
                                            equipAtk -= item.StatPoint;
                                        }
                                    }
                                
                                }

                                purchasedItems[intEquipmentActive - 1].IsEuipmented = !purchasedItems[intEquipmentActive - 1].IsEuipmented;
                                if (purchasedItems[intEquipmentActive - 1].StatType == "def") { equipDef += purchasedItems[intEquipmentActive - 1].StatPoint; } else { equipAtk += purchasedItems[intEquipmentActive - 1].StatPoint; }
                            }

                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                    }
                }
            }
        }


        public class ShowShop
        {
            // 상점 입장 시 기본 화면
            public void DisplayShop(List<Item> itemList, Status status, ref int equipAtk, ref int equipDef)
            {
                Console.WriteLine($"상점 \n필요한 아이템을 얻을 수 있는 상점입니다.\n [보유 골드]\n{status.Gold} G \n");

                Console.WriteLine("[아이템 목록]");

                for (int i = 0; i < itemList.Count; i++)
                {
                    Console.WriteLine($"- {(itemList[i].IsEuipmented ? "[E]" : "")} {itemList[i].Name} \t| {itemList[i].Desc} \t| {ConvertType(itemList[i].StatType)} +{itemList[i].StatPoint} \t| {(itemList[i].IsPurchased ? "구매완료" : itemList[i].HowMuch.ToString() + " G")}");
                }

                Console.WriteLine("1.아이템 구매\n2.아이템 판매\n3.나가기");
                Console.Write("원하시는 행동을 입력해주세요. \n>>");

                string shopActive = Console.ReadLine();

                switch (shopActive)
                {
                    case "1":
                        DisplayShopPurchase(itemList, status);
                        break;
                    case "2":
                        DisplayShopSale(itemList, status, ref equipAtk, ref equipDef);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("잘못 입력하셨습니다.");
                        DisplayShop(itemList, status, ref equipAtk, ref equipDef);
                        break;
                }
            }

            // 상점 입장 --> 구매 시 화면
            public void DisplayShopPurchase(List<Item> itemList, Status status )
            {
                    bool isKeepingPurchase = true;

                    while (isKeepingPurchase)
                    {

                        Console.WriteLine($"상점 - 아이템 구매\n필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]\n{status.Gold} G \n");

                        Console.WriteLine("[아이템 목록]");

                        int count2 = 1;

                        for (int i = 0; i < itemList.Count; i++)
                        {
                            Console.WriteLine($"- {count2}{(itemList[i].IsEuipmented ? " [E]" : "")} {itemList[i].Name} \t| {itemList[i].Desc} \t| {ConvertType(itemList[i].StatType)} +{itemList[i].StatPoint} \t| {(itemList[i].IsPurchased ? "구매완료" : itemList[i].HowMuch + " G")}");
                            count2++;
                        }

                        Console.WriteLine("0.나가기");
                        Console.Write("원하시는 행동을 입력해주세요. \n>>");

                        string purchaseEqu = Console.ReadLine();
                        int numPurchaseEqu = int.Parse(purchaseEqu);

                    if (numPurchaseEqu > 0 && numPurchaseEqu < count2)
                        {

                            if (itemList[numPurchaseEqu - 1].IsPurchased == false && status.Gold >= itemList[numPurchaseEqu - 1].HowMuch)
                            {
                                Console.WriteLine("구매를 완료했습니다."); status.Gold -= itemList[numPurchaseEqu - 1].HowMuch; (itemList[numPurchaseEqu - 1].IsPurchased) = true;
                            }
                            else if (status.Gold < itemList[numPurchaseEqu - 1].HowMuch) { Console.WriteLine("Gold 가 부족합니다."); }
                            else if (itemList[numPurchaseEqu - 1].IsPurchased == true) { Console.WriteLine("이미 구매한 아이템입니다."); }

                        }

                        else if (numPurchaseEqu == 0)
                        {
                            isKeepingPurchase = false;
                            return;
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                    }
                }

            // 상점 입장 --> 판매 시 화면
            public void DisplayShopSale(List<Item> itemList, Status status, ref int equipAtk, ref int equipDef) // 여기다가 ref 안쓰고 해보자
            {
                bool isKeepingSale = true;

                while (isKeepingSale)
                {

                    Console.WriteLine($"상점 - 아이템 판매\n필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]\n{status.Gold} G \n");

                    Console.WriteLine("[아이템 목록]");

                    int count3 = 1;

                    for (int i = 0; i < itemList.Count; i++)
                    {
                        if (itemList[i].IsPurchased == true)
                        {
                            Console.WriteLine($"- {(itemList[i].IsEuipmented ? "[E]" : "")}{itemList[i].Name} \t| {itemList[i].Desc} \t| {ConvertType(itemList[i].StatType)} +{itemList[i].StatPoint}");
                        }
                    }

                    Console.WriteLine("0.나가기");
                    Console.Write("원하시는 행동을 입력해주세요. \n>>");

                    string saletActive = Console.ReadLine();
                    int intSaleActive = int.Parse(saletActive);

                    if (saletActive == "0")
                    {
                        isKeepingSale = false;
                    }
                    else if (intSaleActive >= 1 && intSaleActive <= itemList.Count(i => i.IsPurchased))
                    {
                        var purchasedItems = itemList.Where(item => item.IsPurchased).ToList();

                        purchasedItems[intSaleActive - 1].IsPurchased = false;

                        status.Gold += (int)(purchasedItems[intSaleActive - 1].HowMuch * 0.85);

                        if (purchasedItems[intSaleActive - 1].IsEuipmented)
                        {
                            purchasedItems[intSaleActive - 1].IsEuipmented = !purchasedItems[intSaleActive - 1].IsEuipmented;
                            if (purchasedItems[intSaleActive - 1].StatType == "def") { equipDef -= purchasedItems[intSaleActive - 1].StatPoint; } else { equipAtk -= purchasedItems[intSaleActive - 1].StatPoint; }
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        DisplayShopSale(itemList, status, ref equipAtk, ref equipDef);
                    }
                }
            }
        }



        public class Rest
        {
            public int restPrice;
            public string restActive;
            public void getRest(Status status)
            {
                restPrice = 500;

                Console.WriteLine("휴식하기");
                Console.WriteLine($"{restPrice} G 를 내면 체력을 회복할 수 있습니다. (보유골드 : {status.Gold} G)\n");
                Console.WriteLine("1.휴식하기\n0.나가기\n");
                Console.Write("원하시는 행동을 입력해주세요. \n>>");

                restActive = Console.ReadLine();

                if (restActive == "1")
                {
                    if (status.Gold > 500 && status.HealthPoint < status.MaxHealthPoint)
                    {
                        Console.WriteLine("휴식을 완료했습니다.");
                        status.Gold -= restPrice;
                        status.HealthPoint = status.MaxHealthPoint;
                        getRest(status);
                    }
                    else if (status.Gold < 500)
                    {
                        Console.WriteLine("Gold가 부족합니다.");
                        getRest(status);
                    }
                    else
                    {
                        Console.WriteLine("최대 체력입니다.");
                        getRest(status);
                    }
                }
                else if(restActive == "0") { return; }
                else
                {
                    Console.WriteLine("잘못 입력하셨습니다.");
                    getRest(status);
                }
            }
        }

        public class Dungeon
        {
            public string dungeonActive;
            public void DisplayDungeon(Status status, int equipAtk, int equipDef)
            {

                Console.WriteLine("던전입장");
                Console.WriteLine("이곳에서 던전에 들어가기전 활동을 할 수 있습니다.\n");
                Console.WriteLine("1.쉬운 던전\t| 방어력 5 이상 권장\n1.일반 던전\t| 방어력 11 이상 권장\n3.어려운 던전\t| 방어력 17 이상 권장\n0.나가기\n");
                Console.Write("원하시는 행동을 입력해주세요. \n>>");

                dungeonActive = Console.ReadLine();

                switch (dungeonActive)
                {
                    case "1":
                        int easyLevel = 5;
                        EnterDungeon(status, easyLevel, equipAtk, equipDef);
                        break;
                    
                    case "2":
                        int normalDificulty = 11;
                        EnterDungeon(status, normalDificulty, equipAtk, equipDef);
                        break;
                    
                    case "3":
                        int hardDificulty = 17;
                        EnterDungeon(status, hardDificulty, equipAtk, equipDef);
                        break;
                    
                    case "0":
                        return;

                    default:
                        Console.WriteLine("잘못 입력하셨습니다.");
                        DisplayDungeon(status, equipAtk, equipDef);
                        break;
                }
            }

            public void EnterDungeon(Status status, int dificulty, int equipAtk, int equipDef)
            {
                Random random = new Random();
                int randomMinusHealthy = random.Next(20, 36);
                int defMinushealthy = (status.DefensePoint + equipDef) - dificulty;
                int totalMinusHealthy = randomMinusHealthy + (defMinushealthy * -1);
                int clearReward = 1;

                switch(dificulty)
                {
                    case 5:
                        clearReward = 1000;
                        break;
                    case 11:
                        clearReward = 1700;
                        break;
                    case 17:
                        clearReward = 2500;
                        break;
                    default:
                        Console.WriteLine("난이도 설정에 문제가 있으니 코드 확인해보세요");
                        break;
                }

                int totalReward = clearReward + (int)(clearReward * random.Next((status.AttackPoint + equipAtk), 2 * (status.AttackPoint + equipAtk)) * 0.01);


                // 권장 방어력보다 낮을 때 40% 확률로 실패. 보상 없이 체력 1/2로 감소;
                if ((status.DefensePoint + equipDef) < dificulty)
                {
                    int percent = random.Next(0, 10);
                    if (percent < 4)
                    {
                        Console.WriteLine("던전 실패");
                        Console.WriteLine("체력 감소 전" + status.HealthPoint);
                        status.HealthPoint /= 2;
                        Console.WriteLine("체력 감소 후" + status.HealthPoint);
                    }
                    // 권장 방어력보다 낮을 때, 60% 확률로 던전 클리어. 
                    // 1. 방어력에 비례해 체력 감소 변동,
                    // 2. 공격력에 비례해 보상 획득 증가
                    else
                    {
                        status.HealthPoint -= totalMinusHealthy;
                        status.Gold += totalReward;
                        status.LevelUp(status);
                    }
                }
                // 권장 방어력보다 높으면 무조건 성공.
                else
                {
                    status.HealthPoint -= totalMinusHealthy;
                    status.Gold += totalReward;
                    status.LevelUp(status);
                }
            }
        }
    }
}
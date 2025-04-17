//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;
//using System.Collections.Generic;
//using static ConsoleApp1.personalProjectTest;
//using System.Security.Cryptography.X509Certificates;


//namespace ConsoleApp1
//{
//    internal class personalProjectTest
//    {

//        static void Main(string[] args)
//        {

//            Status status = new Status();

//            List<Item> itemList = new List<Item>();
//            itemList.Add(new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", "def", 5, 1000));
//            itemList.Add(new Item("무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", "def", 9, 2000));
//            itemList.Add(new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", "def", 15, 3500));
//            itemList.Add(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", "atk", 2, 600));
//            itemList.Add(new Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", "atk", 5, 1500));
//            itemList.Add(new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", "atk", 7, 3500));


//            // 값 제대로 담겼는지 확인용
//            /*foreach (Item item in itemList)
//            {
//                Console.WriteLine("Name" + item.Name);
//                Console.WriteLine("Desc" + item.Desc);
//                Console.WriteLine("장비여부" + item.IsEuipmented);
//                Console.WriteLine("구매여부" + item.IsPurchased);
//                Console.WriteLine("장비포인트" + item.StatPoint);
//                Console.WriteLine("장비타입" + item.StatType);
//                Console.WriteLine("HowMuch" + item.HowMuch);
//            } */

//            // items.Count(item => item.isEquipped)

//            // List담긴 값 불러오기
//            //for (int i = 0; i < itemList.Count; i++) {
//            //        Console.WriteLine($"{itemList[i].Name} \t| {itemList[i].Desc} \t| {ConvertType(itemList[i].StatType)} +{itemList[i].StatPoint}");
//            //}

//            bool isPlaying = true;
//            int hasEquipCount = 1;
//            int equipAtk = 0;
//            int equipDef = 0;

//            while (isPlaying)

//            {
//                Console.WriteLine("다음 반복?");
//                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
//                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다. + \n");
//                Console.WriteLine("1.상태보기\n2.인벤토리\n3.상점\n0.게임종료");
//                Console.Write("원하시는 행동을 입력해주세요. \n>>");

//                string mainActive = Console.ReadLine();

//                switch (mainActive)
//                {
//                    case "1":
//                        isPlaying = false;

//                        Console.WriteLine("상태 보기 \n캐릭터의 정보가 표시됩니다.\n");
//                        Console.WriteLine($"Lv. {status.level} \nChad ( {status.className} )\n공격력 : {status.attackPoint} {(equipAtk > 0 ? $"(+{equipAtk})" : "")}\n방어력 : {status.defensePoint} {(equipDef > 0 ? $"(+{equipDef})" : "")}\n체 력 : {status.healthPoint}\nGold : {status.gold} G\n");
//                        Console.WriteLine("0. 나가기\n");
//                        Console.Write("원하시는 행동을 입력해주세요. \n>>");

//                        string statusActive = Console.ReadLine();

//                        if (statusActive == "0") { isPlaying = true; } else { mainActive = "1"; }

//                            break;
//                    case "2":
//                        isPlaying = false;
//                        Console.WriteLine("인벤토리 \n보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]\n");

//                        for (int i = 0; i < itemList.Count; i++)
//                        {
//                            if (itemList[i].IsPurchased == true)
//                            {
//                                Console.WriteLine($"- {(itemList[i].IsEuipmented ? "[E]" : "")}{itemList[i].Name} \t| {itemList[i].Desc} \t| {ConvertType(itemList[i].StatType)} +{itemList[i].StatPoint}");

//                            }
//                        }

//                        Console.WriteLine("\n1.장착 관리\n0.나가기\n");
//                        Console.Write("원하시는 행동을 입력해주세요. \n>>");
//                        string inventoryActive = Console.ReadLine();

//                        if (inventoryActive == "0")
//                        {
//                            isPlaying = true;
//                        }
//                        else if (inventoryActive == "1")
//                        {

//                            bool isKeepingEquipment = true;

//                            while (isKeepingEquipment)
//                            {

//                                Console.WriteLine("인벤토리 - 장착 관리\n보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]");

//                                int count1 = hasEquipCount;

//                                for (int i = 0; i < itemList.Count; i++)
//                                {
//                                    if (itemList[i].IsPurchased == true)
//                                    {
//                                        Console.WriteLine($"- {(itemList[i].IsEuipmented ? "[E]" : "")}{count1} {itemList[i].Name} \t| {itemList[i].Desc} \t| {ConvertType(itemList[i].StatType)} +{itemList[i].StatPoint}");
//                                        count1++;

//                                    }
//                                }

//                                Console.WriteLine("0.나가기");
//                                Console.Write("원하시는 행동을 입력해주세요. \n>>");

//                                string equipmentActive = Console.ReadLine();
//                                int intEquipmentActive = int.Parse(equipmentActive);

//                                if (equipmentActive == "0")
//                                {
//                                    isKeepingEquipment = false;
//                                    isPlaying = true;
//                                }
//                                else if (intEquipmentActive >= 1 && intEquipmentActive <= itemList.Count(i => i.IsPurchased))
//                                {
//                                    var purchasedItems = itemList.Where(item => item.IsPurchased).ToList();

//                                    if (purchasedItems[intEquipmentActive - 1].IsEuipmented)
//                                    {
//                                        purchasedItems[intEquipmentActive - 1].IsEuipmented = !purchasedItems[intEquipmentActive - 1].IsEuipmented;
//                                        if (purchasedItems[intEquipmentActive - 1].StatType == "def") { equipDef -= purchasedItems[intEquipmentActive - 1].StatPoint; } else { equipAtk -= purchasedItems[intEquipmentActive - 1].StatPoint; }
//                                    }
//                                    else
//                                    {
//                                        purchasedItems[intEquipmentActive - 1].IsEuipmented = !purchasedItems[intEquipmentActive - 1].IsEuipmented;
//                                        if (purchasedItems[intEquipmentActive - 1].StatType == "def") { equipDef += purchasedItems[intEquipmentActive - 1].StatPoint; } else { equipAtk += purchasedItems[intEquipmentActive - 1].StatPoint; }
//                                    }

//                                }
//                                else
//                                {
//                                    Console.WriteLine("잘못된 입력입니다.");
//                                }
//                            }
//                        }

//                        break;
//                    case "3":
//                        isPlaying = false;

//                        Console.WriteLine($"상점 \n필요한 아이템을 얻을 수 있는 상점입니다.\n [보유 골드]\n{status.gold} G \n");

//                        Console.WriteLine("[아이템 목록]");

//                        for (int i = 0; i < itemList.Count; i++)
//                        {
//                            Console.WriteLine($"- {(itemList[i].IsEuipmented ? "[E]" : "")} {itemList[i].Name} \t| {itemList[i].Desc} \t| {ConvertType(itemList[i].StatType)} +{itemList[i].StatPoint} \t| {(itemList[i].IsPurchased ? "구매완료" : itemList[i].HowMuch.ToString() + " G")}");
//                        }

//                        Console.WriteLine("1.아이템 구매\n2.나가기");
//                        Console.Write("원하시는 행동을 입력해주세요. \n>>");

//                        string shopActive = Console.ReadLine();

//                        if (shopActive == "2")
//                        {
//                            isPlaying = true;
//                        }
//                        else if (shopActive == "1")
//                        {

//                            bool isKeepingPurchase = true;

//                            while (isKeepingPurchase)
//                            {

//                                Console.WriteLine($"상점 - 아이템 구매\n필요한 아이템을 얻을 수 있는 상점입니다.\n [보유 골드]\n{status.gold} G \n");

//                                Console.WriteLine("[아이템 목록]");

//                                int count2 = hasEquipCount;

//                                for (int i = 0; i < itemList.Count; i++)
//                                {

//                                    Console.WriteLine($"- {count2}{(itemList[i].IsEuipmented ? " [E]" : "")} {itemList[i].Name} \t| {itemList[i].Desc} \t| {ConvertType(itemList[i].StatType)} +{itemList[i].StatPoint} \t| {(itemList[i].IsPurchased ? "구매완료" : itemList[i].HowMuch + " G")}");
//                                    count2++;
//                                }

//                                Console.WriteLine("0.나가기");
//                                Console.Write("원하시는 행동을 입력해주세요. \n>>");

//                                string purchaseEqu = Console.ReadLine();
//                                int numPurchaseEqu = int.Parse(purchaseEqu);

//                                if (numPurchaseEqu > 0 && numPurchaseEqu < 7)
//                                {

//                                    if (itemList[numPurchaseEqu - 1].IsPurchased == false && status.gold >= itemList[numPurchaseEqu - 1].HowMuch)
//                                    {
//                                        Console.WriteLine("구매를 완료했습니다."); status.gold -= itemList[numPurchaseEqu - 1].HowMuch; (itemList[numPurchaseEqu - 1].IsPurchased) = true;
//                                    }
//                                    else if (status.gold < itemList[numPurchaseEqu - 1].HowMuch) { Console.WriteLine("Gold 가 부족합니다."); }
//                                    else if (itemList[numPurchaseEqu - 1].IsPurchased == true) { Console.WriteLine("이미 구매한 아이템입니다."); }
//                                }

//                                else if (numPurchaseEqu == 0)
//                                {
//                                    isKeepingPurchase = false;
//                                    isPlaying = true;
//                                }
//                                else
//                                {
//                                    Console.WriteLine("잘못된 입력입니다.");
//                                }
//                            }
//                        }
//                        break;

//                    case "0":
//                        Console.WriteLine("게임을 종료합니다.");
//                        break;
//                    default:
//                        Console.WriteLine("잘못된 입력입니다.");
//                        break;
//                }
//            }
//        }


//        struct Status()
//        {
//            public string level = "01";
//            public string name = "Jone";
//            public string className = "전사";
//            public int attackPoint = 10;
//            public int defensePoint = 5;
//            public int healthPoint = 100;
//            public int gold = 50000;
//        }

//        enum PlayerActive
//        {
//            gameEnd = 0,
//            showStatus = 1,
//            showInventory = 2,
//            showShop = 3,
//        }


//        public class Item
//        {
//            public String Name { get; set; }
//            public String Desc { get; set; }
//            public Boolean IsPurchased { get; set; }
//            public Boolean IsEuipmented { get; set; }
//            public String StatType { get; set; }
//            public int StatPoint { get; set; }
//            public int HowMuch { get; set; }

//            public Item(string name, string desc, string statType, int statPoint, int howMuch)
//            {
//                Name = name;
//                Desc = desc;
//                IsPurchased = false;
//                IsEuipmented = false;
//                StatType = statType;
//                StatPoint = statPoint;
//                HowMuch = howMuch;
//            }
//        }

//        static string ConvertType(string type)
//        {
//            if (type == "def") return "방어력";

//            return "공격력";
//        }

//    }
//}
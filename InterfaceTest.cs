//using static ConsoleApp1.InterfaceTest;

//namespace ConsoleApp1
//{
//    internal class InterfaceTest
//    {
//        //public interface IMovable
//        //{
//        //    void Move(int x, int y);
//        //}

//        //public class Player : IMovable
//        //{
//        //    public void Move(int x, int y)
//        //    {

//        //    }

//        //}

//        //public class Enermy : IMovable
//        //{
//        //    public void Move(int x, int y)
//        //    {

//        //    }

//        //}

//        //    public interface IUsable
//        //{
//        //    void Use();
//        //}

//        //public class Item : IUsable
//        //{

//        //    public string Name { get; set; }
//        //    public void Use()
//        //    {
//        //        Console.WriteLine($"아이템 {Name}을 사용하셨습니다.");
//        //    }
//        //}

//        //public class Player
//        //{      public void UseItem(IUsable item)
//        //    {
//        //        item.Use();
//        //    }
//        //}

//        public enum Month
//        {
//            Jar = 1,
//            Feb,
//            Mar,
//            Apr,
//            May,
//            Jun,
//            Jul,
//            Aug,
//            Sep,
//            Oct,
//            Nov,
//            Dec,
//        }

//        public static void ProcessMonth(int month)
//        {
//            if (month >= (int) Month.Jar && month <= (int)Month.Dec)
//            {
//                Month selectMonth = (Month)month;
//                Console.WriteLine($"선택한 월은 {selectMonth}입니다.");
//            }
//        }


//        // NegativeNumberException을 실행하면 Exception Exception의 base가 먼저 실행되고, 이후 자신의 message가 실행됨.
//        public class NegativeNumberException : Exception
//        {
//            public NegativeNumberException(string message) : base(message)
//            {
//            }
//        }






//        static void Main(string[] args)
//        {

//            //int userInput = 4;
//            //ProcessMonth(userInput);


//            //Player player = new Player();
//            //Item item = new Item() { Name = "Health potion"};

//            //player.UseItem(item);

//            //IMovable movableObject1 = new Enermy();
//            //IMovable movableObject2 = new Player();

//            //movableObject1.Move(1, 2);
//            //movableObject2.Move(1, 9);

//            try
//            {
//                int number = -10;
//                if (number < 0)
//                {
//                    throw new NegativeNumberException("음수는 처리할 수 없습니다.");
//                }
//            }
//            catch (NegativeNumberException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("예외가 발생했습니다: " + ex.Message);
//            }




//        }
//    }
//}
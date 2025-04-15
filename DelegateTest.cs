namespace ConsoleApp1
{
    internal class DelegateTest
    {
        //delegate void MyDelegate(string message);

        //static void Method1(string message)
        //{
        //    Console.WriteLine("Method1: " + message);
        //}

        //static void Method2(string message)
        //{
        //    Console.WriteLine("Method2: " + message);
        //}


        //// 델리게이트 선언
        //public delegate void EnemyAttackHandler(float damage);

        //// 적 클래스
        //public class Enemy
        //{
        //    // 공격 이벤트
        //    public event EnemyAttackHandler OnAttack;

        //    // 적의 공격 메서드
        //    public void Attack(float damage)
        //    {
        //        // 이벤트 호출
        //        OnAttack?.Invoke(damage);
        //        // null 조건부 연산자
        //        // null 참조가 아닌 경우에만 멤버에 접근하거나 메서드를 호출
        //    }
        //}

        //// 플레이어 클래스
        //public class Player
        //{
        //    // 플레이어가 받은 데미지 처리 메서드
        //    public void HandleDamage(float damage)
        //    {
        //        // 플레이어의 체력 감소 등의 처리 로직
        //        Console.WriteLine("플레이어가 {0}의 데미지를 입었습니다.", damage);
        //    }
        //}


        static int Add(int x, int y)
            { return x + y; }


        static void PrintMessage(string message) { Console.WriteLine(message); }



        static void Main(string[] args)
        {

            Func<int, int, int> addFunc = Add;
            int Result = addFunc(3, 5);

            Console.WriteLine(Result);

            Action<string> message = PrintMessage;
            Console.WriteLine(message);



            //// 적 객체 생성
            //Enemy enemy = new Enemy();

            //// 플레이어 객체 생성
            //Player player = new Player();

            //// 플레이어의 데미지 처리 메서드를 적의 공격 이벤트에 추가
            //enemy.OnAttack += player.HandleDamage;

            //// 적의 공격
            //enemy.Attack(10.0f);




            //MyDelegate myDelegate = Method1;
            //myDelegate += Method2;

            //myDelegate("Hello");

        }
    }
}



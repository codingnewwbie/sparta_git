//namespace ConsoleApp1
//{
//    internal class Program2
//    {
//        static void Main(string[] args)
//        {

//            // 챕터 2 실습
//            //int playerScore = 80;

//            //if (playerScore >= 70)
//            //{
//            //    Console.WriteLine("플레이어의 점수는 70점 이상입니다. 합격입니다!");
//            //}
//            //Console.WriteLine("프로그램이 종료됩니다.");


//            //int itemCount = 5;
//            //string itemName = "HP 포션";

//            //if (itemCount > 0)
//            //{
//            //    Console.WriteLine($"보유한 {itemName}의 수량: {itemCount}");
//            //}
//            //else
//            //{
//            //    Console.WriteLine($"보유한 {itemName}이 없습니다.");
//            //}

//            //Console.WriteLine("게임을 시작합니다.");
//            //Console.WriteLine("1: 전사 / 2: 마법사 / 3: 궁수");
//            //Console.Write("직업을 선택하세요: ");
//            //string job = Console.ReadLine();

//            //switch (job)
//            //{
//            //    case "1":
//            //        Console.WriteLine("전사를 선택하셨습니다.");
//            //        break;
//            //    case "2":
//            //        Console.WriteLine("마법사를 선택하셨습니다.");
//            //        break;
//            //    case "3":
//            //        Console.WriteLine("궁수를 선택하셨습니다.");
//            //        break;
//            //    default:
//            //        Console.WriteLine("올바른 값을 입력해주세요.");
//            //        break;
//            //}

//            //Console.WriteLine("게임을 종료합니다.");

//            //Console.Write("문자를 입력하세요: ");
//            //char input = Console.ReadLine()[0];

//            //if (input >= 'A' && input <= 'z') //if (input >= 'a' && input <= 'z' || input >= 'A' && input <= 'Z')
//            //{
//            //    Console.WriteLine("알파벳입니다.");
//            //}
//            //else
//            //{
//            //    Console.WriteLine("알파벳이 아닙니다.");
//            //}


//            //for (int i = 2; i <= 9; i++)
//            //{
//            //    for (int j = 1; j <= 9; j++)
//            //    {
//            //        Console.Write(j + " x " + i + " = " + (j * i) + " \t");
//            //    }
//            //    Console.WriteLine();
//            //}


//            //for (int i = 1; i <= 10; i++)
//            //{
//            //    if (i % 3 == 0)
//            //    {
//            //        continue; // 3의 배수인 경우 다음 숫자로 넘어감
//            //    }

//            //    Console.WriteLine(i);
//            //    if (i == 7)
//            //    {
//            //        break; // 7이 출력된 이후에는 반복문을 빠져나감
//            //    }
//            //}



//            //int sum = 0;

//            //while (true)
//            //{
//            //    Console.Write("숫자를 입력하세요: ");
//            //    int input = int.Parse(Console.ReadLine());

//            //    if (input == 0)
//            //    {
//            //        Console.WriteLine("프로그램을 종료합니다.");
//            //        break;
//            //    }

//            //    if (input < 0)
//            //    {
//            //        Console.WriteLine("음수는 무시합니다.");
//            //        continue;
//            //    }

//            //    sum += input;
//            //    Console.WriteLine("현재까지의 합: " + sum);
//            //}

//            //Console.WriteLine("합계: " + sum);


//            //string[] choices = { "가위", "바위", "보" };
//            //string playerChoice = "";
//            //string computerChoice = choices[new Random().Next(0, 3)];

//            //while (playerChoice != computerChoice)
//            //{
//            //    Console.Write("가위, 바위, 보 중 하나를 선택하세요: ");
//            //    playerChoice = Console.ReadLine();

//            //    Console.WriteLine("컴퓨터: " + computerChoice);

//            //    if (playerChoice == computerChoice)
//            //    {
//            //        Console.WriteLine("비겼습니다!");
//            //    }
//            //    else if ((playerChoice == "가위" && computerChoice == "보") ||
//            //             (playerChoice == "바위" && computerChoice == "가위") ||
//            //             (playerChoice == "보" && computerChoice == "바위"))
//            //    {
//            //        Console.WriteLine("플레이어 승리!");
//            //    }
//            //    else
//            //    {
//            //        Console.WriteLine("컴퓨터 승리!");
//            //    }
//            //}


//            // 컴퓨터 가위바위보 바꾸기
//            //string[] choices = { "가위", "바위", "보" };

//            //while (true)
//            //{
//            //    string playerChoice = "";
//            //    string computerChoice = choices[new Random().Next(0, 3)];

//            //    Console.Write("가위, 바위, 보 중 하나를 선택하세요: ");
//            //    playerChoice = Console.ReadLine();

//            //    Console.WriteLine("컴퓨터: " + computerChoice);

//            //    if (playerChoice == computerChoice)
//            //    {
//            //        Console.WriteLine("비겼습니다!");
//            //        break;
//            //    }
//            //    else if ((playerChoice == "가위" && computerChoice == "보") ||
//            //             (playerChoice == "바위" && computerChoice == "가위") ||
//            //             (playerChoice == "보" && computerChoice == "바위"))
//            //    {
//            //        Console.WriteLine("플레이어 승리!");
//            //    }
//            //    else
//            //    {
//            //        Console.WriteLine("컴퓨터 승리!");
//            //    }
//            //}

//            //    int targetNumber = new Random().Next(1, 101); ;
//            //    int guess = 0;
//            //    int count = 0;

//            //    Console.WriteLine("1부터 100 사이의 숫자를 맞춰보세요.");

//            //    while (guess != targetNumber)
//            //    {
//            //        if (guess == targetNumber)
//            //        {
//            //            Console.WriteLine("축하합니다. 정답입니다");
//            //        }
//            //        else if (guess > targetNumber)
//            //        {
//            //            Console.WriteLine("그 수보다 작습니다");
//            //            count++;
//            //            guess = int.Parse(Console.ReadLine());
//            //        }
//            //        else {
//            //            Console.WriteLine("그 수보다 큽니다");
//            //            count++;
//            //            guess = int.Parse(Console.ReadLine());
//            //        }
//            //    }
//            //    Console.WriteLine($"{count}번만에 맞추셨습니다.");


//            // 위와 같은 결과지만 다른 방식의 코드
//            //int targetNumber = new Random().Next(1, 101); ;
//            //int guess = 0;
//            //int count = 0;

//            //Console.WriteLine("1부터 100 사이의 숫자를 맞춰보세요.");

//            //while (guess != targetNumber)
//            //{
//            //    Console.Write("추측한 숫자를 입력하세요: ");
//            //    guess = int.Parse(Console.ReadLine());
//            //    count++;

//            //    if (guess < targetNumber)
//            //    {
//            //        Console.WriteLine("좀 더 큰 숫자를 입력하세요.");
//            //    }
//            //    else if (guess > targetNumber)
//            //    {
//            //        Console.WriteLine("좀 더 작은 숫자를 입력하세요.");
//            //    }
//            //    else
//            //    {
//            //        Console.WriteLine("축하합니다! 숫자를 맞추셨습니다.");
//            //        Console.WriteLine("시도한 횟수: " + count);
//            //    }
//            //}

//        }
//    }
//}

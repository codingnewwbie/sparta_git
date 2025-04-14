//namespace ConsoleApp1
//{
//    internal class Program3
//    {
//        static void Main(string[] args)
//        {
//            // 플레이어의 공격력, 방어력, 체력, 스피드를 저장할 배열
//            //int[] playerStats = new int[4];

//            //// 능력치를 랜덤으로 생성하여 배열에 저장
//            //Random rand = new Random();
//            //for (int i = 0; i < playerStats.Length; i++)
//            //{
//            //    playerStats[i] = rand.Next(1, 11);
//            //}

//            //// 능력치 출력
//            //Console.WriteLine("플레이어의 공격력: " + playerStats[0]);
//            //Console.WriteLine("플레이어의 방어력: " + playerStats[1]);
//            //Console.WriteLine("플레이어의 체력: " + playerStats[2]);
//            //Console.WriteLine("플레이어의 스피드: " + playerStats[3]);



//            //int[] scores = new int[5];  // 5명의 학생 성적을 저장할 배열

//            //// 성적 입력 받기
//            //for (int i = 0; i < scores.Length; i++)
//            //{
//            //    Console.Write("학생 " + (i + 1) + "의 성적을 입력하세요: ");
//            //    scores[i] = int.Parse(Console.ReadLine());
//            //}

//            //// 성적 총합 계산
//            //int sum = 0;
//            //for (int i = 0; i < scores.Length; i++)
//            //{
//            //    sum += scores[i];
//            //}

//            //// 성적 평균 출력
//            //double average = (double)sum / scores.Length;
//            //Console.WriteLine("성적 평균은 " + average + "입니다.");


//            //Random random = new Random();  // 랜덤 객체 생성
//            //int[] numbers = new int[3];  // 3개의 숫자를 저장할 배열

//            //// 3개의 랜덤 숫자 생성하여 배열에 저장
//            //for (int i = 0; i < numbers.Length; i++)
//            //{
//            //    numbers[i] = random.Next(1, 10);
//            //}

//            //int attempt = 0;  // 시도 횟수 초기화
//            //while (true)
//            //{
//            //    Console.Write("3개의 숫자를 입력하세요 (1~9): ");
//            //    int[] guesses = new int[3];  // 사용자가 입력한 숫자를 저장할 배열

//            //    // 사용자가 입력한 숫자 배열에 저장
//            //    for (int i = 0; i < guesses.Length; i++)
//            //    {
//            //        guesses[i] = int.Parse(Console.ReadLine());
//            //    }

//            //    int correct = 0;  // 맞춘 숫자의 개수 초기화

//            //    // 숫자 비교 및 맞춘 개수 계산
//            //    for (int i = 0; i < numbers.Length; i++)
//            //    {
//            //        for (int j = 0; j < guesses.Length; j++)
//            //        {
//            //            if (numbers[i] == guesses[j])
//            //            {
//            //                correct++;
//            //                break;
//            //            }
//            //        }
//            //    }

//            //    attempt++;  // 시도 횟수 증가
//            //    Console.WriteLine("시도 #" + attempt + ": " + correct + "개의 숫자를 맞추셨습니다.");

//            //    // 모든 숫자를 맞춘 경우 게임 종료
//            //    if (correct == 3)
//            //    {
//            //        Console.WriteLine("축하합니다! 모든 숫자를 맞추셨습니다.");
//            //        break;
//            //    }
//            //}

//            // 2차원 배열로 맵 생성
//            //            int[,] map = new int[5, 5]
//            //{
//            //            { 1, 1, 1, 1, 1 },
//            //            { 1, 0, 0, 0, 1 },
//            //            { 1, 0, 1, 0, 1 },
//            //            { 1, 0, 0, 0, 1 },
//            //            { 1, 1, 1, 1, 1 }
//            //};

//            //            for (int i = 0; i < 5; i++)
//            //            {
//            //                for (int j = 0; j < 5; j++)
//            //                {
//            //                    if (map[i, j] == 1)
//            //                    {
//            //                        Console.Write("■ ");
//            //                    }
//            //                    else
//            //                    {
//            //                        Console.Write("□ ");
//            //                    }
//            //                }
//            //                Console.WriteLine();
//            //            }



//            //void PrintLine()
//            //{
//            //    for (int i = 0; i < 10; i++)
//            //    {
//            //        Console.Write("=");
//            //    }
//            //    Console.WriteLine();
//            //}

//            //void PrintLine2(int count)
//            //{
//            //    for (int i = 0; i < count; i++)
//            //    {
//            //        Console.Write("=");
//            //    }
//            //    Console.WriteLine();
//            //}

//            //int Add(int x, int y)
//            //{
//            //    return x + y;
//            //}



//            //PrintLine();
//            //PrintLine2(20);

//            //int result = Add(10, 20);
//            //Console.WriteLine(result);

//            //int sum1 = Add(10, 20);
//            //float sum2 = Add(10.5f, 21.1f);
//            //int sum3 = Add(10, 20, 30);


//            //Console.WriteLine(sum1 + sum2 + sum3);


            

//            // 메서드 호출
//            CountDown(5);


//        }


//        static void CountDown(int n)
//        {
//            if (n <= 0)
//            {
//                Console.WriteLine("Done");
//            }
//            else
//            {
//                Console.WriteLine(n);
//                CountDown(n - 1);  // 자기 자신을 호출
//            }
//        }


//        //static int Add(int a, int b)
//        //{
//        //    return a + b;
//        //}

//        //static int Add(int a, int b, int c)
//        //{
//        //    return a + b + c;
//        //}

//        //static float Add(float a, float b)
//        //{
//        //    return a + b;
//        //}

//    }
//}

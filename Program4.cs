//namespace ConsoleApp1
//{
//    internal class Program4
//    {
//        static void Main(string[] args)
//        {
//            //Dog dog = new Dog();
//            //dog.Name = "Bobby";
//            //dog.Age = 3;

//            //dog.Eat();
//            //dog.Sleep();
//            //dog.Bark();


//            //Cat cat = new Cat();
//            //cat.Name = "moew";
//            //cat.Age = 3;

//            //cat.Eat();
//            //cat.Sleep();
//            //cat.Meow();

//            //Marine marine = new Marine();
//            //marine.Move();
//            //marine.Attack();

//            //Zergling zergling = new Zergling();
//            //zergling.Move();
//            //zergling.Attack();

//            //// #2 참조형태와 실형태가 다를때
//            //List<Unit> list = new List<Unit>();
//            //list.Add(new Marine());
//            //list.Add(new Zergling());

//            //foreach (Unit unit in list)
//            //{
//            //    unit.Move();
//            //}

//            //Stack<int> intStack = new Stack<int>();
//            //intStack.Push(1);
//            //intStack.Push(2);
//            //intStack.Push(3);
//            //Console.WriteLine(intStack.Pop()); // 출력 결과: 3


//            // out 키워드 사용 예시
//            void Divide(int a, int b, out int quotient, out int remainder)
//            {
//                quotient = a / b;
//                remainder = a % b;
//            }

//            int quotient, remainder;
//            Divide(7, 3, out quotient, out remainder);
//            Console.WriteLine($"{quotient}, {remainder}"); // 출력 결과: 2, 1

//            // ref 키워드 사용 예시
//            void Swap(ref int a, ref int b)
//            {
//                int temp = a;
//                a = b;
//                b = temp;
//            }

//            int x = 1, y = 2;
//            Swap(ref x, ref y);
//            Console.WriteLine($"{x}, {y}"); // 출력 결과: 2, 1




//            int age;
//            float age2 = 35.5f;
            

//            age = (int)age2;

//            Console.WriteLine(age);


//            Console.WriteLine(Int32.Parse(age.ToString()));
//            Console.WriteLine(int.Parse(age.ToString()));


//        }


//        // 접근제한 or 유효성 검사
//        class Person
//        {
//            private string name;
//            private int age;

//            public string Name
//            {
//                get { return name; }
//                private set { name = value; }
//            }

//            public int Age
//            {
//                get { return age; }
//                set
//                {
//                    if (value >= 0)
//                        age = value;
//                }
//            }
//        }




//        //자동 프로퍼티
//        //class Person
//        //{
//        //    public string Name { get; set; }
//        //    public int Age { get; set; }
//        //}



//        // 부모 클래스
//        //public class Animal
//        //{
//        //    public string Name { get; set; }
//        //    public int Age { get; set; }

//        //    public void Eat()
//        //    {
//        //        Console.WriteLine("Animal is eating.");
//        //    }

//        //    public void Sleep()
//        //    {
//        //        Console.WriteLine("Animal is sleeping.");
//        //    }
//        //}

//        //// 자식 클래스
//        //public class Dog : Animal
//        //{


//        //    public void Bark()
//        //    {
//        //        Console.WriteLine("Dog is barking");
//        //    }
//        //}

//        //public class Cat : Animal
//        //{
//        //    public void Meow()
//        //    {
//        //        Console.WriteLine("Cat is Meow");
//        //    }


//        //    public void Sleep()
//        //    {
//        //        Console.WriteLine("Cat Sleep!");
//        //    }
//        //}

//        //public class Unit
//        //{
//        //    public virtual void Move()
//        //    {
//        //        Console.WriteLine("두발로 걷기");
//        //    }

//        //    public void Attack()
//        //    {
//        //        Console.WriteLine("Unit 공격");
//        //    }
//        //}

//        //public class Marine : Unit
//        //{

//        //}

//        //public class Zergling : Unit
//        //{
//        //    public override void Move()
//        //    {
//        //        Console.WriteLine("네발로 걷기");
//        //    }
//        //}


//        // 제너릭 클래스 선언 예시
//        class Stack<T> // 선입후출
//        {
//            private T[] elements;
//            private int top;

//            public Stack()
//            {
//                elements = new T[100];
//                top = 0;
//            }

//            public void Push(T item)
//            {
//                elements[top++] = item; // 넣을 땐 item을 top에 대입하고 난 뒤 top += 처리. (T[0]에 1을 넣고 0 + 1, T[1]에 2을 넣고 1+1 ...)
//            }

//            public T Pop()
//            {
//                return elements[--top]; // 뺄 땐 top에 -1을 하고(넣고 나서 + 해서 그냥 top에는 데이터 없음) 빼는 값 출력.
//            }
//        }





//    }
//}

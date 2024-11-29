namespace OrderedArray
{
    class Program
    {
        public static void Main()
        {
            // new Program().TestOrderedList1();
            // new Program().TestOrderedList2();
            OrderedListBenchmark.RunBenchmark();
        }

        private void TestOrderedList1()
        {
            int[] randomNumbers = new int[10];
            Random rand = new Random();

            for (int i = 0; i < randomNumbers.Length; i++)
            {
                int randNum = rand.Next(0, 100);

                // Ensures no duplicates
                while (randomNumbers.Contains(randNum))
                {
                    randNum = rand.Next(0, 100);
                }

                randomNumbers[i] = randNum;
            }

            Console.WriteLine($"Random Numbers: {String.Join(", ", randomNumbers)}");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();

            MyOrderedList1<int> list = new MyOrderedList1<int>();

            foreach(int num in randomNumbers)
            {
                list.Insert(num);
            }

            Console.WriteLine(list);

        }

        private void TestOrderedList2()
        {
            int[] randomNumbers = new int[10];
            Random rand = new Random();

            for (int i = 0; i < randomNumbers.Length; i++)
            {
                int randNum = rand.Next(0, 100);

                // Ensures no duplicates
                while (randomNumbers.Contains(randNum))
                {
                    randNum = rand.Next(0, 100);
                }

                randomNumbers[i] = randNum;
            }

            Console.WriteLine($"Random Numbers: {String.Join(", ", randomNumbers)}");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();

            MyOrderedList2<int> list = new MyOrderedList2<int>();

            foreach (int num in randomNumbers)
            {
                list.Insert(num);
            }

            Console.WriteLine(list);

        }
    }

}
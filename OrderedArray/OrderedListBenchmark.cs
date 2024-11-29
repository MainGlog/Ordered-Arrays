/*
* !!!RUN IN RELEASE CONFIGURATION WHEN BENCHMARKING!!!
*/

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace OrderedArray
{
    public class OrderedListBenchmark
    {
        public static void RunBenchmark()
        {
            BenchmarkRunner.Run<MyBenchmark>();
		}
    }

    // Memory is not important for these benchmarks
    // [MemoryDiagnoser]
    [MinIterationCount(5)]
    [MaxIterationCount(12)]
    public class MyBenchmark
    {
		private MyList<int> myList = new MyList<int>();
		private MyOrderedList1<int> list1 = new MyOrderedList1<int>();
		private MyOrderedList2<int> list2 = new MyOrderedList2<int>();

		[GlobalSetup]
		public void Setup()
		{
			List<BenchmarkInstructions2> instructions = BenchmarkInstructions2.GenerateInstructions(BenchmarkInstructions2.Op.Insert);
			ExecuteInstructions(myList, instructions);
			ExecuteInstructions(list1, instructions);
			ExecuteInstructions(list2, instructions);
		}

		[Benchmark]
        public void TestMyList()
        {
            MyList<int> list = new MyList<int>();
            BenchmarkInstructions2.Op[] exclude = { BenchmarkInstructions2.Op.InsertInto };
            List<BenchmarkInstructions2> instructions = BenchmarkInstructions2.GenerateInstructions(exclude);
            ExecuteInstructions(list, instructions);
        }

		[Benchmark]
		public void TestMyOrderedList1()
		{
			MyOrderedList1<int> list = new MyOrderedList1<int>();
			BenchmarkInstructions2.Op[] exclude = { BenchmarkInstructions2.Op.InsertInto };
			List<BenchmarkInstructions2> instructions = BenchmarkInstructions2.GenerateInstructions(exclude);
			ExecuteInstructions(list, instructions);
		}

		[Benchmark]
		public void TestMyOrderedList2()
		{
			MyOrderedList2<int> list = new MyOrderedList2<int>();
			BenchmarkInstructions2.Op[] exclude = { BenchmarkInstructions2.Op.InsertInto };
			List<BenchmarkInstructions2> instructions = BenchmarkInstructions2.GenerateInstructions(exclude);
			ExecuteInstructions(list, instructions);
		}

		[Benchmark]
        public void TestInsertMyList()
        {
            MyList<int> list = new MyList<int>();
            List<BenchmarkInstructions2> instructions 
                = BenchmarkInstructions2.GenerateInstructions(BenchmarkInstructions2.Op.Insert, null, 10000);
            ExecuteInstructions(list, instructions);
        }

		[Benchmark]
		public void TestInsertMyOrderedList1()
		{
			MyOrderedList1<int> list = new MyOrderedList1<int>();
			List<BenchmarkInstructions2> instructions = 
                BenchmarkInstructions2.GenerateInstructions(BenchmarkInstructions2.Op.Insert, null, 10000);
			ExecuteInstructions(list, instructions);
		}

		[Benchmark]
		public void TestInsertMyOrderedList2()
		{
			MyOrderedList2<int> list = new MyOrderedList2<int>();
			List<BenchmarkInstructions2> instructions =
				BenchmarkInstructions2.GenerateInstructions(BenchmarkInstructions2.Op.Insert, null, 10000);
			ExecuteInstructions(list, instructions);
		}

		[Benchmark]
        public void TestSearchMyList()
        {
            List<BenchmarkInstructions2> instructions =
				BenchmarkInstructions2.GenerateInstructions(BenchmarkInstructions2.Op.Search, myList);
			ExecuteInstructions(myList, instructions);
        }

		//ADD THIS AFTER BINARY SEARCH SLIDE
		[Benchmark]
		public void TestSearchMyOrderedList1()
		{
            List<BenchmarkInstructions2> instructions =
                BenchmarkInstructions2.GenerateInstructions(BenchmarkInstructions2.Op.Search, list1);
			ExecuteInstructions(list1, instructions);
		}

		//ADD THIS AFTER BINARY SEARCH SLIDE
		[Benchmark]
		public void TestSearchMyOrderedList2()
		{
			List<BenchmarkInstructions2> instructions =
				BenchmarkInstructions2.GenerateInstructions(BenchmarkInstructions2.Op.Search, list2);
			ExecuteInstructions(list2, instructions);
		}

		[Benchmark]
        public void TestRemoveMyList()
        {
            List<BenchmarkInstructions2> instructions = 
                BenchmarkInstructions2.GenerateInstructions(BenchmarkInstructions2.Op.Remove, myList, 12000);
            ExecuteInstructions(myList, instructions);
        }

		//ADD THIS AFTER BINARY SEARCH SLIDE
		[Benchmark]
		public void TestRemoveMyOrderedList1()
		{
			List<BenchmarkInstructions2> instructions =
				BenchmarkInstructions2.GenerateInstructions(BenchmarkInstructions2.Op.Remove, list1, 12000);
			ExecuteInstructions(list1, instructions);
		}

		//ADD THIS AFTER BINARY SEARCH SLIDE
		[Benchmark]
		public void TestRemoveMyOrderedList2()
		{
			List<BenchmarkInstructions2> instructions =
				BenchmarkInstructions2.GenerateInstructions(BenchmarkInstructions2.Op.Remove, list2, 12000);
			ExecuteInstructions(list2, instructions);
		}

		private void ExecuteInstructions(IList<int> list, List<BenchmarkInstructions2> instructions)
        {
            foreach (BenchmarkInstructions2 inst in instructions)
            {
                switch (inst.Instruction)
                {
                    case BenchmarkInstructions2.Op.Insert:
                        list.Insert(inst.Number);
                        break;
                    case BenchmarkInstructions2.Op.InsertInto:
                        throw new NotSupportedException("Inserting at an index is not supported in an ordered list.");
                    case BenchmarkInstructions2.Op.Search:
                        list.Find(inst.Number);
                        break;
                    case BenchmarkInstructions2.Op.Remove:
                        list.Remove(inst.Number);
                        break;
                    case BenchmarkInstructions2.Op.RemoveAt:
                        list.RemoveAt(inst.Index);
                        break;
                    case BenchmarkInstructions2.Op.Clear:
                        list.Clear();
                        break;
                }
            }
        }
    }
}
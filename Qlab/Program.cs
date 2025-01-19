using System;

namespace Qlab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Queue<int> q = new Queue<int>();
            q.Insert(7);
            q.Insert(10);
            q.Insert(3);
            Console.WriteLine(q);

            Queue<int> qCopy = SetQCopy(q);
            Console.WriteLine(q);

            q.Insert(17);
            qCopy.Insert(13);

            Console.WriteLine(q);

            int num = 10;
            Console.WriteLine("\nCheck if the number " + num + " existed in the queue: ");
            Console.WriteLine(CheckIfNumExisting(q, 10));

            num = 2;
            Console.WriteLine("\nCheck if the number " + num + " is perfect: ");
            Console.WriteLine(CheckSumOfNeighbors(q, 2));

            Queue<int> q2 = new Queue<int>();
            q2.Insert(-1);
            q2.Insert(1);
            q2.Insert(2);
            q2.Insert(1);
            Console.WriteLine("\nCheck if the queue is perfect: ");
            Console.WriteLine(CheckQIsPerfect(q2));


            Queue<int> q3 = new Queue<int>();
            q3.Insert(-1);
            q3.Insert(1);
            q3.Insert(2);
            q3.Insert(3);
            Console.WriteLine("\nSorted the queue form low to high number: ");
            Console.WriteLine("Original queue:");
            Console.WriteLine(q3);
            Console.WriteLine("Sorted queue with new number inserted:");
            Queue<int> sortedQueue = SortedQueue(q3, 0);
            Console.WriteLine(sortedQueue);
        }

        public static Queue<int> SetQCopy(Queue<int> q)
        {
            Queue<int> qCopy = new();
            Queue<int> qTemp = new();
            int currItem;
            //פריקת התור המקורי ויצירת תור העתק ותור זמני
            while (!q.IsEmpty())
            {
                currItem = q.Remove();
                qTemp.Insert(currItem);
                qCopy.Insert(currItem);
            }
            //שחזור התור המקורי
            while (!qTemp.IsEmpty())
            {
                q.Insert(qTemp.Remove());
            }
            return qCopy;
        }

        public static bool CheckIfNumExisting(Queue<int> q, int num)
        {
            //The function receives a queue with numbers and a number
            //Returns if the number is exist in the queue
            Queue<int> qCopy = SetQCopy(q);
            int currCheck;
            while (!q.IsEmpty())
            {
                currCheck = qCopy.Remove();
                if (currCheck == num)
                {
                    Console.WriteLine("" + q);
                    return true;
                }
            }
            Console.WriteLine("" + q);
            return false;
        }

        public static bool CheckSumOfNeighbors(Queue<int> q, int numIndex)
        {
            //Receives a queue with numbers and a number of index 
            //Returns if the number is perfect
            Queue<int> qCopy = SetQCopy(q);
            Queue<int> qLength = SetQCopy(q);
            int queueLen = 0;

            while (!qLength.IsEmpty())
            {
                qLength.Remove();
                queueLen++;
            }
            int neighborL = 0;
            int neighborR = 0;
            int tragetNum = 0;

            if (numIndex == 1 || numIndex == queueLen)
            {
                Console.WriteLine(q);
                return false;
            }
            for (int i = 1; i < numIndex; i++)
            {
                neighborL = qCopy.Remove();
            }
            tragetNum = qCopy.Remove();
            neighborR = qCopy.Remove();
            if (neighborL + neighborR == tragetNum)
            {
                Console.WriteLine(q);
                return true;
            }
            Console.WriteLine(q);
            return false;
        }

        public static bool CheckQIsPerfect(Queue<int> q)
        {
            //The function receives a queue with int numbers
            //Returns if the queue is perfect
            Queue<int> qCopy = SetQCopy(q);
            qCopy.Remove();
            int i = 2;
            bool isPerfect = false;
            while (!qCopy.IsEmpty())
            {
                qCopy.Remove();
                if (qCopy.IsEmpty())
                {
                    return isPerfect;
                }
                //Using the function to check if the number is perfect
                isPerfect = CheckSumOfNeighbors(q, i);
                i++;
            }
            return isPerfect;
        }

        public static Queue<int> SortedQueue(Queue<int> q, int num)
        {
            //The function receives a queue with ints and a number
            //Returns a queue sorted with the new number
            Queue<int> qCopy = SetQCopy(q);
            Queue<int> sortedQueue = new Queue<int>();
            bool inserted = false;

            while (!qCopy.IsEmpty())
            {
                int currItem = qCopy.Remove();

                // If we haven't entered the new number yet
                if (!inserted && num < currItem)
                {
                    sortedQueue.Insert(num);
                    inserted = true;
                }
                //enter the current number
                sortedQueue.Insert(currItem);
            }
            //If the new number is the biggest
            if (!inserted)
            {
                sortedQueue.Insert(num);
            }
            return sortedQueue;
        }
    }
}
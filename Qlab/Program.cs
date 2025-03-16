using System;
//lior zisser 21/1/2025
//ניסיתי לעשות את האתגר אבל לא היה לי הרבה זמן אז לא הספקתי להיגע לסיומו
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
            Console.WriteLine(q3);
            Console.WriteLine(sortedQueue);


            Queue<int> q4 = new Queue<int>();
            q4.Insert(-1);
            q4.Insert(1);
            q4.Insert(2);
            q4.Insert(3);
            Console.WriteLine("\nSorted the queue form low to high number: ");
            Console.WriteLine("Original queue:");
            Console.WriteLine(q3);
            Console.WriteLine("Sorted queue with new number inserted:");
            Queue<int> sortedQueue2 = SortedQueue(q4, 4);
            Console.WriteLine(q4);
            Console.WriteLine(sortedQueue2);
            
            student s1 = new("mark", 40);
            student s2 = new("yahin", 57);
            student s3 = new("igor", 85);
            student s4 = new("larisa", 100);
            student s5 = new("Yosi", 72);

            Queue<student> q5 = new Queue<student>();
            q5.Insert(s1);
            q5.Insert(s2);
            q5.Insert(s3);
            q5.Insert(s4);

            Console.WriteLine("\nSorted the queue form low to high grade: ");
            Console.WriteLine("Original queue:");
            Console.WriteLine(q5);
            Console.WriteLine("Sorted queue with new grade inserted:");
            Queue<student> sortedQueueGrade = SortedQueueS(q5, s5);
            Console.WriteLine(q5);
            Console.WriteLine(sortedQueueGrade);

            Console.Write("\n");
            Queue<student> q6 = new Queue<student>();
            Queue<student> sortedQueueGrade2 = SortedQueueS(q6, s5);
            Console.WriteLine(q6);
            Console.WriteLine(sortedQueueGrade2);
        }

        public static Queue<T> SetQCopy<T>(Queue<T> q)
        {
            Queue<T> qCopy = new();
            Queue<T> qTemp = new();
            T currItem;
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
                if (isPerfect == false)
                {
                    return isPerfect;
                }
                i++;
            }
            return isPerfect;
        }

        public static Queue<int> SortedQueue(Queue<int> q, int num)
        {
            //The function receives a queue with ints and a number
            //Returns a queue sorted with the new number
            //Queue<int> sortedQueue = new Queue<int>();
            Queue<int> qCopy = SetQCopy(q);
            bool inserted = false;
            if (qCopy.IsEmpty())
            {
                q.Insert(num);
                return q;
            }
            while (!q.IsEmpty())
            {
                q.Remove();
            }
            while (!qCopy.IsEmpty())
            {
                int currItem = qCopy.Remove();

                // If we haven't entered the new number yet
                if (!inserted && num < currItem)
                {
                    q.Insert(num);
                    inserted = true;
                }
                //enter the current number
                q.Insert(currItem);
            }
            //If the new number is the biggest
            if (!inserted)
            {
                q.Insert(num);
            }
            return q;
        }




        // Student class:
        public static Queue<student> SortedQueueS(Queue<student> q, student newStudent)
        {
            // The function receives a queue of students and a new student
            // Returns a queue sorted by grade with the new student added
           
            Queue<student> qCopy = SetQCopyS(q);
            bool inserted = false;
            Queue<student> orderQ = EmptyQ2Copy(q);
            if (qCopy.IsEmpty())
            {
                q.Insert(newStudent);
                return q;
            }
            while (!qCopy.IsEmpty())
            {
                student current = qCopy.Remove();

                // Insert the new student in the correct position
                if (!inserted && newStudent.GetGrade() < current.GetGrade()) 
                {
                    q.Insert(newStudent);
                    inserted = true;
                }

                // Add the current student
                q.Insert(current);
            }

            // If the new student has the highest grade, insert at the end
            if (!inserted)
            {
                q.Insert(newStudent);
            }
            return q;
        }

        public static Queue<student> SetQCopyS(Queue<student> q)
        {
            Queue<student> qCopy = new();
            Queue<student> qTemp = new();
            student currItem;
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

        public static Queue<T> EmptyQ2Copy<T>(Queue<T> q)
        {
            Queue<T> qCopy = SetQCopy(q);
            while (!q.IsEmpty())
            {
                T curr = q.Remove();
                qCopy.Insert(curr);
            }
            return qCopy;
        }

            public static int LastAndRemove(Queue<int> q)
        {
            int queueLength = 0;
            int result = 0;
            Queue<int> qCopy = SetQCopy(q);
            while (!q.IsEmpty())
            {
                q.Remove();
                queueLength++;
            }

            for(int i = 1; i <= queueLength; i++)
            {
                if(i < queueLength)
                {
                    int number = qCopy.Remove();
                    q.Insert(number);
                }
                else
                {
                    result = qCopy.Remove();
                }
            }
            Console.WriteLine(q);
            return result;
        }
    }
}

namespace Qlab;
public class Program

{
    public static void Main(string[] args)
    {
        /*
        Console.WriteLine("Hello, World!");
        Queue<int> q = new Queue<int>();
        q.Insert(7);
        q.Insert(10);
        q.Insert(3);
        Console.WriteLine(q);
        Queue<int> qCopy = SetQCopy(q);
        Console.WriteLine(q);
        Console.WriteLine(qCopy);
        q.Insert(17);
        qCopy.Insert(13);
        Console.WriteLine(q);
        Console.WriteLine(qCopy);
        Console.WriteLine(CheckNum(q, 10));
        Console.WriteLine(CheckSumOfNeighbors(q, 2));
        */
        Queue<int> q2 = new Queue<int>();  
        q2.Insert(1);
        q2.Insert(3);
        q2.Insert(2);
        q2.Insert(-2);
        Console.WriteLine(CheckQIsPerfect(q2)); 

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

    public static bool CheckNum(Queue<int> q, int num)
    {
        Queue<int> qCopy = SetQCopy(q);
        int currCheck;
        while (!q.IsEmpty())
        {
            currCheck = qCopy.Remove();
            if (currCheck == num)
            {
                Console.WriteLine("\n" + q);
                return true;
            }
        }
        Console.WriteLine("\n" + q);
        return false;
    }

    public static bool CheckSumOfNeighbors(Queue<int> q, int numIndex)
    {
        Queue<int> qCopy = SetQCopy(q);
        Queue<int> qLength = SetQCopy(q);
        int queueLen = 0;

        while (!qLength.IsEmpty())
        {
            qLength.Remove();
            queueLen++;
        }
        //Console.WriteLine(queueLen);
        int neighborL = 0;
        int neighborR = 0;
        int tragetNum = 0;

        if (numIndex == 1 || numIndex == queueLen)
        {
            //Console.WriteLine("\n" + q);
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
            //Console.WriteLine("\n" + q);
            return true;
        }
        //Console.WriteLine("\n" + q);
        return false;
    }

    public static bool CheckQIsPerfect(Queue<int> q)
    {
        Queue<int> qCopy = SetQCopy(q);
        qCopy.Remove();
        int i = 2;
        bool isPerfect = false;
        while(!qCopy.IsEmpty())
        {
            qCopy.Remove();
            if (qCopy.IsEmpty())
            {
                Console.WriteLine("dsf"+ isPerfect);
                return isPerfect;
            }
            isPerfect = CheckSumOfNeighbors(q, i);
            i++;
        }
        return isPerfect;
    }
}
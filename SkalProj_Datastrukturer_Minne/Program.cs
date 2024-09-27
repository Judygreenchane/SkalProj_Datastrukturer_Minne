using System;
using System.Collections;
using System.Diagnostics;

namespace SkalProj_Datastrukturer_Minne
{
    //Stack works in LIFO (Last in first out) manner. It is used for storing local variables .Each time a function is called, a stack frame is created containing its local variables, parameters, and return address.
    //When the function finishes executing, the stack frame is automatically popped off the stack. Stack memory is fixed and it gives fast access. It is used for temporary storage.
    //We get an item from stack only if  it's top items are popped off.

    //Heap allows random access that is  according to our priority.All reference types are stored in heap. Suppose if we create an object of a class, the whole object itself have memory in heap but its address stored in stack. 
    //The heap is used when the size of the data is not known at compile-time . Heap needs memory management.
    //When we allocate memory on the heap , a pointer to that memory is returned, and it persists until manually deleted or garbage collected.

    //Value types store a particular value in memory either in stack or in heap. Assigning one value type to another copies the actual data .Value type hold values.
    //Where as Reference types stores address of a particular memory location ,that is it points to another memory location.Multiple variables can reference the same object, so changes through one reference affect the others.Reference types hold addresses(of another location).


    //In first case, it is working with value types. y=x means only value of x is assigned to value of y .Y's value changed to 4 but x still  remains as 3.So it returns 3.
    //In second case ,it is working with reference types.Here X and Y are reference types and holds address that points to the real object in memory . When y=x means both holding same address and pointing to the  same object in memory.
    //So if we make any  change to the real object by using y (y.Myvalue=4), we get the changed value only when accessing using x ,since there is only one memory location and both x and y pointing to the same.
    /// <summary>
    /// /
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                     +"\n5. RecursiveEven"
                    + "\n6. Fibanocci Series"
                    + "\n7. IterativeEven "
                    + "\n8. Fibonacci Iteration "
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();

                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                       Console .WriteLine( RecursiveEven(4));
                        break;
                    case '6':
                      FibanocciSeries();
                        break;
                    case '7':
                        Console.WriteLine( IterativeEven(3));
                        break;
                    case '8':
                       FibanocciIteration();
                        break;

                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        private static void FibanocciIteration()
        {
            Console.WriteLine("Please enter the number of terms in the fibonacci series");
            int n = int.Parse(Console.ReadLine());
            long f1 = 0;
            long f2 = 1;
            long f3;
            if (n == 1) { 
                Console.Write($"{f1}  ");
            }
            else if (n == 2)  Console.Write($"{f1}    {f2}  ");
            
            else
            {
                Console.Write("0   1   ");
            for(int i = 2; i < n; i++)
            {
                f3 = f1 + f2;

                Console.Write( f3 + "  ");
                f1 = f2;
                f2 = f3;

            }
            }
            
           
        }

        private static int IterativeEven(int n)
        {
            int result = 2;
            for (int i = 0; i < n-1; i++)
            {
                result += 2;
            }
            return result;

        }

        private static int RecursiveEven(int n)
        {
            if (n == 1)
                return 2;
            return (RecursiveEven(n - 1)+2);
        }

        static void  FibanocciSeries()
        {
            Console.WriteLine("Enter number of terms in the fibanocci series");
            int n =int.Parse ( Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(Fibonacci(i));
            }

        }
        static int Fibonacci(int n)
            {
               
                if (n == 0)
                    return 0;
                else if (n == 1)
                    return 1;
                else
                   
                    return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        

        private static void StringReverse()
        {
            string rev = string.Empty;
            Stack stack = new Stack();
            Console.WriteLine("Enter the string to reverse");
            string input = Console.ReadLine();
            foreach (char c in input)
            {
                stack.Push(c);
            }
            while (stack.Count > 0)
            {

                rev += stack.Pop();
            }
            Console.WriteLine($"The  reverse of the given string {input} is  : {rev}");

        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            // When the first item adds to the list ,its internal array's capacity becomes 4.
            // Then from the 5th element onwards its capacity become double
            //When the first item is adding,it gets a capacity to hold 4 values.So if we are adding 5th element, then only capacity will increase otherwise it won't increase the capacity.
            //But if we remove the items , its capacity is not decreasing .
            //If we know the size of the array before hand or if it has fixed size, then we can go for self defined array. 

            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            bool programQuit = false;
            int count = 0;
            int capacity = 0;
            List<string> theList = new List<string>();
            while (programQuit == false)
            {
                Console.WriteLine("Enter the string if you want to continue  or enter 0 If you want to exit ");

                string input = Console.ReadLine();
                char nav = input[0];

                switch (nav)
                {
                    case '+':
                        theList.Add(input.Substring(1));
                        count = theList.Count;
                        capacity = theList.Capacity;
                        Console.WriteLine($"{input.Substring(1)} added to the list");
                        Console.WriteLine($"Count is :{count}   Capacity is :{capacity} ");

                        break;
                    case '-':
                        theList.Remove(input.Substring(1));
                        count = theList.Count;
                        capacity = theList.Capacity;
                        Console.WriteLine($"{input.Substring(1)} removed from the list");
                        Console.WriteLine($"Count is :{count}   Capacity is :{capacity} ");
                        break;
                    case '0':
                        programQuit = true;

                        break;

                    default:
                        Console.WriteLine(" Please enter some valid input. If you want to add the string start the input with a '+' and followed by string.Use '-' instead of '+' if you want to remove a string");
                        break;

                }
            }
            // string value = input.Substring(1);








        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            Queue queue = new Queue();
            int count = 0;
            bool programQuit = false;
            while (programQuit == false)
            {
                Console.WriteLine("If you want to continue and add the string start the input with a '+' and followed by string. Enter '-'  if you want to delete from queue or enter 0 If you want to exit");

                string input = Console.ReadLine();
                char nav = input[0];

                switch (nav)
                {
                    case '+':
                        queue.Enqueue(input.Substring(1));

                        count = queue.Count;

                        Console.WriteLine("  List of values in  the queue");
                        DisplayItemsOfQueue(queue);

                        break;
                    case '-':
                        queue.Dequeue();
                        count = queue.Count;

                        Console.WriteLine("List of values in  the queue");
                        DisplayItemsOfQueue(queue);
                        break;
                    case '0':
                        programQuit = true;

                        break;

                    default:
                        Console.WriteLine(" Please enter some valid input.");
                        break;

                }
            }
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }
        static void DisplayItemsOfQueue(Queue queue)
        {
            foreach (string item in queue)
                Console.WriteLine(item);
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            Stack stack = new Stack();
            int count = 0;
            bool programQuit = false;
            while (programQuit == false)
            {
                Console.WriteLine("If you want to continue and push the string start the input with a '+' and followed by string. Enter '-' if you want to pop from stack   or Enter 'r' to get a string rverse or enter 0 If you want to exit");

                string input = Console.ReadLine();
                char nav = input[0];

                switch (nav)
                {
                    case '+':
                        stack.Push(input.Substring(1));

                        Console.WriteLine("  List of values in  the Stack");
                        DisplayItemsOfStack(stack);

                        break;
                    case '-':
                        stack.Pop();

                        Console.WriteLine("List of values in  the Stack");
                        DisplayItemsOfStack(stack);
                        break;
                    case 'r':
                        StringReverse();
                        break;
                    case '0':
                        programQuit = true;

                        break;

                    default:
                        Console.WriteLine(" Please enter some valid input.");
                        break;

                }
            }
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }
        static void DisplayItemsOfStack(Stack stack)
        {
            foreach (string item in stack)
                Console.WriteLine(item);
        }

        static void CheckParanthesis()
        {
            bool flag=false;
            char c;
            Console.WriteLine("Enter the string for paranthesis check");
            string s = Console.ReadLine();
            Stack myStack = new Stack();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                {
                    myStack.Push(s[i]);
                }
                else
                if (s[i] == ')' || s[i] == ']' || s[i] == '}')
                {
                    if (myStack.Count == 0)
                        flag = false;
                    else
                    if (ReturnMatchingBracket(s[i]).ToString() != myStack.Pop().ToString())

                        flag = false;
                    else
                       flag  = true ;
                    // c= ReturnMatchingBracket(s[i]);
                }
                
                
            }
            if (flag ==true  && myStack.Count ==0 )
            
                Console.WriteLine(" Paranthesis are matching ");
            else
                Console.WriteLine("Paranthesis are not  matching ");

            // return flag == true ? 1 : 0;
            // return myStack.Count == 0 ? 1 : 0;
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }
        static char ReturnMatchingBracket(char ch)
        {
            if (')' == ch) return '(';
            else if (']' == ch) return '[';
            else if ('}' == ch) return '{';
            else return '0';


            }
        }
        

}



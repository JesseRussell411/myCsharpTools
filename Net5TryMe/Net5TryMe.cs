using System;
using JesseRussell.FancyTyping;

namespace Net5TryMe
{
    class Foo
    {
    }
    class Net5TryMe
    {
        static void somethingWithFoo(NullChecked<Foo> foo)
        {
            Console.WriteLine("Doing something with foo...");
        }
        static void Main(string[] args)
        {
            Foo f = null;

            somethingWithFoo(f);
        }
    }
}

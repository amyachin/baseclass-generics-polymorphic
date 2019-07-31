using System;

namespace ReflectionOnBaseClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var caller = new Caller<MyClient>();
            Console.WriteLine(caller.Acccessor.EndPointA);
            Console.WriteLine(caller.Acccessor.EndPointB);
            Console.ReadLine();

        }
    }



  
    class Caller<TClient> where TClient: class, new()
    {
        public Caller()
        {
            Acccessor = ClientBaseAccessor.CreateAccessor(new TClient());
        }


        public ClientBaseAccessor Acccessor { get; }
    }

}

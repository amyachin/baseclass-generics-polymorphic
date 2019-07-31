using System;

namespace ReflectionOnBaseClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var caller = new Caller<MyClient>();
            Console.ReadLine();

        }
    }



  
    class Caller<TClient> where TClient: class, new()
    {
        public Caller()
        {
            Acccessor = ClientBaseAccessor.CreateAccessor(new TClient());

            Console.WriteLine(Acccessor.EndPointA);
            Console.WriteLine(Acccessor.EndPointB);

        }


        private ClientBaseAccessor Acccessor { get; }
    }

}

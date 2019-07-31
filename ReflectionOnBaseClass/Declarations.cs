using System;

public abstract class ClientBase<TInterface>
{
    public ClientBase()
    {
        EndPointA = "EndPointA";
        EndPointB = "EndPointB";
    }

    public string EndPointA { get; }
    public string EndPointB { get; }

}

public interface MyInterface
{
    void DoSomething();
    void DoOtherThing();
}


public class MyClient : ClientBase<MyInterface>
{
    public void DoSomething()
    {
        throw new NotImplementedException();
    }

    public void DoOtherThing()
    {
        throw new NotImplementedException();
    }


}
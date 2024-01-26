var obj = new ComplexService(null, null);


interface IService1
{
    
}

interface IService2
{
    
}

class ComplexService(IService1? service1, IService2? service2)
{
    public void Foo()
    {
        service1.Equals(null!);
        service2.Equals(null!);
    }
}
namespace Sturmer.Nazwa.Interfaces
{
    public interface IPlane
    {
        Sturmer.Nazwa.Interfaces.IProducer Producer
        {
            set;
            get;
        }
        string Name
        {
            set;
            get;
        }

        int Range
        {
            set;
            get;
        }
    }
}
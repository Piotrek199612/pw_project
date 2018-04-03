namespace Sturmer.Nazwa.Interfaces
{
    public interface IProducer
    {
        Sturmer.Nazwa.Core.ProducerName Name
        {
            set;
            get;
        }

        string Country
        {
            set;
            get;
        }

        int Employment
        {
            set;
            get;
        }
    }
}
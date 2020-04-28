using System;
namespace VSCodeEventBus.DTO
{
    public class Link
    {
        public string Href { get; }
        public string Method { get; }
        public string Relation { get; }


        public Link(string href, string method, string relation)
        {
            Href = href;
            Method = method;
            Relation = relation;
        }
    }
}
using System.Reflection.Metadata.Ecma335;

namespace Test.InternalService
{
    public class PseudoDBService
    {
        public readonly IDictionary<long, DBResult1> data;

        public PseudoDBService()
        {
            data = new Dictionary<long, DBResult1>
            {
                [78] = new DBResult1
                {
                    DBProperty1 = "alpha",
                    DBProperty2 = DateTime.Parse("2021-12-31"),
                },
                [99] = new DBResult1
                {
                    DBProperty1 = "beta",
                    DBProperty2 = DateTime.Parse("2022-01-22"),
                }
            };
        }

        public  DBResult1 GetData(long id)
        {
            // simulate a database query
            Console.Error.WriteLine("call to \"DATABASE\"");
            if (data.ContainsKey(id))
            {
                return data[id];
            }
            else
            {
                return null;
            }
        }
    }
}
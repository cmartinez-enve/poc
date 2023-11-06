namespace Test.InternalService
{
    public class PseudoRestService
    {
        private readonly IDictionary<string, RestData> data;

        public PseudoRestService()
        {
            data = new Dictionary<string, RestData>
            {
                ["D893493L"] = new RestData
                {
                    Id = 78,
                    Name = "Gusvav",
                },
                ["D896493L"] = new RestData
                {
                    Id = 99,
                    Name = "Michel",
                },
            };
        }

        public RestData OperationNL(string str)
        {
            // simulate rest
            Console.Error.WriteLine("call to \"REST\"");
            if (data.ContainsKey(str))
            {
                return data[str];
            }
            else
            {
                return null;
            }
        }
    }
}
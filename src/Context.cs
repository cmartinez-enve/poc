
using Test.Calculable;
using Test.ContextService;

namespace Test
{
    public class Context
    {
        public Data data { get; set; }

        private IDictionary<PropertyEnum, IContextService> properties;

        public Context()
        {
            var dbContextService = new PseudoDBContextService(this);

            var restContextService = new PseudoRestContextService(this);

            this.properties = new Dictionary<PropertyEnum, IContextService>
            {
                [PropertyEnum.DB_PROPERTY1] = dbContextService,
                [PropertyEnum.DB_PROPERTY2] = dbContextService,
                [PropertyEnum.ID] = restContextService,
                [PropertyEnum.NAME] = restContextService,
            };
        }

        public T GetOrCalculate<T>(PropertyEnum prop)
        {
            if (this.properties.ContainsKey(prop))
            {
                var service = this.properties[prop];
                return (T) service.GetOrCalculate<T>(prop);
            }
            else 
            {
                throw new Exception("property not defined");
            }
        }
    }
}
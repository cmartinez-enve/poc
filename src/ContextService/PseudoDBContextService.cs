using Test.Calculable;
using Test.InternalService;

namespace Test.ContextService
{
    public class PseudoDBContextService : IContextService
    {
        private Context context;

        private PseudoDBService internalService;

        private DBResult1 cache;

        public PseudoDBContextService(Context context)
        {
            this.context = context;
            this.internalService = new PseudoDBService(); // injection
        }

        public T GetOrCalculate<T>(PropertyEnum prop)
        {
            var id = context.GetOrCalculate<long>(PropertyEnum.ID);
            cache ??= this.internalService.GetData(id);

            if (cache == null)
            {
                // throw exception?
                throw new Exception("Invalid property");
            }

            object value = prop switch
            {
                PropertyEnum.DB_PROPERTY1 => cache.DBProperty1,
                PropertyEnum.DB_PROPERTY2 => cache.DBProperty2,
                _ => throw new Exception($"no definition for property ${nameof(prop)}"),
            };
            return (T) value;
        }
    }
}
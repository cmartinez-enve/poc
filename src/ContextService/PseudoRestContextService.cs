using Test.Calculable;
using Test.InternalService;

namespace Test.ContextService
{
    public class PseudoRestContextService : IContextService
    {
        private readonly Context context;

        private readonly PseudoRestService internalService;

        private RestData cache;

        public PseudoRestContextService(Context context)
        {
            this.context = context;
            this.internalService = new PseudoRestService();
        }

        public T GetOrCalculate<T>(PropertyEnum prop)
        {
            cache ??= this.internalService.OperationNL(context.data.PropertyAlpha);

            if (cache == null)
            {
                throw new Exception($"No data for: {context.data.PropertyAlpha}");
            }

            // maps enum to values
            object value = prop switch
            {
                PropertyEnum.ID => cache.Id,
                PropertyEnum.NAME => cache.Name,
                _ => throw new Exception($"no definition for property ${nameof(prop)}"),
            };
            return (T) value;
        }
    }
}
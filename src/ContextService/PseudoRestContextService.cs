using Test.Calculable;
using Test.InternalService;

namespace Test.ContextService
{
    public class PseudoRestContextService : IContextService
    {
        private Context context;

        private PseudoRestService internalService;

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
                // throw exception?
                throw new Exception("invalid data");
            }

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
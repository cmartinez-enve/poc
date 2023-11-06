using Test.Calculable;

namespace Test.ContextService
{
    public interface IContextService
    {
        public T GetOrCalculate<T>(PropertyEnum prop);
    }
}
using Test;

namespace Test.Calculable
{
    public class CalculableData2
    {
        private readonly Context context;

        public long Id
        {
            get
            {
                return context.GetOrCalculate<long>(PropertyEnum.ID);
            }
        }

        public string Name
        {
            get
            {
                return context.GetOrCalculate<string>(PropertyEnum.NAME);
            }
        }

        public CalculableData2(Context context)
        {
            this.context = context;
        }
    }
}
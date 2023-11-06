using HandlebarsDotNet;
using Test.Calculable;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var alpha = args[0];
            var code = args[1];
            var templateName = args[2];

            var context = new Context
            {
                data = new Data
                {
                    PropertyAlpha = alpha,
                    Code = code
                }
            };

            var templateContext = new Dictionary<string, object>();

            templateContext["data"] = context.data;
            templateContext["data1"] = new CalculableData1(context);
            templateContext["data2"] = new CalculableData2(context);

            var result = evalTemplate(templateContext, templateName);

            Console.WriteLine(result);
        }

        private static string evalTemplate(Dictionary<string, object> templateContext, string templateName)
        {
            string templateSource;
            switch (templateName)
            {
                case "notice1":
                    templateSource = "this is : property1 {{ data1.property1 }} and this is property2 : {{ data1.Property2 }}";
                    break;
                case "notice2":
                    templateSource = "this is the ID: {{ data2.id }} and the name: {{ data2.name }}";
                    break;
                case "notice3":
                    templateSource = "this is the code: {{ data.code }}";
                    break;
                default:
                    throw new Exception($"Unknown template: {templateName}");
            }

            var template = Handlebars.Compile(templateSource);
            return template(templateContext);
        }
    }
}
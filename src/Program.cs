using HandlebarsDotNet;
using Test.Calculable;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Data from request
            var alpha = args[0];
            var code = args[1];

            // template name
            var templateName = args[2];

            // context for calculable data
            var context = new Context
            {
                data = new Data
                {
                    PropertyAlpha = alpha,
                    Code = code
                }
            };

            // context for template evaluation
            var templateContext = new Dictionary<string, object>
            {
                ["data"] = context.data,
                ["data1"] = new CalculableData1(context),
                ["data2"] = new CalculableData2(context)
            };

            var result = EvalTemplate(templateContext, templateName);

            Console.WriteLine(result);
        }

        private static string EvalTemplate(Dictionary<string, object> templateContext, string templateName)
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
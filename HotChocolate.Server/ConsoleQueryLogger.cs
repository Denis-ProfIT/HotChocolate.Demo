using HotChocolate.Execution;
using HotChocolate.Execution.Instrumentation;

namespace HotChocolate.Server;

public class MyExecutionEventListener : ExecutionDiagnosticEventListener
{
    public override IDisposable ExecuteRequest(IRequestContext context)
    {
        if (context.Request.VariableValues is not  null)
        {
            Console.WriteLine("Variables:");
            Console.WriteLine(string.Join(Environment.NewLine, context.Request.VariableValues.Values));
        }

        Console.WriteLine("Query:");
        Console.WriteLine(context.Request.Query);

        return base.ExecuteRequest(context);
    }
}
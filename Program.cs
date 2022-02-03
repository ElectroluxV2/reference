using reference.strategy;

var context = new Context<string, List<string>>();
var data = new List<string>
{
    "Red",
    "Green",
    "Blue"
};

context.SetStrategy(new MergeAndFormatStringStrategy(" "));
Console.WriteLine(context.Execute(data));

context.SetStrategy(new AlternatingCaseStringStrategy());
Console.WriteLine(context.Execute(data));


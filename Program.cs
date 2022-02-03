using reference.builder;
using reference.strategy;

var context = new Context<string, List<string>>();
var data = new List<string>
{
    "Red",
    "Green",
    "Blue"
};

context.SetStrategy(new MergeAndFormatStringStrategy(", "));
Console.WriteLine(context.Execute(data));

context.SetStrategy(new AlternatingCaseStringStrategy());
Console.WriteLine(context.Execute(data));

/////////////////////////////////////////////////////////

Console.WriteLine(new POSTQueryBuilder("http://localhost")
    .WithAcceptedContentType("text/html")
    .Build());
    
Console.WriteLine(new POSTQueryBuilder("http://localhost")
    .WithAcceptedContentType("text/html")
    .WithAcceptedResponseCode("200")
    .WithParameters(new Dictionary<string, string>
    {
        {"param1", "value1"},
        {"param2", "value2"}
        
    })
    .Build());
    
Console.WriteLine(new GETQueryBuilder("http://localhost")
    .WithAcceptedContentType("text/html")
    // .WithAcceptedResponseCode("200")
    .WithParameters(new Dictionary<string, string>
    {
        {"param1", "value1"},
        {"param2", "value2"}
        
    })
    .Build());
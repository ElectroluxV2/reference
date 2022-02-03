using reference.builder;
using reference.observer;
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
    
/////////////////////////////////////////////////////////

var progress = new Subject<int>();


var observer = (int value) =>
{
    Console.WriteLine($"Got value {value}");
};

progress.Attach(observer);
progress.Next(1);
progress.Next(2);
progress.Detach(observer);
progress.Next(3);



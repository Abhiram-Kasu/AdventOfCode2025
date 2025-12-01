
var currCount = 50;
var count = 0;
while (Console.ReadLine() is { } input)
{
    input = input.Trim();
    if( input.Length <=1) continue;
    var multiplier = input[0] switch
    {
        'L' => -1,
        'R' => 1,
        _ => throw new ArgumentException("Invalid direction")
    };
    var number = int.Parse(input[1..]);
    currCount += number * multiplier;
    // in `Program.cs`
    currCount = ((currCount % 100) + 100) % 100;

    if(currCount == 0)
    {
        count++;
    }

}
Console.WriteLine(count);


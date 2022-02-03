namespace reference.strategy;

public class AlternatingCaseStringStrategy: IStrategy<string, List<string>>
{
    private static char ModifyCharacterIfNeeded(ref int counter, in char character)
    {
        if (character.Equals(' ')) return character;
        if (counter++ % 2 != 0) return character;

        return char.ToUpper(character);
    }
    public string Execute(List<string> data)
    {
        var counter = 0;
        var charArray = string.Join(" ", data.Select(word => word.Trim().ToLower()))
            .Select(c => ModifyCharacterIfNeeded(ref counter, c)).ToArray();

        return string.Concat(charArray);
    }
}
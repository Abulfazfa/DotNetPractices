
string myString = "hello";
Console.WriteLine(myString.Capitalize());

var list = new List<int>()
{
    1, 2, 3, 4, 5
};
Console.WriteLine(list.MyExtension());
public static class StringExtensions
{
    public static string Capitalize(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }
        return char.ToUpper(str[0]) + str.Substring(1);
    }
}

public static class IEnumerableExtensions
{
    public static double MyExtension(this IEnumerable<int> list)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }
        return (double)list.Sum();
    }
}
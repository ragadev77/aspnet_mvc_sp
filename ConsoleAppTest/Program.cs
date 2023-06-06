using Microsoft.VisualBasic;
using System.Linq;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("--- Variant 1 ---");
string str1 = "1225441";//Console.ReadLine("");
int lenStr = str1.Length-1;
Console.WriteLine(str1);
int ival1 = Convert.ToInt32(str1);
Console.WriteLine(lenStr);
foreach (char c in str1)
{
    var result = c.ToString() + string.Concat(System.Linq.Enumerable.Repeat("0", (int)lenStr));
    Console.WriteLine(result);
    lenStr -= 1;
}
Console.WriteLine("Result : {0}", ival1);
Console.ReadLine();

Console.WriteLine("--- Variant 2 ---");
Console.Write("Input Text (default hello world) : ");
string str2 = Console.ReadLine();
// if input empty then value = "hello world"
if (str2.Length == 0) str2 = "hello world";
Console.WriteLine(str2);

//remove in between space
str2 = str2.Replace(" ", "");

//use the LINQ 'Count' extension method
//int result3 = str2.ToCharArray().Count(c => c == 'l');

// remove duplicate char from string 
var unique = new HashSet<char>(str2);

foreach (char c in unique)
{
    int result2 = str2.ToCharArray().Count(x => x == c);
    var result = string.Format("{0} - {1}", c.ToString(), result2);
    Console.WriteLine(result);
}
Console.WriteLine();

Console.WriteLine("--- Variant 3 ---");
Console.Write("Input int limit (default 32): ");
string sLimit = Console.ReadLine();
if (sLimit.Length == 0) sLimit = "32";
int ival2 = Convert.ToInt32(sLimit);
for (int i = 1; i <= ival2; i++)
{
    string result = i.ToString();
    if (i % 5 == 0 && i != 5)
        result = "IDIC ";
    else if (i % 6 == 0 && i != 6)
        result = "LPS ";
    else
        result = string.Format("{0} ", i.ToString());
    Console.Write(result);
}
Console.WriteLine("");

Console.WriteLine("--- Variant 4 ---");
Console.Write("Input Text : ");
string str3 = Console.ReadLine();
if (str3.Length == 0) str3 = "SELamaT paGi sEMua hALoO";
Console.WriteLine(str3);
str3 = str3.ToLower();
Console.WriteLine(string.Format("Format Judul : {0}", UppercaseTitle(str3)));
Console.WriteLine(string.Format("Format Biasa : {0}", UppercaseFirst(str3)));

static string UppercaseFirst(string s)
{
    if (string.IsNullOrEmpty(s))
    {
        return string.Empty;
    }
    char[] a = s.ToCharArray();
    a[0] = char.ToUpper(a[0]);
    return new string(a);
}

static string UppercaseTitle(string s)
{
    var result = string.Empty;
    if (string.IsNullOrEmpty(s))
    {
        return string.Empty;
    }
    string[] str = s.Split(' ');
    foreach(var x in str)
    {        
        string res = UppercaseFirst(x);
        result += res+" ";
    }
    return new string(result);
}

Console.WriteLine("");
Console.ReadLine();

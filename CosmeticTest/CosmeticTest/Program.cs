// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Text.RegularExpressions;

static string RemoveSign4VietnameseString(string str)
{
    string[] VietnameseSigns = new string[]
    {
        "aAeEoOuUiIdDyY",

        "áàạảãâấầậẩẫăắằặẳẵ",

        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

        "éèẹẻẽêếềệểễ",

        "ÉÈẸẺẼÊẾỀỆỂỄ",

        "óòọỏõôốồộổỗơớờợởỡ",

        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

        "úùụủũưứừựửữ",

        "ÚÙỤỦŨƯỨỪỰỬỮ",

        "íìịỉĩ",

        "ÍÌỊỈĨ",

        "đ",

        "Đ",

        "ýỳỵỷỹ",

        "ÝỲỴỶỸ"
    };

    for (int i = 1; i < VietnameseSigns.Length; i++)
    {
        for (int j = 0; j < VietnameseSigns[i].Length; j++)
            str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
    }
    return str;
}

static string ConvertToURLSlug(string str)
{
    str = str.Trim();
    str = RemoveSign4VietnameseString(str);
    Regex rgx = new Regex("[^a-zA-Z0-9 -]");
    str = rgx.Replace(str, "");
    str = Regex.Replace(str, @"\s+", "-");
    return str.ToLower();
}

Console.WriteLine(RemoveSign4VietnameseString("Xin chào Việt Nam!"));
Console.WriteLine(ConvertToURLSlug("Xin #chào &Việt@ :Nam!"));
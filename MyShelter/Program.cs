using System;
//从0.000001开始的OOP
//说起来，写这个。。。好像跟小时候玩的那些桌面游戏好像。。。还像写翻译题
namespace MyShelter
{
    class Program
    {
        static void Main(string[] args)
        {
            var companion = new Companion("hya", "hyq@m.com");
            Console.WriteLine($"Companion {companion.UID} was created for {companion.Owner} with email @{companion.email}.");
        }
    }
}

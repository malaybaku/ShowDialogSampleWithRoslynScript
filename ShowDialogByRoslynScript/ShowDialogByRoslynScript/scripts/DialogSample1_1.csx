#r "PresentationFramework"

using System;
using System.Windows;

Console.WriteLine("Sample using System.Windows.MessageBox...");

var result = MessageBox.Show(
    "プログラミングは好きですか?",
    "test",
    MessageBoxButton.YesNo,
    MessageBoxImage.Question
    );

if (result == MessageBoxResult.Yes)
{
    Console.WriteLine("私もです！");
}
else
{
    Console.WriteLine("それは残念です。");
}


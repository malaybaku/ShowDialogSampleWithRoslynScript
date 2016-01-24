#r "Microsoft.VisualBasic"

using System;
using Microsoft.VisualBasic;

Console.WriteLine("Sample using Microsoft.VisualBasic.Interaction.InputBox...");

string input = Interaction.InputBox("貴方の名前を教えて下さい");
Console.WriteLine($"こんにちは、{input}さん");

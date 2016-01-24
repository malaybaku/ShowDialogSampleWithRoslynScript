#r "PresentationFramework"
//あまりやらないパターン: 実行可能ファイルをアセンブリとして参照
#r "ShowDialogByRoslynScript.exe"

using System;

Console.WriteLine("Sample using dll reference...");

//UI要素は理由が無いならUIスレッド上で作るべき
//ref: バックグラウンド スレッドで UI 要素を作るとメモリリークする (WPF) http://grabacr.net/archives/1851
var window = UIDispatcher.Invoke(() => new DialogSample.MyWindow());

if (window.ShowDialog() == true)
{
    Console.WriteLine(window.PersonName);
    Console.WriteLine(window.IsMale);
}

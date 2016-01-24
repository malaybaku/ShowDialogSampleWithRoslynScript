#r "PresentationFramework"

using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;


Console.WriteLine("Sample loading XAML file at runtime...");

var uri = new Uri("/xamls/TestWindow.xaml", UriKind.Relative);
var info = Application.GetRemoteStream(uri);
var window = UIDispatcher.Invoke(() => new XamlReader().LoadAsync(info.Stream) as Window);

//適当にVMを組んで渡す
//ウィンドウ渡すのは「OK」ボタン押したときに閉じる挙動をラクして定義するため
var vm = new MyWindowViewModel(window);
window.DataContext = vm;
if (window.ShowDialog() == true)
{
    Console.WriteLine(vm.PersonName);
    Console.WriteLine(vm.IsMale);
}

//ウィンドウのVM
public class MyWindowViewModel
{
    public MyWindowViewModel(Window w)
    {
        OKCommand = new ActionCommand(() =>
        {
            w.DialogResult = true;
            w.Close();
        });
    }

    public string PersonName { get; set; }
    public bool IsMale { get; set; }

    public ICommand OKCommand { get; }
}

//テキトーなICommandの実装
public class ActionCommand : ICommand
{
    public ActionCommand(Action action)
    {
        _action = action;
    }

    private readonly Action _action;

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter) => true;

    public void Execute(object parameter) => _action();
}



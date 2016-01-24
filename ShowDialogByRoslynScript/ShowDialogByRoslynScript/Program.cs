using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Threading;

using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace ShowDialogByRoslynScript
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var uiDispatcherProvider = new UIDispatcherProvider();
            RunScripts(uiDispatcherProvider).Wait();
        }

        static async Task RunScripts(UIDispatcherProvider provider)
        {
            try
            {
                //await RunScript("scripts\\DialogSample1_1.csx", provider);
                //await RunScript("scripts\\DialogSample1_2.csx", provider);
                //await RunScript("scripts\\DialogSample2.csx", provider);
                //await RunScript("scripts\\DialogSample3.csx", provider);
                await RunScript("scripts\\DialogSample4.csx", provider);
            }
            catch(Exception)
            {

            }
        }

        //以下の設定をして実行
        //1. 相対パスで他のスクリプトがロード出来るようにする
        //2. 実行ディレクトリに置かれたアセンブリを参照できるようにする
        //3. UIスレッドを参照可能にする
        static async Task RunScript(string filepath, UIDispatcherProvider provider)
            => await CSharpScript.RunAsync(
                File.ReadAllText(filepath),
                ScriptOptions
                    .Default
                    .WithFilePath(Path.GetFullPath(filepath))
                    .WithMetadataResolver(
                        ScriptMetadataResolver
                            .Default
                            .WithSearchPaths(Environment.CurrentDirectory)
                        ),
                provider,
                typeof(UIDispatcherProvider)
                );

    }

    public class UIDispatcherProvider
    {
        public UIDispatcherProvider()
        {
            UIDispatcher = Dispatcher.CurrentDispatcher;
        }

        public Dispatcher UIDispatcher { get; }
    }
}

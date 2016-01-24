#r "System.Windows.Forms"
#load "MyForm.csx"

using System;
using System.Windows.Forms;

Console.WriteLine("Sample using form which is fully defined in C#...");

var form = new MyForm();
if (form.ShowDialog() == DialogResult.OK)
{
    Console.WriteLine(form.PersonName);
    Console.WriteLine(form.IsMale);
}
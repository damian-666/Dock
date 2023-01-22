using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DockMvvmSample.Views.Tools;

public class Tool1View : UserControl
{
    public Tool1View()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        //todo try a put the source for the content control
        //mg thing of avalonina.inside.. but not his complex game class
        //i have a simples possible one.. 
        //AvaloniaInside.MonoGame    the nuget doesnt come with symbols i can pull
        //do its needs to get a brush out of a theme or whatever.. im guessin backgroud

        //its purplse if thats a clue..  thoug mabyue if sayingits white it wonttry 
        //themeing it but it is looking for that i guess...
    

        Background = Avalonia.Media.Brushes.White;
        try
        {


            AvaloniaXamlLoader.Load(this);
        }

        catch (Exception ex)
        {
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using Dock.Avalonia.Controls;
using Dock.Model;
using Dock.Model.Avalonia.Json;
using Dock.Model.Core;
using Dock.Serializer;

using AvaloniaInside.MonoGame;
using DockXamlSample;
using Dock.Model.Avalonia.Controls;
using Avalonia.LogicalTree;
using Microsoft.Xna.Framework;

namespace DockXamlSample;

public class MainView : UserControl
{
    private readonly IDockSerializer _serializer;
    private readonly IDockState _dockState;

    public MainView()
    {
        InitializeComponent();

        // _serializer = new DockSerializer(typeof(AvaloniaList<>));
        _serializer = new AvaloniaDockSerializer();

        _dockState = new DockState();



  //      var  mgControlUser = this.FindControl<ToolControl>("MGGAMEVIEW");

     

        var dock = this.FindControl<DockControl>("Dock");
        if (dock is { })
        {
            var layout = dock.Layout;
            if (layout is { })
            {
                _dockState.Save(layout);
            }
        }
    }

    Game1 game1;


    Game GameSource => new Game1();

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);

        //     mgControl.Game = new Game1();
        //  var mgContro = new MonoGameControl();
        //    MonoGameControl mgContro =   this.FindControl<MonoGameControl>("mgControl");

        //     var mgControlUser = this.FindControl<UserControl>("mgControlUC");




        var dock = this.FindControl<DockControl>("Dock");

        INameScope nameScope = this.FindNameScope();

        Tool mgtool = nameScope.Find<Tool>("MGGAMEVIEW");
        // var mgControlUser = dock.Find<UserControl>();

        if (mgtool != null)
        {
            var mgControl = new MonoGameControl();

            game1 = new Game1();
            mgControl.Game = game1;
            mgtool.Content = mgControl;
        } 


            // game1.RunOneFrame();
            //   game1.Run(GameRunBehavior.Asynchronous);
          game1.Run();//blocks  anyways seems totallly wrong .. 




            //     MonoGameControl mgContro =   this.Find<MonoGameControl>("mgControl");
            //          mgContro.Game = new Game1();
            //         mgContro.Game.Run();
        



    }

    private List<FilePickerFileType> GetOpenOpenLayoutFileTypes()
    {
        return new List<FilePickerFileType>
        {
            StorageService.Json,
            StorageService.All
        };
    }

    private List<FilePickerFileType> GetSaveOpenLayoutFileTypes()
    {
        return new List<FilePickerFileType>
        {
            StorageService.Json,
            StorageService.All
        };
    }


        
    private async Task OpenLayout()
    {
        var storageProvider = StorageService.GetStorageProvider();
        if (storageProvider is null)
        {
            return;
        }

        var result = await storageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open layout",
            FileTypeFilter = GetOpenOpenLayoutFileTypes(),
            AllowMultiple = false
        });

        var file = result.FirstOrDefault();

        if (file is not null && file.CanOpenRead)
        {
            try
            {
                await using var stream = await file.OpenReadAsync();
                using var reader = new StreamReader(stream);
                var dock = this.FindControl<DockControl>("Dock");
                if (dock is { })
                {
                    var layout = _serializer.Load<IDock?>(stream);
                    if (layout is { })
                    {
                        dock.Layout = layout;
                        _dockState.Restore(layout);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    private async Task SaveLayout()
    {
        var storageProvider = StorageService.GetStorageProvider();
        if (storageProvider is null)
        {
            return;
        }

        var file = await storageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Save layout",
            FileTypeChoices = GetSaveOpenLayoutFileTypes(),
            SuggestedFileName = "layout",
            DefaultExtension = "json",
            ShowOverwritePrompt = true
        });

        if (file is not null && file.CanOpenWrite)
        {
            try
            {
                await using var stream = await file.OpenWriteAsync();
                var dock = this.FindControl<DockControl>("Dock");
                if (dock?.Layout is { })
                {
                    _serializer.Save(stream, dock.Layout);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    private void CloseLayout()
    {
        var dock = this.FindControl<DockControl>("Dock");
        if (dock is { })
        {
            dock.Layout = null;
        }
    }

    private async void FileOpenLayout_OnClick(object? sender, RoutedEventArgs e)
    {
        await OpenLayout();
    }

    private async void FileSaveLayout_OnClick(object? sender, RoutedEventArgs e)
    {
        await SaveLayout();
    }

    private void FileCloseLayout_OnClick(object? sender, RoutedEventArgs e)
    {
        CloseLayout();
    }
}


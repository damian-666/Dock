﻿using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Metadata;
using Avalonia.Styling;
using Dock.Model.Avalonia.Core;
using Dock.Model.Controls;

namespace Dock.Model.Avalonia.Controls;

/// <summary>
/// Tool.
/// </summary>
[DataContract(IsReference = true)]
public class Tool : DockableBase, ITool, IDocument, IToolContent, ITemplate<Control>, IRecyclingDataTemplate
{
    /// <summary>
    /// Defines the <see cref="Content"/> property.
    /// </summary>
    public static readonly StyledProperty<object?> ContentProperty =
        AvaloniaProperty.Register<Tool, object?>(nameof(Content));

    /// <summary>
    /// Initializes new instance of the <see cref="Tool"/> class.
    /// </summary>
    public Tool()
    {
    }

    /// <summary>
    /// Gets or sets the content to display.
    /// </summary>
    [Content]
    [TemplateContent]
    [ResolveByName]
    [IgnoreDataMember]
    public object? Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember]
    public Type? DataType { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Control Build()
    {
        return (Control)Load(Content).Control;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    object ITemplate.Build() => Build();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public bool Match(object? data)
    {
        if (DataType == null)
        {
            return true;
        }
        else
        {
            return DataType.IsInstanceOfType(data);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public Control Build(object? data) => Build(data, null);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="existing"></param>
    /// <returns></returns>
    public Control Build(object? data, Control? existing)
    {
        try
        {

            //TODO this doenst work needs a Templatecontent o

            //   return Content as Control;

            //stilll i using tool agein needs a tejmpate
            //or IServiceProvidor..

            /// set focus ot the right pagen MGVewi to make it try again activate..


            return existing ?? TemplateContent.Load(Content)?.Control!;
        }
        catch      (Exception exc)
        {
            Debug.WriteLine(exc, "MGCONTROL");
        }

        return null;
          
        }

    private static ControlTemplateResult Load(object templateContent)
    {
        if (templateContent is Func<IServiceProvider, object> direct)
        {
            return (ControlTemplateResult)direct(null!);
        }
        throw new ArgumentException(nameof(templateContent));
    }
}

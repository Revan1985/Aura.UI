﻿using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;
using System;

namespace Aura.UI.ControlsGallery
{
    public class App : Application
    {
        public override void Initialize()
        {
            Styles.Insert(0, FluentLight);
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }

        public static Styles FluentDark = new Styles
        {
            new StyleInclude(new Uri("avares://Aura.UI.ControlsGallery/Styles"))
            {
                Source = new Uri("avares://Avalonia.Themes.Fluent/FluentDark.xaml")
            },
            new StyleInclude(new Uri("avares://Aura.UI.ControlsGallery/Styles"))
            {
                Source = new Uri("avares://Aura.UI/AuraUI.xaml")
            }
        };

        public static Styles FluentLight = new Styles
        {
            new StyleInclude(new Uri("avares://Aura.UI.ControlsGallery/Styles"))
            {
                Source = new Uri("avares://Avalonia.Themes.Fluent/FluentLight.xaml")
            },
            new StyleInclude(new Uri("avares://Aura.UI.ControlsGallery/Styles"))
            {
                Source = new Uri("avares://Aura.UI/AuraUI.xaml")
            }
        };
    }
}

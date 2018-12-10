﻿using System.Windows;
using System.Windows.Controls;
using Dynamo.ViewModels;
using Dynamo.Wpf.Extensions;

namespace Unfancify
{
  /// <summary>
  /// Dynamo View Extension that can control both the Dynamo application and its UI (menus, view, canvas, nodes).
  /// </summary>
  public class UnfancifyViewExtension : IViewExtension
  {
    // Make sure to generate a new guid for your tool
    // e.g. here: https://www.guidgenerator.com
    public string UniqueId => "811ac4d9-6bf5-4e9e-8241-2b4180985ff5";
    public string Name => "Unfancify";

    private MenuItem extensionMenu;
    private ViewLoadedParams viewLoadedParams;
    private DynamoViewModel dynamoViewModel => viewLoadedParams.DynamoWindow.DataContext as DynamoViewModel;

    /// <summary>
    /// Method that is called when Dynamo starts, but is not yet ready to be used.
    /// </summary>
    /// <param name="vsp">Parameters that provide references to Dynamo settings, version and extension manager.</param>
    public void Startup(ViewStartupParams vsp) { }

    /// <summary>
    /// Method that is called when Dynamo has finished loading and the UI is ready to be interacted with.
    /// </summary>
    /// <param name="vlp">
    /// Parameters that provide references to Dynamo commands, settings, events and
    /// Dynamo UI items like menus or the background preview. This object is supplied by Dynamo itself.
    /// </param>
    public void Loaded(ViewLoadedParams vlp)
    {
      // Hold a reference to the Dynamo params to be used later
      viewLoadedParams = vlp;
      // Add custom menu items to Dynamo's UI
      MakeMenuItems();
    }

    /// <summary>
    /// Adds custom menu items to the Dynamo menu.
    /// </summary>
    public void MakeMenuItems()
    {
      // Create a completely top-level new menu item
      extensionMenu = new MenuItem { Header = "AU Workshop" };

      // Create a new sub-menu item for our tool
      var unfancifyMenuItem = new MenuItem { Header = "Unfancify" };
      // Add a tool tip to our menu item
      unfancifyMenuItem.ToolTip = new ToolTip { Content = "Simplify your graph..." };
      // Define what happens when our sub-menu item is clicked
      unfancifyMenuItem.Click += (sender, args) =>
      {
        MessageBox.Show("There's still a long way to go...");
      };
      // Add our sub-menu item to our top-level menu item
      extensionMenu.Items.Add(unfancifyMenuItem);

      // Add our top-level menu to the Dynamo menu
      viewLoadedParams.dynamoMenu.Items.Add(extensionMenu);
    }

    /// <summary>
    /// Method that is called when the host Dynamo application is closed.
    /// </summary>
    public void Shutdown() { }

    /// <summary>
    /// Method that is called for freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose() { }
  }
}

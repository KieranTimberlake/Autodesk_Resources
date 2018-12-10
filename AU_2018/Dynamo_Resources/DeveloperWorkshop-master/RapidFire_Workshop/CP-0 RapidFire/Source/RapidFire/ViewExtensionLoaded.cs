using Dynamo.Controls;
using Dynamo.ViewModels;
using Dynamo.Wpf.Extensions;
using RapidFire.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RapidFire
{
    public class ViewExtensionLoaded : IViewExtension
    {
        public string UniqueId => "C46362AA-B570-43FE-B684-B0EC45E816DC";

        public string Name => "Rapid Fire";
        private RapidFire RF;

        public void Loaded(ViewLoadedParams p)
        {
            // initiaite a RapidFire instance that needs a DynamoView so it can add nodes
            RF = new RapidFire(p.DynamoWindow as DynamoView);

            // add a Menu Item for editing the Keyboard Shortcuts
            var rfMenuItem = new MenuItem { Header = "Rapid Fire" };

            MenuItem shortcutsMenuItem = new MenuItem();
            shortcutsMenuItem.Header = "Keyboard Shortcuts";
            shortcutsMenuItem.Click += (o, e) =>
            {
                //TODO Create instance of the RapidFireViewModel

                //TODO Create instance of the View
                    
                //TODO Show it from the menu click

                //TODO save the shortcuts if desired
          
            };

            rfMenuItem.Items.Add(shortcutsMenuItem);
            p.dynamoMenu.Items.Insert(p.dynamoMenu.Items.Count-1, rfMenuItem);

            // Register all of the even handlers
            Events.RegisterEventHandlers(p, RF);
        }

        public void Startup(ViewStartupParams p) { }

        public void Shutdown()
        {
            Events.UnregisterEventHandlers();
        }

        public void Dispose() { }
    }
}

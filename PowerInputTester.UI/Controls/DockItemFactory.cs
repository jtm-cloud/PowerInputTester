using PowerInputTester.UI.Events;
using PowerInputTester.UI.Models;
using System;
using System.Collections.Generic;

namespace PowerInputTester.UI.Controls
{
    public class DockItemFactory : IDisposable
    {
        public IList<DockItem> Create(string parent, UIEventHandler handler)
        {
            switch (parent)
            {
                case "Left":
                    IList<DockItem> leftList = new List<DockItem>()
                    {
                        new DockItem("Test Info", handler),
                        new DockItem("EUT Configuration", handler),
                        new DockItem("Subtests", handler)
                    };
                    return leftList;
                case "Right":
                    IList<DockItem> rightList = new List<DockItem>()
                    {
                        new DockItem("Power Supply", handler),
                        new DockItem("Oscilloscope", handler)
                    };
                    return rightList;
                default:
                    IList<DockItem> emptyList = new List<DockItem>();
                    return emptyList;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

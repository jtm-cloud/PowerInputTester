using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerInputTester.Controls
{
    public class DockItemFactory : IDisposable
    {
        public IList<DockItem> Create(string parent, UIEventManager handler)
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

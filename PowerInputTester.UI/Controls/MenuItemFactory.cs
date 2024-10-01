using PowerInputTester.UI.Events;
using PowerInputTester.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerInputTester.UI.Controls
{
    public class MenuItemFactory : IDisposable
    {
        public IList<MenuItem> Create(string parent, UIEventHandler handler)
        {
            switch (parent)
            {
                case "File":
                    IList<MenuItem> fileList = new List<MenuItem>()
                    {
                        new MenuItem("New", handler),
                        new MenuItem("Open", handler),
                        new MenuItem("Close", handler),
                        new MenuItem("Save", handler),
                        new MenuItem("Exit", handler)
                    };
                    return fileList;
                case "Edit":
                    IList<MenuItem> editList = new List<MenuItem>()
                    {
                        new MenuItem("Cut", handler),
                        new MenuItem("Copy", handler),
                        new MenuItem("Paste", handler),
                        new MenuItem("Delete", handler),
                        new MenuItem("Select All", handler)
                    };
                    return editList;
                case "View":
                    IList<MenuItem> viewList = new List<MenuItem>()
                    {
                        new MenuItem("None", handler)
                    };
                    return viewList;
                case "Test":
                    IList<MenuItem> testList = new List<MenuItem>()
                    {
                        new MenuItem("None", handler)
                    };
                    return testList;
                case "Help":
                    IList<MenuItem> helpList = new List<MenuItem>()
                    {
                        new MenuItem("None", handler)
                    };
                    return helpList;
                case "New":
                    IList<MenuItem> newList = new List<MenuItem>()
                    {
                        new MenuItem("Project", handler),
                        new MenuItem("Test", handler),
                        new MenuItem("Repository", handler),
                        new MenuItem("Equipment", handler)
                    };
                    return newList;
                default:
                    IList<MenuItem> emptyList = new List<MenuItem>();
                    return emptyList;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

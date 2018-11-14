using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit
{
    public delegate void ToolSelectedEventHandler(ITool tool);

    public interface IToolbox
    {
        event ToolSelectedEventHandler ToolSelected;
        void AddTool(ITool tool);
        void RemoveTool(ITool tool);
        void AddSeparator();
        ITool ActiveTool { get; }
    }
}

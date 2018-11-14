using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit
{
    public interface IMenuItem
    {
        string Text { get; set; }
        void AddMenuItem(IMenuItem menuItem);
        void AddSeparator();
        void SetCommand(ICommand command);
    }
}

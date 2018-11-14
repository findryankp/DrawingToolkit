using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit
{
    public interface IToolbarItem
    {
        String Name { get; set; }
        void SetCommand(ICommand command);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit
{
    public interface IMenubar
    {
        //kaena dalam menu ba rperlu berisi item2nya seperti file dll maka ditambahkanlah IMenuItem
        void AddMenuItem(IMenuItem menuItem);
    }
}

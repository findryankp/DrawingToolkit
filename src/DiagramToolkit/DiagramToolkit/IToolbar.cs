using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit
{
    public interface IToolbar
    {
        void AddToolbarItem(IToolbarItem toolbarItem); //menambahkan item toolbar
        void AddSeparator(); // menambahkan garis pemisah
    }

    public interface IToolbarItem
    {
        String Name { get; set; }
    }
}

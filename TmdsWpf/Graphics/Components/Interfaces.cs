using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tmds.Graphics.Components
{
    interface IComponent
    {
        Canvas Canvas { get; set; }
        void Draw();
        
    }
}

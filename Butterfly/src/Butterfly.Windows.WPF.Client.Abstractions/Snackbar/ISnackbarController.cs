using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Windows.WPF.Client.Abstractions.Snackbar
{
    public interface ISnackbarController
    {
        void Enqueue(object @object);
    }
}

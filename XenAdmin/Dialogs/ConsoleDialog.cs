using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XenAdmin.Controls;
using XenAPI;

namespace XenAdmin.Dialogs
{
    public partial class ConsoleDialog : XenDialogBase
    {
        const int MAX_VMS = 15;
        ConsolePanel[] consolePanels;

        public ConsoleDialog()
        {
            InitializeComponent();
            // Can we use reflection here?
            consolePanels = new ConsolePanel[]{
                consolePanel1,
                consolePanel2,
                consolePanel3,
                consolePanel4,
                consolePanel5,
                consolePanel6,
                consolePanel7,
                consolePanel8,
                consolePanel9,
                consolePanel10,
                consolePanel11,
                consolePanel12,
                consolePanel13,
                consolePanel14,
                consolePanel15
            };
            for (int i = 0; i < MAX_VMS; ++i)
                consolePanels[i].MinimalMode();
        }

        public ConsoleDialog(IEnumerable<VM> vms)
            : this()
        {
            int i = 0;
            foreach (var vm in vms)
            {
                if (i < MAX_VMS)
                {
                    consolePanels[i].setCurrentSource(vm);
                    consolePanels[i].UnpauseActiveView();
                }
                ++i;
            }
            for (; i < MAX_VMS; ++i)
                consolePanels[i].setCurrentSource((VM)null);
        }
    }
}

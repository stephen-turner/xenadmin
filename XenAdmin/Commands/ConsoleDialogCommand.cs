using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenAdmin.Dialogs;
using XenAPI;

namespace XenAdmin.Commands
{
    class ConsoleDialogCommand : Command
    {
        public ConsoleDialogCommand(IMainWindow mainWindow, IEnumerable<SelectedItem> selection)
            : base(mainWindow, selection)
        { }

        public override string ContextMenuText
        {
            get
            {
                return "Show Consoles";
            }
        }

        protected override bool CanExecuteCore(SelectedItemCollection selection)
        {
            return selection.Count == 1 && (selection.FirstIsLiveHost || selection.FirstIsPool) || selection.AllItemsAre<VM>();
        }

        protected override void ExecuteCore(SelectedItemCollection selection)
        {
            var xo = selection.FirstAsXenObject;
            var vms = (xo is VM) ? selection.AsXenObjects<VM>() : xo.Connection.Cache.VMs.Where(vm => vm.is_a_real_vm && vm.name_label.StartsWith("Win"));
            var consoleDialog = new ConsoleDialog(vms);
            consoleDialog.Show(Program.MainWindow);
        }
    }
}

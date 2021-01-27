using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Ong.Friendly.FormsStandardControls;
using System.Diagnostics;

namespace EmployeeManagementDriver
{
    public class AppDriver
    {
        WindowsAppFriend _app;
        public MainFormDriver MainForm { get; private set; }

        public AppDriver()
        {
            var process = Process.Start("EmployeeManagement.exe");
            _app = new WindowsAppFriend(process);
            MainForm = new MainFormDriver(new WindowControl(_app, process.MainWindowHandle));
        }

        public void Release()
        {
            Process.GetProcessById(_app.ProcessId).CloseMainWindow();
        }
    }
}

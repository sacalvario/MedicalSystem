using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

using MedicalSystem.Contracts.Views;

namespace MedicalSystem.Views
{
    public partial class ShellWindow : IShellWindow
    {
        public ShellWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "CloseWindow")
            {
                CloseWindow();
            }

        }

        public Frame GetNavigationFrame()
            => shellFrame;

        public void ShowWindow()
            => Show();

        public void CloseWindow()
            => Close();
    }
}

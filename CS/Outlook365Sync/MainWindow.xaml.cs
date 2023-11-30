using DevExpress.Xpf.Scheduling;
using DevExpress.XtraScheduler.Microsoft365Calendar;
using System.Threading.Tasks;
using System.Windows;

namespace Outlook365Sync {
    public partial class MainWindow : Window {
        DXOutlook365Sync dXOutlook365Sync;
        MainWindowVM viewModel = new MainWindowVM();
        public MainWindow() {
            InitializeComponent();
            DataContext = viewModel;
            dXOutlook365Sync = new DXOutlook365Sync(uiScheduler.CreateStorageAdapter());
            dXOutlook365Sync.InitComplete += OnInitComplete;
            dXOutlook365Sync.CalendarSynchronizeComplete += OnCalendarSynchronizeComplete;
            dXOutlook365Sync.CustomizeAppointmentToEvent += OnCustomizeAppointmentToEvent;
            dXOutlook365Sync.CustomizeEventToAppointment += OnCustomizeEventToAppointment;
        }

        private void OnCustomizeEventToAppointment(object sender, ConvertEventArgs e)
            => viewModel.AddLog($"{e.Event.Subject}: CustomizeEventToAppointment fired");

        private void OnCustomizeAppointmentToEvent(object sender, ConvertEventArgs e)
            => viewModel.AddLog($"{e.Appointment.Subject}: CustomizeAppointmentToEvent fired");

        private void OnCalendarSynchronizeComplete(object sender, OperationCompleteEventArgs e)
            => viewModel.AddLog("Calendar Synchronize Completed");

        void OnInitComplete(object sender, InitCompleteEventArgs e)
            => viewModel.AddLog("Init completed");

        private async void OnImportFromOutlook(object sender, RoutedEventArgs e) => await ProcessAction(Actions.Outlook2Scheduler);
        private async void OnExportToOutlook(object sender, RoutedEventArgs e) => await ProcessAction(Actions.Scheduler2Outlook);
        private async void OnFullSynchronize(object sender, RoutedEventArgs e) => await ProcessAction(Actions.FullSynchronize);

        async Task ProcessAction(Actions actions) {
            if (viewModel.InitStatus != InitStatus.Success)
                viewModel.InitStatus = await dXOutlook365Sync.InitAsync();
            switch (actions) {
                case Actions.Scheduler2Outlook:
                    await dXOutlook365Sync.ExportSchedulerToOutlookAsync(viewModel.AllowRemoveMS365Events);
                    break;
                case Actions.Outlook2Scheduler:
                    await dXOutlook365Sync.ImportOutlookToSchedulerAsync(viewModel.AllowRemoveAppointments);
                    break;
                case Actions.FullSynchronize:
                    await dXOutlook365Sync.MergeSchedulerAndOutlookAsync(viewModel.UseTracker);
                    break;
            }
        }
    }
}

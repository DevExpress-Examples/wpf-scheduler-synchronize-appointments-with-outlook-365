using DevExpress.XtraScheduler.Microsoft365Calendar;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Outlook365Sync {
    public enum Actions {
        Scheduler2Outlook,
        Outlook2Scheduler,
        FullSynchronize
    }
    public class MainWindowVM : INotifyPropertyChanged {
        bool allowRemoveAppointments;
        public bool AllowRemoveAppointments {
            get => allowRemoveAppointments;
            set { allowRemoveAppointments = value; }
        }

        bool allowRemoveMS365Events;
        public bool AllowRemoveMS365Events {
            get => allowRemoveMS365Events;
            set { allowRemoveMS365Events = value; }
        }

        bool useTracker;
        public bool UseTracker {
            get => useTracker;
            set { useTracker = value; }
        }

        InitStatus? initStatus;
        public InitStatus? InitStatus {
            get => initStatus;
            set {
                initStatus = value;
                OnPropertyChanged();
            }
        }
        public string Log { get; private set; }
        public void AddLog(string log) {
            Log = $"{Log}\n{DateTime.Now:HH:mm:ss} - {log}";
            OnPropertyChanged(nameof(Log));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/723089508/23.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1202782)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Scheduler - Synchronize User Appointments with Microsoft 365 Calendars

The [DevExpress WPF Scheduler](https://www.devexpress.com/products/net/controls/wpf/scheduler/) allows you to synchronize user appointments with Microsoft 365 Calendars (bi-directionally). You can export appointments from the Scheduler control to Microsoft 365 calendars, import Microsoft 365 events to the Scheduler control, or merge the Scheduler control's appointments with Microsoft 365 calendars.

> **NOTE**
> 
> The [DXOutlook365Sync](https://docs.devexpress.com/WindowsForms/DevExpress.XtraScheduler.Microsoft365Calendar.DXOutlook365Sync) component used in this example requires that you register the application in Azure as demonstrated in the following topic: [Register an application with the Microsoft identity platform](https://learn.microsoft.com/en-us/entra/identity-platform/quickstart-register-app). After the registration, populate variables in the `InitComponent()` method with obtained tenant and client IDs.

## Files to Review

* [MainWindow.xaml](./CS/Outlook365Sync/MainWindow.xaml)
* [MainWindow.xaml.cs](./CS/Outlook365Sync/MainWindow.xaml.cs)
* [MainViewModel.cs](./CS/Outlook365Sync/MainViewModel.cs)

## Documentation

* [DXOutlook365Sync Class](https://docs.devexpress.com/WindowsForms/DevExpress.XtraScheduler.Microsoft365Calendar.DXOutlook365Sync)

namespace Club.Bpms.Domain;

public partial class ClubMenuDefinitions : MenuDefinition
{
    public override MenuItem Identify()
    {
        return AddMenu(nameof(DomainProvider.Domain), "", "", "");
    }

    public override bool DefineMenuItems()
    {
        var homeMenuItem = AddMenu("صفحه اول", "home-menu", "Home", "Index");
        homeMenuItem.IsPublic = true;
        /*AddMenu("کارتابل", "cartable-menu", "", "");
        {
            StartSubMenus();
            AddMenu("کارهای ورودی", "cartable-menu", "Process", "MyProcesses");
            //AddMenuForProcess("کارهای فرآیند درخواست بررسی دسترسی پرسنل", "cartable-menu",
            //    nameof(RequestToReviewPersonnelAccess));
            //AddMenuForProcess("کارهای فرآیند درخواست مجوز موقت", "cartable-menu",
            //    nameof(RequestToChangeProfile));
            /*AddMenu("گزارش فرآیند", "cartable-menu", "", "");
            {
                StartSubMenus();
                //AddMenuForReport("گزارش فرآیند درخواست دسترسی", "cartable-menu", "IUM", nameof(PersonnelProfile), nameof(PersonnelAccessDefinitions.ProcessReport));
                //AddMenuForReport("گزارش فرآیند مجوز موقت", "cartable-menu", "IUM", nameof(PersonnelProfile), nameof(PersonnelAccessDefinitions.ProcessReport));
                EndSubMenus();
            }
            AddMenu("نظارت بر کسب و کار", "cartable-menu", "", "");
            {
                StartSubMenus();
                AddMenu<ActivityInstanceRecordDefinitions.ProcessDashboard>("داشبورد", null, null, null, "WorkflowId=ServicePurchaseProcess", "cartable-menu");
                AddMenu<ProcessInstanceRecordDefinitions.TotalProcessAnalysis>("نظارت بر فرآیندها", "cartable-menu");
                AddMenu<ProcessInstanceRecordDefinitions.ProcessAnalysis>("نظارت بر فرآیندهای غیرفعال", "cartable-menu");
                AddMenu<ProcessInstanceRecordDefinitions.ActiveProcessAnalysis>("نظارت بر فرآیندهای فعال", "cartable-menu");
                AddMenuDivider();
                AddMenu<ActivityInstanceRecordDefinitions.ProcessAnalysis>("نظارت بر فعالیت‌های کسب و کار", "cartable-menu");
                AddMenu<ActivityInstanceRecordDefinitions.OneProcessAnalysis>("نظارت بر فعالیت‌های یک فرآیند", "cartable-menu");
                AddMenu<ActivityInstanceRecordDefinitions.ReportOfMyWork>("نظارت بر فعالیت‌های من", "cartable-menu");
                EndSubMenus();
            }* /
            EndSubMenus();
        }*/
        /*AddMenu("شروع فرآیند", "process-menu", "", "");
        {
            StartSubMenus();
            //AddMenuForProcessTask("درخواست بررسی دسترسی پرسنل", "process-menu",
            //    nameof(RequestToReviewPersonnelAccess), "RequestToReviewPersonnelAccessTask");
            //AddMenuForProcessTask("درخواست مجوز موقت", "process-menu",
            //    nameof(RequestToChangeProfile), "RequestToChangeProfileTask");
            EndSubMenus();
        }*/
        AddMenu_Club();
        
        AddMenu("طراحی", "design-menu", "", "");
        {
            StartSubMenus();
            AddMenu("طراحی فرآیند", "design-menu", "Process", "BpmnDesign"); // todo icon!																																  //				    addMenu("فهرست فرآیند‌ها", "fa fa-process", "Process", "List"); // todo icon!
            AddMenu("طراحی مدل اطلاعات و رابط کاربری", "design-menu", "MetaDesign/App", "entity"); // todo icon
            AddMenu("طراحی مجموعه‌های پایه", "design-menu", "MetaDesign/App", "enum"); // todo icon
            AddMenu("طراحی منو", "design-menu", "MetaDesign/App", "menu"); // todo icon!
            AddMenu("یکسان‌سازی پایگاه داده", "design-menu", "Migration", "Index");
            EndSubMenus();
        }
        return true;
    }
}

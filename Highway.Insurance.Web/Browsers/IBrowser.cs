namespace Highway.Insurance.UI.Web.Browsers
{
    public interface IBrowser
    {
        string Name { get; set; }
        string ProcessName { get; set; }
        string WindowClassName { get; set; }
        string DialogClassName { get; set; }
    }
}

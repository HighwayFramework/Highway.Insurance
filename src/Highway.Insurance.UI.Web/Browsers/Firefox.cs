namespace Highway.Insurance.UI.Web.Browsers
{
    public class Firefox : Browser, IBrowser
    {
        public const string Name = "firefox";

        public Firefox()
            : base(Name, "MozillaWindowClass")
        {
        }
    }
}

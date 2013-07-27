namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class DynamicWebPage : WebPage
    {
        public DynamicWebPage(string title)
            : base(title)
        {
            SetWindowTitle(title);
        }

        /// <summary>
        /// Gets the instance of T, which is an Object repository class (page definition).
        /// </summary>
        /// <typeparam name="T">Object repository class</typeparam>
        /// <returns>instance of T</returns>
        public static T GetBrowserWindow<T>(string title)
        {
            return (T)(object)ObjectRepositoryManager.GetInstance<T>(new object[]{title});
        }
    }
}

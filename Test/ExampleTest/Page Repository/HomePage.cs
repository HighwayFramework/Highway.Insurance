using Highway.Insurance.UI.Web.Controls.HtmlControls;

namespace ExampleTest.PageRepository
{
    public class HomePage
    {
        public EnhancedHtmlButton SubmitButton { get { return new EnhancedHtmlButton("Id=something;InnerText~something"); } }

        public EnhancedHtmlButton OtherSubmitButton { get { return new EnhancedHtmlButton("input.btn[Id=something]");}}

        public EnhancedHtmlImage ImageInSubmitButton { get { return OtherSubmitButton.Get<EnhancedHtmlImage>("a.btn image"); } }
    }
}
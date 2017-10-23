using System.Collections.Generic;
using System.IO;
using System.Linq;
using SimpleMvc.Framework.Contracts;

namespace SimpleMvc.Framework.Views
{
    public class View : IRenderable
    {
        public const string BaseLayoutFileName = "Layout";

        public const string ContentPlaceholder = "{{{content}}}";

        public const string HtmlExtension = ".html";

        public const string LocalErrorPath = "\\SimpleMvc.Framework\\Errors\\Error.html";

        private readonly string templateFullQualifedName;

        private readonly IDictionary<string, string> viewData;

        public View(string templateFullQualifedName, IDictionary<string, string> viewData)
        {
            this.templateFullQualifedName = templateFullQualifedName;
            this.viewData = viewData;
        }

        public string Render()
        {
            string fullHtml = this.ReadFile();

            if (this.viewData.Any())
            {
                foreach (var parameter in this.viewData)
                {
                    fullHtml = fullHtml.Replace($"{{{{{{{parameter.Key}}}}}}}", parameter.Value);
                }
            }

            return fullHtml;
        }

        private string ReadFile()
        {
            string layoutHtml = this.RenderLayoutHtml();

            string templateFullQualifiedNameWithExtension = this.templateFullQualifedName + HtmlExtension;
            if (!File.Exists(templateFullQualifiedNameWithExtension))
            {
                string errorPath = this.GetErrorPath();
                string errorHtml = File.ReadAllText(errorPath);
                viewData.Add("error", "Requested view does not exist!");
                return errorHtml;
            }

            string fileHtml = File.ReadAllText(templateFullQualifiedNameWithExtension);
            string fullHtml = layoutHtml.Replace(ContentPlaceholder, fileHtml);

            return fullHtml;
        }

        private string RenderLayoutHtml()
        {
            string layoutHtmlQualifiedName = string.Format(
                "{0}\\{1}{2}",
                MvcContext.Get.ViewsFolder,
                BaseLayoutFileName,
                HtmlExtension);

            if (!File.Exists(layoutHtmlQualifiedName))
            {
                string errorPath = this.GetErrorPath();
                string errorHtml = File.ReadAllText(errorPath);
                this.viewData.Add("error", "Layout view does not exist!");
                return errorHtml;
            }

            string layoutHtmlFileContent = File.ReadAllText(layoutHtmlQualifiedName);

            return layoutHtmlFileContent;
        }

        private string GetErrorPath()
        {
            string appDirectoryPath = Directory.GetCurrentDirectory();
            DirectoryInfo parentDirectory = Directory.GetParent(appDirectoryPath);
            string parentDirectoryPath = parentDirectory.FullName;

            string errorPagePath = parentDirectoryPath + LocalErrorPath;

            return errorPagePath;
        }
    }
}
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace CabMeter
{
    public class Handlebars
    {
        public static HtmlString RenderTemplates(string path)
        {
            var output = new StringBuilder();
            var files = Directory.GetFiles(HttpContext.Current.Server.MapPath(path));
            foreach (string file in files)
            {
                using (var streamReader = new StreamReader(file))
                {
                    string fileContent = streamReader.ReadToEnd();
                    output.Append(string.Format("<script type=\"text/x-handlebars\" data-template-name=\"{0}\">", GetTemplateName(file)));
                    output.Append(fileContent);
                    output.Append("</script>");
                };
            }

            return new HtmlString(output.ToString());
        }

        private static string GetTemplateName(string file)
        {
            return file.Split('\\').Last().Replace(".handlebars", "").Replace('.', '/');
        }
    }
}
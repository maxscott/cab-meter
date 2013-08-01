using Cassette;
using Cassette.Scripts;
using Cassette.Stylesheets;

namespace CabMeter.App_Start
{
    public class CassetteBundleConfiguration : IConfiguration<BundleCollection>
    {
        public void Configure(BundleCollection bundles)
        {
            bundles.Add<StylesheetBundle>("Content", new[] { "core.css", "bootstrap.css", "bootstrap-responsive.css" });

            bundles.AddPerIndividualFile<ScriptBundle>("scripts", new FileSearch
            {
                Pattern = "*.js"
            });
            bundles.AddPerIndividualFile<ScriptBundle>("scripts/app", new FileSearch
            {
                Pattern = "*.js;*.js.coffee"
            });
            bundles.AddPerSubDirectory<ScriptBundle>("scripts/app", new FileSearch
            {
                Pattern = "*.js;*.js.coffee"
            }, excludeTopLevel: true);
        }
    }
}
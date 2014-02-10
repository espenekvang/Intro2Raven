using System.Web.Optimization;

namespace Bekk.Simple.Employee.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new LessBundle("~/Content/less").Include("~/Content/less/*.less"));
        }
    }
}
using System.Diagnostics;

namespace PrismFullNavigation.Extensions
{
    public static class PageExtensions
    {
        public static bool IsModal(this Page page)
        {
            try
            {
                var navigation = page.Parent;
                foreach (var item in page.Navigation.ModalStack)
                {
                    if (item == navigation)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

            }
            return false;
        }
    }
}


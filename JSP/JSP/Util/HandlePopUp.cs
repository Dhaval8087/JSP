using DAL.Dtos;
using System.Linq;

namespace JSP.Util
{
    public static class HandlePopUp
    {
        public static void ShowPopUp(ResponseBase response)
        {
            if (response.ResultMessages.Any())
            {
                string msg = string.Empty;
                Xceed.Wpf.Toolkit.MessageBox.Show(response.ResultMessages.FirstOrDefault().Message);
            }
        }
    }
}

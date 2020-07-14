using System;
using System.IO;

namespace WpfStorage
{
    class FileLogger
    {
        public void LogAddedProduct(object source, EventArgs args)
        {
            using (StreamWriter sw = new StreamWriter(@"..\..\ManagerActions.txt", true))
            {
                sw.WriteLine("Manager added a product - {0}", DateTime.Now.ToString());
            }
        }

        public void LogEditedProduct(object source, EventArgs args)
        {
            using (StreamWriter sw = new StreamWriter(@"..\..\ManagerActions.txt", true))
            {
                sw.WriteLine("Manager edited a product - {0}", DateTime.Now.ToString());
            }
        }

        public void LogDeletedProduct(object source, EventArgs args)
        {
            using (StreamWriter sw = new StreamWriter(@"..\..\ManagerActions.txt", true))
            {
                sw.WriteLine("Manager deleted a product - {0}", DateTime.Now.ToString());
            }
        }
    }
}

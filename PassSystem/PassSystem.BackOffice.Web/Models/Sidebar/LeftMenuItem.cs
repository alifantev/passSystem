using System;
using System.Text;

namespace PassSystem.BackOffice.Web.Models.Sidebar
{
    public class LeftMenuItem
    {
        public String Id { get; set; }
        public String Text { get; set; }
        public String Controller { get; set; }
        public String Action { get; set; }
        public String Class { get; set; }
        public String ClassName => Class;
        public Boolean Active { get; set; }

        public String Url
        {
            get
            {
                StringBuilder result = new StringBuilder();
                result.Append("/");
                
                if (!String.IsNullOrWhiteSpace(Controller))
                {
                    result.Append(Controller);

                    if (!String.IsNullOrWhiteSpace(Action))
                    {
                        result.Append("/").Append(Action);
                    }
                }

                return result.ToString();
            }
        }
    }
}
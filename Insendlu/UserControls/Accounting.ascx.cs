using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insendlu.UserControls
{
    public partial class Accounting : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            else
            {
                var accountText = accounting.Text;
                var isDigit = IsDigitsOnly(accountText);
                if (isDigit)
                {
                    return;
                }
                else
                {
                    if (accountText.StartsWith("R"))
                    {
                        var test = accountText.Replace("R", "").Replace(",", "").Trim();
                        var check = test.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray();
                        accounting.Text = BuildString(check);
                        accountText = check.ToString();
                        var finalState = test.Replace(" ", string.Empty);
                        var final = finalState;
                    }

                }
            }
        }
        private string BuildString(char[] check)
        {
            var s = new StringBuilder(check.Length);
            for (int i = 0; i < check.Length; i++)
            {
                s.Append(check[i]);
            }
            return s.ToString();
        }
        private bool IsDigitsOnly(string str)
        {
            foreach (var c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        protected void accounting_OnTextChanged(object sender, EventArgs e)
        {
            accounting.Text = string.Format("{0:#,##0.00}", double.Parse(accounting.Text));
        }
    }
}
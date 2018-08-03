using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using ikvm.extensions;
using Insendlu.Entities.Connection;

using Insendu.Services;
using java.lang;
using java.lang.reflect;
using Array = System.Array;
using String = System.String;

namespace Insendlu
{
    public partial class ResetPassword : Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly UserService _userService;
        private readonly Encryptor.Encryptor _encryptor;
        private static string _tempPassword;
        
        public ResetPassword()
        {
            _userService = new UserService();
            _insendluEntities = new InsendluEntities();
            _encryptor = new Encryptor.Encryptor();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var check = Convert.ToString(Request.QueryString["temppass"]);

                var temp = !string.IsNullOrEmpty(check) ? check : string.Empty;

                if (string.IsNullOrEmpty(temp))
                {
                    Response.Redirect("index.aspx");
                }
                else
                {
                    _tempPassword = RetunTempPassword();
                    txtEmail.Value = String.Empty;
                    newPass.Value = String.Empty;
                    passconfirm.Value = String.Empty;
                }
            }
            else
            {
                var check = CheckPasswordMatch(newPass.Value, passconfirm.Value);

                if (check)
                {
                    UpdatePassword(newPass.Value, txtEmail.Value, _tempPassword);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert","alert('Error: Passwords Don't Match')");
                }
              
            }
        }

        private string RetunTempPassword()
        {
            var counter = Request.RawUrl.Split('?');
            var check1 = counter[1].Split('=');
            var final = check1[1];

            for (int i = 0; i < check1.Length; i++)
            {
                if (string.IsNullOrEmpty(check1[i]))
                {
                    final += "=";
                }

            }

            return final;
        }

        private bool CheckPasswordMatch(string newPassword, string confirmPass)
        {
            return newPassword.Equals(confirmPass);
        }

        private void UpdatePassword(string password, string email, string temp)
        {
            var user = _userService.GetUserByEmailAndTempPass(email, temp);

            if (user != null)
            {
                var enCrypt = _encryptor.Encrypt(password);

                user.password = enCrypt;
                user.status = 1;
                user.temporary_password = String.Empty;

                _insendluEntities.Entry(user).State = EntityState.Modified;
                int success = _insendluEntities.SaveChanges();

                if (success == 1)
                {
                    Session["passupdated"] = true;
                    Response.Redirect("index.aspx");
                }
                
                
            }
        }
    }
}
using System;
using System.Linq;
using System.Drawing;
using Insendlu.Entities.Connection;
using Insendu.Services;
using Insendlu.Entities.MySqlConnection;

namespace Insendlu
{
    public partial class HomePage : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly insedluEntities _insedluEntities;
        private readonly ProjectService _projectService;
        private readonly Encryptor.Encryptor _encryptor;

        public HomePage()
        {
            _insendluEntities = new InsendluEntities();
            _insedluEntities = new insedluEntities();
            _projectService = new ProjectService();
            _encryptor = new Encryptor.Encryptor();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var start = false;
                var check = Convert.ToBoolean(Session["passupdated"]) != start ? true : false;

                if (check)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Password Updated Successfully, Please login')", true);
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Value;
            var password = txtPassword.Value;
            var decryDecrypted = _encryptor.Encrypt(password);

            var user = (from users in _insendluEntities.Users
                        where users.email == email
                        select users).SingleOrDefault();

            if (user != null)
            {
                Session["UserType"] = user.user_type_id;

                if (user.status == 0)
                {
                    if (user.temporary_password == decryDecrypted)
                    {
                        Session["Username"] = user.name;
                        Session["ID"] = user.id;

                        var userProf = (from prof in _insendluEntities.UserProfiles
                            where prof.user_id == user.id
                            select prof).FirstOrDefault();

                        if (userProf != null)
                        {
                            if (userProf.profile_pic != null)
                            {
                                Session["image"] = "data: Image/png;base64," + Convert.ToBase64String(userProf.profile_pic);
                            }
                            else
                            {
                                Session["image"] = "assets/images/avatars/user.jpg";
                            }
                        }

                        //if (user.user_type_id == 1)
                        //{
                        //    Response.Redirect("~/UserDashboard.aspx");
                        //}

                        Response.Redirect("~/Dashboard.aspx");
                    }
                }
                else if (user.password == decryDecrypted)
                {
                    
                    Session["Username"] = user.name;
                    Session["ID"] = user.id;

                    var userProf = (from prof in _insendluEntities.UserProfiles
                                    where prof.user_id == user.id
                                    select prof).FirstOrDefault();

                    if (userProf != null)
                    {
                        if (userProf.profile_pic != null)
                        {
                            Session["image"] = "data: Image/png;base64," + Convert.ToBase64String(userProf.profile_pic);
                        }
                        else
                        {
                            Session["image"] = "assets/images/avatars/user.jpg";
                        }
                    }

                    //if (user.user_type_id == 2)
                    //{
                    //    Response.Redirect("~/UserDashboard.aspx");
                    //}

                    Response.Redirect("~/Dashboard.aspx");
                }
                else
                {
                    errorMessage.Text = "Incorrect credentials, re-try again";
                    errorMessage.BackColor = Color.IndianRed;
                    errorMessage.Visible = true;
                }
                

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('No user found with those credentials, please try again or contact Admin')", true);
                errorMessage.Text = "No user found with those credentials, please try again later";
                errorMessage.BackColor = Color.IndianRed;
                errorMessage.Visible = true;
            }
           
            
        }

        protected void btnRegister_OnClick(object sender, EventArgs e)
        {
            
            var pass = txtNewUserPassword.Value;
            var username = txtNewUserEmail.Value;
            var firstName = name.Value;
            var lastName = surname.Value;

            var id = _projectService.AddUser(firstName, lastName, username,1);

            if (id < 1)
            {
                
            }
            
        }

        protected void Send_OnClick(object sender, EventArgs e)
        {
            var here = forgotPassemail.Value;
        }
    }
}
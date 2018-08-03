using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using AjaxControlToolkit;
using Insendlu.Entities.Connection;
using Insendu.Services;

namespace Insendlu
{
    public partial class UserProfilesEdit : Page
    {
        private static int _id;
        private readonly InsendluEntities _insendluEntities;
        private readonly ImageService _imageService;
        private readonly ProjectService _projectService;

        public UserProfilesEdit()
        {
            _insendluEntities = new InsendluEntities();
            _projectService = new ProjectService();
            _imageService = new ImageService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);
            if (id == 0)
            {
                _id = Convert.ToInt32(Session["ID"]);
            }
            else
            {
                _id = id;
            }


            if (!IsPostBack)
            {
                if (_id > 0)
                {
                    FillDetails(_id);
                }
                else
                {
                    Response.Redirect("index.aspx");
                }

                if (Session["image"] != null)
                {
                    var images = Session["image"].ToString();
                    if (!string.IsNullOrEmpty(images))
                    {
                        image.Src = images;
                        ImgageCopy.Src = images;
                    }

                }
            }
            else
            {
                if (Session["image"] != null)
                {
                    var images = Session["image"].ToString();
                    if (!string.IsNullOrEmpty(images))
                    {
                        image.Src = images;
                        ImgageCopy.Src = images;
                    }

                }
            }


        }
        private void FillDetails(int id)
        {
            var user = (from us in _insendluEntities.Users
                        where us.id == id
                        select us).First();

            var profile = (from pro in _insendluEntities.UserProfiles where pro.user_id == _id select pro).FirstOrDefault();

            if (user != null)
            {
                txtName.InnerText = user.name;
                txtDisplayName.InnerText = user.name;

                cellphone.Text = profile != null ? profile.contact_number : string.Empty;
                txtSurname.InnerText = user.surname;
                txtDisplaySurname.InnerText = user.surname;
                biography.Text = profile != null ? profile.past_experience : string.Empty;
                qualification.Text = profile != null ? profile.qualification : string.Empty;
                department.Text = profile != null ? profile.department : string.Empty;
                responsibility.Text = profile != null ? profile.responsibility : string.Empty;
                awards.Text = profile != null ? profile.awards : string.Empty;
                email.Text = user.email;
                personalInterest.Text = profile != null ? profile.personal_interest : string.Empty;
                txtPosition.Text = profile != null ? profile.position : string.Empty;
                motivation.Text = profile != null ? profile.biography : string.Empty;
            }
        }
        protected void AjaxFileUpload1_OnUploadComplete(object sender, AjaxFileUploadEventArgs e)
        {
            var id = _id;

            var filename = Page.Server.MapPath("~/Uploads/CVS/" + Path.GetFileName(e.FileName));
            //CV
            AjaxFileUpload1.SaveAs(filename);
        }
        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            var userPosition = !string.IsNullOrEmpty(txtPosition.Text) ? txtPosition.Text : string.Empty;
            var biographicalInfo = !string.IsNullOrEmpty(biography.Text) ? biography.Text : string.Empty;
            var motivationaLetter = !string.IsNullOrEmpty(motivation.Text) ? motivation.Text : string.Empty;
            var contact = !string.IsNullOrEmpty(cellphone.Text) ? cellphone.Text : string.Empty;
            var quali = !string.IsNullOrEmpty(qualification.Text) ? qualification.Text : string.Empty;
            var depart = !string.IsNullOrEmpty(department.Text) ? department.Text : string.Empty;
            var responsiblty = !string.IsNullOrEmpty(responsibility.Text) ? responsibility.Text : string.Empty;
            var award = !string.IsNullOrEmpty(awards.Text) ? awards.Text : string.Empty;
            var personalIntrst = !string.IsNullOrEmpty(personalInterest.Text) ? personalInterest.Text : string.Empty;

            var file = FileUpload.HasFile;
            var getProfile = (from prof in _insendluEntities.UserProfiles where prof.user_id == _id select prof).SingleOrDefault();
            var user = (from prof in _insendluEntities.Users where prof.id == _id select prof).SingleOrDefault();

            var byteArray = new byte[] { };

            if (file && (FileUpload.PostedFile.ContentType == "image/jpeg"))
            {
                byteArray = _imageService.ReadToEnd(FileUpload.PostedFile.InputStream);
            }

            if (user != null)
            {
                user.contact_number = contact;

                _insendluEntities.SaveChanges();
            }

            if (getProfile != null)
            {
                getProfile.contact_number = contact;
                getProfile.profile_pic = byteArray != new byte[] {} ? byteArray : null;
                getProfile.position = userPosition;
                getProfile.past_experience = biographicalInfo;
                getProfile.biography = motivationaLetter;

                getProfile.awards = award;
                getProfile.department = depart;
                getProfile.personal_interest = personalIntrst;
                getProfile.responsibility = responsiblty;
                getProfile.qualification = quali;


                try
                {
                    _insendluEntities.SaveChanges();
                    FillDetails(_id);
                    if (getProfile.profile_pic != null)
                        SetImage(byteArray);
                    Response.Redirect("Dashboard.aspx");
                }
                catch (DbEntityValidationException validation)
                {

                    var error = validation.EntityValidationErrors;
                }

            }
            else
            {
                var userProfile = new UserProfile
                {
                    user_id = _id,
                    position = userPosition,
                    past_experience = biographicalInfo,
                    biography = motivationaLetter,
                    contact_number = contact,
                    profile_pic = byteArray != new byte[] { } ? byteArray : null,
                    awards = award,
                    department = depart,
                    personal_interest = personalIntrst,
                    qualification = quali,
                    responsibility = responsiblty
                };

                _insendluEntities.UserProfiles.Add(userProfile);
                _insendluEntities.SaveChanges();

                if(userProfile.profile_pic != null)
                    SetImage(byteArray);

                FillDetails(_id);
                Response.Redirect("Dashboard.aspx");
            }

        }
        private void SetImage(byte[] byteArray)
        {
            var imgString = "data: Image/png;base64," + Convert.ToBase64String(byteArray);

            image.Src = imgString;
            Session["image"] = "data: Image/png;base64," + Convert.ToBase64String(byteArray);
             
        }
    }
}
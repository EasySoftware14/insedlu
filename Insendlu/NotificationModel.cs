using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
////using Insendlu.Entities.Domain;

namespace Insendlu
{
    public class NotificationModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string CreatedBy { get; set; }
        public string Date { get; set; }

        public NotificationModel(Notification notification)
        {
            Id = notification.id;
            Body = notification.body;
            Date = notification.created_at.Value.ToString("dd-MMMM-yyyy");

        }
    }   
}
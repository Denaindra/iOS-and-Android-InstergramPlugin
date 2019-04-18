using System;
using System.Collections.Generic;

namespace XamarinKit.Models
{
    public class FriendListResponseModel
    {
        public string status { get; set; }
        public List<Service> services { get; set; }
    }

    public class Service
    {
        public string PICTURE_URL { get; set; }
        public string USERNAME { get; set; }
    }

}

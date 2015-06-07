using Microsoft.WindowsAzure.Mobile.Service;

namespace efwams.DataObjects
{
    public class EvalUserItem : EntityData
    {
        //This class is used to identify users of the app that are
        //submitting an eval. It uses the Social Logon of thier choice
        //as a means of uniquly submitting a speaker eval

        public string UserSocialID { get; set; }
        public string UserSocialName { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }
        public bool ITPro { get; set; }
        public bool Developer { get; set; }
        public bool BusinessAnalyst { get; set; }
        public string Other { get; set; }

    }
}

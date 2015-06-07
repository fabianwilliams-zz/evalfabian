using Microsoft.WindowsAzure.Mobile.Service;

namespace efwams.DataObjects
{
    public class EvalItem : EntityData
    {
        //this class hold unique evals per session per speaker
        //its baseically a join table between the users social identifier
        //and the session to be evaluated along with comments about the session

        public string UserSocialID { get; set; }
        public string SessionTitle { get; set; }
        public string SessionNumber { get; set; }
        public string SpeakerName { get; set; }
        public string SpeakerTH { get; set; }
        public int EvalContentRating { get; set; }
        public int EvalDeliveryRating { get; set; }
        public string EvalComments { get; set; }

    }
}

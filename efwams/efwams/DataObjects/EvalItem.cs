using Microsoft.WindowsAzure.Mobile.Service;

namespace efwams.DataObjects
{
    public class EvalItem : EntityData
    {
        //this class hold unique evals per session per speaker
        //its baseically a join table between the users social identifier
        //and the session to be evaluated along with comments about the session
    }
}

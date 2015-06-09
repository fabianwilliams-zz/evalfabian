using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;

namespace fwevals
{
	public class EvalItem
	{
		public string Id { get; set;}
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


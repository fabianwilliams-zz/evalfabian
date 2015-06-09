using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;

namespace fwevals
{
	public class SpeakerSessionItem
	{
		//used to hold a list of sessions the speaker will deliver
		//will be used on the main screen for end user to click/tap
		//in order to do a session eveal
		public string Id {get;set;}
		public string EventName { get; set; }
		public string EventCity { get; set; }
		public string EventURL { get; set; }
		public string EventHashTag { get; set; }
		public string SessionTitle { get; set; }
		public string SessionNumber { get; set; }
		public string SpeakerName { get; set; }
		public string EmailForGravatar { get; set; }
		public string EmailForContact { get; set; }
		public string SpeakerTH { get; set; }
		public string MyTweet { get; set; }
	}
}


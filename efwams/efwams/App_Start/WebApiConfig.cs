using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using efwams.DataObjects;
using efwams.Models;
using Microsoft.WindowsAzure.Mobile.Service;

namespace efwams
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            Database.SetInitializer(new MobileServiceInitializer());
        }
    }

    public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            List<SpeakerSessionItem> speakerSessionItems = new List<SpeakerSessionItem>
            {
                //this is to seed the Speaker Session Items
                new SpeakerSessionItem
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = "SharePoint Saturday Boston",
                    EventCity = "Boston",
                    EventURL = "http://www.spsevents.org/city/dc/2015summer",
                    EventHashTag = "#SPSBOS",
                    SessionTitle = "Azure Mobile Services and Xamarin.Forms",
                    SessionNumber = "12345",
                    SpeakerName = "Fabian G. Williams",
                    EmailForGravatar = "jahmekyanbwoy@yahoo.com",
                    EmailForContact = "fabian@adotob.com",
                    SpeakerTH = "@fabianwilliams",
                    MyTweet = "Test - Prepping for Boston Session on 6/13/2015"

                }, 

                new SpeakerSessionItem
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = "SharePoint Saturday DC",
                    EventCity = "Chevy Chase",
                    EventURL = "http://www.spsevents.org/city/boston/2015",
                    EventHashTag = "#SPSBOS",
                    SessionTitle = "Xamarin.Forms with Azure Mobile Services",
                    SessionNumber = "54321",
                    SpeakerName = "F.G. Williams",
                    EmailForGravatar = "fabian@adotob.com",
                    EmailForContact = "fabian@adotob.com",
                    SpeakerTH = "@fabianwilliams",
                    MyTweet = "Test - Prepping for DC Session on 6/13/2015"

                }, 
            };
            
            List<TodoItem> todoItems = new List<TodoItem>
            {                
                // this is to seed the to do items
                new TodoItem 
                { 
                    Id = Guid.NewGuid().ToString(), 
                    Text = "First item", 
                    Complete = false 
                },
                new TodoItem 
                { 
                    Id = Guid.NewGuid().ToString(), 
                    Text = "Second item", 
                    Complete = false 
                },
            };

            foreach (SpeakerSessionItem ssItem in speakerSessionItems)
            {
                context.Set<SpeakerSessionItem>().Add(ssItem);
            }

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            //now commit the seeded items to the respecteive tables

            base.Seed(context);
        }
    }
}


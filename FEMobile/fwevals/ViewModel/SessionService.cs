using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
#if __IOS__
using UIKit;
#elif __ANDROID__
using Mono;
#endif
using System.Threading;


namespace fwevals
{
	public class SessionService
	{
		private MobileServiceClient MobileService = new MobileServiceClient(
			"Your WAMS URI here",
			"Your WAMS Application Key Here"
		);

		public List<SpeakerSessionItem> Items { get; private set;}

		private IMobileServiceSyncTable<SpeakerSessionItem> speakersessionTable;

		public async Task InitializeAsync()
		{
			var store = new MobileServiceSQLiteStore("localdata.db");
			store.DefineTable<SpeakerSessionItem> ();
			await this.MobileService.SyncContext.InitializeAsync(store);

			speakersessionTable = this.MobileService.GetSyncTable<SpeakerSessionItem>();
		}

		public async Task SyncAsync()
		{
			// Comment this back in if you want auth
			//if (!await IsAuthenticated())
			//    return;
			await InitializeAsync();
			await this.MobileService.SyncContext.PushAsync();

			var query = speakersessionTable.CreateQuery();

			await speakersessionTable.PullAsync("SpeakerSessionItems", query);
		}

		public async Task<IEnumerable<SpeakerSessionItem>> SearchTodoItems(string searchInput)
		{
			await SyncAsync ();
			var query = speakersessionTable.CreateQuery ();

			if (!string.IsNullOrWhiteSpace(searchInput)) {
				query = query.Where (ei => 
					ei.Id == searchInput
					|| searchInput.ToUpper().Contains(ei.SessionTitle.ToUpper()) // workaround bug: these are backwards
					|| searchInput.ToUpper().Contains(ei.SpeakerName.ToUpper())
				);
			}

			return await query.ToEnumerableAsync();
		}

		public async Task<List<SpeakerSessionItem>> SearchTodo()
		{
			try {
				// update the local store
				// all operations on todoTable use the local database, call SyncAsync to send changes
				await SyncAsync(); 							

				// This code refreshes the entries in the list view by querying the local TodoItems table.
				// The query excludes completed TodoItems -- not anymore
				//I took out todoItems.Complete and replaced it with todoItem.Remove -- Fabian Williams
				Items = await speakersessionTable.ToListAsync();

			} catch (MobileServiceInvalidOperationException e) {
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
				return null;
			}

			return Items;
		}
	}
}


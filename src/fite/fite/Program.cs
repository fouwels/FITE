using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Timer = System.Windows.Forms.Timer;

namespace fite
{
	class Program
	{
		[DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
		public static extern IntPtr FindWindow(string lpClassName,string lpWindowName);

		[DllImport("USER32.DLL")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		private static Models.PlayersCurrentMoveDataModel _playersCurrentMoveDataModel;

		private static IntPtr AppHandle;

		static void Main(string[] args)
		{
			//**init**
			_playersCurrentMoveDataModel = new Models.PlayersCurrentMoveDataModel();
			_playersCurrentMoveDataModel.Blue = new List<Models.PlayersCurrentMoveDataModel.MoveSet>();
			_playersCurrentMoveDataModel.Red = new List<Models.PlayersCurrentMoveDataModel.MoveSet>();

			//**Patch debug into console**
			var writer = new TextWriterTraceListener(System.Console.Out);
			Debug.Listeners.Add(writer);
		
			//**get handle**
			AppHandle = FindWindow("SSFIVAE", "SSFIVAE");
			//IntPtr calculatorHandle = FindWindow("Notepad", "Untitled - Notepad");
			if (AppHandle == IntPtr.Zero)
			{
				Debug.WriteLine("Handle not found");
			}

			//**start listener** [recursive hue]
			WebListener(new List<string>
			{
				"http://localhost:1338/fite/"
				//"https://yolo.localtunnel.me:443/"
			});

			while (true)
			{
				//var key = Console.ReadLine();
				//EnterKeys(new List<string> {key, key, key, key, key, key});
				
				Console.WriteLine("enter to start test crap");
				Console.ReadLine();
				Debug.WriteLine("testing sync");
				SyncKeyTesting();
				Debug.WriteLine("done testing sync");

				//if (_playersCurrentMoveDataModel.Blue.Count > 0 && _playersCurrentMoveDataModel.Red.Count > 0)
				//{
				//	PlayMoves(_playersCurrentMoveDataModel.Red.First());
				//	PlayMoves(_playersCurrentMoveDataModel.Blue.First());
				//}
			}


		}

		static async Task WebListener(List<string> prefixes)
		{
			var listener = new HttpListener();
			foreach (var s in prefixes)
			{
				listener.Prefixes.Add(s);
			}
			listener.Start();
			listener.BeginGetContext(WebCallback, listener); //down the rabbit hole
			//listener.Stop();	
		}

		private static void WebCallback(IAsyncResult result)
		{
			Debug.WriteLine("callback");
			var listener = (HttpListener) result.AsyncState;
			var context = listener.EndGetContext(result);
			var resp = context.Response;

			//response
			string responseString = "<HTML><BODY>Ayyyyyo</BODY></HTML>";
			byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

			resp.ContentLength64 = buffer.Length;
			System.IO.Stream output = resp.OutputStream;
			output.Write(buffer, 0, buffer.Length);
			output.Close();

			var request = context.Request;
			//handle request

			//testing -> append mock data
			var mdata = Services.MockMoveSetsRedBlue();
			_playersCurrentMoveDataModel.Blue.AddRange(mdata.Blue);
			_playersCurrentMoveDataModel.Red.AddRange(mdata.Red);
			//////testing///////////


			//yolo recursion
			listener.BeginGetContext(WebCallback, listener);

		}
		static async void PlayMoves(Models.PlayersCurrentMoveDataModel.MoveSet MoveSet)
		{
			if (MoveSet.Moves.Count != 0)
			{
				var currentMove = MoveSet.Moves[0];
				await EnterKeys(currentMove.Keypresses);
				MoveSet.Moves.RemoveAt(0);
				var timer = new System.Timers.Timer
				{
					Interval = 1000
				};
				timer.Elapsed += (sender, args) => PlayMoves(MoveSet);
			}
		}

		static void SyncKeyTesting()
		{
			var keys = new List<string>
			{
				"2",
				"2",
				"2",
				"2",
				"2",
				"2",
				"2",
				"2",
				"2"
			};
			EnterKeys(keys);
		}
		static async Task EnterKeys(List<String> keys)
		{
			if (keys.Count != 0)
			{
				var currentkey = keys[0];
				SendKeyPress(currentkey);
				await SendKeyPress(currentkey);
				keys.RemoveAt(0);
				var timer = new System.Timers.Timer
				{
					Interval = 4000
				};
				timer.Elapsed += (sender, args) => EnterKeys(keys);
			}

		}

		async static Task SendKeyPress(string key)
		{
			Debug.WriteLine("Sending" + key + " @" + DateTime.Now.TimeOfDay.Milliseconds);
			SetForegroundWindow(AppHandle);
			for (int i = 0; i < 20; i++) //yolo
			{
				SendKeys.SendWait(key);
			}
			Debug.WriteLine("Sent?" + key + " @" + DateTime.Now.TimeOfDay.Milliseconds);
		}
	}
}

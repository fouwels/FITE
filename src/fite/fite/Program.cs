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

		private static Models.PlayersCurrentMoveDataModel _playerMoveSetsBuffer;

		private static IntPtr AppHandle;
		public static bool isDoubled = false;

		static void Main(string[] args)
		{
			//**init**
			_playerMoveSetsBuffer = new Models.PlayersCurrentMoveDataModel();
			_playerMoveSetsBuffer.Blue = new List<Models.PlayersCurrentMoveDataModel.MoveSet>();
			_playerMoveSetsBuffer.Red = new List<Models.PlayersCurrentMoveDataModel.MoveSet>();

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
				
				//Console.WriteLine("enter to start test crap");
				//Console.ReadLine();
				//Debug.WriteLine("testing sync");
				//SyncKeyTesting();
				//Debug.WriteLine("done testing sync");

				//if (_playersCurrentMoveDataModel.Blue.Count > 0 && _playersCurrentMoveDataModel.Red.Count > 0)
				//{
				//	PlayMoves(_playersCurrentMoveDataModel.Red.First());
				//	PlayMoves(_playersCurrentMoveDataModel.Blue.First());
				//}

				if (_playerMoveSetsBuffer.Blue.Count > 0 && _playerMoveSetsBuffer.Red.Count > 0)
				{
					var keypressBufferBlue = new List<string>();
					var keypressBufferRed = new List<string>();
					var keypressBufferMashed = new List<string>();

					var currentMoveSetBlue = _playerMoveSetsBuffer.Blue[0];
					var currentMoveSetRed = _playerMoveSetsBuffer.Red[0];
					foreach (var Move in currentMoveSetBlue.Moves)
					{
						foreach (var key in Move.Keypresses)
						{
							keypressBufferBlue.Add(key);	
						}
					}
					foreach (var Move in currentMoveSetRed.Moves)
					{
						foreach (var key in Move.Keypresses)
						{
							keypressBufferRed.Add(key);
						}
					}
					try
					{ //who needs linq merges?
						keypressBufferMashed.Add(keypressBufferBlue[0]);
						keypressBufferMashed.Add(keypressBufferRed[0]);
						keypressBufferMashed.Add(keypressBufferBlue[1]);
						keypressBufferMashed.Add(keypressBufferRed[1]);
						keypressBufferMashed.Add(keypressBufferBlue[2]);
						keypressBufferMashed.Add(keypressBufferRed[2]);
						keypressBufferMashed.Add(keypressBufferBlue[3]);
						keypressBufferMashed.Add(keypressBufferRed[3]);
						keypressBufferMashed.Add(keypressBufferBlue[4]);
						keypressBufferMashed.Add(keypressBufferRed[4]);
						keypressBufferMashed.Add(keypressBufferBlue[5]);
						keypressBufferMashed.Add(keypressBufferRed[5]);
						keypressBufferMashed.Add(keypressBufferBlue[6]);
						keypressBufferMashed.Add(keypressBufferRed[6]);
						keypressBufferMashed.Add(keypressBufferBlue[7]);
						keypressBufferMashed.Add(keypressBufferRed[7]);
						keypressBufferMashed.Add(keypressBufferBlue[8]);
						keypressBufferMashed.Add(keypressBufferRed[8]);
						keypressBufferMashed.Add(keypressBufferBlue[9]);
						keypressBufferMashed.Add(keypressBufferRed[9]);
						keypressBufferMashed.Add(keypressBufferBlue[10]);
						keypressBufferMashed.Add(keypressBufferRed[10]);
						keypressBufferMashed.Add(keypressBufferBlue[11]);
						keypressBufferMashed.Add(keypressBufferRed[11]);
						keypressBufferMashed.Add(keypressBufferBlue[12]);
						keypressBufferMashed.Add(keypressBufferRed[12]);
						keypressBufferMashed.Add(keypressBufferBlue[13]);
						keypressBufferMashed.Add(keypressBufferRed[13]);
						keypressBufferMashed.Add(keypressBufferBlue[14]);
						keypressBufferMashed.Add(keypressBufferRed[14]);
						keypressBufferMashed.Add(keypressBufferBlue[15]);
						keypressBufferMashed.Add(keypressBufferRed[15]);
						keypressBufferMashed.Add(keypressBufferBlue[16]);
						keypressBufferMashed.Add(keypressBufferRed[16]);
						keypressBufferMashed.Add(keypressBufferBlue[17]);
						keypressBufferMashed.Add(keypressBufferRed[17]);
					}
					catch (Exception)
					{
					}
					EnterKeys(keypressBufferMashed);
					_playerMoveSetsBuffer = new Models.PlayersCurrentMoveDataModel();
					_playerMoveSetsBuffer.Blue = new List<Models.PlayersCurrentMoveDataModel.MoveSet>();
					_playerMoveSetsBuffer.Red = new List<Models.PlayersCurrentMoveDataModel.MoveSet>();
				}
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
			_playerMoveSetsBuffer.Blue.AddRange(mdata.Blue);
			_playerMoveSetsBuffer.Red.AddRange(mdata.Red);
			_playerMoveSetsBuffer.Blue.AddRange(mdata.Blue);
			_playerMoveSetsBuffer.Red.AddRange(mdata.Red);
			_playerMoveSetsBuffer.Blue.AddRange(mdata.Blue);
			_playerMoveSetsBuffer.Red.AddRange(mdata.Red);


			//////testing///////////


			//yolo recursion
			listener.BeginGetContext(WebCallback, listener);
		}

		//static async void PlayMoves(Models.PlayersCurrentMoveDataModel.MoveSet MoveSet)
		//{
		//	if (MoveSet.Moves.Count != 0)
		//	{
		//		var currentMove = MoveSet.Moves[0];
		//		await EnterKeys(currentMove.Keypresses);
		//		MoveSet.Moves.RemoveAt(0);
		//		var timer = new System.Timers.Timer
		//		{
		//			Interval = 1000
		//		};
		//		timer.Elapsed += (sender, args) => PlayMoves(MoveSet);
		//	}
		//}
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
		//static void EnterKeys(List<String> keys)
		//{
		//	if (keys.Count != 0)
		//	{
		//		var currentkey = keys[0];
		//		SendKeyPress(currentkey);
		//		keys.RemoveAt(0);
		//		var timer = new System.Timers.Timer
		//		{
		//			Interval = 4000
		//		};
		//		timer.Elapsed += (sender, args) => EnterKeys(keys);
		//	}

		//}
		static void EnterKeys(List<String> keys)
		{
			if (keys.Count != 0)
			{
				var currentkey = keys[0];
				SendKeyPress(currentkey);
				keys.RemoveAt(0);
				if (isDoubled)
				{
					Thread.Sleep(2000);
					isDoubled = false;
				}
				else
				{
					isDoubled = true;
				}
				EnterKeys(keys);
			}

		}

		static void SendKeyPress(string key)
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

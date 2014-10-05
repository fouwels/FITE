using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Newtonsoft.Json;
using Timer = System.Windows.Forms.Timer;

namespace fite
{
	class Program
	{
		[DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("USER32.DLL")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		private static Models.PlayersCurrentMoveDataModel _playerMoveSetsBuffer;

		private static IntPtr AppHandle;
		public static bool isDoubled = false;

		private static Random rnd = new Random();

		private static void Main(string[] args)
		{
			MainSequence();
			while (true)
			{

			}
		}

		static async void MainSequence()
		{

			//**init**
			_playerMoveSetsBuffer = new Models.PlayersCurrentMoveDataModel();
			_playerMoveSetsBuffer.Blue = new List<Models.PlayersCurrentMoveDataModel.MoveSet>();
			_playerMoveSetsBuffer.Red = new List<Models.PlayersCurrentMoveDataModel.MoveSet>();
			await HttpGet("http://bounce22.azurewebsites.net/home/clear");

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

			while (true)
			{
				var dataString = await HttpGet("http://bounce22.azurewebsites.net/home/");
				var responses = JsonConvert.DeserializeObject<List<String>>(dataString);
				if(dataString != "[]")
				{
					await HttpGet("http://bounce22.azurewebsites.net/home/clear");

					foreach (var response in responses)
					{
						var movesConverted = new Models.PlayersCurrentMoveDataModel.MoveSet();
						movesConverted.Moves = new List<Models.PlayersCurrentMoveDataModel.MoveSet.Move>();
						var moves = response.Split(',');
						if (moves[0].ToLower().Contains("left"))
						{
							foreach (var move in moves)
							{
								try
								{
									movesConverted.Moves.Add(
										new Models.PlayersCurrentMoveDataModel.MoveSet.Move
										{
											hasBeenExecuted = false,
											Keypresses = new List<string>
											{
												KvPs.Blue[move.Trim().ToUpper()]
											}
										});
								}
								catch (Exception)
								{

								}

							}
							_playerMoveSetsBuffer.Blue.Add(movesConverted);

						}
						else
						{
							foreach (var move in moves)
							{
								try
								{
									movesConverted.Moves.Add(
										new Models.PlayersCurrentMoveDataModel.MoveSet.Move
										{
											hasBeenExecuted = false,
											Keypresses = new List<string>
											{
												KvPs.Red[move.Trim().ToUpper()]
											}
										});
								}
								catch (Exception)
								{

								}
							}
							_playerMoveSetsBuffer.Red.Add(movesConverted);
						}
					}
				}


				if (_playerMoveSetsBuffer.Blue.Count > 5 && _playerMoveSetsBuffer.Red.Count > 5)
				{
					Console.SetCursorPosition(0,0);
					Console.WriteLine("**FIGHT**                    ");
					var keypressBufferBlue = new List<string>();
					var keypressBufferRed = new List<string>();
					var keypressBufferMashed = new List<string>();
					
					var currentMoveSetBlue = _playerMoveSetsBuffer.Blue.ElementAt(rnd.Next(1, _playerMoveSetsBuffer.Blue.Count()));
					var currentMoveSetRed = _playerMoveSetsBuffer.Red.ElementAt(rnd.Next(1, _playerMoveSetsBuffer.Blue.Count()));
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
					{
						//who needs linq merges?

						#region mash

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

						#endregion
					}
					catch (Exception)
					{
					}
					EnterKeys(keypressBufferMashed);
					//_playerMoveSetsBuffer = new Models.PlayersCurrentMoveDataModel();
					//_playerMoveSetsBuffer.Blue = new List<Models.PlayersCurrentMoveDataModel.MoveSet>();
					//_playerMoveSetsBuffer.Red = new List<Models.PlayersCurrentMoveDataModel.MoveSet>();
				}
				else
				{
					Console.SetCursorPosition(0,0);
					Console.WriteLine("**Response quota not met**");
				}
				Console.SetCursorPosition(0, 2);
				Console.WriteLine("Move Sequences in buffer:");
				Console.WriteLine("   LEFT: " + _playerMoveSetsBuffer.Blue.Count);
				Console.WriteLine("   RIGHT: " + _playerMoveSetsBuffer.Red.Count);
			}
		}
		public static async Task<string> HttpGet(string urlIn)
		{
			var request = (HttpWebRequest)WebRequest.Create(urlIn);
			request.Accept = "application/json";

			WebResponse response = await request.GetResponseAsync();
			string temp;

			using (Stream stream = response.GetResponseStream())
			using (var reader = new StreamReader(stream))
				temp = reader.ReadToEnd();
			return temp;
		}

		//static async Task WebListener(List<string> prefixes)
		//{
		//	var listener = new HttpListener();
		//	foreach (var s in prefixes)
		//	{
		//		listener.Prefixes.Add(s);
		//	}
		//	listener.Start();
		//	listener.BeginGetContext(WebCallback, listener); //down the rabbit hole
		//	//listener.Stop();	
		//}

		//private static void WebCallback(IAsyncResult result)
		//{
		//	Debug.WriteLine("callback");
		//	var listener = (HttpListener) result.AsyncState;
		//	var context = listener.EndGetContext(result);
		//	var resp = context.Response;

		//	//response
		//	string responseString = "<HTML><BODY>Ayyyyyo</BODY></HTML>";
		//	byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

		//	resp.ContentLength64 = buffer.Length;
		//	System.IO.Stream output = resp.OutputStream;
		//	output.Write(buffer, 0, buffer.Length);
		//	output.Close();

		//	var request = context.Request;
		//	//handle request
		//	//testing -> append mock data
		//	var mdata = Services.MockMoveSetsRedBlue();
		//	_playerMoveSetsBuffer.Blue.AddRange(mdata.Blue);
		//	_playerMoveSetsBuffer.Red.AddRange(mdata.Red);
		//	_playerMoveSetsBuffer.Blue.AddRange(mdata.Blue);
		//	_playerMoveSetsBuffer.Red.AddRange(mdata.Red);
		//	_playerMoveSetsBuffer.Blue.AddRange(mdata.Blue);
		//	_playerMoveSetsBuffer.Red.AddRange(mdata.Red);


		//	//////testing///////////


		//	//yolo recursion
		//	listener.BeginGetContext(WebCallback, listener);
		//}

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
					Thread.Sleep(1000);
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
			Console.SetCursorPosition(0, 7);
			Debug.WriteLine("Sending " + key + " @" + DateTime.Now.TimeOfDay.Milliseconds);
			SetForegroundWindow(AppHandle);
			for (int i = 0; i < 20; i++) //yolo
			{
				SendKeys.SendWait(key);
			}
			Console.SetCursorPosition(0, 8);
			Debug.WriteLine("Sent " + key + " @" + DateTime.Now.TimeOfDay.Milliseconds);
		}
	}
}

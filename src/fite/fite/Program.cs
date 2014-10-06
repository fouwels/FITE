using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace fite
{
	internal class Program
	{
		private const int MinResponses = 1;
		private const int KeyPressDelay = 1000;

		private static Models.PlayersCurrentMoveDataModel _playerMoveSetsBuffer;

		private static IntPtr AppHandle;
		public static bool isDoubled = false;

		private static readonly Random rnd = new Random();

		[DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("USER32.DLL")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		private static void Main(string[] args)
		{
			MainSequence(); //async
			while (true)
			{
			}
		}

		private static async void MainSequence()
		{
			//**init**
			_playerMoveSetsBuffer = new Models.PlayersCurrentMoveDataModel();
			_playerMoveSetsBuffer.Blue = new List<Models.PlayersCurrentMoveDataModel.MoveSet>();
			_playerMoveSetsBuffer.Red = new List<Models.PlayersCurrentMoveDataModel.MoveSet>();
			await HttpGet("http://bounce22.azurewebsites.net/home/clear");

			//**Patch debug into console**
			var writer = new TextWriterTraceListener(Console.Out);
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
				string dataString = await HttpGet("http://bounce22.azurewebsites.net/home/");
				var responses = JsonConvert.DeserializeObject<List<String>>(dataString);
				if (dataString != "[]")
				{
					await HttpGet("http://bounce22.azurewebsites.net/home/clear");

					foreach (string response in responses)
					{
						var movesConverted = new Models.PlayersCurrentMoveDataModel.MoveSet();
						movesConverted.Moves = new List<Models.PlayersCurrentMoveDataModel.MoveSet.Move>();
						string[] moves = response.Split(',');
						if (moves[0].ToLower().Contains("left"))
						{
							foreach (string move in moves)
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
							foreach (string move in moves)
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


				if (_playerMoveSetsBuffer.Blue.Count > MinResponses && _playerMoveSetsBuffer.Red.Count > MinResponses)
				{
					Console.SetCursorPosition(0, 0);
					Console.WriteLine("**FIGHT**                    ");
					var keypressBufferBlue = new List<string>();
					var keypressBufferRed = new List<string>();
					var keypressBufferMashed = new List<string>();

					Models.PlayersCurrentMoveDataModel.MoveSet currentMoveSetBlue =
						_playerMoveSetsBuffer.Blue.ElementAt(rnd.Next(1, _playerMoveSetsBuffer.Blue.Count()));
					Models.PlayersCurrentMoveDataModel.MoveSet currentMoveSetRed =
						_playerMoveSetsBuffer.Red.ElementAt(rnd.Next(1, _playerMoveSetsBuffer.Blue.Count()));
					foreach (Models.PlayersCurrentMoveDataModel.MoveSet.Move Move in currentMoveSetBlue.Moves)
					{
						foreach (string key in Move.Keypresses)
						{
							keypressBufferBlue.Add(key);
						}
					}
					foreach (Models.PlayersCurrentMoveDataModel.MoveSet.Move Move in currentMoveSetRed.Moves)
					{
						foreach (string key in Move.Keypresses)
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
					Console.SetCursorPosition(0, 0);
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
			var request = (HttpWebRequest) WebRequest.Create(urlIn);
			request.Accept = "application/json";

			WebResponse response = await request.GetResponseAsync();
			string temp;

			using (Stream stream = response.GetResponseStream())
			using (var reader = new StreamReader(stream))
				temp = reader.ReadToEnd();
			return temp;
		}

		private static void EnterKeys(List<String> keys)
		{
			if (keys.Count != 0)
			{
				string currentkey = keys[0];
				SendKeyPress(currentkey);
				keys.RemoveAt(0);
				if (isDoubled)
				{
					Thread.Sleep(KeyPressDelay);
					isDoubled = false;
				}
				else
				{
					isDoubled = true;
				}
				EnterKeys(keys);
			}
		}

		private static void SendKeyPress(string key)
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
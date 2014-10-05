using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fite
{
	public class Services
	{
		public static Models.MockDataViewmodel MockMoveSetsRedBlue()
		{
			//sample moves
			var blue = new List<Models.PlayersCurrentMoveDataModel.MoveSet>
			{
				new Models.PlayersCurrentMoveDataModel.MoveSet
				{
					Moves = new List<Models.PlayersCurrentMoveDataModel.MoveSet.Move>
					{
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"7"
							}
						},
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"3"
							}
						},
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"W"
							}
						},
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"C"
							}
						},
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"D"
							}
						},
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"3"
							}
						},
					}
				}
			};
			var red = new List<Models.PlayersCurrentMoveDataModel.MoveSet>
			{
				new Models.PlayersCurrentMoveDataModel.MoveSet
				{
					Moves = new List<Models.PlayersCurrentMoveDataModel.MoveSet.Move>
					{
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"C"
							}
						},
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"x"
							}
						},
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"C"
							}
						},
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"C"
							}

						},
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"Z"
							}
						},
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"C"
							}
						},
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"X"
							}
						},

					}
				}
			};
			//return new Tuple<List<Models.PlayersCurrentMoveDataModel.MoveSet>, List<Models.PlayersCurrentMoveDataModel.MoveSet>>(red, blue);
			return new Models.MockDataViewmodel
			{
				Blue = blue,
				Red = red
			};
		}
	}
}

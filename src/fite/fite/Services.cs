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
								"1"
							}
						},
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"1"
							}
						},
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"1"
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
								"9"
							}
						},
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"9"
							}
						},
						new Models.PlayersCurrentMoveDataModel.MoveSet.Move
						{
							hasBeenExecuted = false,
							Keypresses = new List<string>
							{
								"9"
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

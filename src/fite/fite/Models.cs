using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fite
{
	public class Models
	{
		public class PlayersCurrentMoveDataModel
		{
			public List<MoveSet> Red { get; set; }
			public List<MoveSet> Blue { get; set; }

			public class MoveSet
			{
				public string Name { get; set; }

				public List<Move> Moves { get; set; }

				public class Move
				{
					public bool hasBeenExecuted { get; set; }
					public List<string> Keypresses { get; set; }
				}
			}
		}
		public class MockDataViewmodel
		{
			public List<PlayersCurrentMoveDataModel.MoveSet> Red { get; set; }
			public List<PlayersCurrentMoveDataModel.MoveSet> Blue { get; set; }
		}
	}
}

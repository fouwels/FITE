using System.Collections.Generic;

namespace fite
{
	public class Models
	{
		public class MockDataViewmodel
		{
			public List<PlayersCurrentMoveDataModel.MoveSet> Red { get; set; }
			public List<PlayersCurrentMoveDataModel.MoveSet> Blue { get; set; }
		}

		public class PlayersCurrentMoveDataModel
		{
			public List<MoveSet> Red { get; set; }
			public List<MoveSet> Blue { get; set; }

			public class MoveSet
			{
				public List<Move> Moves { get; set; }

				public class Move
				{
					public bool hasBeenExecuted { get; set; }
					public List<string> Keypresses { get; set; }
				}
			}
		}
	}
}
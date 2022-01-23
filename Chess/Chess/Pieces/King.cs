using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal sealed class King : IPiece
    {
        public Player Player { get; private init; }

        public King(Player player)
        {
            Player = player;
        }
    }
}

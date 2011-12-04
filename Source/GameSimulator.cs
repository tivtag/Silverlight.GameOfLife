// <copyright file="IGameSimulator.cs" company="federrot Software">
//     Copyright (c) federrot Software. All rights reserved.
// </copyright>
// <summary>Defines the GameOfLife.GameSimulator class.</summary>
// <author>Paul Ennemoser</author>

namespace GameOfLife
{
    using System.Diagnostics;

    /// <summary>
    /// Simulates the actual logic of John Conway's Game of Life.
    /// </summary>
    public sealed class GameSimulator : IGameSimulator
    {
        /// <summary>
        /// Simulates one step in the Game of Life.
        /// </summary>
        /// <param name="oldGameField">The IGameField from the last simulation step.</param>
        /// <param name="newGameField">The IGameField to fill with this simulation step.</param>
        public void SimulateStep( IGameField oldGameField, IGameField newGameField )
        {
            Debug.Assert( oldGameField.Width == newGameField.Width );
            Debug.Assert( oldGameField.Height == newGameField.Height );

            int width = oldGameField.Width;
            int height = oldGameField.Height;

            for( int x = 0; x < width; ++x )
            {
                for( int y = 0; y < height; ++y )
                {                    
                    newGameField.SetCellState( x, y, this.SimulateCell( x, y, oldGameField ) );
                }
            }
        }

        /// <summary>
        /// Simulates the state of the cell at the given position.
        /// </summary>
        /// <param name="x">The position of the cell on the x-axis.</param>
        /// <param name="y">The position of the cell on the y-axis.</param>
        /// <param name="gameField">The IGameField to pull the data from.</param>
        /// <returns>
        /// Whether the given cell is 'dead' or 'alive'.
        /// </returns>
        private bool SimulateCell( int x, int y, IGameField gameField )
        {
            int neighborCount = this.GetAliveNeighborCount( x, y, gameField );

            if( gameField.GetCellStateStrict( x, y ) )
            {
                // For a space that is 'populated':
                //  Each cell with one or no neighbors dies, as if by loneliness.
                //  Each cell with four or more neighbors dies, as if by overpopulation.
                //  Each cell with two or three neighbors survives.
                
                return neighborCount == 2 ||  neighborCount == 3;
            }
            else
            {
                // For a space that is 'empty' or 'unpopulated'
                //  Each cell with three neighbors becomes populated.

                return neighborCount == 3;
            }
        }

        /// <summary>
        /// Gets how many 'alive' neighbors the given cell has.
        /// </summary>
        /// <param name="x">The position of the cell on the x-axis.</param>
        /// <param name="y">The position of the cell on the y-axis.</param>
        /// <param name="gameField">The IGameField to pull the data from.</param>
        /// <returns>
        /// The number of alive neighbors.
        /// </returns>
        private int GetAliveNeighborCount( int x, int y, IGameField gameField )
        {
            int count = 0;

            count += this.GetCellState( x + 1, y, gameField );
            count += this.GetCellState( x - 1, y, gameField );
            count += this.GetCellState( x, y + 1, gameField );
            count += this.GetCellState( x, y - 1, gameField );

            count += this.GetCellState( x + 1, y + 1, gameField );
            count += this.GetCellState( x + 1, y - 1, gameField );
            count += this.GetCellState( x - 1, y - 1, gameField );
            count += this.GetCellState( x - 1, y + 1, gameField );

            return count;
        }

        /// <summary>
        /// Gets whether the given cell is considered 'alive'.
        /// </summary>
        /// <param name="x">The position of the cell on the x-axis.</param>
        /// <param name="y">The position of the cell on the y-axis.</param>
        /// <param name="gameField">The IGameField to pull the data from.</param>
        /// <returns>
        /// Returns 0 if the index is out of valid range or the cell is 'dead';
        /// returns 1 if the cell is 'alive'.
        /// </returns>
        private int GetCellState( int x, int y, IGameField gameField )
        {
            if( this.hasSolidWalls )
            {
                if( x < 0 || x >= gameField.Width )
                    return 0;
                if( y < 0 || y >= gameField.Height )
                    return 0;

                return gameField.GetCellStateStrict( x, y ) ? 1 : 0;
            }
            else
            {
                return gameField.GetCellState( x, y ) ? 1 : 0;
            }
        }

        /// <summary>
        /// States whether the walls of the IGameField are solid.
        /// </summary>
        /// <remarks>
        /// If true: Cells outside 'solid walls' are considered dead.
        /// If false: Outside cell positions are 'projected' back into the GameField.
        /// </remarks>
        private bool hasSolidWalls;
    }
}

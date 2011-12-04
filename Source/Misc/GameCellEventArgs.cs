// <copyright file="GameCellEventArgs.cs" company="federrot Software">
//     Copyright (c) federrot Software. All rights reserved.
// </copyright>
// <summary>Defines the GameOfLife.GameCellEventArgs class.</summary>
// <author>Paul Ennemoser</author>

namespace GameOfLife
{
    using System;

    /// <summary>
    /// Provides data for events related to a cell in the Game of Life.
    /// </summary>
    public sealed class GameCellEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the position of the cell on the x-axis.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Gets the position of the cell on the y-axis.
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Initializes a new instance of the GameCellEventArgs class.
        /// </summary>
        /// <param name="x">The position of the cell on the x-axis.</param>
        /// <param name="y">The position of the cell on the y-axis.</param>
        public GameCellEventArgs( int x, int y )
        {
            this.X = x;
            this.Y = y;
        }
    }
}

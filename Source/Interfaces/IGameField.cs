// <copyright file="IGameField.cs" company="federrot Software">
//     Copyright (c) federrot Software. All rights reserved.
// </copyright>
// <summary>Defines the GameOfLife.IGameField interface.</summary>
// <author>Paul Ennemoser</author>

namespace GameOfLife
{
    /// <summary>
    /// Provides access to the cellular field on which all action occurs.
    /// </summary>
    public interface IGameField
    {
        /// <summary>
        /// Gets the width of this IGameField.
        /// </summary>
        int Width { get; }
        
        /// <summary>
        /// Gets the height of this IGameField.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Sets whether the cell at the given position is considered 'alive'.
        /// </summary>
        /// <param name="x">The position of the cell on the x-axis.</param>
        /// <param name="y">The position of the cell on the y-axis.</param>
        /// <param name="isAlive">
        /// The value to set the cell to.
        /// </param>
        void SetCellState( int x, int y, bool isAlive );

        /// <summary>
        /// Gets whether the cell at the given position is considered 'alive'.
        /// </summary>
        /// <param name="x">The position of the cell on the x-axis.</param>
        /// <param name="y">The position of the cell on the y-axis.</param>
        /// <returns>
        /// The value of the cell.
        /// </returns>
        bool GetCellState( int x, int y );

        /// <summary>
        /// Gets whether the cell at the given position is considered 'alive'.
        /// </summary>
        /// <param name="x">The position of the cell on the x-axis.</param>
        /// <param name="y">The position of the cell on the y-axis.</param>
        /// <returns>
        /// The value of the cell.
        /// </returns>
        bool GetCellStateStrict( int x, int y );

        /// <summary>
        /// Clears this IGameField by setting all cells to 'dead'.
        /// </summary>
        void Clear();
    }
}

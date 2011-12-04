// <copyright file="IGameFieldView.cs" company="federrot Software">
//     Copyright (c) federrot Software. All rights reserved.
// </copyright>
// <summary>Defines the GameOfLife.IGameFieldView interface.</summary>
// <author>Paul Ennemoser</author>

namespace GameOfLife
{
    using System;

    /// <summary>
    /// Provides a mechanism to visualize a <see cref="IGameField"/>.
    /// </summary>
    public interface IGameFieldView
    {
        /// <summary>
        /// Fired when the user clicks on any of the cells in this GameFieldView.
        /// </summary>
        event EventHandler<GameCellEventArgs> CellClicked;

        /// <summary>
        /// Refreshes this IGameFieldView based on the given IGameField.
        /// </summary>
        /// <param name="gameField">
        /// The IGameField to 'visualize'.
        /// </param>
        void Refresh( IGameField gameField );
    }
}

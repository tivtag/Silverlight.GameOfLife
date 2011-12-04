// <copyright file="IGameSimulator.cs" company="federrot Software">
//     Copyright (c) federrot Software. All rights reserved.
// </copyright>
// <summary>Defines the GameOfLife.IGameSimulator interface.</summary>
// <author>Paul Ennemoser</author>

namespace GameOfLife
{
    /// <summary>
    /// Responsible for simulating the actual logic of John Conway's Game of Life.
    /// </summary>
    public interface IGameSimulator
    {
        /// <summary>
        /// Simulates one step in the Game of Life.
        /// </summary>
        /// <param name="oldGameField">The IGameField from the last simulation step.</param>
        /// <param name="newGameField">The IGameField to fill with this simulation step.</param>
        void SimulateStep( IGameField oldGameField, IGameField newGameField );
    }
}

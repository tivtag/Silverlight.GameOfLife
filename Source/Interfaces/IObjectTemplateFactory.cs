// <copyright file="IObjectTemplateFactory.cs" company="federrot Software">
//     Copyright (c) federrot Software. All rights reserved.
// </copyright>
// <summary>Defines the GameOfLife.IObjectTemplateFactory interface.</summary>
// <author>Paul Ennemoser</author>

namespace GameOfLife
{
    /// <summary>
    /// Provides a mechanism to add ObjectTemplates to an IGameField.
    /// </summary>
    public interface IObjectTemplateFactory
    {
        /// <summary>
        /// Adds the given ObjectTemplate to the given IGameField.
        /// </summary>
        /// <param name="template">
        /// The template to add.
        /// </param>
        /// <param name="offsetX">
        /// The offset to apply on the x-axis.
        /// </param>
        /// <param name="offsetY">
        /// The offset to apply on the y-axis.
        /// </param>
        /// <param name="gameField">
        /// The IGameField to fill with data.
        /// </param>
        void AddTemplate( ObjectTemplate template, int offsetX, int offsetY, IGameField gameField );
    }
}

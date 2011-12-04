// <copyright file="GameField.cs" company="federrot Software">
//     Copyright (c) federrot Software. All rights reserved.
// </copyright>
// <summary>Defines the GameOfLife.GameField class.</summary>
// <author>Paul Ennemoser</author>

namespace GameOfLife
{
    /// <summary>
    /// Defines the cellular field on which all action occurs.
    /// </summary>
    public sealed class GameField : IGameField
    {   
        /// <summary>
        /// Gets the width of this GameField.
        /// </summary>
        public int Width
        {
            get
            {
                return this.width;
            }
        }

        /// <summary>
        /// Gets the height of this GameField.
        /// </summary>
        public int Height
        {
            get
            {
                return this.height;
            }
        }
       
        /// <summary>
        /// Initializes a new instance of the GameField class.
        /// </summary>
        /// <param name="width">
        /// The width of the new GameField. (in cell-space)
        /// </param>
        /// <param name="height">
        /// The height of the new GameField. (in cell-space)
        /// </param>
        public GameField( int width, int height )
        {
            this.width = width;
            this.height = height;

            this.cells = new bool[width * height];
        }

        /// <summary>
        /// Sets whether the cell at the given position is considered 'alive'.
        /// </summary>
        /// <param name="x">The position of the cell on the x-axis.</param>
        /// <param name="y">The position of the cell on the y-axis.</param>
        /// <param name="isAlive">
        /// The value to set the cell to.
        /// </param>
        public void SetCellState( int x, int y, bool isAlive )
        {
            if( x == -1 )
                x = this.Width - 1;
            x = x % this.Width;

            if( y == -1 )
                y = this.Height - 1;
            y = y % this.Height;

            this.cells[GetIndex( x, y )] = isAlive;
        }     
        
        /// <summary>
        /// Gets whether the cell at the given position is considered 'alive'.
        /// </summary>
        /// <param name="x">The position of the cell on the x-axis.</param>
        /// <param name="y">The position of the cell on the y-axis.</param>
        /// <returns>
        /// The value of the cell.
        /// </returns>
        public bool GetCellState( int x, int y )
        {
            if( x == -1 )
                x = this.Width - 1;
            x = x % this.Width;

            if( x < 0 || x >= this.Width )
                return false;
            
            if( y == -1 )
                y = this.Height - 1;
            y = y % this.Height;

            if( y < 0 || y >= this.Height )
                return false;

            return this.GetCellStateStrict( x, y );
        }

        /// <summary>
        /// Gets whether the cell at the given position is considered 'alive'.
        /// </summary>
        /// <param name="x">The position of the cell on the x-axis.</param>
        /// <param name="y">The position of the cell on the y-axis.</param>
        /// <returns>
        /// The value of the cell.
        /// </returns>
        public bool GetCellStateStrict( int x, int y )
        {
            return this.cells[GetIndex( x, y )];
        }

        /// <summary>
        /// Gets the index into the cells array for the given 2D cell position.
        /// </summary>
        /// <param name="x">The position of the cell on the x-axis.</param>
        /// <param name="y">The position of the cell on the y-axis.</param>
        /// <returns>The index into the cells array.</returns>
        private int GetIndex( int x, int y )
        {
            return x + y * this.width;
        }
        
        /// <summary>
        /// Clears this IGameField by setting all cells to 'dead'.
        /// </summary>
        public void Clear()
        {
            for( int i = 0; i < cells.Length; ++i )
            {
                this.cells[i] = false;
            }
        }

        /// <summary>
        /// The cells of this GameField.
        /// </summary>
        private readonly bool[] cells;

        /// <summary>
        /// The size of this GameField.
        /// </summary>
        private readonly int width, height;
    }
}

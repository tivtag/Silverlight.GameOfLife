// <copyright file="GameFieldView.cs" company="federrot Software">
//     Copyright (c) federrot Software. All rights reserved.
// </copyright>
// <summary>
//     Defines the GameOfLife.GameFieldView class.
// </summary>
// <author>
//     Paul Ennemoser
// </author>

namespace GameOfLife
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// Represents a view over the current <see cref="IGameField"/>.
    /// </summary>
    public sealed class GameFieldView : IGameFieldView
    {
        /// <summary>
        /// Fired when the user clicks on any of the cells in this GameFieldView.
        /// </summary>
        public event EventHandler<GameCellEventArgs> CellClicked;

        /// <summary>
        /// Initializes a new instance of the GameFieldView class.
        /// </summary>
        /// <param name="rowCount">
        /// The number of rows the new GameFieldView should be able to visualize.
        /// </param>
        /// <param name="columnCount">
        /// The number of columns the new GameFieldView should be able to visualize.
        /// </param>
        /// <param name="cellGrid">
        /// The Grid that contains the</param>
        public GameFieldView( int width, int height, Grid cellGrid )
        {
            this.cellGrid = cellGrid;

            int cellWidth  = (int)this.cellGrid.Width / width;
            int cellHeight = (int)this.cellGrid.Height / height;
            int cellSize   = Math.Min( cellWidth, cellHeight );

            this.CreateField( height, width, cellSize );
        }

        private void CreateField( int rowCount, int columnCount, int cellSize )
        {
            this.CreateDefinitions( rowCount, columnCount, cellSize );
            this.CreateRectangles( rowCount, columnCount );
        }

        private void CreateDefinitions( int rowCount, int columnCount, int cellSize )
        {
            this.cellGrid.RowDefinitions.Clear();
            this.cellGrid.ColumnDefinitions.Clear();

            // Create rows.
            for( int i = 0; i < rowCount; ++i )
            {
                this.cellGrid.RowDefinitions.Add(
                    new RowDefinition() { Height = new GridLength( cellSize ) }
                );
            }

            // Create columns.
            for( int i = 0; i < columnCount; ++i )
            {
                this.cellGrid.ColumnDefinitions.Add(
                    new ColumnDefinition() { Width = new GridLength( cellSize ) }
                );
            }
        }

        private void CreateRectangles( int rowCount, int columnCount )
        {
            this.cellGrid.Children.Clear();
            this.cellField = new Rectangle[columnCount, rowCount];

            // And finally.. create the cells :)
            for( int row = 0; row < rowCount; ++row )
            {
                for( int column = 0; column < columnCount; ++column )
                {
                    this.CreateCell( row, column );
                }
            }
        }

        /// <summary>
        /// Creates and setups a single cell.
        /// </summary>
        /// <param name="row">The row of the cell to create.</param>
        /// <param name="column">The column of the cell to create.</param>
        private void CreateCell( int row, int column )
        {
            Rectangle cell = new Rectangle() {
                Fill = brushDead
            };

            cell.MouseLeftButtonDown += this.OnCellMouseLeftButtonDown;

            Grid.SetRow( cell, row );
            Grid.SetColumn( cell, column );

            this.cellField[column, row] = cell;
            this.cellGrid.Children.Add( cell );
        }

        /// <summary>
        /// Refreshes this IGameFieldView based on the given IGameField.
        /// </summary>
        /// <param name="gameField">
        /// The IGameField to 'visualize'.
        /// </param>
        public void Refresh( IGameField gameField )
        {
            int width = gameField.Width;
            int height = gameField.Height;

            for( int x = 0; x < width; ++x )
            {
                for( int y = 0; y < height; ++y )
                {
                    this.RefreshCell( x, y, gameField );
                }
            }
        }

        /// <summary>
        /// Refreshes the cell at the given position.
        /// </summary>
        /// <param name="x">The position of the cell on the x-axis.</param>
        /// <param name="y">The position of the cell on the y-axis.</param>
        /// <param name="gameField">The IGameField to pull the data from.</param>
        private void RefreshCell( int x, int y, IGameField gameField )
        {
            bool isAlive = gameField.GetCellStateStrict( x, y );
            Brush brush = this.GetBrush( isAlive );
            Rectangle rect = this.cellField[x, y];

            if( rect.Fill != brush )
            {
                rect.Fill = brush;
            }
        }

        /// <summary>
        /// Gets the brush for a cell of the given state.
        /// </summary>
        /// <param name="isAlive">
        /// States whether the cell is 'alive' or 'dead'.
        /// </param>
        /// <returns>
        /// The requested color brush.
        /// </returns>
        private Brush GetBrush( bool isAlive )
        {
            return isAlive ? this.brushAlive : this.brushDead;
        }

        /// <summary>
        /// Called when the user has clicked on one of the cells.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The MouseButtonEventArgs that contain the event data.</param>
        private void OnCellMouseLeftButtonDown( object sender, MouseButtonEventArgs e )
        {
            if( this.CellClicked != null )
            {
                var cell = (Rectangle)sender;

                int x = Grid.GetColumn( cell );
                int y = Grid.GetRow( cell );

                this.CellClicked( this, new GameCellEventArgs( x, y ) );
            }

            e.Handled = true;
        }

        /// <summary>
        /// The cellular field.
        /// </summary>
        private Rectangle[,] cellField;

        /// <summary>
        /// The Grid which contains this GameFieldView.
        /// </summary>
        private readonly Grid cellGrid;

        /// <summary>
        /// The color brush used for 'alive' cells.
        /// </summary>
        private readonly SolidColorBrush brushAlive = new SolidColorBrush( Colors.Black );

        /// <summary>
        /// The color brush used for 'dead' cells.
        /// </summary>
        private readonly SolidColorBrush brushDead = new SolidColorBrush( Colors.White );
    }
}

// <copyright file="MainPage.xaml.cs" company="federrot Software">
//     Copyright (c) federrot Software. All rights reserved.
// </copyright>
// <summary>Defines the GameOfLife.MainPage class.</summary>
// <author>Paul Ennemoser</author>

namespace GameOfLife
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// The one and only page of the Game of Life.
    /// </summary>
    public partial class MainPage : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the MainPage class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            this.RefreshButtons();

            int width = (int)this.cellGrid.Width / 10;
            int height = (int)this.cellGrid.Height / 10;

            this.oldGameField = new GameField( width, height );
            this.newGameField = new GameField( width, height );

            this.fieldView = new GameFieldView( width, height, this.cellGrid );
            this.fieldView.CellClicked += OnCellClicked;

            this.simulator = new GameSimulator();
            
            this.gameLoop.Update += OnGameLoopUpdate;
            this.gameLoop.Attach( this );
        }

        /// <summary>
        /// Called when the game loop is updating.
        /// </summary>
        /// <param name="elapsedTime">
        /// The time that has been elapsed since the last update.
        /// </param>
        private void OnGameLoopUpdate( TimeSpan elapsedTime )
        {
            if( !this.isRunning )
                return;

            this.tickTimeLeft -= elapsedTime;

            if( this.tickTimeLeft <= TimeSpan.Zero )
            {
                this.SimulateStep();
                this.tickTimeLeft = tickTime;
            }
        }

        /// <summary>
        /// Simulates the next step in Conway's Game of Life.
        /// </summary>
        private void SimulateStep()
        {
            this.SwapGameFields();

            this.simulator.SimulateStep( this.oldGameField, this.newGameField );
            ++this.step;

            this.fieldView.Refresh( this.newGameField );
        }

        /// <summary>
        /// Swaps the old and the new IGameField.
        /// </summary>
        private void SwapGameFields()
        {
            IGameField temp = this.oldGameField;
            this.oldGameField = this.newGameField;
            this.newGameField = temp;
        }

        /// <summary>
        /// Resets the data related to the simulation.
        /// </summary>
        private void ResetSimulationData()
        {
            this.step = 0;
            this.oldGameField.Clear();
            this.newGameField.Clear();
        }

        /// <summary>
        /// Refreshes the buttons used to control the starting/pausing of the simulation.
        /// </summary>
        private void RefreshButtons()
        {
            this.buttonStart.IsEnabled = !this.isRunning;
            this.buttonPause.IsEnabled = this.isRunning;
        }

        /// <summary>
        /// Called when the user clicks on one of the game cells.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The GameCellEventArgs that contain the event data.</param>
        private void OnCellClicked( object sender, GameCellEventArgs e )
        {
            this.oldGameField.SetCellState( e.X, e.Y, !this.oldGameField.GetCellStateStrict( e.X, e.Y ) );
            this.newGameField.SetCellState( e.X, e.Y, !this.newGameField.GetCellStateStrict( e.X, e.Y ) );

            this.fieldView.Refresh( this.newGameField );
        }
        
        /// <summary>
        /// Called when the user clicks on the 'Start' button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The RoutedEventArgs that contain the event data.</param>
        private void buttonStart_Click( object sender, RoutedEventArgs e )
        {
            this.isRunning = true;
            this.RefreshButtons();
        }

        /// <summary>
        /// Called when the user clicks on the 'Pause' button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The RoutedEventArgs that contain the event data.</param>
        private void buttonPause_Click( object sender, RoutedEventArgs e )
        {
            this.isRunning = false;
            this.RefreshButtons();
        }

        /// <summary>
        /// Called when the user clicks on the 'Reset' button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The RoutedEventArgs that contain the event data.</param>
        private void buttonReset_Click( object sender, RoutedEventArgs e )
        {
            this.ResetSimulationData();
            this.fieldView.Refresh( this.newGameField );
        }

        /// <summary>
        /// Called when the user clicks on the 'Reset' button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The RoutedEventArgs that contain the event data.</param>
        private void buttonAddTemplate_Clicked( object sender, RoutedEventArgs e )
        {
            var template = (ObjectTemplate)this.comboBoxTemplates.SelectedIndex;

            int offsetX = random.Next( 0, this.oldGameField.Width - 1 );
            int offsetY = random.Next( 0, this.oldGameField.Height - 1 );

            this.templateFactory.AddTemplate( template, offsetX, offsetY, this.newGameField );
            this.fieldView.Refresh( this.newGameField );
        }
        
        /// <summary>
        /// Called when the user changes the selection in the Speed-ComboBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The SelectionChangedEventArgs that contain the event data.</param>
        private void comboBoxSpeed_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            var comboBoxSpeed = (ComboBox)sender;
            int index = comboBoxSpeed.SelectedIndex;

            switch( index )
            {
                case 4:
                    this.tickTime = TimeSpan.FromSeconds( 0.0 );
                    break;

                case 3:
                    this.tickTime = TimeSpan.FromSeconds( 0.1 );
                    break;

                case 2:
                    this.tickTime = TimeSpan.FromSeconds( 0.25 );
                    break;

                case 1:
                    this.tickTime = TimeSpan.FromSeconds( 0.5 );
                    break;

                default:
                case 0:
                    this.tickTime = TimeSpan.FromSeconds( 1.0 );
                    break;
            }
        }

        /// <summary>
        /// States whether the simulation is currently running.
        /// </summary>
        private bool isRunning;

        /// <summary>
        /// The time between two simulation steps.
        /// </summary>
        private TimeSpan tickTime = TimeSpan.FromSeconds( 0.25 );

        /// <summary>
        /// The time left until the next simulation step is done.
        /// </summary>
        private TimeSpan tickTimeLeft;

        /// <summary>
        /// The number of steps since the start of the simulation.
        /// </summary>
        private int step;

        /// <summary>
        /// The game field last frame.
        /// </summary>
        private IGameField oldGameField;

        /// <summary>
        /// The game field next frame.
        /// </summary>
        private IGameField newGameField;

        /// <summary>
        /// Handles the visualization of the current IGameField.
        /// </summary>
        private readonly IGameFieldView fieldView;

        /// <summary>
        /// Handles the actual simulation of the game logic.
        /// </summary>
        private readonly IGameSimulator simulator;

        /// <summary>
        /// Responsible for creating template objects.
        /// </summary>
        private readonly IObjectTemplateFactory templateFactory = new ObjectTemplateFactory();

        /// <summary>
        /// The GameLoop object responsible for updating the simulation.
        /// </summary>
        private readonly GameLoop gameLoop = new GameLoop( "Main Loop" );

        /// <summary>
        /// A random number generator.
        /// </summary>
        private readonly Random random = new Random();
    }
}

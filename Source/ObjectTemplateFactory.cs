// <copyright file="IObjectTemplateFactory.cs" company="federrot Software">
//     Copyright (c) federrot Software. All rights reserved.
// </copyright>
// <summary>Defines the GameOfLife.ObjectTemplateFactory interface.</summary>
// <author>Paul Ennemoser</author>

namespace GameOfLife
{
    using System;

    /// <summary>
    /// Provides a mechanism to add ObjectTemplates to an IGameField.
    /// </summary>
    public sealed class ObjectTemplateFactory : IObjectTemplateFactory
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
        public void AddTemplate( ObjectTemplate template, int offsetX, int offsetY, IGameField gameField )
        {
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            this.gameField = gameField;

            switch( template )
            {
                case ObjectTemplate.Glider:
                    this.AddGlider();
                    break;

                case ObjectTemplate.Chaos:
                    this.AddChaos();
                    break;

                case ObjectTemplate.Laser0:
                    this.AddLaser0();
                    break;

                case ObjectTemplate.Laser2:
                    this.AddLaser2();
                    break;

                case ObjectTemplate.Horseshoe:
                    this.AddHorseshoe();
                    break;

                case ObjectTemplate.Flower:
                    this.AddFlower();
                    break;

                case ObjectTemplate.Claphand:
                    this.AddToad();
                    break;

                case ObjectTemplate.Acorn:
                    this.AddAcorn();
                    break;

                case ObjectTemplate.Octagon:
                    this.AddOctagon();
                    break;

                case ObjectTemplate.Pentadecathlon:
                    this.AddPentadecathlon();
                    break;

                case ObjectTemplate.Bugface:
                    this.AddBugface();
                    break;

                case ObjectTemplate.Tumbler:
                    this.AddTumbler();
                    break;

                case ObjectTemplate.Diehard:
                    this.AddDiehard();
                    break;

                case ObjectTemplate.Pulsar:
                    this.AddPulsar();
                    break;
                
                case ObjectTemplate.QueenBeeShuttle:
                    this.AddQueenBeeShuttle();
                    break;
    
                case ObjectTemplate.SpaceshipLightweight:
                    this.AddLightweightSpaceship();
                    break;

                default:
                    throw new NotImplementedException( template.ToString() );
            }
        }

        /// <summary>
        /// Adds a 'Queen Bee Shuttle' to the current IGameField.
        /// </summary>
        private void AddQueenBeeShuttle()
        {
            // X X O O O 
            // O O X O O
            // O O O X O
            // O O O X O
            // O O O X O
            // O O X O O
            // X X O O O 

            // X X O O O 
            this.SetCell( 0, 0, true );
            this.SetCell( 1, 0, true );
            this.SetCell( 2, 0, false );
            this.SetCell( 3, 0, false );
            this.SetCell( 4, 0, false );

            // O O X O O
            this.SetCell( 0, 1, false );
            this.SetCell( 1, 1, false );
            this.SetCell( 2, 1, true );
            this.SetCell( 3, 1, false );
            this.SetCell( 4, 1, false );

            // O O O X O
            this.SetCell( 0, 2, false );
            this.SetCell( 1, 2, false );
            this.SetCell( 2, 2, false );
            this.SetCell( 3, 2, true );
            this.SetCell( 4, 2, false );

            // O O O X O
            this.SetCell( 0, 3, false );
            this.SetCell( 1, 3, false );
            this.SetCell( 2, 3, false );
            this.SetCell( 3, 3, true );
            this.SetCell( 4, 3, false );

            // O O O X O
            this.SetCell( 0, 4, false );
            this.SetCell( 1, 4, false );
            this.SetCell( 2, 4, false );
            this.SetCell( 3, 4, true );
            this.SetCell( 4, 4, false );

            // O O X O O
            this.SetCell( 0, 5, false );
            this.SetCell( 1, 5, false );
            this.SetCell( 2, 5, true );
            this.SetCell( 3, 5, false );
            this.SetCell( 4, 5, false );

            // X X O O O 
            this.SetCell( 0, 6, true );
            this.SetCell( 1, 6, true );
            this.SetCell( 2, 6, false );
            this.SetCell( 3, 6, false );
            this.SetCell( 4, 6, false );
        }

        /// <summary>
        /// Adds a 'Bugface' to the current IGameField.
        /// </summary>
        private void AddBugface()
        {           
            // X X O X X 
            // X X O X X
            // O O X O O

            // X X O X X 
            this.SetCell( 0, 0, true );
            this.SetCell( 1, 0, true );
            this.SetCell( 2, 0, false );
            this.SetCell( 3, 0, true );
            this.SetCell( 4, 0, true );

            // X X O X X 
            this.SetCell( 0, 1, true );
            this.SetCell( 1, 1, true );
            this.SetCell( 2, 1, false );
            this.SetCell( 3, 1, true );
            this.SetCell( 4, 1, true );

            // O O X O O 
            this.SetCell( 0, 2, false );
            this.SetCell( 1, 2, false );
            this.SetCell( 2, 2, true );
            this.SetCell( 3, 2, false );
            this.SetCell( 4, 2, false );
        }

        /// <summary>
        /// Adds a 'Pulsar' to the current IGameField.
        /// </summary>
        private void AddPulsar()
        {
            // . . X X . . . . . X X . .
            // . . . X X . . . X X . . .
            // X . . X . X . X . X . . X
            // X X X . X X . X X . X X X
            // . X . X . X . X . X . X .
            // . . X X X . . . X X X . .
            // . . . . . . . . . . . . .
            // . . X X X . . . X X X . .
            // . X . X . X . X . X . X .
            // X X X . X X . X X . X X X
            // X . . X . X . X . X . . X
            // . . . X X . . . X X . . .
            // . . X X . . . . . X X . .

            // O O X X O O O O O X X O O
            this.SetCell( 0, 0, false );
            this.SetCell( 1, 0, false );
            this.SetCell( 2, 0, true );
            this.SetCell( 3, 0, true );
            this.SetCell( 4, 0, false );
            this.SetCell( 5, 0, false );
            this.SetCell( 6, 0, false );
            this.SetCell( 7, 0, false );
            this.SetCell( 8, 0, false );
            this.SetCell( 9, 0, true );
            this.SetCell( 10, 0, true );
            this.SetCell( 11, 0, false );
            this.SetCell( 12, 0, false );

            // O O O X X O O O X X O O O
            this.SetCell( 0, 1, false );
            this.SetCell( 1, 1, false );
            this.SetCell( 2, 1, false );
            this.SetCell( 3, 1, true );
            this.SetCell( 4, 1, true );
            this.SetCell( 5, 1, false );
            this.SetCell( 6, 1, false );
            this.SetCell( 7, 1, false );
            this.SetCell( 8, 1, true );
            this.SetCell( 9, 1, true );
            this.SetCell( 10, 1, false );
            this.SetCell( 11, 1, false );
            this.SetCell( 12, 1, false );

            // X O O X O X O X O X O O X
            this.SetCell( 0, 2, true );
            this.SetCell( 1, 2, false );
            this.SetCell( 2, 2, false );
            this.SetCell( 3, 2, true );
            this.SetCell( 4, 2, false );
            this.SetCell( 5, 2, true );
            this.SetCell( 6, 2, false );
            this.SetCell( 7, 2, true );
            this.SetCell( 8, 2, false );
            this.SetCell( 9, 2, true );
            this.SetCell( 10, 2, false );
            this.SetCell( 11, 2, false );
            this.SetCell( 12, 2, true );

            // X X X O X X O X X O X X X      
            this.SetCell( 0, 3, true );
            this.SetCell( 1, 3, true );
            this.SetCell( 2, 3, true );
            this.SetCell( 3, 3, false );
            this.SetCell( 4, 3, true );
            this.SetCell( 5, 3, true );
            this.SetCell( 6, 3, false );
            this.SetCell( 7, 3, true );
            this.SetCell( 8, 3, true );
            this.SetCell( 9, 3, false );
            this.SetCell( 10, 3, true );
            this.SetCell( 11, 3, true );
            this.SetCell( 12, 3, true );

            // O X O X O X O X O X O X O
            this.SetCell( 0, 4, false );
            this.SetCell( 1, 4, true );
            this.SetCell( 2, 4, false );
            this.SetCell( 3, 4, true );
            this.SetCell( 4, 4, false );
            this.SetCell( 5, 4, true );
            this.SetCell( 6, 4, false );
            this.SetCell( 7, 4, true );
            this.SetCell( 8, 4, false );
            this.SetCell( 9, 4, true );
            this.SetCell( 11, 4, false );
            this.SetCell( 11, 4, true );
            this.SetCell( 12, 4, false );

            // O O X X X O O O X X X O O
            this.SetCell( 0, 5, false );
            this.SetCell( 1, 5, false );
            this.SetCell( 2, 5, true );
            this.SetCell( 3, 5, true );
            this.SetCell( 4, 5, true );
            this.SetCell( 5, 5, false );
            this.SetCell( 6, 5, false );
            this.SetCell( 7, 5, false );
            this.SetCell( 8, 5, true );
            this.SetCell( 9, 5, true );
            this.SetCell( 10, 5, true );
            this.SetCell( 11, 5, false );
            this.SetCell( 12, 5, false );

            // O O O O O O O O O O O O O
            this.SetCell( 0, 6, false );
            this.SetCell( 1, 6, false );
            this.SetCell( 2, 6, false );
            this.SetCell( 3, 6, false );
            this.SetCell( 4, 6, false );
            this.SetCell( 5, 6, false );
            this.SetCell( 6, 6, false );
            this.SetCell( 7, 6, false );
            this.SetCell( 8, 6, false );
            this.SetCell( 9, 6, false );
            this.SetCell( 10, 6, false );
            this.SetCell( 11, 6, false );
            this.SetCell( 12, 6, false );

            // O O X X X O O O X X X O O
            this.SetCell( 0, 7, false );
            this.SetCell( 1, 7, false );
            this.SetCell( 2, 7, true );
            this.SetCell( 3, 7, true );
            this.SetCell( 4, 7, true );
            this.SetCell( 5, 7, false );
            this.SetCell( 6, 7, false );
            this.SetCell( 7, 7, false );
            this.SetCell( 8, 7, true );
            this.SetCell( 9, 7, true );
            this.SetCell( 10, 7, true );
            this.SetCell( 11, 7, false );
            this.SetCell( 12, 7, false );

            // O X O X O X O X O X O X O
            this.SetCell( 0, 8, false );
            this.SetCell( 1, 8, true );
            this.SetCell( 2, 8, false );
            this.SetCell( 3, 8, true );
            this.SetCell( 4, 8, false );
            this.SetCell( 5, 8, true );
            this.SetCell( 6, 8, false );
            this.SetCell( 7, 8, true );
            this.SetCell( 8, 8, false );
            this.SetCell( 9, 8, true );
            this.SetCell( 10, 8, false );
            this.SetCell( 11, 8, true );
            this.SetCell( 12, 8, false );

            // X X X O X X O X X O X X X      
            this.SetCell( 0, 9, true );
            this.SetCell( 1, 9, true );
            this.SetCell( 2, 9, true );
            this.SetCell( 3, 9, false );
            this.SetCell( 4, 9, true );
            this.SetCell( 5, 9, true );
            this.SetCell( 6, 9, false );
            this.SetCell( 7, 9, true );
            this.SetCell( 8, 9, true );
            this.SetCell( 9, 9, false );
            this.SetCell( 10, 9, true );
            this.SetCell( 11, 9, true );
            this.SetCell( 12, 9, true );

            // X O O X O X O X O X O O X
            this.SetCell( 0, 10, true );
            this.SetCell( 1, 10, false );
            this.SetCell( 2, 10, false );
            this.SetCell( 3, 10, true );
            this.SetCell( 4, 10, false );
            this.SetCell( 5, 10, true );
            this.SetCell( 6, 10, false );
            this.SetCell( 7, 10, true );
            this.SetCell( 8, 10, false );
            this.SetCell( 9, 10, true );
            this.SetCell( 10, 10, false );
            this.SetCell( 11, 10, false );
            this.SetCell( 12, 10, true );

            // O O O X X O O O X X O O O
            this.SetCell( 0, 11, false );
            this.SetCell( 1, 11, false );
            this.SetCell( 2, 11, false );
            this.SetCell( 3, 11, true );
            this.SetCell( 4, 11, true );
            this.SetCell( 5, 11, false );
            this.SetCell( 6, 11, false );
            this.SetCell( 7, 11, false );
            this.SetCell( 8, 11, true );
            this.SetCell( 9, 11, true );
            this.SetCell( 10, 11, false );
            this.SetCell( 11, 11, false );
            this.SetCell( 12, 11, false );

            // O O X X O O O O O X X O O
            this.SetCell( 0, 12, false );
            this.SetCell( 1, 12, false );
            this.SetCell( 2, 12, true );
            this.SetCell( 3, 12, true );
            this.SetCell( 4, 12, false );
            this.SetCell( 5, 12, false );
            this.SetCell( 6, 12, false );
            this.SetCell( 7, 12, false );
            this.SetCell( 8, 12, false );
            this.SetCell( 9, 12, true );
            this.SetCell( 10, 12, true );
            this.SetCell( 11, 12, false );
            this.SetCell( 12, 12, false );
        }

        /// <summary>
        /// Adds a 'Tumbler' to the current IGameField.
        /// </summary>
        private void AddTumbler()
        {
            // O X O O O X O 
            // O X X O X X O 
            // O O X O X O O 
            // X O X O X O X 
            // X X O O O X X 
            // O X O O O X O 

            // O X O O O X O 
            this.SetCell( 0, 0, false );
            this.SetCell( 1, 0, true );
            this.SetCell( 2, 0, false );
            this.SetCell( 3, 0, false );
            this.SetCell( 4, 0, false );
            this.SetCell( 5, 0, true );
            this.SetCell( 6, 0, false );

            // O X X O X X O 
            this.SetCell( 0, 1, false );
            this.SetCell( 1, 1, true );
            this.SetCell( 2, 1, true );
            this.SetCell( 3, 1, false );
            this.SetCell( 4, 1, true );
            this.SetCell( 5, 1, true );
            this.SetCell( 6, 1, false );

            // O O X O X O O 
            this.SetCell( 0, 2, false );
            this.SetCell( 1, 2, false );
            this.SetCell( 2, 2, true );
            this.SetCell( 3, 2, false );
            this.SetCell( 4, 2, true );
            this.SetCell( 5, 2, false );
            this.SetCell( 6, 2, false );

            // X O X O X O X 
            this.SetCell( 0, 3, true );
            this.SetCell( 1, 3, false );
            this.SetCell( 2, 3, true );
            this.SetCell( 3, 3, false );
            this.SetCell( 4, 3, true );
            this.SetCell( 5, 3, false );
            this.SetCell( 6, 3, true );

            // X X O O O X X 
            this.SetCell( 0, 4, true );
            this.SetCell( 1, 4, true );
            this.SetCell( 2, 4, false );
            this.SetCell( 3, 4, false );
            this.SetCell( 4, 4, false );
            this.SetCell( 5, 4, true );
            this.SetCell( 6, 4, true );

            // O X O O O X O 
            this.SetCell( 0, 5, false );
            this.SetCell( 1, 5, true );
            this.SetCell( 2, 5, false );
            this.SetCell( 3, 5, false );
            this.SetCell( 4, 5, false );
            this.SetCell( 5, 5, true );
            this.SetCell( 6, 5, false );
        }

        /// <summary>
        /// Adds a 'Pentadecathlon' to the current IGameField.
        /// </summary>
        private void AddPentadecathlon()
        {
            // O O X O O O O X O O
            // X X O X X X X O X X
            // O O X O O O O X O O

            // O O X O O O O X O O
            this.SetCell( 0, 0, false );
            this.SetCell( 1, 0, false );
            this.SetCell( 2, 0, true );
            this.SetCell( 3, 0, false );
            this.SetCell( 4, 0, false );
            this.SetCell( 5, 0, false );
            this.SetCell( 6, 0, false );
            this.SetCell( 7, 0, true );
            this.SetCell( 8, 0, false );
            this.SetCell( 9, 0, false );

            // X X O X X X X O X X
            this.SetCell( 0, 1, true );
            this.SetCell( 1, 1, true );
            this.SetCell( 2, 1, false );
            this.SetCell( 3, 1, true );
            this.SetCell( 4, 1, true );
            this.SetCell( 5, 1, true );
            this.SetCell( 6, 1, true );
            this.SetCell( 7, 1, false );
            this.SetCell( 8, 1, true );
            this.SetCell( 9, 1, true );

            // O O X O O O O X O O
            this.SetCell( 0, 2, false );
            this.SetCell( 1, 2, false );
            this.SetCell( 2, 2, true );
            this.SetCell( 3, 2, false );
            this.SetCell( 4, 2, false );
            this.SetCell( 5, 2, false );
            this.SetCell( 6, 2, false );
            this.SetCell( 7, 2, true );
            this.SetCell( 8, 2, false );
            this.SetCell( 9, 2, false );
        }

        /// <summary>
        /// Adds an 'Octagon' to the current IGameField.
        /// </summary>
        private void AddOctagon()
        {  
            // O X O O X O
            // X O X X O X
            // O X O O X O
            // O X O O X O
            // X O X X O X
            // O X O O X O

            // O X O O X O
            this.SetCell( 0, 0, false );
            this.SetCell( 1, 0, true );
            this.SetCell( 2, 0, false );
            this.SetCell( 3, 0, false );
            this.SetCell( 4, 0, true );
            this.SetCell( 5, 0, false );

            // X O X X O X
            this.SetCell( 0, 1, true );
            this.SetCell( 1, 1, false );
            this.SetCell( 2, 1, true );
            this.SetCell( 3, 1, true );
            this.SetCell( 4, 1, false );
            this.SetCell( 5, 1, true );

            // O X O O X O
            this.SetCell( 0, 2, false );
            this.SetCell( 1, 2, true );
            this.SetCell( 2, 2, false );
            this.SetCell( 3, 2, false );
            this.SetCell( 4, 2, true );
            this.SetCell( 5, 2, false );

            // O X O O X O
            this.SetCell( 0, 3, false );
            this.SetCell( 1, 3, true );
            this.SetCell( 2, 3, false );
            this.SetCell( 3, 3, false );
            this.SetCell( 4, 3, true );
            this.SetCell( 5, 3, false );

            // X O X X O X
            this.SetCell( 0, 4, true );
            this.SetCell( 1, 4, false );
            this.SetCell( 2, 4, true );
            this.SetCell( 3, 4, true );
            this.SetCell( 4, 4, false );
            this.SetCell( 5, 4, true );
            
            // O X O O X O
            this.SetCell( 0, 5, false );
            this.SetCell( 1, 5, true );
            this.SetCell( 2, 5, false );
            this.SetCell( 3, 5, false );
            this.SetCell( 4, 5, true );
            this.SetCell( 5, 5, false );
        }

        /// <summary>
        /// Adds a 'Lightweight spaceship' to the current IGameField.
        /// </summary>
        private void AddLightweightSpaceship()
        {   
            // O X O O X
            // X O O O O
            // X O O O X
            // X X X X 0

            // O X O O X
            this.SetCell( 0, 0, false );
            this.SetCell( 1, 0, true );
            this.SetCell( 2, 0, false );
            this.SetCell( 3, 0, false );
            this.SetCell( 4, 0, true );

            // X O O O O
            this.SetCell( 0, 1, true );
            this.SetCell( 1, 1, false );
            this.SetCell( 2, 1, false );
            this.SetCell( 3, 1, false );
            this.SetCell( 4, 1, false );

            // X O O O X
            this.SetCell( 0, 2, true );
            this.SetCell( 1, 2, false );
            this.SetCell( 2, 2, false );
            this.SetCell( 3, 2, false );
            this.SetCell( 4, 2, true );

            // X X X X 0
            this.SetCell( 0, 3, true );
            this.SetCell( 1, 3, true );
            this.SetCell( 2, 3, true );
            this.SetCell( 3, 3, true );
            this.SetCell( 4, 3, false );
        }

        /// <summary>
        /// Adds a 'Acorn' to the current IGameField.
        /// </summary>
        private void AddAcorn()
        {
            // O X O O O O O
            // O O O X O O O
            // X X O O X X X

            // O X O O O O O
            this.SetCell( 0, 0, false );
            this.SetCell( 1, 0, true );
            this.SetCell( 2, 0, false );
            this.SetCell( 3, 0, false );
            this.SetCell( 4, 0, false );
            this.SetCell( 5, 0, false );
            this.SetCell( 6, 0, false );

            // O O O X O O O
            this.SetCell( 0, 1, false );
            this.SetCell( 1, 1, false );
            this.SetCell( 2, 1, false );
            this.SetCell( 3, 1, true );
            this.SetCell( 4, 1, false );
            this.SetCell( 5, 1, false );
            this.SetCell( 6, 1, false );

            // X X O O X X X
            this.SetCell( 0, 2, true );
            this.SetCell( 1, 2, true );
            this.SetCell( 2, 2, false );
            this.SetCell( 3, 2, false );
            this.SetCell( 4, 2, true );
            this.SetCell( 5, 2, true );
            this.SetCell( 6, 2, true );
        }
        
        /// <summary>
        /// Adds a 'Diehard' to the current IGameField.
        /// </summary>
        private void AddDiehard()
        {
            // O O O O O O X O
            // X X O O O O O O
            // O X O O O X X X

            // O O O O O X O
            this.SetCell( 0, 0, false );
            this.SetCell( 1, 0, false );
            this.SetCell( 2, 0, false );
            this.SetCell( 3, 0, false );
            this.SetCell( 4, 0, false );
            this.SetCell( 5, 0, false );
            this.SetCell( 6, 0, true );
            this.SetCell( 7, 0, false );

            // X X O O O O O
            this.SetCell( 0, 1, true );
            this.SetCell( 1, 1, true );
            this.SetCell( 2, 1, false );
            this.SetCell( 3, 1, false );
            this.SetCell( 4, 1, false );
            this.SetCell( 5, 1, false );
            this.SetCell( 6, 1, false );
            this.SetCell( 7, 1, false );

            // O X O O X X X
            this.SetCell( 0, 2, false );
            this.SetCell( 1, 2, true );
            this.SetCell( 2, 2, false );
            this.SetCell( 3, 2, false );
            this.SetCell( 4, 2, false );
            this.SetCell( 5, 2, true );
            this.SetCell( 6, 2, true );
            this.SetCell( 7, 2, true );
        }

        /// <summary>
        /// Adds a 'Chaos' to the current IGameField.
        /// </summary>
        private void AddChaos()
        {           
            // O O X O
            // X X O O
            // O O X X
            // O X O O

            // O O X O
            this.SetCell( 0, 0, false );
            this.SetCell( 1, 0, false );
            this.SetCell( 2, 0, true );
            this.SetCell( 3, 0, false );

            // X X O O
            this.SetCell( 0, 1, true );
            this.SetCell( 1, 1, true );
            this.SetCell( 2, 1, false );
            this.SetCell( 3, 1, false );

            // O O X X
            this.SetCell( 0, 2, false );
            this.SetCell( 1, 2, false );
            this.SetCell( 2, 2, true );
            this.SetCell( 3, 2, true );

            // O X O O
            this.SetCell( 0, 3, false );
            this.SetCell( 1, 3, true );
            this.SetCell( 2, 3, false );
            this.SetCell( 3, 3, false );
        }

        /// <summary>
        /// Adds a 'Toad' to the current IGameField.
        /// </summary>
        private void AddToad()
        {   
            // O X X X
            // X X X O

            // O X X X
            this.SetCell( 0, 0, false );
            this.SetCell( 1, 0, true );
            this.SetCell( 2, 0, true );
            this.SetCell( 3, 0, true );

            // X X X O
            this.SetCell( 0, 1, true );
            this.SetCell( 1, 1, true );
            this.SetCell( 2, 1, true );
            this.SetCell( 3, 1, false );
        }

        /// <summary>
        /// Adds a 'Flower' to the current IGameField.
        /// </summary>
        private void AddFlower()
        {
            // O X X O
            // X O X X
            // O X X O
            
            // O X X O
            this.SetCell( 0, 0, false );
            this.SetCell( 1, 0, true );
            this.SetCell( 2, 0, true );
            this.SetCell( 3, 0, false );

            // X O X X
            this.SetCell( 0, 1, true );
            this.SetCell( 1, 1, false );
            this.SetCell( 2, 1, true );
            this.SetCell( 3, 1, true );

            // O X X O
            this.SetCell( 0, 2, false );
            this.SetCell( 1, 2, true );
            this.SetCell( 2, 2, true );
            this.SetCell( 3, 2, false );
        }

        /// <summary>
        /// Adds a 'Glider' to the current IGameField.
        /// </summary>
        private void AddGlider()
        {
            // O X O
            // O O X
            // X X X

            // O X O
            this.SetCell( 0, 0, false );
            this.SetCell( 1, 0, true );
            this.SetCell( 2, 0, false );

            // O O X
            this.SetCell( 0, 1, false );
            this.SetCell( 1, 1, false );
            this.SetCell( 2, 1, true );

            // X X X
            this.SetCell( 0, 2, true );
            this.SetCell( 1, 2, true );
            this.SetCell( 2, 2, true );
        }

        /// <summary>
        /// Adds a 'Horseshoe' to the current IGameField.
        /// </summary>
        private void AddHorseshoe()
        {
            // X X X
            // X O X
            // X O X
            // O O O
            // X O X
            // X O X
            // X X X

            // X X X
            this.SetCell( 0, 0, true );
            this.SetCell( 1, 0, true );
            this.SetCell( 2, 0, true );

            // X O X
            this.SetCell( 0, 1, true );
            this.SetCell( 1, 1, false );
            this.SetCell( 2, 1, true );

            // X O X
            this.SetCell( 0, 2, true );
            this.SetCell( 1, 2, false );
            this.SetCell( 2, 2, true );

            // O O O
            this.SetCell( 0, 3, false );
            this.SetCell( 1, 3, false );
            this.SetCell( 2, 3, false );

            // X O X
            this.SetCell( 0, 4, true );
            this.SetCell( 1, 4, false );
            this.SetCell( 2, 4, true );

            // X O X
            this.SetCell( 0, 5, true );
            this.SetCell( 1, 5, false );
            this.SetCell( 2, 5, true );

            // X X X
            this.SetCell( 0, 6, true );
            this.SetCell( 1, 6, true );
            this.SetCell( 2, 6, true );
        }

        /// <summary>
        /// Adds a 'Laser-0' to the current IGameField.
        /// </summary>
        private void AddLaser0()
        {
            // X X O O
            // X O O O
            // O O O X
            // O O X X

            // X X O O
            this.SetCell( 0, 0, true );
            this.SetCell( 1, 0, true );
            this.SetCell( 2, 0, false );
            this.SetCell( 3, 0, false );

            // X O O O
            this.SetCell( 0, 1, true );
            this.SetCell( 1, 1, false );
            this.SetCell( 2, 1, false );
            this.SetCell( 3, 1, false );

            // O O O X
            this.SetCell( 0, 2, false );
            this.SetCell( 1, 2, false );
            this.SetCell( 2, 2, false );
            this.SetCell( 3, 2, true );

            // O O X X
            this.SetCell( 0, 3, false );
            this.SetCell( 1, 3, false );
            this.SetCell( 2, 3, true );
            this.SetCell( 3, 3, true );
        }

        /// <summary>
        /// Adds a 'Laser-2' to the current IGameField.
        /// </summary>
        private void AddLaser2()
        {
            // X X O O O
            // X O X O O
            // O O O O O
            // O O X O X
            // O O O X X

            // X X O O O
            this.SetCell( 0, 0, true );
            this.SetCell( 1, 0, true );
            this.SetCell( 2, 0, false );
            this.SetCell( 3, 0, false );
            this.SetCell( 4, 0, false );

            // X O X O O
            this.SetCell( 0, 1, true );
            this.SetCell( 1, 1, false );
            this.SetCell( 2, 1, true );
            this.SetCell( 3, 1, false );
            this.SetCell( 4, 1, false );

            // O O O O O
            this.SetCell( 0, 2, false );
            this.SetCell( 1, 2, false );
            this.SetCell( 2, 2, false );
            this.SetCell( 3, 2, false );
            this.SetCell( 4, 2, false );

            // O O X O X
            this.SetCell( 0, 3, false );
            this.SetCell( 1, 3, false );
            this.SetCell( 2, 3, true );
            this.SetCell( 3, 3, false );
            this.SetCell( 4, 3, true );

            // O O O X X
            this.SetCell( 0, 4, false );
            this.SetCell( 1, 4, false );
            this.SetCell( 2, 4, false );
            this.SetCell( 3, 4, true );
            this.SetCell( 4, 4, true );
        }

        /// <summary>
        /// Sets the cell at the given position to the given state.
        /// </summary>
        /// <param name="x">The relative position of the cell on the x-axis.</param>
        /// <param name="y">The relative position of the cell on the y-axis.</param>
        /// <param name="isAlive">The state to set.</param>
        private void SetCell( int x, int y, bool isAlive )
        {
            this.gameField.SetCellState( x + this.offsetX, y + this.offsetY, isAlive );
        }

        /// <summary>
        /// Captures the currently used offset.
        /// </summary>
        private int offsetX, offsetY;

        /// <summary>
        /// Captures the currently used IGameField.
        /// </summary>
        private IGameField gameField;
    }
}

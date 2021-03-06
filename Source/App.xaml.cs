﻿
namespace GameOfLife
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Documents;
	using System.Windows.Input;
	using System.Windows.Media;
	using System.Windows.Media.Animation;
	using System.Windows.Shapes;

    public partial class App : Application
    {
        public App()
        {
            this.Startup += this.OnStartup;
            this.UnhandledException += this.OnUnhandledException;

            InitializeComponent();
        }

        private void OnStartup( object sender, StartupEventArgs e )
        {
            this.RootVisual = new MainPage();
        }

        private void OnUnhandledException( object sender, ApplicationUnhandledExceptionEventArgs e )
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if( !System.Diagnostics.Debugger.IsAttached )
            {

                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke( delegate { ReportErrorToDOM( e ); } );
            }
        }
		
        private void ReportErrorToDOM( ApplicationUnhandledExceptionEventArgs e )
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace( '"', '\'' ).Replace( "\r\n", @"\n" );

                System.Windows.Browser.HtmlPage.Window.Eval( "throw new Error(\"Unhandled Error in Silverlight 2 Application " + errorMsg + "\");" );
            }
            catch( Exception )
            {
				// eat it.
            }
        }
    }
}

Namespace My
    ' The following events are availble for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_UnhandledException (ByVal sender As Object, _
                                                      ByVal e As _
                                                         Microsoft.VisualBasic.ApplicationServices. _
                                                         UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Dim message As String
            message = "Mot biet le chua duoc quan ly." + Constants.vbCrLf + "Mo ta loi:" + e.Exception.Message + _
                      Constants.vbCrLf + "Chi tiet loi:" + e.Exception.StackTrace() + Constants.vbCrLf + "Vui long lien he..."
            MessageBox.Show (message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Write to logfile
        End Sub
    End Class
End Namespace



Imports System.Security.Cryptography
Imports System.IO
Imports System.Deployment.Application

Public Class frmHashChecker

    Private _file As String = String.Empty

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strAppTitel As String

        'Vorbereitungen
        strAppTitel = "Hash Checker"

        If (ApplicationDeployment.IsNetworkDeployed) Then
            Text = strAppTitel & " " & ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
        Else
            Text = strAppTitel & " " & My.Application.Info.Version.ToString()
        End If

        If My.Settings.HashType = "SHA256" Then
            Width = 625
        ElseIf My.Settings.HashType = "SHA1" Then
            Width = 480
        Else
            Width = 480
        End If

    End Sub

    Private Sub btnDatei_Click(sender As Object, e As EventArgs) Handles btnDatei.Click

        'Vorhandenen Hash sichern
        If Not txtFileHash.Text = String.Empty Then txtTestHash.Text = txtFileHash.Text

        'Aufräumen
        txtDatei.Text = String.Empty
        txtFileHash.Text = String.Empty
        txtTestHash.BackColor = SystemColors.Window

        'Los geht's
        Dim ofd As New OpenFileDialog
        ofd.Title = "Bitte Datei wählen ..."
        ofd.CheckFileExists = True
        If ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            _file = ofd.FileName
            txtDatei.Text = Helper.fnPathShorten(_file, 55)
            CalcHashForFile()
            If Not txtTestHash.Text = String.Empty Then sbCompare()
        Else
            _file = String.Empty
        End If

    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        txtTestHash.Text = txtFileHash.Text
    End Sub

    Private Sub btnVergleich_Click(sender As Object, e As EventArgs) Handles btnVergleich.Click
        sbCompare()
    End Sub

    Private Sub cmbHA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHA.SelectedIndexChanged

        If My.Settings.HashType = "SHA256" Then
            Width = 625
        ElseIf My.Settings.HashType = "SHA1" Then
            Width = 480
        Else
            Width = 480
        End If

        If Not _file = String.Empty Then CalcHashForFile()
        If Not txtFileHash.Text = String.Empty Then sbCompare()

    End Sub

    Private Sub txtTestHash_TextChanged(sender As Object, e As EventArgs) Handles txtTestHash.TextChanged
        txtTestHash.BackColor = SystemColors.Window
        If Not txtFileHash.Text = String.Empty Then sbCompare()
    End Sub

    Private Function MD5FileHash(ByVal sFile As String) As String

        Dim MD5CSP As New MD5CryptoServiceProvider
        Dim fs As New FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)

        MD5CSP.ComputeHash(fs)
        fs.Close()
        Return BitConverter.ToString(MD5CSP.Hash).Replace("-", "")

    End Function

    Private Function SHA1FileHash(ByVal sFile As String) As String

        Dim SHA1CSP As New SHA1CryptoServiceProvider
        Dim fs As New FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)

        SHA1CSP.ComputeHash(fs)
        fs.Close()
        Return BitConverter.ToString(SHA1CSP.Hash).Replace("-", "")

    End Function

    Private Function SHA256FileHash(ByVal sFile As String) As String

        Dim SHA256CSP As New SHA256CryptoServiceProvider
        Dim fs As New FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)

        SHA256CSP.ComputeHash(fs)
        fs.Close()
        Return BitConverter.ToString(SHA256CSP.Hash).Replace("-", "")

    End Function

    Private Sub CalcHashForFile()

        Select Case cmbHA.Text
            Case "MD5"
                txtFileHash.Text = MD5FileHash(_file)
            Case "SHA1"
                txtFileHash.Text = SHA1FileHash(_file)
            Case "SHA256"
                txtFileHash.Text = SHA256FileHash(_file)
        End Select

        btnCopy.Enabled = True

    End Sub

    Private Sub sbCompare()

        If String.Compare(txtFileHash.Text, txtTestHash.Text, True) = 0 Then
            txtTestHash.BackColor = Color.LightGreen
        Else
            txtTestHash.BackColor = Color.IndianRed
        End If
    End Sub

    Private Sub InstallUpdateSyncWithInfo()

        Dim info As UpdateCheckInfo = Nothing

        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

            Try
                info = AD.CheckForDetailedUpdate()
            Catch dde As DeploymentDownloadException
                MessageBox.Show("The new version of the application cannot be downloaded at this time. " & Environment.NewLine & "Please check your network connection, or try again later. Error: " + dde.Message)
                Return
            Catch ioe As InvalidOperationException
                MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " & ioe.Message)
                Return
            End Try

            If (info.UpdateAvailable) Then
                Dim doUpdate As Boolean = True

                If (Not info.IsUpdateRequired) Then
                    Dim dr As DialogResult = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel)
                    If (Not System.Windows.Forms.DialogResult.OK = dr) Then
                        doUpdate = False
                    End If
                Else
                    ' Display a message that the app MUST reboot. Display the minimum required version.
                    MessageBox.Show("This application has detected a mandatory update from your current " &
                    "version to version " & info.MinimumRequiredVersion.ToString() &
                    ". The application will now install the update and restart.",
                    "Update Available", MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
                End If

                If (doUpdate) Then
                    Try
                        AD.Update()
                        MessageBox.Show("The application has been upgraded, and will now restart.")
                        Application.Restart()
                    Catch dde As DeploymentDownloadException
                        MessageBox.Show("Cannot install the latest version of the application. " & Environment.NewLine & "Please check your network connection, or try again later.")
                        Return
                    End Try
                End If
            End If
        End If
    End Sub
End Class

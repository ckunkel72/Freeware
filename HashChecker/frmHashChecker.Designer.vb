<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHashChecker
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHashChecker))
        Me.btnDatei = New System.Windows.Forms.Button()
        Me.txtDatei = New System.Windows.Forms.TextBox()
        Me.txtFileHash = New System.Windows.Forms.TextBox()
        Me.txtTestHash = New System.Windows.Forms.TextBox()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnVergleich = New System.Windows.Forms.Button()
        Me.cmbHA = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnDatei
        '
        Me.btnDatei.Location = New System.Drawing.Point(12, 37)
        Me.btnDatei.Name = "btnDatei"
        Me.btnDatei.Size = New System.Drawing.Size(154, 23)
        Me.btnDatei.TabIndex = 0
        Me.btnDatei.Text = "Datei wählen"
        Me.btnDatei.UseVisualStyleBackColor = True
        '
        'txtDatei
        '
        Me.txtDatei.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatei.Enabled = False
        Me.txtDatei.Location = New System.Drawing.Point(176, 39)
        Me.txtDatei.Name = "txtDatei"
        Me.txtDatei.Size = New System.Drawing.Size(417, 20)
        Me.txtDatei.TabIndex = 1
        '
        'txtFileHash
        '
        Me.txtFileHash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileHash.Enabled = False
        Me.txtFileHash.Location = New System.Drawing.Point(176, 68)
        Me.txtFileHash.Name = "txtFileHash"
        Me.txtFileHash.Size = New System.Drawing.Size(417, 20)
        Me.txtFileHash.TabIndex = 2
        '
        'txtTestHash
        '
        Me.txtTestHash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTestHash.Location = New System.Drawing.Point(176, 97)
        Me.txtTestHash.Name = "txtTestHash"
        Me.txtTestHash.Size = New System.Drawing.Size(417, 20)
        Me.txtTestHash.TabIndex = 3
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(12, 66)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(154, 23)
        Me.btnCopy.TabIndex = 7
        Me.btnCopy.Text = "Hash-Wert kopieren"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'btnVergleich
        '
        Me.btnVergleich.Location = New System.Drawing.Point(12, 95)
        Me.btnVergleich.Name = "btnVergleich"
        Me.btnVergleich.Size = New System.Drawing.Size(154, 23)
        Me.btnVergleich.TabIndex = 8
        Me.btnVergleich.Text = "Hash-Werte vergleichen"
        Me.btnVergleich.UseVisualStyleBackColor = True
        '
        'cmbHA
        '
        Me.cmbHA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.HashChecker.My.MySettings.Default, "HashType", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cmbHA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHA.FormattingEnabled = True
        Me.cmbHA.Items.AddRange(New Object() {"MD5", "SHA1", "SHA256"})
        Me.cmbHA.Location = New System.Drawing.Point(176, 12)
        Me.cmbHA.Name = "cmbHA"
        Me.cmbHA.Size = New System.Drawing.Size(101, 21)
        Me.cmbHA.TabIndex = 9
        Me.cmbHA.Text = Global.HashChecker.My.MySettings.Default.HashType
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Hash Algorithmus"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmHashChecker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 131)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbHA)
        Me.Controls.Add(Me.btnVergleich)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.txtTestHash)
        Me.Controls.Add(Me.txtFileHash)
        Me.Controls.Add(Me.txtDatei)
        Me.Controls.Add(Me.btnDatei)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.HashChecker.My.MySettings.Default, "WindowPos", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = Global.HashChecker.My.MySettings.Default.WindowPos
        Me.Name = "frmHashChecker"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDatei As System.Windows.Forms.Button
    Friend WithEvents txtDatei As System.Windows.Forms.TextBox
    Friend WithEvents txtFileHash As System.Windows.Forms.TextBox
    Friend WithEvents txtTestHash As System.Windows.Forms.TextBox
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents btnVergleich As System.Windows.Forms.Button
    Friend WithEvents cmbHA As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

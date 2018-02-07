<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.PositionLabel = New System.Windows.Forms.Label()
        Me.XBox = New System.Windows.Forms.TextBox()
        Me.YBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ScriptButton = New System.Windows.Forms.Button()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OuvrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnregistrerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnregistrerSousToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox
        '
        Me.PictureBox.BackColor = System.Drawing.Color.Beige
        Me.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox.Location = New System.Drawing.Point(12, 104)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(1141, 792)
        Me.PictureBox.TabIndex = 0
        Me.PictureBox.TabStop = False
        '
        'PositionLabel
        '
        Me.PositionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PositionLabel.Location = New System.Drawing.Point(12, 35)
        Me.PositionLabel.Name = "PositionLabel"
        Me.PositionLabel.Size = New System.Drawing.Size(205, 63)
        Me.PositionLabel.TabIndex = 1
        Me.PositionLabel.Text = "X:Y"
        Me.PositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'XBox
        '
        Me.XBox.Location = New System.Drawing.Point(297, 76)
        Me.XBox.Name = "XBox"
        Me.XBox.Size = New System.Drawing.Size(100, 22)
        Me.XBox.TabIndex = 2
        Me.XBox.Text = "0"
        Me.XBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'YBox
        '
        Me.YBox.Location = New System.Drawing.Point(403, 76)
        Me.YBox.Name = "YBox"
        Me.YBox.Size = New System.Drawing.Size(100, 22)
        Me.YBox.TabIndex = 3
        Me.YBox.Text = "0"
        Me.YBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(297, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(206, 38)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Position du carrée vert :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ScriptButton
        '
        Me.ScriptButton.Location = New System.Drawing.Point(1001, 35)
        Me.ScriptButton.Name = "ScriptButton"
        Me.ScriptButton.Size = New System.Drawing.Size(152, 63)
        Me.ScriptButton.TabIndex = 5
        Me.ScriptButton.Text = "Générer le script"
        Me.ScriptButton.UseVisualStyleBackColor = True
        '
        'MenuStrip
        '
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichierToolStripMenuItem, Me.AideToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1165, 28)
        Me.MenuStrip.TabIndex = 6
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OuvrirToolStripMenuItem, Me.EnregistrerToolStripMenuItem, Me.EnregistrerSousToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        Me.FichierToolStripMenuItem.Size = New System.Drawing.Size(64, 24)
        Me.FichierToolStripMenuItem.Text = "Fichier"
        '
        'OuvrirToolStripMenuItem
        '
        Me.OuvrirToolStripMenuItem.Name = "OuvrirToolStripMenuItem"
        Me.OuvrirToolStripMenuItem.Size = New System.Drawing.Size(188, 26)
        Me.OuvrirToolStripMenuItem.Text = "Ouvrir"
        '
        'EnregistrerToolStripMenuItem
        '
        Me.EnregistrerToolStripMenuItem.Name = "EnregistrerToolStripMenuItem"
        Me.EnregistrerToolStripMenuItem.Size = New System.Drawing.Size(188, 26)
        Me.EnregistrerToolStripMenuItem.Text = "Enregistrer"
        '
        'EnregistrerSousToolStripMenuItem
        '
        Me.EnregistrerSousToolStripMenuItem.Name = "EnregistrerSousToolStripMenuItem"
        Me.EnregistrerSousToolStripMenuItem.Size = New System.Drawing.Size(188, 26)
        Me.EnregistrerSousToolStripMenuItem.Text = "Enregistrer sous"
        '
        'AideToolStripMenuItem
        '
        Me.AideToolStripMenuItem.Name = "AideToolStripMenuItem"
        Me.AideToolStripMenuItem.Size = New System.Drawing.Size(52, 24)
        Me.AideToolStripMenuItem.Text = "Aide"
        '
        'TextBox
        '
        Me.TextBox.Location = New System.Drawing.Point(509, 76)
        Me.TextBox.Name = "TextBox"
        Me.TextBox.Size = New System.Drawing.Size(486, 22)
        Me.TextBox.TabIndex = 7
        Me.TextBox.Text = "Grille.Ajoute_Vertex(%C, New Point(%X, %Y), Mondes.Normal)"
        Me.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(509, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(486, 38)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Ligne de script à générer (""%X"" sera remplacé par la valeur en X, ""%Y"" sera rempl" &
    "acé par la valeur en Y)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1165, 908)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox)
        Me.Controls.Add(Me.ScriptButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.YBox)
        Me.Controls.Add(Me.XBox)
        Me.Controls.Add(Me.PositionLabel)
        Me.Controls.Add(Me.PictureBox)
        Me.Controls.Add(Me.MenuStrip)
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox As PictureBox
    Friend WithEvents PositionLabel As Label
    Friend WithEvents XBox As TextBox
    Friend WithEvents YBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ScriptButton As Button
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents FichierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OuvrirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnregistrerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnregistrerSousToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents AideToolStripMenuItem As ToolStripMenuItem
End Class

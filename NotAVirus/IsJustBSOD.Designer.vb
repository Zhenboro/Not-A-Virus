<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IsJustBSOD
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbl_Icon = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbl_ErrorInfo = New System.Windows.Forms.Label()
        Me.lbl_Information = New System.Windows.Forms.Label()
        Me.lbl_Title = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Icon
        '
        Me.lbl_Icon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Icon.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Icon.Font = New System.Drawing.Font("Ebrima", 120.0!)
        Me.lbl_Icon.ForeColor = System.Drawing.Color.White
        Me.lbl_Icon.Location = New System.Drawing.Point(3, 0)
        Me.lbl_Icon.Name = "lbl_Icon"
        Me.lbl_Icon.Size = New System.Drawing.Size(1040, 212)
        Me.lbl_Icon.TabIndex = 0
        Me.lbl_Icon.Text = ":("
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.lbl_Status)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.lbl_Title)
        Me.Panel1.Controls.Add(Me.lbl_Icon)
        Me.Panel1.Location = New System.Drawing.Point(114, 131)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1046, 582)
        Me.Panel1.TabIndex = 1
        '
        'lbl_Status
        '
        Me.lbl_Status.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Status.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status.ForeColor = System.Drawing.Color.White
        Me.lbl_Status.Location = New System.Drawing.Point(39, 331)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(1004, 79)
        Me.lbl_Status.TabIndex = 6
        Me.lbl_Status.Text = "0% complete"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.lbl_ErrorInfo)
        Me.Panel2.Controls.Add(Me.lbl_Information)
        Me.Panel2.Location = New System.Drawing.Point(3, 413)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1040, 166)
        Me.Panel2.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(43, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(110, 110)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'lbl_ErrorInfo
        '
        Me.lbl_ErrorInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_ErrorInfo.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ErrorInfo.ForeColor = System.Drawing.Color.White
        Me.lbl_ErrorInfo.Location = New System.Drawing.Point(159, 51)
        Me.lbl_ErrorInfo.Name = "lbl_ErrorInfo"
        Me.lbl_ErrorInfo.Size = New System.Drawing.Size(878, 76)
        Me.lbl_ErrorInfo.TabIndex = 4
        Me.lbl_ErrorInfo.Text = "If you call a support person, give them this info:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Stop code: PAGE_FAULT_IN_NONP" &
    "AGED_AREA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "What failed: portcls.sys"
        Me.lbl_ErrorInfo.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lbl_Information
        '
        Me.lbl_Information.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Information.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Information.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Information.ForeColor = System.Drawing.Color.White
        Me.lbl_Information.Location = New System.Drawing.Point(159, 0)
        Me.lbl_Information.Name = "lbl_Information"
        Me.lbl_Information.Size = New System.Drawing.Size(878, 51)
        Me.lbl_Information.TabIndex = 3
        Me.lbl_Information.Text = "For more information about this issue and possible fixes, visit https://www.windo" &
    "ws.com/stopcode"
        '
        'lbl_Title
        '
        Me.lbl_Title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Title.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Title.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Title.ForeColor = System.Drawing.Color.White
        Me.lbl_Title.Location = New System.Drawing.Point(39, 212)
        Me.lbl_Title.Name = "lbl_Title"
        Me.lbl_Title.Size = New System.Drawing.Size(1004, 119)
        Me.lbl_Title.TabIndex = 1
        Me.lbl_Title.Text = "Your PC ran into a problem and needs to restart. We're just collecting some error" &
    " info, and then we'll restart for you."
        '
        'IsJustBSOD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1275, 845)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IsJustBSOD"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IsJustBSOD"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lbl_Icon As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbl_Title As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lbl_Information As Label
    Friend WithEvents lbl_ErrorInfo As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lbl_Status As Label
End Class

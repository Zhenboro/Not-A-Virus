<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ItsASimpleQuestion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btn_Yes = New System.Windows.Forms.Button()
        Me.btn_No = New System.Windows.Forms.Button()
        Me.lbl_Question = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn_Yes
        '
        Me.btn_Yes.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_Yes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Yes.Location = New System.Drawing.Point(119, 439)
        Me.btn_Yes.Name = "btn_Yes"
        Me.btn_Yes.Size = New System.Drawing.Size(110, 40)
        Me.btn_Yes.TabIndex = 0
        Me.btn_Yes.Text = "Yes"
        Me.btn_Yes.UseVisualStyleBackColor = True
        '
        'btn_No
        '
        Me.btn_No.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_No.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_No.Location = New System.Drawing.Point(286, 439)
        Me.btn_No.Name = "btn_No"
        Me.btn_No.Size = New System.Drawing.Size(110, 40)
        Me.btn_No.TabIndex = 1
        Me.btn_No.Text = "No"
        Me.btn_No.UseVisualStyleBackColor = True
        '
        'lbl_Question
        '
        Me.lbl_Question.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Question.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Question.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Question.Location = New System.Drawing.Point(12, 9)
        Me.lbl_Question.Name = "lbl_Question"
        Me.lbl_Question.Size = New System.Drawing.Size(490, 427)
        Me.lbl_Question.TabIndex = 2
        Me.lbl_Question.Text = "Are u dumb?"
        Me.lbl_Question.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 399)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(490, 37)
        Me.Label1.TabIndex = 3
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ItsASimpleQuestion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 491)
        Me.Controls.Add(Me.btn_No)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Yes)
        Me.Controls.Add(Me.lbl_Question)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ItsASimpleQuestion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ItsASimpleQuestion"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_Yes As Button
    Friend WithEvents btn_No As Button
    Friend WithEvents lbl_Question As Label
    Friend WithEvents Label1 As Label
End Class

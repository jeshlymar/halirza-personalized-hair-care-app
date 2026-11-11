<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HalirzaQuestionnaire
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        grpbxQuestionnaire = New GroupBox()
        lblThankYou = New Label()
        btnSubmit = New Button()
        btnStart = New Button()
        lblWelcome = New Label()
        lblOther = New Label()
        txtbxOther = New TextBox()
        btnNext = New Button()
        rdiobxOptionFour = New RadioButton()
        rdiobxOptionThree = New RadioButton()
        rdiobxOptionTwo = New RadioButton()
        rdiobxOptionOne = New RadioButton()
        btnShopping = New Button()
        grpbxQuestionnaire.SuspendLayout()
        SuspendLayout()
        ' 
        ' grpbxQuestionnaire
        ' 
        grpbxQuestionnaire.BackColor = Color.Azure
        grpbxQuestionnaire.Controls.Add(lblThankYou)
        grpbxQuestionnaire.Controls.Add(btnSubmit)
        grpbxQuestionnaire.Controls.Add(btnStart)
        grpbxQuestionnaire.Controls.Add(lblWelcome)
        grpbxQuestionnaire.Controls.Add(lblOther)
        grpbxQuestionnaire.Controls.Add(txtbxOther)
        grpbxQuestionnaire.Controls.Add(btnNext)
        grpbxQuestionnaire.Controls.Add(rdiobxOptionFour)
        grpbxQuestionnaire.Controls.Add(rdiobxOptionThree)
        grpbxQuestionnaire.Controls.Add(rdiobxOptionTwo)
        grpbxQuestionnaire.Controls.Add(rdiobxOptionOne)
        grpbxQuestionnaire.Font = New Font("Segoe Script", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpbxQuestionnaire.Location = New Point(217, 106)
        grpbxQuestionnaire.Margin = New Padding(4)
        grpbxQuestionnaire.Name = "grpbxQuestionnaire"
        grpbxQuestionnaire.Padding = New Padding(4)
        grpbxQuestionnaire.Size = New Size(545, 293)
        grpbxQuestionnaire.TabIndex = 0
        grpbxQuestionnaire.TabStop = False
        grpbxQuestionnaire.Text = "Hair Type And Texture: What Is Your Natural Hair Type?"
        ' 
        ' lblThankYou
        ' 
        lblThankYou.BackColor = Color.LightBlue
        lblThankYou.Location = New Point(0, 0)
        lblThankYou.Name = "lblThankYou"
        lblThankYou.Size = New Size(545, 293)
        lblThankYou.TabIndex = 1
        lblThankYou.Text = "Thank You For Taking The Halirza Hair Test!" & vbCrLf & vbCrLf & "You Will Now Be Redirected To A Form To Browse Hair Products!" & vbCrLf
        lblThankYou.TextAlign = ContentAlignment.MiddleCenter
        lblThankYou.Visible = False
        ' 
        ' btnSubmit
        ' 
        btnSubmit.Location = New Point(227, 245)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.Size = New Size(106, 41)
        btnSubmit.TabIndex = 10
        btnSubmit.Text = "Submit"
        btnSubmit.UseVisualStyleBackColor = True
        btnSubmit.Visible = False
        ' 
        ' btnStart
        ' 
        btnStart.BackColor = Color.PowderBlue
        btnStart.Location = New Point(211, 131)
        btnStart.Name = "btnStart"
        btnStart.Size = New Size(134, 56)
        btnStart.TabIndex = 9
        btnStart.Text = "Start"
        btnStart.UseVisualStyleBackColor = False
        ' 
        ' lblWelcome
        ' 
        lblWelcome.BackColor = Color.LightBlue
        lblWelcome.Font = New Font("Segoe Script", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblWelcome.Location = New Point(0, 0)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(545, 293)
        lblWelcome.TabIndex = 8
        lblWelcome.Text = "Welcome To Halirza"
        lblWelcome.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lblOther
        ' 
        lblOther.AutoSize = True
        lblOther.Location = New Point(263, 74)
        lblOther.Name = "lblOther"
        lblOther.Size = New Size(70, 31)
        lblOther.TabIndex = 6
        lblOther.Text = "Other"
        ' 
        ' txtbxOther
        ' 
        txtbxOther.Location = New Point(360, 73)
        txtbxOther.Name = "txtbxOther"
        txtbxOther.Size = New Size(100, 38)
        txtbxOther.TabIndex = 5
        ' 
        ' btnNext
        ' 
        btnNext.Location = New Point(211, 245)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(106, 41)
        btnNext.TabIndex = 4
        btnNext.Text = "Next"
        btnNext.UseVisualStyleBackColor = True
        ' 
        ' rdiobxOptionFour
        ' 
        rdiobxOptionFour.AutoSize = True
        rdiobxOptionFour.Location = New Point(17, 193)
        rdiobxOptionFour.Name = "rdiobxOptionFour"
        rdiobxOptionFour.Size = New Size(85, 35)
        rdiobxOptionFour.TabIndex = 3
        rdiobxOptionFour.TabStop = True
        rdiobxOptionFour.Text = "Coily"
        rdiobxOptionFour.UseVisualStyleBackColor = True
        ' 
        ' rdiobxOptionThree
        ' 
        rdiobxOptionThree.AutoSize = True
        rdiobxOptionThree.Location = New Point(17, 152)
        rdiobxOptionThree.Name = "rdiobxOptionThree"
        rdiobxOptionThree.Size = New Size(88, 35)
        rdiobxOptionThree.TabIndex = 2
        rdiobxOptionThree.TabStop = True
        rdiobxOptionThree.Text = "Curly"
        rdiobxOptionThree.UseVisualStyleBackColor = True
        ' 
        ' rdiobxOptionTwo
        ' 
        rdiobxOptionTwo.AutoSize = True
        rdiobxOptionTwo.Location = New Point(17, 111)
        rdiobxOptionTwo.Name = "rdiobxOptionTwo"
        rdiobxOptionTwo.Size = New Size(86, 35)
        rdiobxOptionTwo.TabIndex = 1
        rdiobxOptionTwo.TabStop = True
        rdiobxOptionTwo.Text = "Wavy"
        rdiobxOptionTwo.UseVisualStyleBackColor = True
        ' 
        ' rdiobxOptionOne
        ' 
        rdiobxOptionOne.AutoSize = True
        rdiobxOptionOne.Location = New Point(17, 70)
        rdiobxOptionOne.Name = "rdiobxOptionOne"
        rdiobxOptionOne.Size = New Size(120, 35)
        rdiobxOptionOne.TabIndex = 0
        rdiobxOptionOne.TabStop = True
        rdiobxOptionOne.Text = "Straight"
        rdiobxOptionOne.UseVisualStyleBackColor = True
        ' 
        ' btnShopping
        ' 
        btnShopping.BackColor = Color.PowderBlue
        btnShopping.Font = New Font("Segoe Script", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnShopping.Location = New Point(428, 436)
        btnShopping.Name = "btnShopping"
        btnShopping.Size = New Size(106, 41)
        btnShopping.TabIndex = 1
        btnShopping.Text = "Proceed To Shopping"
        btnShopping.UseVisualStyleBackColor = False
        btnShopping.Visible = False
        ' 
        ' HalirzaQuestionnaire
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(1000, 591)
        Controls.Add(btnShopping)
        Controls.Add(grpbxQuestionnaire)
        Font = New Font("Segoe Script", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Margin = New Padding(4)
        Name = "HalirzaQuestionnaire"
        Text = "Halirza Questionnaire"
        grpbxQuestionnaire.ResumeLayout(False)
        grpbxQuestionnaire.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents grpbxQuestionnaire As GroupBox
    Friend WithEvents rdiobxOptionTwo As RadioButton
    Friend WithEvents rdiobxOptionOne As RadioButton
    Friend WithEvents rdiobxOptionThree As RadioButton
    Friend WithEvents lblOther As Label
    Friend WithEvents txtbxOther As TextBox
    Friend WithEvents btnNext As Button
    Friend WithEvents rdiobxOptionFour As RadioButton
    Friend WithEvents lblWelcome As Label
    Friend WithEvents btnStart As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents lblThankYou As Label
    Friend WithEvents btnShopping As Button

End Class

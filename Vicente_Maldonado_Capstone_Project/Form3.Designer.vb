<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HalirzaCheckout
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        lblPoints = New Label()
        pnlCartList = New Panel()
        SuspendLayout()
        ' 
        ' lblPoints
        ' 
        lblPoints.AutoSize = True
        lblPoints.Location = New Point(617, 239)
        lblPoints.Name = "lblPoints"
        lblPoints.Size = New Size(49, 19)
        lblPoints.TabIndex = 0
        lblPoints.Text = "Label1"
        ' 
        ' pnlCartList
        ' 
        pnlCartList.Location = New Point(12, 12)
        pnlCartList.Name = "pnlCartList"
        pnlCartList.Size = New Size(698, 483)
        pnlCartList.TabIndex = 1
        ' 
        ' HalirzaCheckout
        ' 
        AutoScaleDimensions = New SizeF(8F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1000, 591)
        Controls.Add(pnlCartList)
        Controls.Add(lblPoints)
        Name = "HalirzaCheckout"
        Text = "Halirza Checkout"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents lblPoints As Label
    Friend WithEvents pnlCartList As Panel
End Class

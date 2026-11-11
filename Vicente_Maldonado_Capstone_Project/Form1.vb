Imports System.IO

Public Class HalirzaQuestionnaire


    'Empty strings for questions in the test
    Dim hairType As String = ""
    Dim curlPattern As String = ""
    Dim hairTexture As String = ""
    Dim hairThickness As String = ""
    Dim hairConcerns As String = ""
    Dim heatTools As String = ""
    Dim scalpIssues As String = ""
    Dim hairGoals As String = ""

    'Save the users response to the variables above based on the question and which box is checked
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        btnNext.Visible = True
        If grpbxQuestionnaire.Text = "Hair Type And Texture: What Is Your Natural Hair Type?" Then
            If Not (rdiobxOptionOne.Checked Or rdiobxOptionTwo.Checked Or rdiobxOptionThree.Checked Or rdiobxOptionFour.Checked Or txtbxOther.Text <> "") Then
                MessageBox.Show("Please select or enter an option before continuing.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If rdiobxOptionOne.Checked Then
                hairType = rdiobxOptionOne.Text
            ElseIf rdiobxOptionTwo.Checked Then
                hairType = rdiobxOptionTwo.Text
            ElseIf rdiobxOptionThree.Checked Then
                hairType = rdiobxOptionThree.Text
            ElseIf rdiobxOptionFour.Checked Then
                hairType = rdiobxOptionFour.Text
            Else
                hairType = txtbxOther.Text
            End If
            HalirzaShopping.UserHairType = hairType
            grpbxQuestionnaire.Text = "Hair Type And Texture: What Is Your Hair's Curl Pattern?"
            rdiobxOptionOne.Text = "3A"
            rdiobxOptionTwo.Text = "3B"
            rdiobxOptionThree.Text = "4A"
            rdiobxOptionFour.Text = "4B"
            txtbxOther.Clear()
            rdiobxOptionOne.Checked = False
            rdiobxOptionTwo.Checked = False
            rdiobxOptionThree.Checked = False
            rdiobxOptionFour.Checked = False
        ElseIf grpbxQuestionnaire.Text = "Hair Type And Texture: What Is Your Hair's Curl Pattern?" Then
            If Not (rdiobxOptionOne.Checked Or rdiobxOptionTwo.Checked Or rdiobxOptionThree.Checked Or rdiobxOptionFour.Checked Or txtbxOther.Text <> "") Then
                MessageBox.Show("Please select or enter an option before continuing.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If rdiobxOptionOne.Checked Then
                curlPattern = rdiobxOptionOne.Text
            ElseIf rdiobxOptionTwo.Checked Then
                curlPattern = rdiobxOptionTwo.Text
            ElseIf rdiobxOptionThree.Checked Then
                curlPattern = rdiobxOptionThree.Text
            ElseIf rdiobxOptionFour.Checked Then
                curlPattern = rdiobxOptionFour.Text
            Else
                curlPattern = txtbxOther.Text
            End If
            HalirzaShopping.UserCurlPattern = curlPattern
            grpbxQuestionnaire.Text = "Hair Type And Texture: How Would You Describe Your Hair's Texture?"
            rdiobxOptionOne.Text = "Fine"
            rdiobxOptionTwo.Text = "Medium"
            rdiobxOptionThree.Text = "Coarse"
            rdiobxOptionFour.Visible = False
            txtbxOther.Clear()
            rdiobxOptionOne.Checked = False
            rdiobxOptionTwo.Checked = False
            rdiobxOptionThree.Checked = False
            rdiobxOptionFour.Checked = False
        ElseIf grpbxQuestionnaire.Text = "Hair Type And Texture: How Would You Describe Your Hair's Texture?" Then
            If Not (rdiobxOptionOne.Checked Or rdiobxOptionTwo.Checked Or rdiobxOptionThree.Checked Or rdiobxOptionFour.Checked Or txtbxOther.Text <> "") Then
                MessageBox.Show("Please select or enter an option before continuing.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If rdiobxOptionOne.Checked Then
                hairTexture = rdiobxOptionOne.Text
            ElseIf rdiobxOptionTwo.Checked Then
                hairTexture = rdiobxOptionTwo.Text
            ElseIf rdiobxOptionThree.Checked Then
                hairTexture = rdiobxOptionThree.Text
            Else
                hairTexture = txtbxOther.Text
            End If
            HalirzaShopping.UserHairTexture = hairTexture

            grpbxQuestionnaire.Text = "Hair Type And Texture: What Is Your Hair's Thickness?"
            rdiobxOptionOne.Text = "Fine"
            rdiobxOptionTwo.Text = "Medium"
            rdiobxOptionThree.Text = "Thick"
            rdiobxOptionFour.Visible = False
            txtbxOther.Clear()
            rdiobxOptionOne.Checked = False
            rdiobxOptionTwo.Checked = False
            rdiobxOptionThree.Checked = False
        ElseIf grpbxQuestionnaire.Text = "Hair Type And Texture: What Is Your Hair's Thickness?" Then
            If Not (rdiobxOptionOne.Checked Or rdiobxOptionTwo.Checked Or rdiobxOptionThree.Checked Or rdiobxOptionFour.Checked Or txtbxOther.Text <> "") Then
                MessageBox.Show("Please select or enter an option before continuing.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If rdiobxOptionOne.Checked Then
                hairThickness = rdiobxOptionOne.Text
            ElseIf rdiobxOptionTwo.Checked Then
                hairThickness = rdiobxOptionTwo.Text
            ElseIf rdiobxOptionThree.Checked Then
                hairThickness = rdiobxOptionThree.Text
            Else
                hairThickness = txtbxOther.Text
            End If
            HalirzaShopping.UserHairThickness = hairThickness

            grpbxQuestionnaire.Text = "Hair Concerns And Problems: What Are Your Biggest Hair Concerns Or Problems?"
            rdiobxOptionOne.Text = "Frizz"
            rdiobxOptionTwo.Text = "Dryness"
            rdiobxOptionThree.Text = "Breakage"
            rdiobxOptionFour.Text = "Lack of Volume"
            rdiobxOptionFour.Visible = True
            txtbxOther.Clear()
            rdiobxOptionOne.Checked = False
            rdiobxOptionTwo.Checked = False
            rdiobxOptionThree.Checked = False
            rdiobxOptionFour.Checked = False
        ElseIf grpbxQuestionnaire.Text = "Hair Concerns And Problems: What Are Your Biggest Hair Concerns Or Problems?" Then
            If Not (rdiobxOptionOne.Checked Or rdiobxOptionTwo.Checked Or rdiobxOptionThree.Checked Or rdiobxOptionFour.Checked Or txtbxOther.Text <> "") Then
                MessageBox.Show("Please select or enter an option before continuing.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If rdiobxOptionOne.Checked Then
                hairConcerns = rdiobxOptionOne.Text
            ElseIf rdiobxOptionTwo.Checked Then
                hairConcerns = rdiobxOptionTwo.Text
            ElseIf rdiobxOptionThree.Checked Then
                hairConcerns = rdiobxOptionThree.Text
            ElseIf rdiobxOptionFour.Checked Then
                hairConcerns = rdiobxOptionFour.Text
            Else
                hairConcerns = txtbxOther.Text
            End If
            HalirzaShopping.UserHairConcerns = hairConcerns

            grpbxQuestionnaire.Text = "Hair Concerns And Problems: Do You Use Any Heat Styling Tools?"
            rdiobxOptionOne.Text = "Yes"
            rdiobxOptionTwo.Text = "No"
            rdiobxOptionThree.Visible = False
            rdiobxOptionFour.Visible = False
            txtbxOther.Clear()
            rdiobxOptionOne.Checked = False
            rdiobxOptionTwo.Checked = False
            rdiobxOptionThree.Checked = False
            rdiobxOptionFour.Checked = False
        ElseIf grpbxQuestionnaire.Text = "Hair Concerns And Problems: Do You Use Any Heat Styling Tools?" Then
            If Not (rdiobxOptionOne.Checked Or rdiobxOptionTwo.Checked Or rdiobxOptionThree.Checked Or rdiobxOptionFour.Checked Or txtbxOther.Text <> "") Then
                MessageBox.Show("Please select or enter an option before continuing.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If rdiobxOptionOne.Checked Then
                heatTools = rdiobxOptionOne.Text
            ElseIf rdiobxOptionTwo.Checked Then
                heatTools = rdiobxOptionTwo.Text
            Else
                heatTools = txtbxOther.Text
            End If
            HalirzaShopping.UserHeatTools = heatTools

            grpbxQuestionnaire.Text = "Hair Concerns And Problems: Do You Have Any Scalp Issues?"
            rdiobxOptionOne.Text = "Dryness"
            rdiobxOptionTwo.Text = "Itchiness"
            rdiobxOptionThree.Visible = True
            rdiobxOptionThree.Text = "Flakiness"
            rdiobxOptionFour.Visible = False
            txtbxOther.Clear()
            rdiobxOptionOne.Checked = False
            rdiobxOptionTwo.Checked = False
            rdiobxOptionThree.Checked = False
            rdiobxOptionFour.Checked = False
        ElseIf grpbxQuestionnaire.Text = "Hair Concerns And Problems: Do You Have Any Scalp Issues?" Then
            If Not (rdiobxOptionOne.Checked Or rdiobxOptionTwo.Checked Or rdiobxOptionThree.Checked Or rdiobxOptionFour.Checked Or txtbxOther.Text <> "") Then
                MessageBox.Show("Please select or enter an option before continuing.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If rdiobxOptionOne.Checked Then
                scalpIssues = rdiobxOptionOne.Text
            ElseIf rdiobxOptionTwo.Checked Then
                scalpIssues = rdiobxOptionTwo.Text
            ElseIf rdiobxOptionThree.Checked Then
                scalpIssues = rdiobxOptionThree.Text
            Else
                scalpIssues = txtbxOther.Text
            End If
            HalirzaShopping.UserScalpIssues = scalpIssues
            grpbxQuestionnaire.Text = "Lifestyle And Habits: What Are Your Hair Goals?"
            rdiobxOptionOne.Text = "Longer Hair"
            rdiobxOptionTwo.Text = "Healthier Hair"
            rdiobxOptionThree.Text = "Curl Definition"
            rdiobxOptionFour.Visible = True
            rdiobxOptionFour.Text = "Volume"
            btnNext.Visible = False
            btnSubmit.Visible = True
            txtbxOther.Clear()
            rdiobxOptionOne.Checked = False
            rdiobxOptionTwo.Checked = False
            rdiobxOptionThree.Checked = False
            rdiobxOptionFour.Checked = False
        ElseIf grpbxQuestionnaire.Text = "Lifestyle And Habits: What Are Your Hair Goals?" Then
            If Not (rdiobxOptionOne.Checked Or rdiobxOptionTwo.Checked Or rdiobxOptionThree.Checked Or rdiobxOptionFour.Checked Or txtbxOther.Text <> "") Then
                MessageBox.Show("Please select or enter an option before continuing.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If rdiobxOptionOne.Checked Then
                hairGoals = rdiobxOptionOne.Text
            ElseIf rdiobxOptionTwo.Checked Then
                hairGoals = rdiobxOptionTwo.Text
            ElseIf rdiobxOptionThree.Checked Then
                hairGoals = rdiobxOptionThree.Text
            ElseIf rdiobxOptionFour.Checked Then
                hairGoals = rdiobxOptionFour.Text
            Else
                hairGoals = txtbxOther.Text
            End If
            HalirzaShopping.UserHairGoals = hairGoals

        End If
        'Add all of the user responses to a file
        AppPaths.EnsureDataDirectory()
        Dim content As String = $"Hair Type: {hairType}, Curl Pattern: {curlPattern}, Hair Texture: {hairTexture}, Hair Thickness: {hairThickness}, Hair Concerns: {hairConcerns}, Heat Tools: {heatTools}, Scalp Issues: {scalpIssues}, Hair Goals: {hairGoals}"
        File.WriteAllText(AppPaths.GoalsFile, content)


    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        lblWelcome.Visible = False
        btnStart.Visible = False
        grpbxQuestionnaire.Visible = True
        grpbxQuestionnaire.Text = "Hair Type And Texture: What Is Your Natural Hair Type?"
        btnNext.Visible = True

    End Sub

    'Load the form
    Private Sub HalirzaQuestionnaire_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

    End Sub

    'Hide the submit and next button and show the thank you message along with the button to proceed to the shopping form
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        btnSubmit.Visible = False
        btnNext.Visible = False
        lblThankYou.Visible = True
        btnShopping.Visible = True

    End Sub

    'Hide the questionnair and take the user to the shopping form
    Private Sub btnShopping_Click(sender As Object, e As EventArgs) Handles btnShopping.Click
        lblWelcome.Visible = True
        btnStart.Visible = True
        Me.Visible = False
        lblThankYou.Visible = False
        btnShopping.Visible = False
        HalirzaShopping.Visible = True
    End Sub

End Class

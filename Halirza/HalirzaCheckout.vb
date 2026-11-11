Imports System.IO
Imports System.Linq

Public Class HalirzaCheckout
    Private cartItems As New List(Of CartItem)

    Private ReadOnly cartPath As String = AppPaths.CartFile
    Private ReadOnly pointsPath As String = AppPaths.PointsFile
    Private lblTotal As New Label()
    Private btnPlaceOrder As New Button()
    Private userPoints As Integer

    'Create the total, points and place order labels and buttons
    Private Sub HalirzaCheckout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AppPaths.EnsureDataDirectory()
        pnlCartList.AutoScroll = True
        Me.Controls.Add(pnlCartList)

        lblTotal.Font = New Font("Tahoma", 20, FontStyle.Bold)
        lblTotal.Location = New Point(710, 65)
        lblTotal.Width = 300
        lblTotal.AutoSize = False
        lblTotal.Height = 300
        Me.Controls.Add(lblTotal)

        lblPoints.Font = New Font("Tahoma", 18, FontStyle.Bold)
        lblPoints.Location = New Point(710, 400)
        lblPoints.Width = 300
        Me.Controls.Add(lblPoints)

        btnPlaceOrder.Text = "Place Order"
        btnPlaceOrder.Location = New Point(710, 450)
        btnPlaceOrder.Width = 120
        AddHandler btnPlaceOrder.Click, AddressOf PlaceOrder
        Me.Controls.Add(btnPlaceOrder)
        LoadUserPoints()
        LoadCart()
        DisplayCart()
        UpdateTotals()


    End Sub

    'Read from the file and assign the user points
    Private Sub LoadUserPoints()
        If IO.File.Exists(pointsPath) Then
            Dim pointsStr = IO.File.ReadAllText(pointsPath)
            If Not Integer.TryParse(pointsStr, Globalization.NumberStyles.Integer, Globalization.CultureInfo.InvariantCulture, userPoints) OrElse userPoints < 0 Then
                userPoints = 0
            End If
        Else
            userPoints = 0
        End If
    End Sub

    'Read from the file and place the information from the file into a list
    Private Sub LoadCart()
        'cartItems.Clear()

        If IO.File.Exists(cartPath) Then
            Dim lines() As String = IO.File.ReadAllLines(cartPath)

            For Each line In lines
                Dim parts() As String = line.Split("|"c)
                If parts.Length >= 6 Then
                    Dim parsedPrice As Decimal
                    Dim parsedQuantity As Integer
                    Dim parsedStock As Integer
                    If Decimal.TryParse(parts(3), Globalization.NumberStyles.Number, Globalization.CultureInfo.InvariantCulture, parsedPrice) AndAlso
                       Integer.TryParse(parts(4), parsedQuantity) AndAlso
                       Integer.TryParse(parts(5), parsedStock) Then
                        cartItems.Add(New CartItem With {
                            .Title = parts(0),
                            .Description = parts(1),
                            .ImagePath = AppPaths.GetProductImage(parts(2)),
                            .Price = parsedPrice,
                            .Quantity = parsedQuantity,
                            .Stock = parsedStock
                        })
                    End If
                End If
            Next
        End If
    End Sub
    'Read from the file and for each product in the cart create a panel and add the product information
    Private Sub DisplayCart()
        pnlCartList.Controls.Clear()
        Dim yOffset As Integer = 10

        For Each item In cartItems
            Dim productPanel As New Panel With {
                .Width = pnlCartList.Width - 40,
                .Height = 180,
                .Left = 10,
                .Top = yOffset,
                .BorderStyle = BorderStyle.FixedSingle
            }

            ' Title
            Dim lblTitle As New Label With {
                .Text = item.Title,
                .Font = New Font("Segoe UI", 12, FontStyle.Bold),
                .Top = 10,
                .Left = 120,
                .AutoSize = True
            }

            ' Description
            Dim lblDesc As New Label With {
                .Text = item.Description,
                .Left = 120,
                .Top = 40,
                .Width = 500,
                .Height = 100
            }

            ' Image
            Dim pic As New PictureBox With {
            .Image = Image.FromFile(item.ImagePath),
            .SizeMode = PictureBoxSizeMode.StretchImage,
            .Width = 100,
            .Height = 100,
            .Left = 10,
            .Top = 20
            }

            ' Price
            Dim lblPrice As New Label With {
                .Text = item.Price,
                .Top = 130,
                .Left = 10
            }

            Dim lblQty As New Label() With {
                .Text = $"{item.Quantity}",
                .Top = 140,
                .Left = 330,
                .Width = 30,
                .TextAlign = ContentAlignment.MiddleCenter
            }

            Dim btnAdd As New Button() With {
                .Top = 140,
                .Left = 300,
                .AutoSize = True,
                .Text = "+",
                .Width = 30
            }

            Dim btnRemove As New Button() With {
                .Top = 140,
                .Left = 360,
                .AutoSize = True,
                .Text = "-",
                .Width = 30
            }

            Dim btnDelete As New Button() With {
                .Text = "Remove",
                .Top = 140,
                .Left = 400,
                .Width = 70
            }

            AddHandler btnAdd.Click, Sub() UpdateQuantity(item, lblQty, 1)
            AddHandler btnRemove.Click, Sub() UpdateQuantity(item, lblQty, -1)
            AddHandler btnDelete.Click, Sub() RemoveFromCart(item)


            ' Add controls to product panel
            productPanel.Controls.Add(lblTitle)
            productPanel.Controls.Add(lblDesc)
            productPanel.Controls.Add(pic)
            productPanel.Controls.Add(lblPrice)
            productPanel.Controls.Add(lblQty)
            productPanel.Controls.Add(btnAdd)
            productPanel.Controls.Add(btnRemove)
            productPanel.Controls.Add(btnDelete)

            ' Add to main scrollable panel
            pnlCartList.Controls.Add(productPanel)
            yOffset += productPanel.Height + 10
            yOffset += 40
        Next
    End Sub

    'Update the quantity based on a removal or addition of the product to the cart
    Private Sub UpdateQuantity(item As CartItem, lblQty As Label, delta As Integer)
        Dim newQty = item.Quantity + delta
        If newQty >= 0 AndAlso newQty <= item.Stock Then
            item.Quantity = newQty
            lblQty.Text = $"{item.Quantity}"
            SaveCart()
            UpdateTotals()
        End If
    End Sub

    'Remove the item from the cart list and re-display the items in the cart
    Private Sub RemoveFromCart(item As CartItem)
        item.Quantity = 0
        cartItems.Remove(item)
        SaveCart()
        DisplayCart()
        UpdateTotals()
    End Sub

    'Read from the file and save the cart information to a file
    Private Sub SaveCart()
        Dim lines As New List(Of String)
        For Each item In cartItems
            lines.Add($"{item.Title}|{item.Description}|{Path.GetFileName(item.ImagePath)}|{item.Price.ToString(Globalization.CultureInfo.InvariantCulture)}|{item.Quantity}|{item.Stock}")
        Next
        IO.File.WriteAllLines(cartPath, lines)
    End Sub

    'Calculate the discount for the user
    Private Function CalculateDiscount(subtotal As Decimal) As Decimal
        If subtotal > 200 Then
            Return subtotal * 0.05D ' 5% discount
        End If
        Return 0D
    End Function

    'Calculate the tax for the user
    Private Function CalculateTax(amount As Decimal) As Decimal
        Return amount * 0.1D ' 10% tax
    End Function

    'Calculate and display the subtotals, tax, and final pay amount
    Private Sub UpdateTotals()
        Dim subtotal As Decimal = cartItems.Sum(Function(i) i.Price * i.Quantity)
        Dim discount As Decimal = CalculateDiscount(subtotal)
        Dim taxedAmount As Decimal = subtotal - discount
        Dim tax As Decimal = CalculateTax(taxedAmount)
        Dim total As Decimal = taxedAmount + tax


        Dim pointsApplied As Integer = CInt(Math.Min(userPoints, Decimal.Floor(total)))
        Dim finalTotal As Decimal = Math.Max(0D, total - pointsApplied)

        lblTotal.Text = $"Subtotal: {subtotal:C} {Environment.NewLine}{Environment.NewLine}Discount: {discount:C} {Environment.NewLine}{Environment.NewLine}Tax: {tax:C} {Environment.NewLine}{Environment.NewLine}Points applied: {pointsApplied} {Environment.NewLine}{Environment.NewLine}Total after points: {finalTotal:C}"
        lblPoints.Text = $"Your Points: {userPoints}"
    End Sub

    'Place the order
    Private Sub PlaceOrder(sender As Object, e As EventArgs)
        If cartItems.Count = 0 OrElse Not cartItems.Any(Function(item) item.Quantity > 0) Then
            MessageBox.Show("Your cart is empty. Add a product before placing an order.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim subtotal As Decimal = cartItems.Sum(Function(i) i.Price * i.Quantity)
        Dim discount As Decimal = CalculateDiscount(subtotal)
        Dim taxedAmount As Decimal = subtotal - discount
        Dim tax As Decimal = CalculateTax(taxedAmount)
        Dim total As Decimal = taxedAmount + tax

        ' One loyalty point is applied as one currency unit.
        Dim pointsToUse As Integer = CInt(Math.Min(userPoints, Decimal.Floor(total)))
        Dim finalTotal As Decimal = total - pointsToUse
        Dim pointsEarned As Integer = CInt(Math.Floor(finalTotal / 10D))

        ' Deduct redeemed points and add points earned from this purchase.
        userPoints = userPoints - pointsToUse + pointsEarned

        ' Save the updated point balance.
        IO.File.WriteAllText(pointsPath, userPoints.ToString(Globalization.CultureInfo.InvariantCulture))

            ' Clear cart
            IO.File.WriteAllText(cartPath, "")
            cartItems.Clear()

            MessageBox.Show($"Purchase successful! 🎉 You redeemed {pointsToUse} points and earned {pointsEarned} points. Your new balance is {userPoints} points. Thank you!", "Order Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information)

            DisplayCart()
            UpdateTotals()

            Dim btnReturn As New Button()
            btnReturn.Text = "🛍️ Return to Shopping"
            btnReturn.Dock = DockStyle.Bottom
            btnReturn.Height = 40
            AddHandler btnReturn.Click, AddressOf ReturnToShopping
            Controls.Add(btnReturn)
    End Sub
    'Return the user to the shopping form
    Private Sub ReturnToShopping(sender As Object, e As EventArgs)
        Dim halirzaShopping As New HalirzaShopping() ' ← Replace with your actual product form name
        halirzaShopping.Show()
        Me.Close()
    End Sub

    'Class with all of the properties of the stock items
    Private Class CartItem
        Public Property Title As String
        Public Property Description As String
        Public Property ImagePath As String

        Public Property Stock As Integer
        Public Property Price As Decimal
        Public Property Quantity As Integer
    End Class
End Class



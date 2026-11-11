Imports System.IO

' Centralized paths for product assets and user-specific application data.
Public Module AppPaths
    Private ReadOnly DataDirectory As String = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "Halirza"
    )

    Public ReadOnly Property GoalsFile As String
        Get
            Return Path.Combine(DataDirectory, "goals.txt")
        End Get
    End Property

    Public ReadOnly Property CartFile As String
        Get
            Return Path.Combine(DataDirectory, "cart.txt")
        End Get
    End Property

    Public ReadOnly Property PointsFile As String
        Get
            Return Path.Combine(DataDirectory, "points.txt")
        End Get
    End Property

    Public Function GetProductImage(fileName As String) As String
        Return Path.Combine(AppContext.BaseDirectory, fileName)
    End Function

    Public Sub EnsureDataDirectory()
        Directory.CreateDirectory(DataDirectory)
    End Sub
End Module

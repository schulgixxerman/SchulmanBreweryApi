Public Class BreweryModel
    Public Property Id As Integer
    Public Property Name As String
    Public Property Type As String
    Public Property Street As String
    Public Property City As String
    Public Property State As String
    Public Property ZipCode As Integer
    Public Property ZipExtn As Integer
    Public Property Country As String
    Public Property WebsiteUrl As String
    Public Property Results As New List(Of Object)
End Class

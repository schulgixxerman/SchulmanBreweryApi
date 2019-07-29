Imports System.Web.Http
Imports System.Data.SqlClient

Namespace Controllers
    'API controller retreives brewery data from BreweryDB and returns the data as a serialized JSON object
    Public Class BreweryApiController
        Inherits ApiController


        'GET: /Brweery/GetDetails
        'This function retreives Harrisburg, PA brewery data from my local database. The ajax call in index.vbhtml does not currently call this function as the database
        'must be set up before it will work correctly
        <HttpGet>
        Public Function GetDetailsFromDB() As String
            Dim connectionString = ConfigurationManager.ConnectionStrings("BreweryDB").ConnectionString
            Dim sqlString = "SELECT * FROM T_BREWERY"
            Dim sqlCon = New SqlConnection(connectionString)
            Dim json As New Script.Serialization.JavaScriptSerializer
            Dim model As New BreweryModel
            Dim dataTable = New DataTable

            Using sqlCon
                sqlCon.Open()
                Dim sqlDa = New SqlDataAdapter("SELECT * FROM T_BREWERY", sqlCon)
                sqlDa.Fill(dataTable)
            End Using

            For Each row As DataRow In dataTable.Rows
                Dim tempBrewery As New BreweryModel
                tempBrewery.Id = row.ItemArray(0)
                tempBrewery.Name = row.ItemArray(1)
                tempBrewery.Type = row.ItemArray(2)
                tempBrewery.Street = row.ItemArray(3)
                tempBrewery.City = row.ItemArray(4)
                tempBrewery.State = row.ItemArray(5)
                tempBrewery.ZipCode = row.ItemArray(6)
                tempBrewery.ZipExtn = row.ItemArray(7)
                tempBrewery.Country = row.ItemArray(8)
                tempBrewery.WebsiteUrl = row.ItemArray(9)
                model.Results.Add(tempBrewery)
            Next

            Return json.Serialize(model)
        End Function
        'This function was written to test static data. This is the function that is called by default from index.html
        <HttpGet>
        Public Function GetDetailsFromStatic() As String
            Dim json As New Script.Serialization.JavaScriptSerializer
            Dim model, Zeroday, Planning, ABC, Boneshire, SpringGate, Millworks, VegetableHunter, Wolf As New BreweryModel

            Zeroday.Id = 6348
            Zeroday.Name = "Zeroday Brewing Company"
            Zeroday.Type = "brewpub"
            Zeroday.Street = "250 Reily St Ste 103"
            Zeroday.City = "Harrisburg"
            Zeroday.State = "Pennsylvania"
            Zeroday.ZipCode = 17102
            Zeroday.ZipExtn = 2550
            Zeroday.Country = "United States"
            Zeroday.WebsiteUrl = "http://www.zerodaybrewing.com"
            model.Results.Add(Zeroday)

            Planning.Id = 6045
            Planning.Name = "Brewery in Planning - Harrisburg"
            Planning.Type = "planning"
            Planning.Street = ""
            Planning.City = "Harrisburg"
            Planning.State = "Pennsylvania"
            Planning.ZipCode = 17111
            Planning.ZipExtn = 2231
            Planning.Country = "United States"
            Planning.WebsiteUrl = ""
            model.Results.Add(Planning)

            ABC.Id = 6005
            ABC.Name = "Appalachian Brewing Co - Harrisburg"
            ABC.Type = "brewpub"
            ABC.Street = "50 N Cameron St"
            ABC.City = "Harrisburg"
            ABC.State = "Pennsylvania"
            ABC.ZipCode = 17101
            ABC.ZipExtn = 2407
            ABC.Country = "United States"
            ABC.WebsiteUrl = "http://www.abcbrew.com"
            model.Results.Add(ABC)

            Boneshire.Id = 6030
            Boneshire.Name = "Boneshire Brew Works"
            Boneshire.Type = "micro"
            Boneshire.Street = "7462 Derry St"
            Boneshire.City = "Harrisburg"
            Boneshire.State = "Pennsylvania"
            Boneshire.ZipCode = 17111
            Boneshire.ZipExtn = 5228
            Boneshire.Country = "United States"
            Boneshire.WebsiteUrl = "http://www.boneshire.com"
            model.Results.Add(Boneshire)

            SpringGate.Id = 6281
            SpringGate.Name = "Spring Gate Brewery"
            SpringGate.Type = "brewpub"
            SpringGate.Street = "5790 Devonshire Rd"
            SpringGate.City = "Harrisburg"
            SpringGate.State = "Pennsylvania"
            SpringGate.ZipCode = 17112
            SpringGate.ZipExtn = 3508
            SpringGate.Country = "United States"
            SpringGate.WebsiteUrl = "http://www.springgatebrewery.com"
            model.Results.Add(SpringGate)

            Millworks.Id = 6305
            Millworks.Name = "The Millworks Brewery"
            Millworks.Type = "brewpub"
            Millworks.Street = "430 Verbeke St"
            Millworks.City = "Harrisburg"
            Millworks.State = "Pennsylvania"
            Millworks.ZipCode = 17102
            Millworks.ZipExtn = 2052
            Millworks.Country = "United States"
            Millworks.WebsiteUrl = "http://www.millworksharrisburg.com"
            model.Results.Add(Millworks)

            VegetableHunter.Id = 6309
            VegetableHunter.Name = "The Vegetable Hunter"
            VegetableHunter.Type = "brewpub"
            VegetableHunter.Street = "614 N 2nd St"
            VegetableHunter.City = "Harrisburg"
            VegetableHunter.State = "Pennsylvania"
            VegetableHunter.ZipCode = 17101
            VegetableHunter.ZipExtn = 1001
            VegetableHunter.Country = "United States"
            VegetableHunter.WebsiteUrl = "http://www.thevegetablehunter.com"
            model.Results.Add(VegetableHunter)

            Wolf.Id = 6341
            Wolf.Name = "Wolf Brewing Company"
            Wolf.Type = "planning"
            Wolf.Street = ""
            Wolf.City = "Harrisburg"
            Wolf.State = "Pennsylvania"
            Wolf.ZipCode = 17112
            Wolf.ZipExtn = 1550
            Wolf.Country = "United States"
            Wolf.WebsiteUrl = "http://www.wolfbrewingco.com"
            model.Results.Add(Wolf)

            Return json.Serialize(model)
        End Function

    End Class
End Namespace
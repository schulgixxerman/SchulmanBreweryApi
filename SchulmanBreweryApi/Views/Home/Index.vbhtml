<style>
    .title {
        font-weight:bold;
    }
</style>
<script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
<script type="text/javascript">

        $(document).ready(function () {
            $.ajax({
                type: "GET",
                contentType: "application/json",
                datatype: 'json',
                url: "http://localhost:58758/api/breweryapi/GetDetailsFromStatic",                
                success: function (result) {
                    var data = JSON.parse(result);
                    $.each(data.Results, function () {
                        $('#breweryData').append('<p><span class="title">' + this.Name + ' | ' + this.Type + '</span></p>');
                        $('#breweryData').append('<p><span>' + this.Street + '</span>')
                        $('#breweryData').append('<p><span>' + this.City + ', ' + this.State + '</span>')
                        $('#breweryData').append('<p><span>' + this.ZipCode + '-' + this.ZipExtn + '</span>')
                        $('#breweryData').append('<p><span>' + this.Country + '</span>')
                        $('#breweryData').append('<p><a href=' + this.WebsiteUrl + '>' + this.WebsiteUrl + '</span>')

                    });
                }
            });            
        });
</script>
<div id="breweryData">    
</div>

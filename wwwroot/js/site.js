$(document).ready(function(){

   
    
    $('#autho').on('click', function(){
        $.ajax({
            url: 'institucional/GetAutoridades',
            method: 'GET',
            success: function(response){
                for(var i=0; i>response.lenght; i++){

                }
            }

        })
    })
})
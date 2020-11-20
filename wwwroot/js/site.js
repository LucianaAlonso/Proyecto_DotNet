$(document).ready(function(){

    $('#loggin-usuario').on('click', function(){
        
    })
    
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
$(document).ready(function(){

    
    $('#editMedicoModal').on('show.bs.modal', function (event) {
        $("#editMedicoModal input").val("");
    });

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
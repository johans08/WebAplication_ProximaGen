function CreateAlert(tittle, icon, body) {
    Swal.fire({
        icon: icon,
        title: tittle,
        text: body
    });
}

function EliminarDatosAjax(id, controller, action, mensajeSucces, mensajeError, dataString) {
   
    Swal.fire({
        title: '¿Estás seguro?',
        text: 'No podrás revertir esta acción',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sí, eliminar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            // Si el usuario confirma, llama a la función para eliminar el estado
            EliminarEstado(id, controller, action, mensajeSucces, mensajeError, dataString);
        }
    });
}


function EliminarEstado(idEstado, controller, action, mensajeSucces, mensajeError, dataString) {
    var data = {};
    data[dataString] = idEstado;

    $.ajax({
        type: 'POST',
        url: '../../' + controller + '/' + action, // Asegúrate de que la URL sea correcta (Controller y Action)
        data: data,
        success: function (data) {
            if (data.success) {
                Swal.fire({
                    title: "Eliminacion Correcta",
                    text: mensajeSucces,
                    icon: "success"
                }).then((result) => {
                    if (result.isConfirmed) {
                        // Si el usuario confirma, llama a la función para eliminar el estado
                        EliminarEstado(id, controller, action, mensajeSucces, mensajeError, dataString);
                    }
                });
            } else {
                Swal.fire({
                    title: "Eliminacion Correcta",
                    text: mensajeSucces,
                    icon: "success"
                }).then((result) => {
                    location.reload();
                });
            }
        },
        error: function () {
            // Manejar errores de la solicitud AJAX
            Swal.fire('Error', mensajeError, 'error');
        }
    });
}

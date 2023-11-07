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
                // Éxito, realizar alguna acción como recargar la tabla
                // Puedes mostrar un mensaje de éxito si lo deseas
                Swal.fire(mensajeSucces, 'success');
            }
        },
        error: function () {
            // Manejar errores de la solicitud AJAX
            Swal.fire('Error', mensajeError, 'error');
        }
    });
}

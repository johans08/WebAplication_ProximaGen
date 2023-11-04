function CreateAlert(tittle, icon, body) {
    Swal.fire({
        icon: icon,
        title: tittle,
        text: body
    });
}

function EliminarDatosAjax(idEstado) {
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
            EliminarEstado(idEstado);
        }
    });
}


function EliminarEstado(idEstado) {
    $.ajax({
        type: 'POST',
        url: '../../Maintenance/DeleteStatus', // Asegúrate de que la URL sea correcta
        data: { idEstado: idEstado },
        success: function (data) {
            if (data.success) {
                // Éxito, realizar alguna acción como recargar la tabla
                // Puedes mostrar un mensaje de éxito si lo deseas
                Swal.fire('Eliminado', 'El estado ha sido eliminado con éxito', 'success');
            }
        },
        error: function () {
            // Manejar errores de la solicitud AJAX
            Swal.fire('Error', 'Hubo un problema al eliminar el estado', 'error');
        }
    });
}

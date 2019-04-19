
class Instructores {
    constructor() {

    }
    guardarInstructor(id, funcion, ...data) {
        var action = data[0], especialidad = data[1], nombre = data[2], apellido = data[3];
        var documento = data[4], email = data[5], telefono = data[6];
        var estado = data[7];
        alert(action);
        //if (especialidad == "") {
        //    document.getElementById("Especialidad").focus();
        //} else {
        //    if (nombre == "") {
        //        document.getElementById("Nombre").focus();
        //    } else {
        //        if (apellido == "") {
        //            document.getElementById("Apellidos").focus();
        //        } else {
        //            if (documento == "") {
        //                document.getElementById("Documento").focus();
        //            } else {
        //                if (email == "") {
        //                    document.getElementById("Email").focus();
        //                } else {
        //                    if (telefono == "") {
        //                        document.getElementById("Telefono").focus();
        //                    } else {
        //                        $.post(
        //                            action,
        //                            {
        //                                id, especialidad, nombre, apellido, documento, email, telefono,
        //                                estado, funcion
        //                            },
        //                            (response) => {

        //                            }
        //                        );
        //                        }
        //                    }
        //                }
        //        }
        //    }
        //}
    }
}

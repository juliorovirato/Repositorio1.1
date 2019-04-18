
class Horarios {
    constructor(dia, hora, actividad, action) {
        this.dia = dia;
        this.hora = hora;
        this.actividad = actividad;
        this.action = action;
    }
    getActividades() {
        var action = this.action;
        var count = 1;
        $.ajax({
            type: "POST",
            url: action,
            data: {},
            success: (response) => {
                console.log(response);
                if (0 < response.length) {
                    for (var i = 0; i < response.length; i++) {
                        document.getElementById('ActividadHorarios').options[count] = new Option(response[i].nombre, response[i].actividadID);
                        count++;
                    }
                }
            }
        });
    }
    agregarHorario(id, funcion) {
        if (this.dia == "") {
            document.getElementById("Dia").focus();
        } else {
            if (this.hora == "") {
                document.getElementById("Hora").focus();
            } else {
                if (this.actividad == "0") {
                    document.getElementById("mensaje").innerHTML = "Seleccione una actividad";
                } else {
                    var dia = this.dia;
                    var hora = this.hora;
                    var actividad = this.actividad;
                    var action = this.action;
                    console.log(dia);
                    $.ajax({
                        type: "POST",
                        url: action,
                        data: {
                            id, dia, hora, actividad, funcion
                        },
                        success: (response) => {
                            if ("Save" == response[0].code) {
                                this.restablecer();
                            } else {
                                document.getElementById("mensaje").innerHTML = "No se puede guardar el curso";
                            }
                        }
                    });
                }
            }
        }
    }
    filtrarHorario(numPagina, order) {
        var valor = this.dia;
        var action = this.action;
        if (valor == "") {
            valor = "null";
        }
        $.ajax({
            type: "POST",
            url: action,
            data: { valor, numPagina, order },
            success: (response) => {
                $("#resultSearch").html(response[0]);
                $("#paginado").html(response[1]);
            }
        });
    }
    restablecers() {
        document.getElementById("Dia").value = "";
        document.getElementById("Hora").value = "";
        document.getElementById('ActividadHorarios').selectedIndex = 0;
        document.getElementById("mensaje").innerHTML = "";

        $('#modalCS').modal('hide');
    }
}
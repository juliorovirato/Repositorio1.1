﻿var localStorage = window.localStorage;
class Actividades {
    constructor(nombre, cantidadIns, descripcion, estado, action) {
        this.nombre = nombre;
        this.cantidadIns = cantidadIns;
        this.descripcion = descripcion;
        this.estado = estado;
        this.action = action;
    }
    agregarActividad() {
        if (this.nombre == "") {
            document.getElementById("Nombre").focus();
        } else {
            if (this.cantidadIns == "") {
                document.getElementById("CantidadIns").focus();
            } else {
                if (this.descripcion == "") {
                    document.getElementById("Descripcion").focus();
                } else {
                    if (this.estado == 0) {
                        document.getElementById("mensaje").innerHTML = "Seleccione un estado";
                    } else {
                        var nombre = this.nombre;
                        var cantidadIns = this.cantidadIns;
                        var descripcion = this.descripcion;
                        var estado = this.estado;
                        var action = this.action;
                        var mensaje = '';
                        $.ajax({
                            type: "POST",
                            url: action,
                            data: {
                                nombre, cantidadIns, descripcion, estado
                            },
                            success: (response) => {
                                $.each(response, (index, val) => {
                                    mensaje = val.code;
                                });
                                if (mensaje == "Save") {
                                    this.restablecer();
                                } else {
                                    document.getElementById("mensaje").innerHTML = "No se puede guardar la categoria";
                                }
                                //console.log(response);
                            }
                        });
                    }
                }
            }
        }
    }
    filtrarDatos(numPagina) {
        var valor = this.nombre;
        var action = this.action;
        if (valor == "") {
            valor = "null";
        }
        $.ajax({
            type: "POST",
            url: action,
            data: { valor, numPagina },
            success: (response) => {
                console.log(response);
                $.each(response, (index, val) => {
                    $("#resultSearch").html(val[0]);
                    $("#paginado").html(val[1]);
                });
            }
        });
    }
    qetActividad(id) {
        var action = this.action;
        $.ajax({
            type: "POST",
            url: action,
            data: { id },
            success: (response) => {
                console.log(response);
                localStorage.setItem("actividad", JSON.stringify(response));
            }
        });
    }
    restablecer() {
        document.getElementById("Nombre").value = "";
        document.getElementById("CantidadIns").value = "";
        document.getElementById("Descripcion").value = "";
        document.getElementById("mensaje").innerHTML = "";
        document.getElementById("Estado").selectedIndex = 0;
        $('#modalAC').modal('hide');
    }
}

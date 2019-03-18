var localStorage = window.localStorage;
class Actividades {
    constructor(nombre, cantidad, descripcion, estado, codinstructor, action) {
        this.nombre = nombre;
        this.cantidad = cantidad;
        this.descripcion = descripcion;
        this.estado = estado;
        this.codinstructor = codinstructor;
        this.action = action
    }
    agregarActividad() {
        if (this.nombre == "") {
            document.getElementById("Nombre").focus();
        } else {
            if (this.cantidad == 0) {
                document.getElementById("Cantidad").focus();
            } else {
                if (this.descripcion == "") {
                    document.getElementById("Descripcion").focus();
                } else {
                    if (this.estado == 0) {
                        document.getElementById("mensaje").innerHTML = "Seleccione un estado";
                    } else {
                        if (this.codinstructor == "") {
                            document.getElementById("Codigo").focus();
                        } else {
                            var nombre = this.nombre;
                            var cantidad = this.cantidad;
                            var descripcion = this.descripcion;
                            var estado = this.estado;
                            var codinstructor = this.codinstructor;
                            var action = this.action;
                            var mensaje = '';
                            $.ajax({
                                type: "POST",
                                url: action,
                                data: {
                                    nombre, cantidad, descripcion, estado, codinstructor
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
                                }
                            });
                        }
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
                    $("#Paginado").html(val[1]);
                });
            }
        });
    }
    getActividades(id) {
        var action = this.action;
        $.ajax({
            type: "POST",
            url: action,
            data: { id },
            success: (response) => {
                console.log(response);
                localStorage.setItem("actividades", JSON.stringify(response));
            }
        })
    }
    restablecer() {
        document.getElementById("Nombre").value = "";
        document.getElementById("Cantidad").value = "";
        document.getElementById("Descripcion").value = "";
        document.getElementById("mensaje").innerHTML = "";
        document.getElementById("Estado").selectedIndex = 0;
        document.getElementById("Codigo").value = "";
        $('#modalAC').modal('hide');  
    }
}
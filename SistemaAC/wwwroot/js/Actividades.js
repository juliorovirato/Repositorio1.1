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
                                    console.log(response);
                                }
                            });
                        }
                    }
                }
            }
        }
    }
}
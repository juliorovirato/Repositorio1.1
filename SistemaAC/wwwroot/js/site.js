// Write your JavaScript code.
$('#modalEditar').on('shown.bs.modal', function () {
  $('#myInput').focus()
})
$('#modalAC').on('shown.bs.modal', function () {
    $('#Nombre').focus()
})
/** Codigo de Usuarios */
function getUsuario(id,action) {
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function (response) {
            mostrarUsuario(response);
        }
    });
}

var items;
var j = 0;

var id;
var userName;
var email
var phoneNumber;
var role;
var selectRole;

var accessFailedCount;
var concurrencyStamp;
var emailConfirmed;
var lockoutEnabled;
var lockoutEnd;
var normalizedUserName;
var normalizedEmail;
var passwordHash;
var phoneNumberConfirmed;
var securityStamp;
var twoFactorEnabled;

function mostrarUsuario(response) {
    items = response;
    for (var i = 0; i < 3; i++) {
        var x = document.getElementById('Select');
        x.remove(i);
    }

    $.each(items, function (index, val) {
        $('input[name=Id]').val(val.id);
        $('input[name=UserName]').val(val.userName);
        $('input[name=Email]').val(val.email);
        $('input[name=PhoneNumber]').val(val.phoneNumber);
        document.getElementById('Select').options[0] = new Option(val.role, val.roleId);

        $("#dEmail").text(val.email);
        $("#dUserName").text(val.userName);
        $("#dPhoneNumber").text(val.phoneNumber);
        $("#dRole").text(val.role);

        $("#eUsuario").text(val.email);
        $('input[name=EIdUsuario]').val(val.id);
    });
}

function getRoles(action) {
    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            if (j == 0) {
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('Select').options[i] = new Option(response[i].text, response[i].value);
                    document.getElementById('SelectNuevo').options[i] = new Option(response[i].text, response[i].value);
                }
                j = 1;
            }
        }
    });
}

function editarUsuario(action) {
    id = $('input[name=Id]')[0].value;
    email = $('input[name=Email]')[0].value;
    phoneNumber = $('input[name=PhoneNumber]')[0].value;
    role = document.getElementById('Select');
    selectRole = role.options[role.selectedIndex].text;

    $.each(items, function (index, val) {
        accessFailedCount = val.accessFailedCount;
        concurrencyStamp = val.concurrencyStamp;
        emailConfirmed = val.emailConfirmed;
        lockoutEnabled = val.lockoutEnabled;
        lockoutEnd = val.lockoutEnd;
        userName = val.userName;
        normalizedUserName = val.normalizedUserName;
        normalizedEmail = val.normalizedEmail;
        passwordHash = val.passwordHash;
        phoneNumberConfirmed = val.phoneNumberConfirmed;
        securityStamp = val.securityStamp;
        twoFactorEnabled = val.twoFactorEnabled;
    });
    $.ajax({
        type: "POST",
        url: action,
        data: {
            id, userName, email, phoneNumber, accessFailedCount,
            concurrencyStamp, emailConfirmed,
            lockoutEnabled, lockoutEnd, normalizedEmail, normalizedUserName,
            passwordHash, phoneNumberConfirmed, securityStamp, twoFactorEnabled, selectRole
        },
        success: function (response) {
            if (response === "Save") {
                window.location.href = "Usuarios";
            }
            else {
                alert("No se puede editar los datos del Usuario");
            }
        }
    });

}

function ocultarDetalleUsuario() {
    $("#modalDetalle").modal("hide");
}

function eliminarUsuario(action) {
    var id = $('input[name=EIdUsuario]')[0].value;
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function (response) {
            if (response == "Delete") {
                window.location.href = "Usuarios";
            }
            else {
                alert("No se puede eliminar el registro");
            }
        }
    });
}

function crearUsuario(action) {
    email = $('input[name=EmailNuevo]')[0].value;
    phoneNumber = $('input[name=PhoneNumberNuevo]')[0].value;
    passwordHash = $('input[name=PasswordHashNuevo]')[0].value;
    role = document.getElementById('SelectNuevo');
    selectRole = role.options[role.selectedIndex].text;

    if (email == "") {
        $('#EmailNuevo').focus();
        alert("Ingrese el email del usuario");
    } else {
        if (passwordHash == "") {
            $('#PasswordHashNuevo').focus();
            alert("Ingrese la contraseña del usuario");
        } else {
            $.ajax({
                type: "POST",
                url: action,
                data: {
                    email, phoneNumber, passwordHash, selectRole
                }, success: function (response) {
                    if (response == "Save") {
                        window.location.href = "Usuarios";
                    }
                    else {
                        $('#mensajenuevo').html("No se puede guardar el usuario. <br/>Seleccione un rol. <br/> Ingrese un email correcto. <br/> La contraseña debe tener de 6-100 caracteres, al menos un caracter especial, una letra mayúscula y un número");
                    }
                }
            });
        }
    }
}

$().ready(() => {
    var URLactual = window.location;
    document.getElementById("filtrar").focus();
    switch (URLactual.pathname) {
        case "/Actividades":
            filtrarDatos(1, "nombre");
            break;
        case "/Horarios":
            getActividades(0, 0);
            filtrarHorario(1, "dia");
        case "/Maquinarias":
            getActividades2(0, 0);
            filtrarMaquinaria(1, "nombre");
    }
});
$('#modalCS').on('shown.bs.modal', function () {
    $('#Dia').focus()
})

var idActividad, funcion = 0, idHorario, idMaquinaria;
/** Codigo de Actividades */
var agregarActividad = () => {
    var nombre = document.getElementById("Nombre").value;
    var cantidad = document.getElementById("Cantidad").value;
    var descripcion = document.getElementById("Descripcion").value;
    var estados = document.getElementById('Estado');
    var estado = estados.options[estados.selectedIndex].value;
    if (funcion == 0) {
        var action = 'Actividades/guardarActividad';
    } else {
        var action = 'Actividades/editarActividad';
    }
    var actividad = new Actividades(nombre, cantidad, descripcion, estado, action);
    actividad.agregarActividad(idActividad, funcion);
    funcion = 0;
}

var filtrarDatos = (numPagina, order) => {
    var valor = document.getElementById("filtrar").value;
    var action = 'Actividades/filtrarDatos';
    var actividad = new Actividades(valor, "", "", "", action);
    actividad.filtrarDatos(numPagina, order);
}

var editarEstado = (id, fun) => {
    idActividad = id;
    funcion = fun;
    var action = 'Actividades/getActividades';
    var actividad = new Actividades("", "", "", "", action);
    actividad.qetActividad(id, funcion);
}

var editarActividad = () => {
    var action = 'Actividades/editarActividad';
    var actividad = new Actividades("", "", "", "", action);
    actividad.editarActividad(idActividad, funcion);
}

/** Codigo de Horarios */
var getActividades = (id, fun) => {
    var action = 'Horarios/getActividades';
    var horarios = new Horarios("", "", "", action);
    horarios.getActividades(id, fun);
}
var agregarHorario = () => {
    if (funcion == 0) {
        var action = 'Horarios/agregarHorario';
    } else {
        var action = 'Horarios/editarHorario';
    }
    var dia = document.getElementById("Dia").value;
    var hora = document.getElementById("Hora").value;
    var actividades = document.getElementById('ActividadHorarios');
    var actividad = actividades.options[actividades.selectedIndex].value;
    var horarios = new Horarios(dia, hora, actividad, action);
    horarios.agregarHorario(idHorario, funcion);
    funcion = 0;
}
var filtrarHorario = (numPagina, order) => {
    var valor = document.getElementById("filtrar").value;
    var action = 'Horarios/filtrarHorario';
    var horarios = new Horarios(valor, "", "", action);
    horarios.filtrarHorario(numPagina, order);
}

var editarHorario = (id, fun) => {
    funcion = fun;
    idHorario = id;
    var action = 'Horarios/getHorario';
    var horarios = new Horarios("", "", "", action);
    horarios.getHorario(id, fun);
}

var editarHorario1 = () => {
    var action = 'Horarios/editarHorario';
    var horarios = new Horarios("", "", "", action);
    horarios.editarHorario(idHorario, funcion);
}

var restablecer = () => {
    var horarios = new Horarios("", "", "", "");
    horarios.restablecer();
}

/** Codigo de Maquinarias */
var getActividades2 = (id, fun) => {
    var action = 'Maquinarias/getMaquinaria';
    var maquinaria = new Maquinaria("", "", "", action);
    maquinaria.getMaquinaria(id, fun);
}
var agregarMaquinaria = () => {
    if (funcion == 0) {
        var action = 'Maquinarias/agregarMaquinaria';
    } else {
        var action = 'Maquinarias/editarMaquinaria';
    }

    var nombre = document.getElementById("Nombre").value;
    var cantidad = document.getElementById("Cantidad").value;
    var actividades = document.getElementById('ActividadMaquinarias');
    var actividad = actividades.options[actividades.selectedIndex].value;
    var maquinaria = new Maquinaria(nombre, cantidad, actividad, action);
    maquinaria.agregarMaquinaria(idMaquinaria, funcion);
    funcion = 0;
}
var filtrarMaquinaria = (numPagina, order) => {
    var valor = document.getElementById("filtrar").value;
    var action = 'Maquinarias/filtrarMaquinaria';
    var maquinarias = new Maquinaria(valor, "", "", action);
    maquinarias.filtrarMaquinaria(numPagina, order);
}
var editarMaquinaria = (id, fun) => {
    funcion = fun;
    idMaquinaria = id;
    var action = 'Maquinarias/getMaquinaria';
    var maquinarias = new Maquinaria("", "", "", action);
    maquinarias.getMaquinaria(id, fun);
}
var editarMaquinaria1 = () => {
    var action = 'Maquinarias/editarMaquinaria';
    var cursos = new Cursos("", "", "", action);
    maquinarias.editarMaquinaria(idMaquinaria, funcion);
}
var restablecer = () => {
    var maquinarias = new Maquinaria("", "", "", "");
    maquinarias.restablecer();
}
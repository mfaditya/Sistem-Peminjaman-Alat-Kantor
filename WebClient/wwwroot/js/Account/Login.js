function login() {
    let login = new Object();
    login.Email = $("#inputName").val();
    login.Password = $("#inputPassword").val();

    console.log(login)
    $.ajax({
        type: 'post',
        url: '/Auth/Login',
        data: login
    }).done((result) => {
        console.log("ok", result);
        if (result == '/Dashboard/Employee' || result == '/Dashboard/Manager' || result == '/Dashboard/Admin') {
            //alert("Successed to Login");
            //sessionStorage.setItem("token", result.token);
            //console.log(result.token);
            localStorage.setItem('LoginRes', JSON.stringify(result));
            window.location.href = result;
            $("#inputName").val(null);
        }
        else {
            alert("Failed to Login");
            $("#inputName").val(null);
            $("#inputPassword").val(null);
        }
    }).fail((result) => {
        console.log(result);
        alert("Failed to Login");
    })
}

//function login() {
//    let login = new Object();
//    login.Email = $("#inputName").val();
//    login.Password = $("#inputPassword").val();

//    console.log(login)
//    $.ajax({
//        type: 'post',
//        url: `https://localhost:7095/api/Accounts/Login`,
//        data: JSON.stringify(login),
//        dataType: 'text',
//        headers: {
//            'Content-Type': 'Application/json'
//        },
//        success: function (data) {
//            console.log("berhasil");
//            sessionStorage.setItem("token", data);
//            console.log(data);
//            let jwtData = data.split('.')[1]
//            let decodeJwtJsonData = window.atob(jwtData)
//            let decodeJwtData = JSON.parse(decodeJwtJsonData)
//            let role = decodeJwtData.roles;
//            if (role == "Admin") {
//                window.location.replace("../Dashboard/Admin");
//            } else if (role === "Manager") {
//                window.location.replace("../Dashboard/Manager");
//            } else {
//                window.location.replace("../Dashboard/Employee")
//            }
//        },
//        error: function (jqXHR) {
//            console.log(jqXHR);
//        }
//    })
//}

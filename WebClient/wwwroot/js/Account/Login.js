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
    //$.ajax({
    //    url: `https://localhost:7095/api/Accounts/Login`,
    //    method: "POST",
    //    data: JSON.stringify(data),
    //    dataType: "json",
    //    headers: {
    //        'Content-Type': 'application/json'
    //    },
    //}).done((result) => {
    //    console.log("ok", result);
    //    sessionStorage.setItem("token", result.token);
    //    console.log(result.token);
    //    if (result == '/Dashboard/Employee' || result == '/Dashboard/Manager' || result == '/Dashboard/Admin') {
    //        //alert("Successed to Login");
    //        localStorage.setItem('LoginRes', JSON.stringify(result));
    //        window.location.href = result;
    //        $("#inputName").val(null);
    //    }
    //    else {
    //        alert("Failed to Login");
    //        $("#inputName").val(null);
    //        $("#inputPassword").val(null);
    //    }
    //}).fail((result) => {
    //    console.log(result);
    //    alert("Failed to Login");
    //})
        //success: function (result) {
        //    //$.cookie('token', result.token)
        //    sessionStorage.setItem("token", result.token);
        //    console.log(result.token);
        //    //console.log($.cookie('token))
        //    window.location.replace("../Department/Index")
        //}
    /*})*/
}
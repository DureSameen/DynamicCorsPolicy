document.getElementById("api").addEventListener("click", api, false);
 
 
function api() {
   
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "https://localhost:44337/weatherforecast");
    xhr.onload = function () {
        console.log(xhr.status, JSON.parse(xhr.responseText));
    };
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {    
            if (xhr.status === 200) {   
                console.log("success");
            } else {
                console.log(xhr.status, JSON.parse(xhr.responseText));
            }
        }
    };
    xhr.send();
    
}
 
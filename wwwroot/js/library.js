function BindForm(selector, callback) {
    var formElement = document.querySelector(selector);
    formElement.addEventListener("submit", function(e){
        e.preventDefault();
        var dataObject = {};   
        for(var i = 0; i < formElement.length; i++){
            if(formElement[i].name == "" || formElement[i].name == ""){
                continue;
            }
            dataObject[formElement[i].name] = formElement[i].value;
        }
        fetch(formElement.action, {
            method: formElement.method,
            body: JSON.stringify(dataObject),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        }).then(callback);
    });
}
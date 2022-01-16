const searchWrapper = document.querySelector(".search-input");
const inputBox = searchWrapper.querySelector("input");
const suggBox = searchWrapper.querySelector(".autocom-box");
const hiddenBox = document.querySelector("#CompanyTypeId");


setInterval(() => {
    $.ajax({
        type: 'GET',
        url: '../Company/GetCompanyName',
        dataType: "json",
        success: function (response) {        
            suggestions = [];
            for (var i = 0; i < response.length; i++) {
                suggestions.push({
                    Id: response[i].Id,
                    Companyname: response[i].Name
                });
            }
        }
    });
}, 1000);

inputBox.onkeyup = (e) => {
    let userData = e.target.value;
    let emptyArray = [];
    if (userData) {
        for (var i = 0; i < suggestions.length; i++) {
            emptyArray = suggestions.filter((data) => {
                return data.Companyname.toLocaleLowerCase().startsWith(userData.toLocaleString());
            });
        }
        emptyArray = emptyArray.map((data) => {
            return data = '<li id="' + data.Id + '">' + data.Companyname + '</li>';
        });
        searchWrapper.classList.add("active");
        showSuggestions(emptyArray);
        let allList = suggBox.querySelectorAll("li");
        for (let i = 0; i < allList.length; i++) {
            allList[i].setAttribute("onclick", "select(this)");
        }
    } else {
        searchWrapper.classList.remove("active");
    }
};

function select(element) {
    let selectUserData = element.textContent;
    let val = inputBox.value
    if (selectUserData === " Ekle") {
        //$.ajax({
        //    type: 'POST',
        //    url: '../Company/TypeAdd',
        //    data: { CompanyTypeName: val },
        //    dataType: "json",
        //});
        //setTimeout(() => {
        //    $.ajax({
        //        type: 'POST',
        //        url: '../Company/Typefind',
        //        data: { typ: val },
        //        dataType: "json",
        //        success: function (response) {
        //            console.log(response[0].Id);
        //            console.log(response);
        //            hiddenBox.value = response[0].Id;
        //        }
        //    });
        //}, 1000);
    } else {
        inputBox.value = selectUserData;
        hiddenBox.value = element.id;
    }
    searchWrapper.classList.remove("active");
};

function showSuggestions(list) {
    let listData;
    if (!list.length) {
        userValue = inputBox.value;
        listData = '<li class="add" tabindex="0" aria-controls="example1" type="button" data-toggle="modal" data-target="#CmpAdd"><i class="fas fa-plus"></i> Ekle</li>';
    } else {
        listData = list.join('');
    }
    suggBox.innerHTML = listData;
};

inputBox.onclick = (e) => {
    let dataArray = [];
    dataArray = suggestions.map((data) => {
        return data = '<li id="' + data.Id + '">' + data.Companyname + '</li>';
    });
    searchWrapper.classList.add("active");
    showSuggestions(dataArray);
    let allList = suggBox.querySelectorAll("li");
    for (let i = 0; i < allList.length; i++) {
        allList[i].setAttribute("onclick", "select(this)");
    }
};

inputBox.ondblclick = (e) => {
    searchWrapper.classList.remove("active");
};


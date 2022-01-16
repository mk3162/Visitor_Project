const searchWrapperBranchType = document.querySelector(".branchtype");
const inputBoxBranchType = searchWrapperBranchType.querySelector("input");
const suggBoxBranchType = searchWrapperBranchType.querySelector(".BranchTypeautocom-box");
const hiddenBoxBranchType = document.querySelector("#BranchtypeId");


setInterval(() => {
    $.ajax({
        type: 'GET',
        url: '../Branch/GetBranchType',
        dataType: "json",
        success: function (response) {
            suggestions = [];
            for (var i = 0; i < response.length; i++) {
                suggestions.push({
                    Id: response[i].Id,
                    BranchTypeName: response[i].BranchTypeName
                });
            }
        }
    });
}, 1000);

inputBoxBranchType.onkeyup = (e) => {
    let userData = e.target.value;
    console.log(suggestions);
    let emptyArray = [];
    if (userData) {
        for (var i = 0; i < suggestions.length; i++) {
            emptyArray = suggestions.filter((data) => {
                return data.BranchTypeName.toLocaleLowerCase().startsWith(userData.toLocaleString());
            });
        }
        emptyArray = emptyArray.map((data) => {
            return data = '<li id="' + data.Id + '">' + data.BranchTypeName + '</li>';
        });
        searchWrapperBranchType.classList.add("active");
        showSuggestions(emptyArray);
        let allList = suggBoxBranchType.querySelectorAll("li");
        for (let i = 0; i < allList.length; i++) {
            allList[i].setAttribute("onclick", "select(this)");
        }
    } else {
        searchWrapperBranchType.classList.remove("active");
    }
};

function select(element) {
    let selectUserData = element.textContent;
    let val = inputBoxBranchType.value
    if (selectUserData === " Ekle") {
        $.ajax({
            type: 'POST',
            url: '../Branch/BranchTypeAdd',
            data: { branchTypeName: val },
            dataType: "json",
        });
        setTimeout(() => {
            $.ajax({
                type: 'POST',
                url: '../Branch/BrcTypefind',
                data: { cmp: val },
                dataType: "json",
                success: function (response) {
                    console.log(response[0].Id);
                    console.log(response);
                    hiddenBoxBranchType.value = response[0].Id;
                }
            });
        }, 1000);
    } else {
        inputBoxBranchType.value = selectUserData;
        hiddenBoxBranchType.value = element.id;
    }
    searchWrapperBranchType.classList.remove("active");
};

function showSuggestions(list) {
    let listData;
    if (!list.length) {
        userValue = inputBoxBranchType.value;
        listData = '<li class="add"><i class="fas fa-plus"></i> Ekle</li>';
    } else {
        listData = list.join('');
    }
    suggBoxBranchType.innerHTML = listData;
};

inputBoxBranchType.onclick = (e) => {
    let dataArray = [];
    dataArray = suggestions.map((data) => {
        return data = '<li id="' + data.Id + '">' + data.BranchTypeName + '</li>';
    });
    searchWrapperBranchType.classList.add("active");
    showSuggestions(dataArray);
    let allList = suggBoxBranchType.querySelectorAll("li");
    for (let i = 0; i < allList.length; i++) {
        allList[i].setAttribute("onclick", "select(this)");
    }
};

inputBoxBranchType.ondblclick = (e) => {
    searchWrapperBranchType.classList.remove("active");
};


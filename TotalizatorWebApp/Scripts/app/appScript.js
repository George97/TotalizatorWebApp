(function () {
    console.log('load module');
    onAdd = function (addBtn) {
        console.log('click');
        console.log(addBtn);
        console.log($(addBtn).parent());
        var textEl = $(addBtn).parent().children().find(2);
        console.log(textEl);
    };
})();
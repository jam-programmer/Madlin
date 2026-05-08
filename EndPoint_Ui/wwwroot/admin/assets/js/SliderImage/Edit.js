$(document).ready(function () {
    let category = document.getElementById("selectedCategory");
    console.log( category);
    CKEDITOR.replace('editor-fa');
    CKEDITOR.replace('editor-en');
    $('#dropDownCategory').select2({
        placeholder: 'یک دسته بندی انتخاب کنید',
        ajax: {
            delay: 250,
            url: '/Admin/Project/GetCategories',
            data: function (params) {
                var query = {
                    search: params.term

                }
                return query;
            }, processResults: function (data) {
                return {
                    results: data.map(function (item) {
                        return {
                            id: item.id,
                            text: item.title
                        };
                    })
                };
            }
        }

    });
    if (category) {
        let key = category.getAttribute("key");
        let value = category.getAttribute("value");


        
        if (key && value) {
            var initialOption = new Option(value, key, true, true);
            $('#dropDownCategory').append(initialOption).trigger('change');
        }
    }
});
$(document).ready(function () {

    

    $('#datepicker').datepicker({
        dateFormat: "yy/mm/dd",
        showOtherMonths: true,
        selectOtherMonths: false
    });
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

});
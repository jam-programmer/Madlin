$(document).ready(function () {
    CKEDITOR.replace('editor-fa');
    CKEDITOR.replace('editor-en');
    $('#dropDownCategory').select2({
        placeholder: 'یک دسته بندی انتخاب کنید',
        ajax: {
            delay: 250,
            url: '/Admin/Blog/GetCategories',
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
    $('#dropDownTag').select2({
        placeholder: 'یک یا چند برچسب انتخاب کنید',
        multiple: true,
        ajax: {
            delay: 250,
            url: '/Admin/Blog/GetTags',
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
$(document).ready(function () {
    let category = document.getElementById("selectedCategory");
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
    if (category) {
        let key = category.getAttribute("key");
        let value = category.getAttribute("value");


        
        if (key && value) {
            var initialOption = new Option(value, key, true, true);
            $('#dropDownCategory').append(initialOption).trigger('change');
        }
    }
    $(document).ready(function () {

        // ۱. مقداردهی اولیه Select2 (فقط برای جستجو)
        $('#dropDownTag').select2({
            placeholder: 'یک یا چند برچسب انتخاب کنید',
            multiple: true,
            ajax: {
                delay: 250,
                url: '/Admin/Blog/GetTags', // آدرس جستجو
                data: function (params) {
                    return {
                        search: params.term
                    };
                },
                processResults: function (data) {
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

        // ۲. دریافت لیست انتخاب شده‌ها هنگام لود شدن صفحه
        // فرض می‌کنیم ID وبلاگ را در یک فیلد مخفی یا متغیر دارید
        let blogId = document.getElementById("blogId").value;

        if (blogId) { // فقط اگر ID وجود داشت درخواست بفرست
            $.ajax({
                url: '/Admin/Blog/GetSelectedTags',
                type: 'GET',
                data: { Id: blogId },
                success: function (selectedTags) {
                    // ۳. تبدیل داده‌ها به فرمت استاندارد Select2 (آرایه ID)
                    // سرور باید لیستی از اشیاء شامل id و text برگرداند

                    // استخراج لیست آی‌دی‌ها
                    var ids = selectedTags.map(function (item) {
                        return item.id;
                    });

                    // ۴. ایجاد آبجکت داده‌ها برای Select2 (اختیاری اما توصیه می‌شود)
                    // این کار باعث می‌شود Select2 نام تگ‌ها را بدون نیاز به جستجو نمایش دهد
                    var option = new Option(selectedTags[0].text, selectedTags[0].id, true, true);

                    // روش صحیح برای چندین گزینه:
                    // ابتدا داده‌ها را به Select2 معرفی می‌کنیم (برای نمایش متن)
                    $('#dropDownTag').append(selectedTags.map(function (t) {
                        return new Option(t.text, t.id, true, true);
                    }));

                    // سپس تغییرات را اعمال می‌کنیم
                    $('#dropDownTag').trigger('change');
                },
                error: function () {
                    console.error("خطا در دریافت تگ‌های انتخاب شده");
                }
            });
        }
    });
});
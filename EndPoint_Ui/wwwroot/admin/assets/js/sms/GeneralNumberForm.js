$('#dropDownNumber').select2({
    placeholder: 'یک شماره موبایل انتخاب کنید',
    tags: true, // اجازه ورود مقادیر دلخواه
    createTag: function (params) {
        // مقدار وارد شده توسط کاربر را به عنوان یک گزینه جدید برگردان
        var term = $.trim(params.term);
        if (term === '') {
            return null;
        }
        return {
            id: term,
            text: term,
            newOption: true
        };
    },
    ajax: {
        delay: 250,
        url: '/Admin/Sms/GetNumbers',
        data: function (params) {
            return { search: params.term };
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

function RemoveParameter(id) {
   
    let parameter = document.getElementById(id);
    if (parameter) {
        parameter.remove();
        }
    

}
function AppendParameters() {
    const elementId = generateRandomString(10);
    let parameters = document.getElementById("parameters");
    let row = ` <div class="form-row mt-3 mx-2" id="${elementId}">
                   <div class="col-5">
                       <input type="text" name="Parameters[${elementId}].Key" class="form-control" placeholder="کلید">
                   </div>
                   <div class="col-5">
                       <input type="text" name="Parameters[${elementId}].Value" class="form-control" placeholder="مقدار">
                   </div> 
                   <div class="col">
                       <a onclick="RemoveParameter('${elementId}')" class="btn btn-danger text-white">حذف</a>
                   </div>  <!-- این فیلد مخفی به ASP.NET می‌گوید که این یک آیتم لیست است -->
                    <input type="hidden" name="Parameters.Index" value="${elementId}" />
                 </div>`

    parameters.insertAdjacentHTML('beforeend', row);
}
function generateRandomString(length) {
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    let result = '';
    const charactersLength = characters.length;

    for (let i = 0; i < length; i++) {
        result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }

    return result;
}

$(document).ready(function () {
    CKEDITOR.replace('editor-fa');
    CKEDITOR.replace('editor-en');
  
});

function generateRandomString(length) {
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    let result = '';
    const charactersLength = characters.length;

    for (let i = 0; i < length; i++) {
        result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }

    return result;
}


function RemoveUrl(id) {

    let url = document.getElementById(id);
    if (url) {
        url.remove();
    }


}
function AddUrl() {
    const elementId = generateRandomString(10);

    let list = document.getElementById("list");
    let row = ` <div class="form-row mt-3 mb-3 mx-2" id="${elementId}">
                   <div class="col-5">
                       <input type="text" name="VideoUrls" class="form-control" placeholder="اسکریپت آپارات">
                   </div>
                  
                   <div class="col">
                       <a onclick="RemoveUrl('${elementId}')" class="btn btn-danger text-white">حذف</a>
                   </div> 
                    <input type="hidden" name="Parameters.Index" value="${elementId}" />
                 </div>`

    list.insertAdjacentHTML('beforeend', row);
}
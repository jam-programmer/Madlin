function SubmitComment(dir,id) {

    let title =         document.getElementById("title").value;
    let message =       document.getElementById("message").value;
    let username =      document.getElementById("username").value;
    let phonenumber =   document.getElementById("phonenumber").value;
    if (!title || !message || !username || !phonenumber) {
        if (dir === "ltr") {
            Swal.fire({
                title: "Validation Error",
                text: "Please complete the form",
                icon: "warning",
                confirmButtonText: "I understand"
            });
        } else {
            Swal.fire({
                title: "خطای اعتبار سنجی",
                text: "لطفا فرم را تکمیل نمائید",
                icon: "warning",
                confirmButtonText: "متوجه شدم"
            });
        }
       
        return;
    }
    let body = {
        productId: id,
        title: title,
        message: message,
        username: username,
        phonenumber: phonenumber
    }
    rest.postAsync("/Product/SubmitQuestion", null, body, function (isSuccess, response) {
        document.getElementById("title").value="";
        document.getElementById("message").value = "";
        document.getElementById("username").value = "";
        document.getElementById("phonenumber").value = "";
        if (response.isSuccess) {
            if (dir === "ltr") {
                Swal.fire({
                    title: "Your comment was successfully submitted",
                    text: "It will be published after approval by experts",
                    icon: "success",
                    confirmButtonText: "I understand"
                });
            } else {
                Swal.fire({
                    title: "دیدگاه شما با موفقیت ثبت شد",
                    text: "بعد از تائید توسط کارشناسان منتشر میشود",
                    icon: "success",
                    confirmButtonText: "متوجه شدم"
                });
            }
          
           
        } else {
            if (dir === "ltr") {
                Swal.fire({
                    title: "Submission failed",
                    text: "It is currently not possible to submit a comment",
                   
                    icon: "warning",
                    confirmButtonText: "I understand"
                });
            } else {
                Swal.fire({
                    title: "ثبت انجام نشد",
                    text: "در حال حاضر امکان ثبت دیدگاه وجود ندارد",
              
                    icon: "warning",
                    confirmButtonText: "متوجه شدم"
                });
            }
           
        }
    });
}



function AddToWishList(productId, dir) {

    let body = {
        productId: productId
    }
    rest.postAsync("/Product/AddToWishList", null, body, function (isSuccess, response) {

        if (response.isSuccess) {
            if (dir === "ltr") {
                Swal.fire({
                    title: "Operation completed successfully",
                    text: "The product has been added to your wishlist",
                    icon: "success",
                    confirmButtonText: "Got it"
                });

            } else {
                Swal.fire({
                    title: "عملیات با موفقیت انجام شد",
                    text: "محصول به لیست علاقه مندی شما اضافه شد",
                    icon: "success",
                    confirmButtonText: "متوجه شدم"
                });
            }


        } else {
           
            if (dir === "ltr") {

                Swal.fire({
                    title: "Request failed",
            
                    html: response,
                    icon: "warning",
                    confirmButtonText: "I understand"
                });
            } else {
                Swal.fire({
                    title: "درخواست انجام نشد",
                    html: response,
                    icon: "warning",
                    confirmButtonText: "متوجه شدم"
                });
            }

        }
    });









}

function RemoveFromWishList(productId,dir) {
    let body = {
        productId: productId
    }

    rest.postAsync("/Product/RemoveFromWishList", null, body, function (isSuccess, response) {

        if (response.isSuccess) {
            if (dir === "ltr") {
                Swal.fire({
                    title: "Operation completed successfully",
                    text: "The product has been removed from your favorites list",
                    icon: "success",
                    confirmButtonText: "Got it"
                });

            } else {
                Swal.fire({
                    title: "عملیات با موفقیت انجام شد",
                    text: "محصول از لیست علاقه مندی شما حذف شد",
                    icon: "success",
                    confirmButtonText: "متوجه شدم"
                });
            }
            let item = document.getElementById("wish_" + productId);
            if (item) {
                item.remove();
            }

        } else {

            if (dir === "ltr") {

                Swal.fire({
                    title: "Request failed",

                    html: response,
                    icon: "warning",
                    confirmButtonText: "I understand"
                });
            } else {
                Swal.fire({
                    title: "درخواست انجام نشد",
                    html: response,
                    icon: "warning",
                    confirmButtonText: "متوجه شدم"
                });
            }

        }
    });
}

async function copyTextToClipboard(text,dir) {
    try {
        await navigator.clipboard.writeText(text);
        if (dir === "ltr") {
            Swal.fire({
                title: "The blog link has been copied",
                icon: "success",
                confirmButtonText: "Got it"
            });

        } else {
            Swal.fire({
                title: "آدرس مقاله کپی شد",
                icon: "success",
                confirmButtonText: "متوجه شدم"
            });
        }
    } catch (err) {
        console.error('خطا در کپی کردن متن: ', err);
    }
}



function JoinToNewsletter(dir) {
    let email = document.getElementById("subscribe-email").value;
    if (!email) {
        if (dir === "ltr") {
            Swal.fire({
                title: "Please Enter your email address",
                icon: "warning",
                confirmButtonText: "Got it"
            });

        } else {
            Swal.fire({
                title: "لطفا ایمیل خود را وارد کنید",
                icon: "warning",
                confirmButtonText: "متوجه شدم"
            });
        }
        return;
    }
    



    let body = {
        email: email
    }

    rest.postAsync("/Home/JoinToNewsletter", null, body, function (isSuccess, response) {

        if (response.isSuccess) {
            if (dir === "ltr") {
                Swal.fire({
                    title: "Operation completed successfully",
                    text: "Welcome to the MADLIN Newsletter",
                    icon: "success",
                    confirmButtonText: "Got it"
                });

            } else {
                Swal.fire({
                    title: "عملیات با موفقیت انجام شد",
                    text: "به خبرنامه مادلین خوش آمدید",
                    icon: "success",
                    confirmButtonText: "متوجه شدم"
                });
            }
            document.getElementById("subscribe-email").value = "";

        } else {

            if (dir === "ltr") {

                Swal.fire({
                    title: "Request failed",

                    html: response,
                    icon: "warning",
                    confirmButtonText: "I understand"
                });
            } else {
                Swal.fire({
                    title: "درخواست انجام نشد",
                    html: response,
                    icon: "warning",
                    confirmButtonText: "متوجه شدم"
                });
            }

        }
    });
}




function SendMessage(dir) {
    let email = document.getElementById("email").value;
    let name = document.getElementById("name").value;
    let message = document.getElementById("message").value;


    if (!name) {
        if (dir === "ltr") {
            Swal.fire({
                title: "Please Enter your name",
                icon: "warning",
                confirmButtonText: "Got it"
            });

        } else {
            Swal.fire({
                title: "لطفا نام و نام خانوادگی خود را وارد کنید",
                icon: "warning",
                confirmButtonText: "متوجه شدم"
            });
        }
        return;
    }

    if (!email) {
        if (dir === "ltr") {
            Swal.fire({
                title: "Please Enter your email address or phone number",
                icon: "warning",
                confirmButtonText: "Got it"
            });

        } else {
            Swal.fire({
                title: "لطفا ایمیل یا شماره تماس خود را وارد کنید",
                icon: "warning",
                confirmButtonText: "متوجه شدم"
            });
        } return;
    }

    if (!message) {
        if (dir === "ltr") {
            Swal.fire({
                title: "Please Enter your message",
                icon: "warning",
                confirmButtonText: "Got it"
            });

        } else {
            Swal.fire({
                title: "لطفا پیام خود را وارد کنید",
                icon: "warning",
                confirmButtonText: "متوجه شدم"
            });
        } return;
    }


   



    let body = {
        email: email,
        message: message,
        name: name
    }

    rest.postAsync("/Home/SendMessage", null, body, function (isSuccess, response) {
        document.getElementById("email").value = "";
        document.getElementById("name").value = "";
        document.getElementById("message").value = "";
        if (response.isSuccess) {
            if (dir === "ltr") {
                Swal.fire({
                    title: "Operation completed successfully",
                    text: "Your message has been sent successfully. We will contact you soon",
                    icon: "success",
                    confirmButtonText: "Got it"
                });

            } else {
                Swal.fire({
                    title: "عملیات با موفقیت انجام شد",
                    text: "پیام شما با موفقیت ارسال شد بزودی با شما ارتباط برقرار خواهیم کرد",
                    icon: "success",
                    confirmButtonText: "متوجه شدم"
                });
            }
            document.getElementById("subscribe-email").value = "";

        } else {

            if (dir === "ltr") {

                Swal.fire({
                    title: "Request failed",

                    html: response,
                    icon: "warning",
                    confirmButtonText: "I understand"
                });
            } else {
                Swal.fire({
                    title: "درخواست انجام نشد",
                    html: response,
                    icon: "warning",
                    confirmButtonText: "متوجه شدم"
                });
            }

        }
    });
}
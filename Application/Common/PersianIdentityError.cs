using Microsoft.AspNetCore.Identity;
using System.Globalization;
namespace Application.Common;
public class PersianIdentityError : IdentityErrorDescriber
{

    public override IdentityError DefaultError()
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.DefaultError();
        }
        return new IdentityError
        {
            Code = nameof(DefaultError),
            Description = "یک خطای ناشناخته رخ داده است."
        };
    }
    public override IdentityError ConcurrencyFailure()
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.ConcurrencyFailure();
        }

        return new IdentityError
        {
            Code = nameof(ConcurrencyFailure),
            Description = "رکورد جاری پیشتر ویرایش شده‌است و تغییرات شما آن‌را بازنویسی خواهد کرد."
        };
    }
    public override IdentityError PasswordMismatch()
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.PasswordMismatch();
        }

        return new IdentityError
        {
            Code = nameof(PasswordMismatch),
            Description = "کلمه عبور نادرست است."
        };
    }
    public override IdentityError InvalidToken()
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.InvalidToken();
        }

        return new IdentityError
        {
            Code = nameof(InvalidToken),
            Description = "کلمه عبور نامعتبر است."
        };
    }
    public override IdentityError LoginAlreadyAssociated()
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.LoginAlreadyAssociated();
        }

        return new IdentityError
        {
            Code = nameof(LoginAlreadyAssociated),
            Description = "این کاربر قبلأ اضافه شده‌است."
        };
    }
    public override IdentityError InvalidUserName(string userName)
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.InvalidUserName( userName);
        }

        return new IdentityError
        {
            Code = nameof(InvalidUserName),
            Description = $"کدملی '{userName}' نامعتبر است، فقط می تواند حاوی اعداد باشد."
        };
    }
    public override IdentityError InvalidEmail(string email)
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.InvalidEmail(email);
        }

        return new IdentityError
        {
            Code = nameof(InvalidEmail),
            Description = $"ایمیل '{email}' نامعتبر است."
        };
    }
    public override IdentityError DuplicateUserName(string userName)
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.DuplicateUserName(userName);
        }

        return new IdentityError
        {
            Code = nameof(DuplicateUserName),
            Description = $"این نام کدملی '{userName}' به کاربر دیگری اختصاص یافته است."
        };
    }
    public override IdentityError DuplicateEmail(string email)
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.DuplicateEmail(email);
        }

        return new IdentityError
        {
            Code = nameof(DuplicateEmail),
            Description = $"ایمیل '{email}' به کاربر دیگری اختصاص یافته است."
        };
    }
    public override IdentityError InvalidRoleName(string role)
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.InvalidRoleName(role);
        }

        return new IdentityError
        {
            Code = nameof(InvalidRoleName),
            Description = $"نام نقش '{role}' نامعتبر است."
        };
    }
    public override IdentityError DuplicateRoleName(string role)
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.DuplicateRoleName(role);
        }

        return new IdentityError
        {
            Code = nameof(DuplicateRoleName),
            Description = $"این نام نقش '{role}' به کاربر دیگری اختصاص یافته است."
        };
    }
    public override IdentityError UserAlreadyHasPassword()
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.UserAlreadyHasPassword();
        }

        return new IdentityError
        {
            Code = nameof(UserAlreadyHasPassword),
            Description = "کلمه‌ی عبور کاربر قبلأ تنظیم شده‌است."
        };
    }
    public override IdentityError UserLockoutNotEnabled()
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.UserLockoutNotEnabled();
        }

        return new IdentityError
        {
            Code = nameof(UserLockoutNotEnabled),
            Description = "این کاربر فعال است."
        };
    }
    public override IdentityError UserAlreadyInRole(string role)
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.UserAlreadyInRole(role);
        }

        return new IdentityError
        {
            Code = nameof(UserAlreadyInRole),
            Description = $"این نقش '{role}' قبلأ به این کاربر اختصاص یافته است."
        };
    }
    public override IdentityError UserNotInRole(string role)
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.UserNotInRole(role);
        }

        return new IdentityError
        {
            Code = nameof(UserNotInRole),
            Description = $"این نقش '{role}' قبلأ به این کاربر اختصاص نیافته است."
        };
    }
    public override IdentityError PasswordTooShort(int length)
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.PasswordTooShort(length);
        }

        return new IdentityError
        {
            Code = nameof(PasswordTooShort),
            Description = $"کلمه عبور باید حداقل {length} کاراکتر باشد."
        };
    }
    public override IdentityError PasswordRequiresNonAlphanumeric()
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.PasswordRequiresNonAlphanumeric();
        }

        return new IdentityError
        {
            Code = nameof(PasswordRequiresNonAlphanumeric),
            Description = "کلمه عبور باید حداقل یک کاراکتر غیر از حروف الفبا داشته باشد."
        };
    }
    public override IdentityError PasswordRequiresDigit()
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.PasswordRequiresDigit();
        }

        return new IdentityError
        {
            Code = nameof(PasswordRequiresDigit),
            Description = "کلمه عبور باید حداقل یک عدد داشته باشد."
        };
    }
    public override IdentityError PasswordRequiresLower()
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.PasswordRequiresLower();
        }
        return new IdentityError
        {
            Code = nameof(PasswordRequiresLower),
            Description = "کلمه عبور باید حداقل یک حرف کوچک داشته باشد."
        };
    }
    public override IdentityError PasswordRequiresUpper()
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.PasswordRequiresUpper();
        }

        return new IdentityError
        {
            Code = nameof(PasswordRequiresUpper),
            Description = "کلمه عبور باید حداقل یک حرف بزرگ داشته باشد."
        };
    }
    public override IdentityError RecoveryCodeRedemptionFailed()
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.RecoveryCodeRedemptionFailed();
        }

        return new IdentityError
        {
            Code = nameof(RecoveryCodeRedemptionFailed),
            Description = "بازیابی ناموفق بود."
        };
    }
    public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
    {
        if (CultureInfo.CurrentUICulture.Name == "en-US")
        {
            return base.PasswordRequiresUniqueChars(uniqueChars);
        }

        return new IdentityError
        {
            Code = nameof(PasswordRequiresUniqueChars),
            Description = $"کلمه عبور باید حداقل داراى {uniqueChars} حرف متفاوت باشد."
        };
    }

}
using IPE.SmsIrClient;
using Microsoft.Identity.Client;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Services.Sms;


#region Sms_Ir
public class VerifySendParameterModel
{
    public string Name { get; set; }
    public string Value { get; set; }
}
public class VerifySendModel
{
    public string Mobile { get; set; }
    public int TemplateId { get; set; }
    public List<VerifySendParameterModel> Parameters { get; set; }
}

public class SmsIrResponse
{
    public object? data { get; set; }
    public string? message { get; set; }
    public int status { get; set; }
}
#endregion



public class SmsService : ISmsService
{
    readonly IGeneralRepository _generalRepository;
    readonly IHttpClientFactory _httpClientFactory;
    public SmsService(IGeneralRepository generalRepository, IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _generalRepository = generalRepository;
    }

    public async Task SendSmsWithExclusiveNumberAsync(ExclusiveNumberDto model)
    {
        (string token, string number) smsInfo = await _generalRepository.GetSmsInfoAsync();

        try
        {
            SmsIr smsIr = new SmsIr(smsInfo.token);

            var bulkSendResult =
                await smsIr.BulkSendAsync(Convert.ToInt64(smsInfo.number),
                model.Message, model.PhoneNumbers);

            if (bulkSendResult.Status != 1)
            {
                ErrorMessage(bulkSendResult.Status);
            }
        }
        catch (Exception ex) 
        {
            throw;
        }
    }

    public async Task SendSmsWithGeneralNumberAsync(GeneralNumberDto data)
    {
        (string token, string number) smsInfo = await _generalRepository.GetSmsInfoAsync();
        SmsIr smsIr = new(smsInfo.token);




     






        try
        {
            HttpClient client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("x-api-key", smsInfo.token);
            List<VerifySendParameterModel> parameters = [];
            foreach (var parameter in data.Parameters!)
            {
                parameters.Add(new VerifySendParameterModel()
                {
                    Name = parameter.Key!,
                    Value = parameter.Value!
                });
            }
            VerifySendModel model = new VerifySendModel()
            {
                Mobile = data.PhoneNumber!,
                TemplateId = data.TemplateCode,
                Parameters = parameters

            };
            string payload = JsonSerializer.Serialize(model);
            StringContent stringContent = new(payload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://api.sms.ir/v1/send/verify",
                stringContent);

            string content = await response.Content.ReadAsStringAsync();
            SmsIrResponse smsIrResponse = JsonSerializer.Deserialize<SmsIrResponse>(content)!;
            if (smsIrResponse.status != 1)
            {
                ErrorMessage(smsIrResponse.status);
            }

        }
        catch (Exception ex)
        {

            throw ;
        }

    }
    void ErrorMessage(in int status)
    {
        string message = status switch
        {
            0 => "درخواست شما با خطا مواجه شده‌است.",
            10 => "کلید وب سرویس نامعتبر است",
            11 => "کلید وب سرویس غیرفعال است",
            12 => "کلید وب سرویس محدود به آی‌پی‌های تعریف شده می‌باشد.",
            13 => "حساب کاربری غیرفعال است",
            14 => "حساب کاربری در حالت تعلیق قرار دارد",
            15 => "به منظور استفاده از وب سرویس پلن خود را ارتقا دهید",
            16 => "مقدار ارسالی پارامتر نادرست می‌باشد",
            20 => "تعداد درخواست بیشتر از حد مجاز است",
            101 => "شماره خط نامعتبر میباشد",
            102 => "اعتبار کافی نمیباشد",
            103 => "درخواست شما دارای متن (های) خالی است",
            104 => "درخواست شما دارای موبایل (های) نادرست است",
            105 => "تعداد موبایل ها بیشتر از حد مجاز (100 عدد) میباشد",
            106 => "تعداد متن ها بیشتر از حد مجاز (100 عدد) میباشد",
            107 => "لیست موبایل ها خالی میباشد",
            108 => "لیست متن ها خالی میباشد",
            109 => "زمان ارسال نامعتبر میباشد",
            110 => "تعداد شماره موبایل ها و تعداد متن ها برابر نیستند",
            111 => "با این شناسه ارسالی ثبت نشده است",
            112 => "رکوردی برای حذف یافت نشد",
            113 => "قالب یافت نشد",
            114 => "طول رشته مقدار پارامتر، بیش از حد مجاز (25 کاراکتر) میباشد",
            115 => "شماره موبایل(ها) در لیست سیاه سامانه می‌باشند",
            116 => "نام یک یا چند پارامتر مقداردهی نشده‌است. لطفا به بخش مستندات ارسال وریفای مراجعه فرمایید",
            117 => "متن ارسال شده مورد تایید نمی‌باشد",
            118 => "تعداد پیام ها بیشتر از حد مجاز میباشد",
            119 => "به منظور استفاده از قالب‌ شخصی سازی شده پلن خود را ارتقا دهید",
            123 => "خط ارسال‌کننده نیاز به فعال‌سازی دارد.",
            124 => "درحال حاضر، فقط امکان ارسال پیامک OTP وجود دارد و قالب شما OTP شناسایی نشده است!",

            _ => "خطای پیش بینی نشده رخ داده است"
        };
        throw new InternalException(message);
    }
}

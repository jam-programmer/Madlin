using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOI.POIFS.Properties;

namespace Infrastructure.Mapping;

internal sealed class RouteMap : IEntityTypeConfiguration<RouteEntity>
{
    public void Configure(EntityTypeBuilder<RouteEntity> builder)
    {
        builder.ToTable("Route", "dbo");

        builder.HasData(new RouteEntity()
        {
            Id = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"),
            Order = 10,
            Name = "اطلاعات پایه",
            Icon = "<i class=\"icon ti-layers\"></i>",
            UniqueId = "navigationBase",
            Url = string.Empty,
            ParentId = Guid.Empty,
            ControllerName = string.Empty,
        }
        , new RouteEntity()
        {
            Id = Guid.Parse("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
            Order = 20,
            Name = "مدیریت محصولات",
            Icon = "<i class=\"icon ti-package\"></i>",
            UniqueId = "navigationProduct",
            Url = string.Empty,
            ControllerName = string.Empty,
            ParentId = Guid.Empty
        }
        , new RouteEntity()
        {
            Id = Guid.Parse("6ba7b810-9dad-11d1-80b4-00c04fd430c8"),
            Order = 30,
            Name = "مدیریت کاربران",
            Icon = "<i class=\"icon ti-user\"></i>",
            UniqueId = "navigationUser",
            Url = string.Empty,
            ControllerName = string.Empty,
            ParentId = Guid.Empty
        }

        , new RouteEntity()
        {
            Id = Guid.Parse("9cb8b710-9dad-12c4-60b4-00c05fd430c8"),
            Order = 40,
            Name = "سامانه پیامک",
            Icon = "<i class=\"icon ti-comment\"></i>",
            UniqueId = "navigationSms",
            Url = string.Empty,
            ControllerName = string.Empty,
            ParentId = Guid.Empty
        }


        , new RouteEntity()
        {
            Id = Guid.Parse("1cb1b110-9bab-12c1-10c4-00c05fc430c8"),
            Order = 50,
            Name = "رسانه",
            Icon = "<i class=\"icon ti-gallery\"></i>",
            UniqueId = "navigationMedia",
            Url = string.Empty,
            ControllerName = string.Empty,
            ParentId = Guid.Empty
        }







        #region Product
        , new RouteEntity()
        {
            Id = Guid.Parse("01234567-89ab-cdef-0123-456789abcdef"),
            Order = 21,
            Name = "دسته بندی محصولات",
            Icon = string.Empty,
            UniqueId = string.Empty,
            Url = "/Admin/ProductCategory/Index",
            ControllerName = "ProductCategory",
            ParentId = Guid.Parse("f47ac10b-58cc-4372-a567-0e02b2c3d479")
        }
        , new RouteEntity()
        {
            Id = Guid.Parse("e4d909c2-d4d8-4b6e-9b9d-1c3a4b5c6d7e"),
            Order = 22,
            Name = "محصولات",
            Icon = string.Empty,
            UniqueId = string.Empty,
            Url = "/Admin/Product/Index",
            ControllerName = "Product",
            ParentId = Guid.Parse("f47ac10b-58cc-4372-a567-0e02b2c3d479")
        }
         , new RouteEntity()
         {
             Id = Guid.Parse("c6b909c2-d6d8-4b6e-7b2d-1c3a3b8c6d1e"),
             Order = 23,
             Name = "دیدگاه ها",
             Icon = string.Empty,
             UniqueId = string.Empty,
             Url = "/Admin/Comment/Index",
             ControllerName = "Comment",
             ParentId = Guid.Parse("f47ac10b-58cc-4372-a567-0e02b2c3d479")
         }

         #endregion

         #region Identity
          , new RouteEntity()
          {
              Id = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3301"),
              Order = 31,
              Name = "‌نقش های کاربری",
              Icon = string.Empty,
              UniqueId = string.Empty,
              Url = "/Admin/Role/Index",
              ControllerName = "Role",
              ParentId = Guid.Parse("6ba7b810-9dad-11d1-80b4-00c04fd430c8")
          }
        , new RouteEntity()
        {
            Id = Guid.Parse("21f202f2-4f89-11d3-9a0c-0305e82c3301"),
            Order = 32,
            Name = "کاربران",
            Icon = string.Empty,
            UniqueId = string.Empty,
            Url = "/Admin/User/Index",
            ControllerName = "User",
            ParentId = Guid.Parse("6ba7b810-9dad-11d1-80b4-00c04fd430c8")
        }
        #endregion


        #region Base

        , new RouteEntity()
        {
            Id = Guid.Parse("7d444840-9dc0-11d1-b245-5ffdce74fad2"),
            Order = 11,
            Name = "سوالات متداول",
            Icon = string.Empty,
            UniqueId = string.Empty,
            Url = "/Admin/Question/Index",
            ControllerName = "Question",
            ParentId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d")
        }
        , new RouteEntity()
        {
            Id = Guid.Parse("8c5e3f1a-9d5f-4b6a-8c7d-0e1f2a3b4c5d"),
            Order = 12,
            Name = "دسته بندی مقالات",
            Icon = string.Empty,
            UniqueId = string.Empty,
            Url = "/Admin/BlogCategory/Index",
            ControllerName = "BlogCategory",
            ParentId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d")
        }
        , new RouteEntity()
        {
            Id = Guid.Parse("9f8e7d6c-5b4a-3c2d-1e0f-123456789abc"),
            Order = 13,
            Name = "برچسب ها",
            Icon = string.Empty,
            UniqueId = string.Empty,
            Url = "/Admin/Tag/Index",
            ControllerName = "Tag",
            ParentId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d")

        }



         , new RouteEntity()
         {
             Id = Guid.Parse("b6c7f8d9-e0a1-4b2c-8d3e-0f1a2b3c4d5e"),
             Order = 14,
             Name = "مقالات",
             Icon = string.Empty,
             UniqueId = string.Empty,
             Url = "/Admin/Blog/Index",
             ControllerName = "Blog",
             ParentId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d")
         }



        , new RouteEntity()
        {
            Id = Guid.Parse("c8d9e0f1-a2b3-4c5d-6e7f-8a9b0c1d2e3f"),
            Order = 15,
            Name = "تنظیمات",
            Icon = string.Empty,
            UniqueId = string.Empty,
            Url = "/Admin/Setting/General",
            ControllerName = "Setting",
            ParentId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d")
        }


          , new RouteEntity()
          {
              Id = Guid.Parse("a4d4a0f1-e5f6-4a7b-8c9d-6a7b0c4b2a3f"),
              Order = 18,
              Name = "عناوین",
              Icon = string.Empty,
              UniqueId = string.Empty,
              Url = "/Admin/Setting/Header",
              ControllerName = "Setting",
              ParentId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d")
          }, new RouteEntity()
          {
              Id = Guid.Parse("f4d2a0f1-a5d1-5a7b-3c9d-6a7b0c7e2a3e"),
              Order = 19,
              Name = "خبرنامه",
              Icon = string.Empty,
              UniqueId = string.Empty,
              Url = "/Admin/Newsletter/Index",
              ControllerName = "Newsletter",
              ParentId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d")
          }, new RouteEntity()
          {
              Id = Guid.Parse("a7d4a5f6-a5d1-567b-2c2d-6a2b0c2e2a3e"),
              Order = 19,
              Name = "درباره ما",
              Icon = string.Empty,
              UniqueId = string.Empty,
              Url = "/Admin/Setting/About",
              ControllerName = "Setting",
              ParentId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d")
          }, new RouteEntity()
          {
              Id = Guid.Parse("b7a4a3f2-a4d8-567b-2c2d-6a2b0c2e2a3e"),
              Order = 19,
              Name = "پیام های ارتباطی",
              Icon = string.Empty,
              UniqueId = string.Empty,
              Url = "/Admin/Message/Index",
              ControllerName = "Message",
              ParentId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d")
          }
          , new RouteEntity()
          {
              Id = Guid.Parse("c3a3a3f3-a4d8-434b-2c2d-6c2c0c2e2a3e"),
              Order = 19,
              Name = "صفحات",
              Icon = string.Empty,
              UniqueId = string.Empty,
              Url = "/Admin/Page/Index",
              ControllerName = "Page",
              ParentId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d")
          }


            , new RouteEntity()
            {
                Id = Guid.Parse("a4a9a9f1-a5d5-123b-4c4d-6c2c0c3a3a3e"),
                Order = 19,
                Name = "اطلاعیه",
                Icon = string.Empty,
                UniqueId = string.Empty,
                Url = "/Admin/Notification/Index",
                ControllerName = "Notification",
                ParentId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d")
            }
            #endregion

            #region SMS
             , new RouteEntity()
             {
                 Id = Guid.Parse("b4b8a8b1-a5d5-123b-5c5d-6c2c0c8a8a3e"),
                 Order = 41,
                 Name = "بانک شماره موبایل",
                 Icon = string.Empty,
                 UniqueId = string.Empty,
                 Url = "/Admin/Bank/Index",
                 ControllerName = "Bank",
                 ParentId = Guid.Parse("9cb8b710-9dad-12c4-60b4-00c05fd430c8")
             }
             , new RouteEntity()
             {
                 Id = Guid.Parse("b5b5a5b7-a5d5-123b-5c5d-6c2c4c8a8a4a"),
                 Order = 42,
                 Name = "ارسال پیامک",
                 Icon = string.Empty,
                 UniqueId = string.Empty,
                 Url = "/Admin/Sms/Index",
                 ControllerName = "Sms",
                 ParentId = Guid.Parse("9cb8b710-9dad-12c4-60b4-00c05fd430c8")
             }

             #endregion




             #region Media
               , new RouteEntity()
               {
                   Id = Guid.Parse("c3d6e0f1-a0b3-4c5d-6e5f-8a1b0c4d2e3f"),
                   Order = 51,
                   Name = "بنر های تبلیغاتی",
                   Icon = string.Empty,
                   UniqueId = string.Empty,
                   Url = "/Admin/Setting/AdvertisingBanner",
                   ControllerName = "Setting",
                   ParentId = Guid.Parse("1cb1b110-9bab-12c1-10c4-00c05fc430c8")
               }
         , new RouteEntity()
         {
             Id = Guid.Parse("c3d4a0f1-a2b3-4b3d-6e5f-6a4b0c4b2e3f"),
             Order = 52,
             Name = "گالری تصاویر",
             Icon = string.Empty,
             UniqueId = string.Empty,
             Url = "/Admin/Image/Index",
             ControllerName = "Image",
             ParentId = Guid.Parse("1cb1b110-9bab-12c1-10c4-00c05fc430c8")
         }

         
           , new RouteEntity()
           {
               Id = Guid.Parse("c2c7a9f1-a5d5-424b-2c2d-6c2c0c2e2a3e"),
               Order = 53,
               Name = "اسلایدر",
               Icon = string.Empty,
               UniqueId = string.Empty,
               Url = "/Admin/Slider/Index",
               ControllerName = "Slider",
               ParentId = Guid.Parse("1cb1b110-9bab-12c1-10c4-00c05fc430c8")
           }

            , new RouteEntity()
            {
                Id = Guid.Parse("c3c3a3f3-a5d5-424a-5c5d-7c7c0c9e2a9c"),
                Order = 54,
                Name = "رویداد ها",
                Icon = string.Empty,
                UniqueId = string.Empty,
                Url = "/Admin/Event/Index",
                ControllerName = "Event",
                ParentId = Guid.Parse("1cb1b110-9bab-12c1-10c4-00c05fc430c8")
            }



            #endregion









        );




    }
}

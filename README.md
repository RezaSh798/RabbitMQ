# Simple RabbitMQ Messaging with .NET

این پروژه یک نمونه ساده از ارسال و دریافت پیام با استفاده از RabbitMQ در دات‌نت است. پروژه شامل دو قسمت است:

- `Producer`: ارسال پیام‌ها به صف `news`
- `Consumer`: دریافت پیام‌ها از صف `news`

## پیش‌نیازها

- [.NET 9.0 SDK یا بالاتر](https://dotnet.microsoft.com/en-us/download)
- [RabbitMQ Server](https://www.rabbitmq.com/download.html)
  - می‌توانید از Docker نیز استفاده کنید:

    ```bash
    docker run -d --hostname my-rabbit --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
    ```

    سپس UI مدیریت RabbitMQ در آدرس [http://localhost:15672](http://localhost:15672) در دسترس خواهد بود.
    - **نام کاربری:** guest
    - **رمز عبور:** guest

## ساختار پروژه

```
RabbitMqDemo.sln
├── Producer/
│   └── Program.cs
└── Consumer/
    └── Program.cs
```

## نحوه اجرا

### اجرای Producer

ابتدا مطمئن شوید که RabbitMQ در حال اجراست. سپس از داخل دایرکتوری `Producer` دستور زیر را اجرا کنید:

```bash
dotnet run
```

این برنامه هر ۲ ثانیه یک پیام جدید تولید کرده و به صف `news` در RabbitMQ می‌فرستد.

### اجرای Consumer

در یک ترمینال جداگانه وارد دایرکتوری `Consumer` شوید و دستور زیر را اجرا کنید:

```bash
dotnet run
```

این برنامه به صف `news` متصل می‌شود و پیام‌ها را دریافت کرده و در کنسول چاپ می‌کند.

## جزئیات فنی

- صف `news` با گزینه‌های زیر ایجاد می‌شود:
  - `durable = true`: پیام‌ها در صورت ری‌استارت RabbitMQ باقی می‌مانند.
  - `exclusive = false`: صف قابل دسترسی برای سایر کانکشن‌ها نیز هست.
  - `autoDelete = false`: صف به‌صورت خودکار حذف نمی‌شود.

- پیام‌ها به صورت `persistent` منتشر می‌شوند تا در صورت ری‌استارت RabbitMQ از بین نروند.

## توسعه‌دهندگان

- این پروژه فقط جنبه‌ی آموزشی دارد و برای شروع یادگیری RabbitMQ در دات‌نت مناسب است.
- جهت توسعه بیشتر می‌توانید قابلیت‌هایی مانند exchange، routing، topic و غیره را نیز اضافه کنید.

## منابع بیشتر

- [RabbitMQ Tutorials](https://www.rabbitmq.com/getstarted.html)
- [RabbitMQ .NET Client](https://github.com/rabbitmq/rabbitmq-dotnet-client)
# 🗄️ راهنمای اجرای Migration

## فایل: `AddCommunityPortalFields.sql`

این Migration فیلدهای مورد نیاز برای قابلیت جامعه‌های مشتریان در پرتال را به جدول `CustomerSegment` اضافه می‌کند.

---

## 🚀 نحوه اجرا

### روش 1: SQL Server Management Studio (SSMS)

1. باز کردن SSMS
2. اتصال به دیتابیس
3. File → Open → File
4. انتخاب فایل `AddCommunityPortalFields.sql`
5. **تغییر نام دیتابیس در خط 7** (اگر لازم است):
   ```sql
   USE [ClubDatabase]; -- نام دیتابیس خود را جایگزین کنید
   ```
6. کلیک بر روی Execute (F5)

### روش 2: sqlcmd (Command Line)

```bash
sqlcmd -S localhost -d ClubDatabase -i AddCommunityPortalFields.sql
```

### روش 3: Azure Data Studio

1. باز کردن Azure Data Studio
2. اتصال به دیتابیس
3. File → Open File
4. انتخاب فایل `AddCommunityPortalFields.sql`
5. تغییر نام دیتابیس (در صورت نیاز)
6. Run (F5)

---

## 📋 تغییرات اعمال شده

این Migration **4 ستون جدید** به جدول `CustomerSegment` اضافه می‌کند:

| ستون | نوع | Nullable | پیش‌فرض | توضیحات |
|------|-----|----------|---------|---------|
| `JoinMode` | `INT` | NO | `1` | نحوه عضویت (1=SystemOnly, 2=WithConditionCheck, 3=WithoutConditionCheck) |
| `IsVisibleInPortal` | `BIT` | NO | `0` | قابلیت نمایش در پرتال مشتریان |
| `ImageUrl` | `NVARCHAR(512)` | YES | `NULL` | آدرس تصویر جامعه |
| `Benefits` | `NVARCHAR(2000)` | YES | `NULL` | مزایای عضویت به صورت JSON Array |

---

## ✅ بررسی موفقیت‌آمیز بودن

بعد از اجرای Migration، این Query را اجرا کنید:

```sql
-- بررسی وجود ستون‌ها
SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    IS_NULLABLE,
    COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'CustomerSegment'
AND COLUMN_NAME IN ('JoinMode', 'IsVisibleInPortal', 'ImageUrl', 'Benefits')
ORDER BY COLUMN_NAME;
```

**خروجی مورد انتظار:**

```
COLUMN_NAME          DATA_TYPE      IS_NULLABLE  COLUMN_DEFAULT
-----------------------------------------------------------------
Benefits            nvarchar        YES          NULL
ImageUrl            nvarchar        YES          NULL
IsVisibleInPortal   bit             NO           ((0))
JoinMode            int             NO           ((1))
```

---

## 🔄 Rollback (در صورت نیاز)

اگر نیاز به برگشت تغییرات دارید:

```sql
USE [ClubDatabase];
GO

-- حذف ستون‌های اضافه شده
ALTER TABLE [dbo].[CustomerSegment] DROP COLUMN IF EXISTS [JoinMode];
ALTER TABLE [dbo].[CustomerSegment] DROP COLUMN IF EXISTS [IsVisibleInPortal];
ALTER TABLE [dbo].[CustomerSegment] DROP COLUMN IF EXISTS [ImageUrl];
ALTER TABLE [dbo].[CustomerSegment] DROP COLUMN IF EXISTS [Benefits];

PRINT 'Rollback completed successfully!';
GO
```

---

## ⚠️ نکات مهم

1. **Backup:** قبل از اجرای Migration حتماً از دیتابیس Backup بگیرید
2. **Environment:** ابتدا روی محیط Development تست کنید
3. **Permissions:** اطمینان حاصل کنید که دسترسی ALTER TABLE دارید
4. **نام دیتابیس:** نام دیتابیس را در خط 7 تغییر دهید
5. **Idempotent:** این اسکریپت Idempotent است (می‌توان چند بار اجرا کرد)

---

## 🧪 تست بعد از Migration

```sql
-- تست 1: Insert یک رکورد نمونه
INSERT INTO CustomerSegment (
    TenantId, Title, Description, IsActive, 
    JoinMode, IsVisibleInPortal, ImageUrl, Benefits,
    CreatedDate, CreatedBy
)
VALUES (
    1, 
    N'جامعه تست',
    N'این یک جامعه تست است',
    1,
    2, -- WithConditionCheck
    1, -- نمایش در پرتال
    'https://example.com/test.jpg',
    N'["مزیت 1", "مزیت 2", "مزیت 3"]',
    GETDATE(),
    1
);

-- تست 2: Select و بررسی
SELECT TOP 1 
    Id, Title, JoinMode, IsVisibleInPortal, ImageUrl, Benefits
FROM CustomerSegment
WHERE Title = N'جامعه تست';

-- تست 3: پاک کردن رکورد تست
DELETE FROM CustomerSegment WHERE Title = N'جامعه تست';
```

---

## 📞 پشتیبانی

در صورت بروز خطا:
1. بررسی پیام خطا در SSMS
2. بررسی دسترسی‌های کاربر دیتابیس
3. اطمینان از اتصال به دیتابیس صحیح
4. مراجعه به تیم DBA

---

✅ **موفق باشید!**


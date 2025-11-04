-- =============================================
-- Migration: Add Community Portal Fields to CustomerSegment
-- Date: 2024-11-02
-- Description: اضافه کردن فیلدهای مورد نیاز برای قابلیت عضویت مشتریان در جامعه‌ها از طریق پرتال
-- =============================================

USE [ClubDatabase]; -- نام دیتابیس خود را جایگزین کنید
GO

-- بررسی وجود ستون‌ها قبل از اضافه کردن
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[CustomerSegment]') AND name = 'JoinMode')
BEGIN
    ALTER TABLE [dbo].[CustomerSegment]
    ADD [JoinMode] INT NOT NULL DEFAULT 1; -- 1 = SystemOnly
    
    PRINT 'Column JoinMode added to CustomerSegment table';
END
ELSE
BEGIN
    PRINT 'Column JoinMode already exists in CustomerSegment table';
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[CustomerSegment]') AND name = 'IsVisibleInPortal')
BEGIN
    ALTER TABLE [dbo].[CustomerSegment]
    ADD [IsVisibleInPortal] BIT NOT NULL DEFAULT 0; -- False by default
    
    PRINT 'Column IsVisibleInPortal added to CustomerSegment table';
END
ELSE
BEGIN
    PRINT 'Column IsVisibleInPortal already exists in CustomerSegment table';
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[CustomerSegment]') AND name = 'ImageUrl')
BEGIN
    ALTER TABLE [dbo].[CustomerSegment]
    ADD [ImageUrl] NVARCHAR(512) NULL;
    
    PRINT 'Column ImageUrl added to CustomerSegment table';
END
ELSE
BEGIN
    PRINT 'Column ImageUrl already exists in CustomerSegment table';
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[CustomerSegment]') AND name = 'Benefits')
BEGIN
    ALTER TABLE [dbo].[CustomerSegment]
    ADD [Benefits] NVARCHAR(2000) NULL;
    
    PRINT 'Column Benefits added to CustomerSegment table';
END
ELSE
BEGIN
    PRINT 'Column Benefits already exists in CustomerSegment table';
END
GO

PRINT '========================================';
PRINT 'Migration completed successfully!';
PRINT '========================================';
GO

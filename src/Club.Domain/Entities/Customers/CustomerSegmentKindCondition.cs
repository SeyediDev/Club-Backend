using Club.Domain.Entities.Customers.Enums;

namespace Club.Domain.Entities.Customers;

/// <summary>
/// شرط نوع جامعه مشتریان - تعریف شرط‌های خاص برای انواع مختلف جامعه‌های مشتریان
/// این موجودیت امکان تعریف شرط‌های دقیق بر اساس پارامترهای مشتری را فراهم می‌کند
/// </summary>
[DisplayName("شرط‌های جامعه‌سازی")]
public class CustomerSegmentKindCondition : ClubBaseCoreAuditableEntity<int>
{
    public int CustomerSegmentId { get; set; }

    [DisplayName("جامعه مشتریان")]
    [SBVR(SBVRModality.Obligatory, "جامعه مشتریان", "هر شرط باید به یک جامعه مشخص تعلق داشته باشد")]
    public CustomerSegment CustomerSegment { get; set; } = null!;

    [DisplayName("نوع جامعه")]
    [SBVR(SBVRModality.Obligatory, "نوع جامعه", "نوع جامعه تعیین می‌کند که جامعه چگونه تعریف شده است")]
    [SBVR(SBVRModality.Recommended, "نوع جامعه", "انتخاب نوع صحیح باعث مدیریت بهتر جامعه می‌شود")]
    public CustomerSegmentKind Kind { get; set; }

    [DisplayName("عنوان شرط")]
    [MaxLength(100)]
    [SBVR(SBVRModality.Obligatory, "عنوان شرط", "عنوان شرط باید واضح و توصیفی باشد")]
    [SBVR(SBVRModality.Recommended, "عنوان شرط", "عنوان باید شامل نوع شرط و معیارهای کلیدی باشد")]
    public string Title { get; set; } = null!;


    [DisplayName("توضیحات شرط")]
    [MaxLength(500)]
    [SBVR(SBVRModality.Recommended, "توضیحات شرط", "توضیحات باید شامل منطق و نحوه ارزیابی شرط باشد")]
    public string? Description { get; set; }

    [DisplayName("اولویت")]
    [SBVR(SBVRModality.Recommended, "اولویت شرط", "اولویت تعیین می‌کند که کدام شرط زودتر بررسی شود")]
    [SBVR(SBVRModality.Permitted, "اولویت شرط", "اولویت 1 بالاترین و اولویت 10 پایین‌ترین است")]
    public int Priority { get; set; } = 1;

    [DisplayName("گروه شرط")]
    [SBVR(SBVRModality.Permitted, "گروه شرط", "گروه شرط برای دسته‌بندی شرط‌های مرتبط استفاده می‌شود. شرط‌های یک گروه با هم And می شوند. و شرط‌های گروه های مختلف با هم Or می شوند ")]
    public ConditionGroup? ConditionGroup { get; set; }

    [DisplayName("نوع شرط")]
    [SBVR(SBVRModality.Recommended, "نوع شرط", "نوع شرط تعیین می‌کند که چگونه شرط ارزیابی شود")]
    public CustomerSegmentConditionKind ConditionKind { get; set; }

    [DisplayName("فرمول شرط")]
    [MaxLength(512)]
    [SBVR(SBVRModality.Permitted, "فرمول شرط", "فرمول شرط برای شرط‌های پیچیده استفاده می‌شود")]
    public string? Constraint { get; set; }

    [DisplayName("مقایسه شود با")]
    [SBVR(SBVRModality.Permitted, "مقایسه شود با", "تعیین می‌کند که شرط با چه چیزی مقایسه شود")]
    public CustomerSegmentCompareWith? CompareWith { get; set; }

    [DisplayName("مقدار شرط")]
    [MaxLength(512)]
    [SBVR(SBVRModality.Permitted, "مقدار شرط", "مقدار مورد نظر برای مقایسه")]
    public string? Value { get; set; }

    [DisplayName("حداقل امتیاز")]
    [SBVR(SBVRModality.Permitted, "حداقل امتیاز", "حداقل امتیاز مورد نیاز برای برقراری شرط")]
    public decimal? MinScore { get; set; }

    [DisplayName("حداکثر امتیاز")]
    [SBVR(SBVRModality.Permitted, "حداکثر امتیاز", "حداکثر امتیاز مجاز برای برقراری شرط")]
    public decimal? MaxScore { get; set; }

    [DisplayName("پیام خطا")]
    [MaxLength(200)]
    [SBVR(SBVRModality.Permitted, "پیام خطا", "پیام خطا در صورت عدم برقراری شرط نمایش داده می‌شود")]
    public string? ErrorMessage { get; set; }
}

/// <summary>
/// نوع شرط جامعه مشتریان - تعیین نحوه ارزیابی شرط
/// </summary>
public enum CustomerSegmentConditionKind
{
    /// <summary>
    /// بدون شرط اضافی
    /// </summary>

    WithoutExtraCondition = 0,

    /// <summary>
    /// فرمول شرط
    /// </summary>

    Formula = 1,

    /// <summary>
    /// برابر
    /// </summary>

    EqualTo = 2,

    /// <summary>
    /// نابرابر
    /// </summary>

    NotEqualTo = 3,

    /// <summary>
    /// بزرگتر
    /// </summary>

    GreaterThan = 4,

    /// <summary>
    /// کوچکتر
    /// </summary>

    LessThan = 5,

    /// <summary>
    /// بزرگتر مساوی
    /// </summary>

    GreaterThanOrEqualTo = 6,

    /// <summary>
    /// کوچکتر مساوی
    /// </summary>

    LessThanOrEqualTo = 7,

    /// <summary>
    /// شامل
    /// </summary>

    Contains = 8,

    /// <summary>
    /// شروع با
    /// </summary>

    StartsWith = 9,

    /// <summary>
    /// پایان با
    /// </summary>

    EndsWith = 10,

    /// <summary>
    /// در بازه
    /// </summary>

    InRange = 11,

    /// <summary>
    /// خارج از بازه
    /// </summary>

    OutOfRange = 12,

    /// <summary>
    /// در لیست
    /// </summary>

    InList = 13,

    /// <summary>
    /// خارج از لیست
    /// </summary>

    NotInList = 14,

    /// <summary>
    /// خالی
    /// </summary>

    IsNull = 15,

    /// <summary>
    /// غیرخالی
    /// </summary>

    IsNotNull = 16
}

/// <summary>
/// مقایسه شود با - تعیین نوع مقایسه
/// </summary>
public enum CustomerSegmentCompareWith
{
    /// <summary>
    /// مقدار ثابت
    /// </summary>

    ConstantValue = 1,

    /// <summary>
    /// پارامتر مشتری
    /// </summary>

    CustomerParameter = 2,

    /// <summary>
    /// امتیاز مشتری
    /// </summary>

    CustomerPoint = 3,

    /// <summary>
    /// سطح امتیاز مشتری
    /// </summary>

    CustomerPointLevel = 4,

    /// <summary>
    /// تاریخ عضویت مشتری
    /// </summary>

    CustomerJoinDate = 5,

    /// <summary>
    /// آخرین فعالیت مشتری
    /// </summary>

    CustomerLastActivity = 6,

    /// <summary>
    /// تعداد خرید مشتری
    /// </summary>

    CustomerPurchaseCount = 7,

    /// <summary>
    /// مبلغ کل خرید مشتری
    /// </summary>

    CustomerTotalPurchase = 8,

    /// <summary>
    /// میانگین خرید مشتری
    /// </summary>

    CustomerAveragePurchase = 9,

    /// <summary>
    /// سن مشتری
    /// </summary>

    CustomerAge = 10,

    /// <summary>
    /// جنسیت مشتری
    /// </summary>

    CustomerGender = 11,

    /// <summary>
    /// شهر مشتری
    /// </summary>

    CustomerCity = 12,

    /// <summary>
    /// فرمول محاسباتی
    /// </summary>

    Formula = 13
}

namespace Club.Domain.Entities.Points.Enums;

public enum PointType : int
{
    [Description("امتیاز عادی")]
    Normal,
    [Description("امتیاز تجربه")]
    Xp,
    [Description("امتیاز ارزش طول‌عمر‌مشتری")]
    Value
}

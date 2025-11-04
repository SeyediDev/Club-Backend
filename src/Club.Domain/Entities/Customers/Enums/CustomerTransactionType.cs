using System.ComponentModel;

namespace Club.Domain.Entities.Customers.Enums;

public enum CustomerTransactionType 
{ 
    [Description("بدهکار")]
    Debit = 1, 
    
    [Description("بستانکار")]
    Credit = 2,
    
    [Description("انتقال امتیاز (خروجی)")]
    PointTransferOut = 3,
    
    [Description("انتقال امتیاز (ورودی)")]
    PointTransferIn = 4,
    
    [Description("کارمزد انتقال")]
    TransferCommission = 5
}

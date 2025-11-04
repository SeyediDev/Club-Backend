using Neo.Bpms.Domain.Entities.Cmmn.Common;
using Club.Domain.Entities.Analytics;
using Club.Domain.Entities.Rewards;

namespace Club.AdminPanel.Domain.Domain;

/// <summary>
/// Club platform menu definitions with modern, colorful icons
/// Icons are defined in /Content/club-icons/club-sprite.svg
/// </summary>
public partial class ClubMenuDefinitions : MenuDefinition
{
    private void AddMenu_Club()
    {
        // Dashboard
        AddMenu("داشبورد", "home-dashboard", "Dashboards", "");
        {
            StartSubMenus();
            AddDashboard<HomePageEntity>("داشبورد کلی", "home-dashboard");
            AddReport<CustomerTransaction>("گزارش تراکنشات مشتریان", "wallet-money");
            AddReport<EventLog>("گزارش فعالیت‌های سیستم", "list-checklist");
            AddReport<RewardAsset>("گزارش دارایی‌های مشتریان", "cube-3d");
            // AddDashboard<HomePageEntity, HomePageEntityUiDefinitions.HomePageDashboard.SurveyAnalyticsDashboard>("تحلیل نظرسنجی‌ها", "survey-poll");
            // AddDashboard<HomePageEntity, HomePageEntity.HomePageDashboard.FeedbackDashboard>("بازخورد مشتریان", "message-feedback");
            // AddDashboard<HomePageEntity, HomePageEntity.HomePageDashboard.ForumDashboard>("انجمن مشتریان", "forum-community");
            EndSubMenus();
        }

        // Customer Management
        AddMenu("مدیریت مشتریان", "users-group", "Customer Management", "");
        {
            StartSubMenus();
            AddMenu<Tenant>("سازمان بهره‌بردار", "building-organization");
            AddMenu<Customer>("مشتریان", "user-circle");
            AddMenu<CustomerParameter>("پارامترهای مشتریان", "user-settings");
            AddMenu("اطلاعات مشتریان", "user-badge", "Customer Information", "");
            {
                StartSubMenus();
                AddMenu<CustomerSegmentMembership>("عضویت جامعه مشتریان", "user-badge");
                AddMenu<CustomerParameterValue>("مقادیر پارامترهای مشتریان", "sliders-h");
                AddMenu<CustomerTransaction>("حساب‌های مشتریان", "wallet-money");
                AddMenu<CustomerPointLevel>("سطوح امتیاز مشتریان", "trophy-star");
                EndSubMenus();
            }

            AddMenu("گزارشات مدیریت مشتریان", "chart-bar", "Customer Reports", "");
            {
                StartSubMenus();
                AddReport<Tenant>("گزارش سازمان بهره‌بردار", "building-organization");
                AddReport<CustomerParameter>("گزارش پارامترهای مشتریان", "user-settings");
                AddReport<Customer>("گزارش مشتریان", "user-circle");
                AddReport<CustomerTransaction>("گزارش تراکنشات", "wallet-money");
                AddReport<CustomerPointLevel>("گزارش سطوح امتیاز", "trophy-star");
                AddReport<CustomerParameterValue>("گزارش پارامترها", "sliders-h");
                AddReport<RewardAsset>("گزارش دارایی‌های مشتریان", "cube-3d");
                EndSubMenus();
            }
            EndSubMenus();
        }

        // Awards
        AddMenu("پاداش‌ها", "box-package", "Awards", "");
        {
            StartSubMenus();
            AddMenu<Reward>("پاداش‌ها", "box-package");
            AddMenu<RewardCost>("هزینه‌های پاداش‌ها", "coins-money");
            AddMenu<RewardAsset>("دارایی‌های پاداش‌ها", "cube-3d");

            AddMenu("گزارشات پاداش‌ها", "chart-bar", "Award Reports", "");
            {
                StartSubMenus();
                AddReport<Reward>("گزارش پاداش‌ها", "box-package");
                AddReport<RewardCost>("گزارش هزینه‌ها", "coins-money");
                AddReport<RewardAsset>("گزارش دارایی‌ها", "cube-3d");
                EndSubMenus();
            }
            EndSubMenus();
        }

        // Organization Products
        AddMenu("محصولات سازمان", "grid-layout", "Organization Products", "");
        {
            StartSubMenus();
            AddMenu<Product>("محصولات سازمان", "grid-layout");

            AddMenu("گزارشات محصولات سازمان", "chart-bar", "Product & Service Reports", "");
            {
                StartSubMenus();
                AddReport<Product>("گزارش محصولات سازمان", "grid-layout");
                EndSubMenus();
            }
            EndSubMenus();
        }

        // Scoring System
        AddMenu("سیستم امتیازدهی", "star-badge", "Scoring System", "");
        {
            StartSubMenus();
            AddMenu<Point>("انواع امتیازات", "star-badge");
            AddMenu<PointLevel>("سطوح امتیاز", "medal-award");
            AddMenu<PointBudget>("بودجه‌های امتیازدهی", "piggy-bank");
            AddMenu<PointConversionRate>("نرخ تبدیل امتیاز", "exchange-transfer");
            
            AddMenu<ScoringRule>("قوانین", "rule-checklist");
            AddMenu<ScoringRuleTriggerCondition>("شرایط فعال‌سازی قوانین", "flag-trigger");
            AddMenu<ScoringRuleAction>("عملیات قوانین", "bolt-lightning");

            AddMenu("گزارشات سیستم امتیازدهی", "chart-bar", "Scoring Reports", "");
            {
                StartSubMenus();
                AddReport<Point>("گزارش امتیازات", "star-badge");
                AddReport<PointLevel>("گزارش سطوح‌امتیازی", "medal-award");
                AddReport<PointBudget>("گزارش بودجه‌ها", "piggy-bank");
                AddReport<ScoringRule>("گزارش قوانین", "rule-checklist");
                EndSubMenus();
            }
            EndSubMenus();
        }

        // Event Management
        AddMenu("مدیریت رویدادها", "calendar-event", "Event Management", "");
        {
            StartSubMenus();
            AddMenu<EventType>("رویدادها", "calendar-event");
            AddMenu<EventTypeParameter>("پارامترهای رویدادها", "cog-settings");
            AddMenu<EventChannel>("منابع رویدادها", "rss-signal");
            AddMenu<EventLog>("لاگ رویدادها", "list-checklist");
            
            AddMenu("گزارشات مدیریت رویدادها", "chart-bar", "Event Reports", "");
            {
                StartSubMenus();
                AddReport<EventType>("گزارش رویدادها", "calendar-event");
                AddReport<EventLog>("گزارش لاگ رویدادها", "list-checklist");
                AddReport<EventChannel>("گزارش منابع رویدادها", "rss-signal");
                EndSubMenus();
            }
            EndSubMenus();
        }

        // Promotion Management
        AddMenu("مدیریت پویش‌ها", "gift-present", "Promotion Management", "");
        {
            StartSubMenus();
            AddMenu<Promotion>("پویش‌ها", "gift-present");
            AddMenu<Lottery>("قرعه‌کشی", "ticket-lottery");
            AddMenu<LotteryReward>("پاداش‌های قرعه‌کشی", "gift-box");
            AddMenu<LotteryParticipant>("شرکت‌کنندگان", "users-group");
            AddMenu("گزارشات مدیریت پویش‌ها", "chart-bar", "Promotion Reports", "");
            {
                StartSubMenus();
                AddReport<Promotion>("گزارش پویش‌ها", "gift-present");
                AddReport<Lottery>("گزارش قرعه‌کشی", "ticket-lottery");
                AddReport<LotteryReward>("گزارش پاداش‌ها", "gift-box");
                AddReport<LotteryParticipant>("گزارش شرکت‌کنندگان", "users-group");
                EndSubMenus();
            }
            EndSubMenus();
        }

        // Survey & Contest Management
        AddMenu("مدیریت نظرسنجی و مسابقات", "survey-poll", "Survey Management", "");
        {
            StartSubMenus();
            AddMenu<Survey>("نظرسنجی‌ها و مسابقات", "survey-poll");
            AddMenu<SurveyParticipation>("شرکت‌کنندگان", "users-group");
            
            AddMenu("گزارشات نظرسنجی", "chart-bar", "Survey Reports", "");
            {
                StartSubMenus();
                AddReport<Survey>("گزارش نظرسنجی‌ها", "survey-poll");
                AddReport<SurveyParticipation>("گزارش شرکت‌کنندگان", "users-group");
                EndSubMenus();
            }
            EndSubMenus();
        }

        // Customer Feedback Management - temporarily disabled
        // AddMenu("مدیریت بازخورد مشتریان", "message-feedback", "Feedback Management", "");
        // {
        //     StartSubMenus();
        //     AddMenu<CustomerFeedback>("بازخوردها (پیشنهادات و انتقادات)", "message-feedback");
        //     AddMenu<FeedbackComment>("نظرات بازخورد", "message-chat");
        //     AddMenu<FeedbackAttachment>("پیوست‌ها", "file-attach");
        //     
        //     AddMenu("گزارشات بازخورد", "chart-bar", "Feedback Reports", "");
        //     {
        //         StartSubMenus();
        //         AddReport<CustomerFeedback>("گزارش بازخوردها", "message-feedback");
        //         AddReport<FeedbackComment>("گزارش نظرات", "message-chat");
        //         EndSubMenus();
        //     }
        //     EndSubMenus();
        // }

        // Forum Management - temporarily disabled
        // AddMenu("مدیریت انجمن", "forum-community", "Forum Management", "");
        // {
        //     StartSubMenus();
        //     AddMenu<ForumTopic>("موضوعات انجمن", "forum-community");
        //     AddMenu<ForumPost>("پست‌های انجمن", "message-reply");
        //     
        //     AddMenu("گزارشات انجمن", "chart-bar", "Forum Reports", "");
        //     {
        //         StartSubMenus();
        //         AddReport<ForumTopic>("گزارش موضوعات", "forum-community");
        //         AddReport<ForumPost>("گزارش پست‌ها", "message-reply");
        //         EndSubMenus();
        //     }
        //     EndSubMenus();
        // }

        // eCRM & Marketing Analytics
        AddMenu("مدیریت ارتباط با مشتریان (eCRM)", "users-group", "eCRM & Marketing", "");
        {
            StartSubMenus();
            
            // Customer Analytics
            AddMenu("تحلیل مشتریان", "chart-line", "Customer Analytics", "");
            {
                StartSubMenus();
                AddMenu<CustomerAnalytics>("تحلیل RFM", "chart-radar");
                AddMenu<CustomerSegment>("جامعه مشتریان", "users-group");
                AddMenu<CustomerSegmentKindCondition>("شرط‌های جامعه‌سازی", "filter-funnel");
                AddReport<CustomerAnalytics>("گزارش تحلیل مشتریان", "chart-line");
                EndSubMenus();
            }
            
            // Marketing Campaigns
            AddMenu("کمپین‌های بازاریابی", "megaphone-speaker", "Marketing Campaigns", "");
            {
                StartSubMenus();
                AddMenu<PromotionMessage>("پیام‌های کمپین", "message-chat");
                AddMenu<PromotionRecipient>("گیرندگان کمپین", "user-check");
                AddReport<PromotionMessage>("گزارش پیام‌ها", "message-chat");
                AddReport<PromotionRecipient>("گزارش گیرندگان", "user-check");
                EndSubMenus();
            }
            
            // Market Analysis
            AddMenu("تحلیل بازار", "chart-pie", "Market Analysis", "");
            {
                StartSubMenus();
                AddMenu<MarketAnalysis>("تحلیل TAM/SAM/SOM", "chart-pie");
                AddMenu<ProductFitAnalysis>("تحلیل تناسب محصول", "target-bullseye");
                AddReport<MarketAnalysis>("گزارش تحلیل بازار", "chart-pie");
                AddReport<ProductFitAnalysis>("گزارش تناسب محصول", "target-bullseye");
                EndSubMenus();
            }
            
            // Advanced Reports
            AddMenu("گزارشات پیشرفته", "chart-bar", "Advanced Reports", "");
            {
                StartSubMenus();
                AddReport<CustomerAnalytics>("گزارش RFM", "chart-radar");
                AddReport<CustomerSegment>("گزارش جامعه‌سازی", "users-group");
                AddReport<Promotion>("گزارش اثربخشی کمپین", "megaphone-speaker");
                AddReport<MarketAnalysis>("گزارش سهم بازار", "chart-pie");
                EndSubMenus();
            }
            
            EndSubMenus();
        }

        // System Settings
        AddMenu("تنظیمات سامانه", "cog-wheel", "System Settings", "");
        {
            StartSubMenus();
            AddMenu<User>("کاربران سامانه", "user-admin");
            AddMenu<Faq>("سوالات متداول", "question-circle");
            AddMenu<Help>("راهنمای سیستم", "info-circle");
            AddMenu<Document>("مستندات", "file-document");
            
            AddMenu("گزارشات تنظیمات سامانه", "chart-bar", "System Reports", "");
            {
                StartSubMenus();
                AddReport<User>("گزارش کاربران", "user-admin");
                AddReport<Faq>("گزارش سوالات متداول", "question-circle");
                AddReport<Help>("گزارش راهنمای سیستم", "info-circle");
                AddReport<Document>("گزارش مستندات", "file-document");
                EndSubMenus();
            }
            EndSubMenus();
        }
    }
}

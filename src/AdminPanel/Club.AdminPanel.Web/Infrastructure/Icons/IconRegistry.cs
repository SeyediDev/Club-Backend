namespace Club.AdminPanel.Domain.Infrastructure.Icons;

/// <summary>
/// Central registry for all Club platform icons
/// Maps entity names and menu items to their corresponding SVG icon identifiers
/// </summary>
public static class IconRegistry
{
    /// <summary>
    /// Base path to Club-specific SVG sprite
    /// </summary>
    public const string SvgSpritePath = "/Content/club-icons/club-sprite.svg";
    
    /// <summary>
    /// Get icon ID for an entity or menu item
    /// </summary>
    public static string GetIconId(string entityOrMenuName)
    {
        return EntityIcons.TryGetValue(entityOrMenuName, out var iconId) 
            ? iconId 
            : "default-icon";
    }
    
    /// <summary>
    /// Entity to Icon mapping
    /// </summary>
    private static readonly Dictionary<string, string> EntityIcons = new()
    {
        // Dashboard & Home
        ["HomePageEntity"] = "home-dashboard",
        ["dashboard-icon"] = "home-dashboard",
        
        // Customer Management
        ["Tenant"] = "building-organization",
        ["Customer"] = "user-circle",
        ["CustomerSegment"] = "users-group",
        ["CustomerParameter"] = "user-settings",
        ["CustomerSegmentMembership"] = "user-badge",
        ["CustomerParameterValue"] = "sliders-h",
        ["CustomerTransaction"] = "wallet-money",
        ["CustomerPointLevel"] = "trophy-star",
        ["users-icon"] = "users-group",

        // Awards & Assets
        ["Award"] = "box-package",
        ["AwardCost"] = "coins-money",
        ["Asset"] = "cube-3d",
        ["AwardCategory"] = "grid-layout",
        ["AwardMerchant"] = "store-shop",
        ["product-icon"] = "box-package",
        
        // Scoring System
        ["Point"] = "star-badge",
        ["PointLevel"] = "medal-award",
        ["PointBudget"] = "piggy-bank",
        ["ScoringRule"] = "rule-checklist",
        ["ScoringRuleTriggerCondition"] = "flag-trigger",
        ["ScoringRuleAction"] = "bolt-lightning",
        ["scoring-icon"] = "star-badge",
        
        // Events
        ["EventType"] = "calendar-event",
        ["EventTypeParameter"] = "cog-settings",
        ["EventChannel"] = "rss-signal",
        ["EventLog"] = "list-checklist",
        ["event-icon"] = "calendar-event",
        
        // Promotions
        ["Promotion"] = "gift-present",
        ["Lottery"] = "ticket-lottery",
        ["promotion-icon"] = "gift-present",
        
        // System Settings
        ["User"] = "user-admin",
        ["Faq"] = "question-circle",
        ["Help"] = "info-circle",
        ["Document"] = "file-document",
        ["settings-icon"] = "cog-wheel",
        
        // Reports
        ["report-icon"] = "chart-bar"
    };
    
    /// <summary>
    /// Icon color scheme based on category
    /// </summary>
    public static class Colors
    {
        // Modern, professional color palette
        public const string Dashboard = "#6366F1"; // Indigo
        public const string Customer = "#10B981"; // Emerald
        public const string Product = "#F59E0B"; // Amber
        public const string Scoring = "#EF4444"; // Red
        public const string Event = "#8B5CF6"; // Purple
        public const string Promotion = "#EC4899"; // Pink
        public const string Settings = "#64748B"; // Slate
        public const string Report = "#0EA5E9"; // Sky
        public const string Default = "#6B7280"; // Gray
        
        /// <summary>
        /// Get color for entity or menu item
        /// </summary>
        public static string GetColor(string entityOrMenuName)
        {
            return entityOrMenuName switch
            {
                // Dashboard
                "HomePageEntity" or "dashboard-icon" => Dashboard,
                
                // Customer related
                var name when name.StartsWith("Customer") || name == "Tenant" || name == "users-icon" => Customer,
                
                // Product related
                var name when name.StartsWith("Product") || name == "Asset" || name == "product-icon" => Product,
                
                // Scoring related
                var name when name.StartsWith("Point") || name.StartsWith("Scoring") || name == "scoring-icon" => Scoring,
                
                // Event related
                var name when name.StartsWith("Event") || name == "event-icon" => Event,
                
                // Promotion related
                var name when name.StartsWith("Promotion") || name == "Lottery" || name == "promotion-icon" => Promotion,
                
                // Settings related
                var name when name == "User" || name == "Faq" || name == "Help" || name == "Document" || name == "settings-icon" => Settings,
                
                // Report
                "report-icon" => Report,
                
                _ => Default
            };
        }
    }
}



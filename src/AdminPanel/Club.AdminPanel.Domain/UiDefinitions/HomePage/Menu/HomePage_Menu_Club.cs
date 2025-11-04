using Neo.Domain.Entities.Common;
using User = Club.Domain.Entities.Common.User;

namespace Club.AdminPanel.Domain.UiDefinitions.HomePage;

public partial class HomePageEntityUiDefinitions
{
    public partial class Default
    {
        private bool _state_is_form;

        private void AddClubMenu()
        {
            AddMultiTabItem("پلتفرم باشگاه مشتریان", nameof(DomainProvider.Domain), ContextualStyle.Secondary, nameof(DomainProvider.Domain));
            _state_is_form = true;
            AddUsersHomePageMenuPart();
            _state_is_form = false;
            AddUsersHomePageMenuPart();
            EndPart();
        }

        private void AddUsersHomePageMenuPart()
        {
            AddClubPart("کاربران", "UsersInfo");
            {
                AddClubPartItem<User>("کاربران");
                EndPart();
            }
            AddClubPart("اطلاعات پایه", "Public Info");
            {
                AddClubPartItem<CultureTerm>("واژه ها");
                EndPart();
            }
            AddClubPart("مستندات", "DocumentsInfo");
            {
                AddClubPartItem<DocumentType>("نوع مستندات");
                AddClubPartItem<Document>("مستندات");
                EndPart();
            }
        }

        void AddClubPartItem<T>(string name, string subject = null, string pageSubType = null, string entityItemId = null, string partName = nameof(Domains.Club))
        {
            if (_state_is_form)
            {
                AddPartForm<T>(name, subject, pageSubType, partName, entityItemId);
            }
            else
            {
                AddPartReport<T>(name, subject, partName, entityItemId);
            }
        }

        private void AddClubPart(string name, string enName)
        {
            AddPart((_state_is_form ? "" : "گزارشات ") + name,
                "IUM " + enName + (_state_is_form ? "-Form" : "-Report"), _state_is_form ? "#FFF" : "#CCE2FF");
        }
    }
}

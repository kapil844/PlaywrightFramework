using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDemo.pages
{
    public class TeamMembersPage
    {
        IPage page;
        ILocator editLink;
        ILocator searchRecordTxt;
        ILocator addTeamMemberBtn;


        public TeamMembersPage(IPage page)
        {
            this.page = page;
            editLink = this.page.Locator("//a[text()='Edit']");
            searchRecordTxt = this.page.GetByPlaceholder("Search team members");
            addTeamMemberBtn = this.page.Locator(" a[title='Add Team Member']");


        }

        public async Task clickOnAddTeamMemberPlusIcon()
        {
            await this.addTeamMemberBtn.ClickAsync();
        }

        public async Task enterSearchRecord(string studentName)
        {
            await this.searchRecordTxt.FillAsync(studentName);
            await this.page.Keyboard.PressAsync("Enter");
        }

        public async Task clickOnEditLink()
        {
            Thread.Sleep(3000);
            await this.editLink.ClickAsync();
        }

        public ILocator getSearchedUser(string name)
        {
            return this.page.GetByText(name);
        }

    }
}

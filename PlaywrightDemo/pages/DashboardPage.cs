using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDemo.pages
{
    public class DashboardPage
    {
        IPage page;
        ILocator setUpMenu;
        ILocator manageTeamMemberLink;
        ILocator closeBtn;
        ILocator pageTitle;

        public DashboardPage(IPage page)
        {
            this.page = page;
            setUpMenu = this.page.Locator("li[role='tablist'] a[aria-label='Setup']");
            manageTeamMemberLink = this.page.Locator("a[aria-label='Manage Team Members']");
            closeBtn = this.page.Locator("button[aria-label='close']");
            pageTitle = this.page.Locator("div[class*='text-center'] h2");

        }

        public async Task clickClosePopup()
        {
            await this.closeBtn.ClickAsync();
        }

        public async Task clickOnSetupMenu()
        {
            await this.setUpMenu.ClickAsync();
        }
        public async Task clickOnManageTeamMembers()
        {
            await this.manageTeamMemberLink.ClickAsync();
        }

        public ILocator getDashboardPageTitle()
        {
            return this.pageTitle;
        }
    }
}

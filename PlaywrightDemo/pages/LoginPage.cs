using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDemo.pages
{
    public class LoginPage
    {
        IPage page;
        ILocator userName;
        ILocator password;
        ILocator signInBtn;

        public LoginPage(IPage page)
        {
            this.page = page;
            userName = this.page.Locator("#UserName");
            password = this.page.Locator("#Password");
            signInBtn = this.page.Locator("#loginBtn");

        }

        public async Task enterUserName(string userName)
        {
            await this.userName.FillAsync(userName);
        }

        public async Task enterPassword(string password)
        {
            await this.password.FillAsync(password);
        }

        public async Task clickOnSiginBtn()
        {
            await this.signInBtn.ClickAsync();
        }

        public async Task verifyUserLoginSucessfully(string Username, string Password)
        {
            await enterUserName(Username);
            await enterPassword(Password);
            await clickOnSiginBtn();
        }
    }
}

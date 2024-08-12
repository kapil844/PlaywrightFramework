using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDemo.pages
{
    public class AddTeamMemberPage
    {
        IPage page;
        ILocator firstNameTxt;
        ILocator lastNameTxt;
        ILocator emailTxt;
        ILocator phoneTxt;
        ILocator userNameTxt;
        ILocator passwordTxt;
        ILocator confirmPasswordTxt;
        ILocator pageTitle;
        ILocator saveAndCloseBtn;
        ILocator savedMessageToastr;
        ILocator extensionCode;
        ILocator studentsRecordList;
        ILocator deleteBtn;
        ILocator confirmPopupDeleteBtn;
        ILocator confirmPopupMessage;
        ILocator loader;

        public AddTeamMemberPage(IPage page) { 
            this.page = page;
            firstNameTxt = this.page.Locator("#firstName");
            lastNameTxt = this.page.Locator("#lastName");
            emailTxt = this.page.Locator("#email");
            phoneTxt = this.page.Locator("#phone");
            userNameTxt = this.page.Locator("#username");
            passwordTxt = this.page.Locator("#password");
            confirmPasswordTxt = this.page.Locator("#confirmPassword");
            pageTitle = this.page.Locator(".pageTitle.text-center");
            saveAndCloseBtn = this.page.Locator("(//button[@type='button'] [not(@disabled)])[last()]");
            savedMessageToastr = this.page.Locator(".alert.alert-success.show.fade.alert-dismissible");
            studentsRecordList = this.page.Locator("table[class='studentsTable table table-responsive'] tbody tr");
            deleteBtn = this.page.Locator("button[class*='btn-danger']");
            confirmPopupDeleteBtn = this.page.Locator("div[class ='modal-body'] button[class*='btn-danger']");
            confirmPopupMessage = this.page.Locator("div[class ='modal-body'] p:not([style*='word'])");
            loader = this.page.Locator("em[class*='fa-spinner']");

        }

        public async Task enterFirstName(string firstname)
        {
            await this.firstNameTxt.FillAsync(firstname);
        }

        public async Task enterLastName(string lastName)
        {
            await this.lastNameTxt.FillAsync(lastName);
        }

        public async Task enterEmail(string email)
        {
            await this.emailTxt.FillAsync(email);
        }

        public async Task enterMobileNumber(string mobileNumber)
        {
            await this.phoneTxt.FillAsync(mobileNumber);
        }

        public async Task enterUserName(string userName)
        {
            await this.userNameTxt.FillAsync(userName);
        }
        public async Task enterPassword(string password)
        {
            await this.passwordTxt.FillAsync(password);
        }

        public async Task enterConfirmPassword(string confirmPassword)
        {
            await this.confirmPasswordTxt.FillAsync(confirmPassword);
        }

        public async Task clickSaveAndClose()
        {
            await this.saveAndCloseBtn.ClickAsync();
        }

        public async Task clickDeleteBtn()
        {
            await this.deleteBtn.ClickAsync();  
        }

        public ILocator getDeletePopupMessage()
        {
            return this.confirmPopupMessage;
        }

        public async Task clickConfirmDeleteBtn()
        {
            await this.confirmPopupDeleteBtn.ClickAsync();
        }

        public ILocator getPageTitle()
        {
            return this.pageTitle;   
        }

        public ILocator getSavedStudentRecord()
        {
            return this.savedMessageToastr;

        }

        public async Task clickOnDeleteBtn()
        {
            await this.deleteBtn.ClickAsync();
        }

        public ILocator waitForLoaderInvisible()
        {
            return this.loader;
        }

        public ILocator getConfirmPopupMessage()
        {
            return this.confirmPopupMessage;
        }

        public async Task createNewTeamMember(string firstName, string lastName, string email, string phoneNumber, string userName, string password)
        {
            await this.enterFirstName(firstName);
            await this.enterLastName(lastName);
            await this.enterEmail(email);
            await this.enterMobileNumber(phoneNumber);
            await this.enterUserName(userName);
            await this.enterPassword(password);
            await this.enterConfirmPassword(password);
            await this.clickSaveAndClose();
        }
    }
}

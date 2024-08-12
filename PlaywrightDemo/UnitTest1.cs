using Microsoft.Playwright;
using PlaywrightDemo.Config;
using PlaywrightDemo.Driver;
using PlaywrightDemo.pages;
using PlaywrightDemo.utils;

namespace PlaywrightDemo
{
    public class Tests
    {
        PlaywrightDriver driver;
        IPage page;
        LoginPage loginPage;
        DashboardPage dashboardPage;
        AddTeamMemberPage addTeamMemberPage;
        TeamMembersPage teamMembersPage;
        CommonMethods commonMethods;
        string userName = "testautomation";
        string password = "Welcome123";
        string firstName = "test";
        string lastname = "Automation";
        string newPassword = "Tug54@1467";
        string mobileNumber = "6545655566";

       [SetUp]
        public async Task Setup()
        {

            TestSettings testSettings = new TestSettings
            {
                Channel = "chrome",
                DevTools = false,
                Headless = false,
                SlowMo = 1500,
            };


            driver = new PlaywrightDriver();
            page = await driver.InitalizePlaywrightAsync(testSettings);
            loginPage = new LoginPage(page);
            await loginPage.verifyUserLoginSucessfully(userName, password);

        }

        [Test]
        public async Task CreateUpdateAndDeleteTeamMember()
        {
            commonMethods = new CommonMethods();
            int rndNumber = commonMethods.getRandomNumber();
            dashboardPage = new DashboardPage(page);
            addTeamMemberPage = new AddTeamMemberPage(page);
            teamMembersPage = new TeamMembersPage(page);
            string rndString = commonMethods.getRandomString();

            await dashboardPage.clickClosePopup();
            var dashboardPageTitleMessage = dashboardPage.getDashboardPageTitle();
            await Assertions.Expect(dashboardPageTitleMessage).ToHaveTextAsync(" Welcome, " + userName);
            await dashboardPage.clickOnSetupMenu();
            await dashboardPage.clickOnManageTeamMembers();
            var dashboardPageTitle = dashboardPage.getDashboardPageTitle();
            await Assertions.Expect(dashboardPageTitle).ToHaveTextAsync("Team Members");
            await teamMembersPage.clickOnAddTeamMemberPlusIcon();
            var expPageTitle = addTeamMemberPage.getPageTitle();
            await Assertions.Expect(expPageTitle).ToHaveTextAsync("Add Team Member");
            // Add New team Member

            await addTeamMemberPage.createNewTeamMember(firstName + rndNumber, lastname + rndNumber, rndString + lastname + commonMethods.getRandomNumber() + "@gmail.com", "7" + rndNumber, rndString + rndNumber, newPassword);
            var loader = addTeamMemberPage.waitForLoaderInvisible();
            await loader.WaitForAsync();
            var expSaveDetailsMessage = addTeamMemberPage.getSavedStudentRecord();
            await Assertions.Expect(expSaveDetailsMessage).ToHaveTextAsync("Saved");
            //Verify Team Member

            await teamMembersPage.enterSearchRecord(firstName+ rndNumber);
            var userNameLocator = teamMembersPage.getSearchedUser(lastname + rndNumber + ", " + firstName + rndNumber);
            await Assertions.Expect(userNameLocator).ToBeVisibleAsync();
            //Update Team Member

            await teamMembersPage.clickOnEditLink();
            await addTeamMemberPage.enterFirstName("Update" + firstName + rndNumber);
            await addTeamMemberPage.enterUserName("Update"+userName+ rndNumber + rndNumber);
            await addTeamMemberPage.clickSaveAndClose();
            await loader.WaitForAsync();
            var expUpdateDetailsMessage = addTeamMemberPage.getSavedStudentRecord();
            await Assertions.Expect(expUpdateDetailsMessage).ToHaveTextAsync("Saved");
            //Verify Updated Team Member

            await teamMembersPage.enterSearchRecord(firstName + rndNumber);
            var updatedUserNameLocator = teamMembersPage.getSearchedUser(lastname + rndNumber + ", Updated" + firstName + rndNumber);
            await Assertions.Expect(updatedUserNameLocator).ToBeVisibleAsync();
            //Delete Esixting Team Member

            await teamMembersPage.clickOnEditLink();
            await loader.WaitForAsync();
            await addTeamMemberPage.clickDeleteBtn();
            var expDeleteMessage = addTeamMemberPage.getDeletePopupMessage();
            await Assertions.Expect(expDeleteMessage).ToHaveTextAsync("Are you sure you want to delete the Team Member "+firstName+ rndNumber + " "+lastname+ rndNumber + "?");
            await addTeamMemberPage.clickConfirmDeleteBtn();
            await loader.WaitForAsync();
            var expDeleteDetailsMessage = addTeamMemberPage.getSavedStudentRecord();
            await Assertions.Expect(expDeleteDetailsMessage).ToHaveTextAsync("Deleted");
            //Verify Deleted Team Member

            await teamMembersPage.enterSearchRecord(firstName + rndNumber);
            var deletedUserNameLocator = teamMembersPage.getSearchedUser(lastname + rndNumber + ", Updated" + firstName + rndNumber);
            await Assertions.Expect(deletedUserNameLocator).ToHaveCountAsync(0);

        }

    }
}
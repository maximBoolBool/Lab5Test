using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

const string authorizeUrl = "https://account.miet.ru/login?backurl=https%3A%2F%2Fmiet.ru%2Fsearch%2F"; 
const string mainPageUrl = "https://miet.ru/search/";
const string userLogin = "8211846";
const string userPassword = "TOXICIS420";

var driver = new ChromeDriver();


try
{
    driver.Navigate().GoToUrl(mainPageUrl);
    
    Authorize(driver);
    Thread.Sleep(1500);
    //
    // SearchText(driver,"цукенг");
    // Thread.Sleep(1500);
    //
    // SearchText(driver,"К");
    // Thread.Sleep(1500);
    
    FindTeacher(driver);
    Thread.Sleep(1500);
    
    CloseWindow(driver);
}
catch (Exception exp)
{
    Console.WriteLine(exp.Message);
}
finally
{
    Thread.Sleep(1000);
    driver.Quit();
}



void CloseWindow(IWebDriver webDriver)
{
    webDriver.Close();
}

// проаверка авторизации
void Authorize(IWebDriver webDriver)
{
    var hamburger = webDriver
        .FindElement(By.ClassName("hamburger"));
    hamburger.Click();

    Thread.Sleep(1000);

    webDriver.Navigate().GoToUrl(authorizeUrl);
    
    Thread.Sleep(1000);
    IWebElement loginInput = webDriver.FindElement(By.XPath("//input[@name='USER_LOGIN']"));
    IWebElement passwordInput = webDriver.FindElement(By.XPath("//input[@name='USER_PASSWORD']"));
    
    loginInput.SendKeys(userLogin);
    passwordInput.SendKeys(userPassword);
    
    Thread.Sleep(1000);
    
    var authorizeButton = driver.FindElement(By.XPath("//button[text()='Войти']")); //webDriver.FindElement(By.ClassName("button blue big-padding"));
    authorizeButton.Click();
    Thread.Sleep(10000);
    
}

// проверка поиска на сайте
void SearchText(IWebDriver webDriver, string searchString)
{
    IWebElement searchInput = webDriver.FindElement(By.XPath("//input[@class='search-bar__input']"));

    searchInput.Clear();
    searchInput.SendKeys(searchString);
    Thread.Sleep(1000);
    searchInput.SendKeys(Keys.Enter);
    Thread.Sleep(2000);
}

void FindTeacher(IWebDriver webDriver)
{
    SearchText(webDriver, "Кожухов");
    Thread.Sleep(1000);
    Thread.Sleep(1000);
    var element = driver.FindElement(By.XPath("//a[contains(text(), 'Люди')]"));
    element.Click();
    Thread.Sleep(1000);
    
}

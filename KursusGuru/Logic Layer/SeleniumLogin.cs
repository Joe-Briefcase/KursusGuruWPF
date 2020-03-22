using System;
using KursusGuru.Logic_Layer;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

public class SeleniumLogin : ISelenium
{
    //Laver en ChromeDriver og sætter Inside som en variabel (fordi det er fucking lang url).
    private IWebDriver _driver = new EdgeDriver();
    private String dtuInside = "https://sts.ait.dtu.dk/adfs/ls/?redirectfromauth=1&SAMLRequest=lZJNawMhEIbvhf6HxXvWdddCVnYTQnMJtFDS0kNuRt1GutHEmQ39%2bdV8tKXQQE%2bC4%2fvMM2oz%2fdj22cEEsN61hOUFyYxTXlv31pIBu9GYTCe3N82eidmAG7c0%2b8EAZot5S6wuWKmkXHe1HnO%2bVlzerQ1THa%2b0KnVdGZK9XtBlQi8ABrNwgNJh3CrKYlRUIzZ%2bYaXgteAsrzlnFatWJJvHNtZJPKY3iDsQlAJCLi3mGodcv1OpO6A90Gkw2gajsAt%2bK6Nny1KzJwlgD6YlnewhysRZHYg9i5MFJ7wEC8LJrQGBSjzPHh9EtBS74NEr35M4d5Y1R%2bdwyl4Pxm4mJF8yufgml4tsXGhDT7gT%2bt47bVMA%2folP6ZifDdrG1zLLeFXBqlQ7l34Ur7h8HTnz6F%2fAhn6rpt9Af32HySc%3d&SigAlg=http%3a%2f%2fwww.w3.org%2f2001%2f04%2fxmldsig-more%23rsa-sha256&Signature=EARncj9nGMjaqawlFA4clnrKA7X8tYWv9z3SBtk5Zw5x6KGF8nQxnF7R6UP44fZWD1IQsGlC9fIRKnKWDtXt4BrjGUXs7iZS7nE91csLXsQI8bfv7CRb6ilrt5RNl%2b0XcrhQ76nS9hiuHJdaNTFsUi6WAnBagG3GSJHYeGhyTVRFum9mhklpu10RYuuVvwsw0x0RN8H3eRBDCrEoX82lNj42UaCXuVll4qfMCqytlwUnMzSIZKCvrWzYyXaRLV3pAKBoFMlgrxflzgH%2bT54L1i8iQPi2e8OuldyPE3DZFxenU3V8mgcCao%2bKt9cz5Le2%2b9h2OkRf4gXJx%2bD54%2fxvTg%3d%3d";
    // Laver et WebElement objekt der kan indeholde et element fra en hjemmeside (f.eks. en tekstboks)
    private IWebElement _element;
   
    public SeleniumLogin()
    {
    }

    public void SeleniumLoginInside(String username, String password)
    {
        //Chrome driveren åbner inside via Chrome
        _driver.Url = dtuInside;

        //Sætter element objektet til et element med den givne XPath, i dette tilfælde er det username på dtuInside
        _element = _driver.FindElement(
            By.XPath("/html/body/div[2]/div[2]/div[1]/div[2]/div/div/form/div[2]/div[1]/input"));

        //Indsætter username i elementet
        _element.SendKeys(username);

        //Password
        _element = _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div[2]/div/div/form/div[2]/div[2]/input"));
        _element.SendKeys(password);

        //Sætter element til login knappen og klikker på den, så vi kan logge ind med de fyldte tekstbokse.
        _element = _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div[2]/div/div/form/div[2]/div[4]/span"));
        _element.Click();

    }

    public void SeleniumLoginLearn(String username, String password)
    {
        throw new System.NotImplementedException();
    }

    public void SeleniumLoginDiplomPortal(String username, String password)
    {
        throw new System.NotImplementedException();
    }

}

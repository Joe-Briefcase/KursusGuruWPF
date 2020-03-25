using System;
using System.Collections.Generic;
using KursusGuru.Logic_Layer;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;

public class SeleniumLogin : ISelenium
{
    //Laver en EdgeDriver og sætter Inside, Learn og diplomportalen som variabler (fordi det er fucking lange urler).
    private IWebDriver _driver = new EdgeDriver();
    private String dtuInside = "https://sts.ait.dtu.dk/adfs/ls/?redirectfromauth=1&SAMLRequest=lZJNawMhEIbvhf6HxXvWdddCVnYTQnMJtFDS0kNuRt1GutHEmQ39%2bdV8tKXQQE%2bC4%2fvMM2oz%2fdj22cEEsN61hOUFyYxTXlv31pIBu9GYTCe3N82eidmAG7c0%2b8EAZot5S6wuWKmkXHe1HnO%2bVlzerQ1THa%2b0KnVdGZK9XtBlQi8ABrNwgNJh3CrKYlRUIzZ%2bYaXgteAsrzlnFatWJJvHNtZJPKY3iDsQlAJCLi3mGodcv1OpO6A90Gkw2gajsAt%2bK6Nny1KzJwlgD6YlnewhysRZHYg9i5MFJ7wEC8LJrQGBSjzPHh9EtBS74NEr35M4d5Y1R%2bdwyl4Pxm4mJF8yufgml4tsXGhDT7gT%2bt47bVMA%2folP6ZifDdrG1zLLeFXBqlQ7l34Ur7h8HTnz6F%2fAhn6rpt9Af32HySc%3d&SigAlg=http%3a%2f%2fwww.w3.org%2f2001%2f04%2fxmldsig-more%23rsa-sha256&Signature=EARncj9nGMjaqawlFA4clnrKA7X8tYWv9z3SBtk5Zw5x6KGF8nQxnF7R6UP44fZWD1IQsGlC9fIRKnKWDtXt4BrjGUXs7iZS7nE91csLXsQI8bfv7CRb6ilrt5RNl%2b0XcrhQ76nS9hiuHJdaNTFsUi6WAnBagG3GSJHYeGhyTVRFum9mhklpu10RYuuVvwsw0x0RN8H3eRBDCrEoX82lNj42UaCXuVll4qfMCqytlwUnMzSIZKCvrWzYyXaRLV3pAKBoFMlgrxflzgH%2bT54L1i8iQPi2e8OuldyPE3DZFxenU3V8mgcCao%2bKt9cz5Le2%2b9h2OkRf4gXJx%2bD54%2fxvTg%3d%3d";
    private String dtuLearn = "https://sts.ait.dtu.dk/adfs/ls/?SAMLRequest=jdHPS8MwFAfwu%2bD%2fUHJvkibtmoZ2MPQymJdNPXiRNE23YpvUvFT8880cQ4%2b7vR984cN79WYJJ7s3n4uBkGwfGwRqGv2lf69EmXPGaVbRIs94WwnWM5XzOC0FEz1KXo2HwdkGMUxRsgVYzNZCUDbEEWU0pTxl7DmrZJFLnmNeUi44f0PJBsD4ELMPzsIyGX8w%2fmvQ5mW%2fa9AphBkkIaNR3uLBwtAZ3IUFdx%2bkYyMZZ6IinIzuOFhyJu%2fOFY47lHxPo4UGLd5Kp2AAadVkQAYtD5unnYxSOXsXnHYjWt%2ffJUn96%2fa3BNVVjdZXoy6EXhV8laqW5mnet10qirJNi0zwTFPTa9bjYGy8CeDWD8dTgFlpg7Wb%2fug1uSAiqCb%2fn7L%2bAQ%3d%3d";
    private String diplomPortal = "http://diplomportal.herokuapp.com/";
    // Laver et WebElement objekt der kan indeholde et element fra en hjemmeside (f.eks. en tekstboks)
    private IWebElement _element;
    private String[] courses { get; set; }
    private String[][] announcements { get; set; }

    public void SeleniumLoginInside(String username, String password)
    {
        //Edge driveren åbner inside via Edge
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

        //Henter kurser fra inside som ligger i en liste /li[] fra 0-5 og vi lægger det derfra i et String array.
        for (int i = 0; i > 5; i++)
        {
            _element = _driver.FindElement(By.XPath("/html/body/form/div[3]/div[6]/div[3]/div[3]/div[2]/div[1]/div/div[2]/div[1]/div[1]/ul/li[" + i + "]/a"));
            courses[i] = _element.Text;
        }

    }

    public void SeleniumLoginLearn(String username, String password)
    {
        //Sætter Edgedriveren til Learn.
        _driver.Url = dtuLearn;

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
        
        // TODO: FÅ DEN TIL AT KLIKKE PÅ ALLE KURSER OG ANNOUNCEMENTS!!!
         
        //Klikker på det første kursus.
        _element = _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div[1]/div/div[1]/div[1]/div[2]/div/d2l-my-courses//d2l-my-courses-container//d2l-tabs/d2l-tab-panel[1]/d2l-my-courses-content//div[2]/div/d2l-enrollment-card[1]//d2l-card//div/a"));
        _element.Click();

        //Henter navnet på kurset vi har klikket på og gemmer det i en String som vi bruger senere.
        _element = _driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div/d2l-image-banner-overlay//div/div[1]/div/h1"));
        String _coursename = _element.Text;

        //Klikker på Announcements så man kommer ind og ser de 20 sidste announcements som standard.
        _element = _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div/div[1]/div[2]/div[1]/div[1]/a/h2"));
        _element.Click();

        //Finder de 10 sidste announcements og lægger dem i et String array sammen med kursus navnet.
        for (int i = 1; i > 11; i=i+2)
        {
            _element = _driver.FindElement(By.XPath("/ html / body / div[3] / div / div[3] / div / div / div[2] / form / div / div / d2l - table - wrapper / table / tbody / tr[" + i + "] / td / div[1] / p / text()"));
            announcements[i][i] = _element.Text;
        }

    }

    public void SeleniumLoginDiplomPortal(String username, String password)
    {
        //Sætter driverens url til diplomportalen.
        _driver.Url = diplomPortal;

        //Klikker på login knappen inde på diplomportalen.
        _element = _driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div/button"));
        _element.Click();

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

        _driver.FindElements(By.XPath("/html/body/div/div/div[2]/div/div/table/tbody/tr/td[2]/text()"));
       
    }

}

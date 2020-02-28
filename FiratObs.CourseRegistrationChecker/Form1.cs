using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiratObs.CourseRegistrationChecker
{
    public partial class Form1 : Form
    {
        IWebDriver webDriver;
        bool isThereEmptyPlace = false;
        string courseInfoText = "";
        TimerManager _timerManager;
        WebDriverWait wait;
        ChromeOptions chromeOptions;
        string userName;
        string password;
        string[] requestedCourses;
        bool isPlaying = false;


        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

        }



        private void btnOk_Click(object sender, EventArgs e)
        {

            userName = tbxUserName.Text;
            password = tbxPassword.Text;
            requestedCourses = tbxCourses.Text.Split('-');

            chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--ignore-certificate-errors");
            chromeOptions.AddArgument("--ignore-ssl-errors");

            btnOk.Text = "Çalışıyor...";
            btnOk.Enabled = false;

            ControlCourse();


        }

        private void ControlCourse()
        {

            try
            {
                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;

                webDriver = new ChromeDriver(service,chromeOptions);
                
                wait = new WebDriverWait(webDriver, timeout: TimeSpan.FromSeconds(45))
                {
                    PollingInterval = TimeSpan.FromSeconds(10),
                };
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

                webDriver.Navigate().GoToUrl("https://jasig.firat.edu.tr/cas/login?service=https://obs.firat.edu.tr/oibs/ogrenci");
                wait.Until(ExpectedConditions.ElementExists(By.Name("username")));
                IWebElement userNameElement = webDriver.FindElement(By.Name("username"));
                wait.Until(ExpectedConditions.ElementExists(By.Name("password")));
                IWebElement passwordElement = webDriver.FindElement(By.Name("password"));
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='fm1']/div[5]/input[4]")));
                IWebElement loginElement = webDriver.FindElement(By.XPath("//*[@id='fm1']/div[5]/input[4]"));


                userNameElement.SendKeys(userName);
                passwordElement.SendKeys(password);
                loginElement.Click();



                IWebElement btnDersDonem = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='lblMenuBuf']/ul/li[3]")));
                btnDersDonem.Click();


                IWebElement btnDersKayit = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='lblMenuBuf']/ul/li[3]/ul/li[1]/a")));
                btnDersKayit.Click();

                wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("IFRAME1")));


                IWebElement btnTeknikSecmeli = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='grdMufDers_btnDK_1']/span")));
                btnTeknikSecmeli.Click();

                Thread.Sleep(5000);
                webDriver.SwitchTo().ParentFrame();
                wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("IFRAME1")));
                wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("bailwal_overlay_frame")));

                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='grdDersler']/tbody")));
                ICollection<IWebElement> courses = webDriver.FindElements(By.XPath("//*[@id='grdDersler']/tbody/tr"));



                courseInfoText += "=========   " + DateTime.Now + "   ============\n\n";

                for (int i = 0; i < courses.Count - 2; i++)
                {
                    IWebElement courseNameElement = courses.ElementAt(i).FindElement(By.XPath("//*[@id='grdDersler']/tbody/tr[" + (i + 2) + "]/td[4]"));
                    IWebElement quota = courses.ElementAt(i).FindElement(By.XPath("//*[@id='grdDersler']/tbody/tr[" + (i + 2) + "]/td[13]"));

                    int quotaSize = Convert.ToInt32(quota.Text.Split('/')[1]);
                    int choosingCount = Convert.ToInt32(quota.Text.Split('/')[0]);

                    foreach (var course in requestedCourses)
                    {
                        if (courseNameElement.Text.Split('[').ElementAt(0).Trim() == course.Trim())
                        {
                            if (quotaSize > choosingCount)
                            {
                                courseInfoText += "\u2705  " + courseNameElement.Text + "(" + quota.Text + ")\n\n";
                                isThereEmptyPlace = true;
                            }
                            else
                            {
                                courseInfoText += courseNameElement.Text + "da boş yer yok. (" + quota.Text + ")\n\n";

                            }
                        }
                    }


                }
                lblCourses.Text = courseInfoText;
                this.Refresh();

                if (isThereEmptyPlace == false)
                {
                    LogQuotaToFile(courseInfoText);
                    webDriver.Quit();
                    courseInfoText = "";

                    ControlCourse();

                }
                else
                {
                    LogQuotaToFile(courseInfoText);
                    PlayNotificationSound(isPlaying);
                    isPlaying = true;
                    courseInfoText = "";
                }


            }
            catch (Exception)
            {

                if (webDriver != null)
                {
                    webDriver.Quit();
                }
                ControlCourse();
            }

            
        }

        void PlayNotificationSound(bool isPlaying)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = Application.StartupPath + "\\Sounds\\ok-notification-alert_C_major.wav";
            if (isPlaying == false)
            {
                player.PlayLooping();
            }
        }
     
        private void LogQuotaToFile(string content)
        {
            string path = Application.StartupPath + "/Quotas.txt";

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Dosya oluşturulma zamanı : " + DateTime.Now);
                    sw.WriteLine("********************************************");
                    sw.WriteLine();
                    sw.WriteLine();
                    
                }
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(content);
                sw.WriteLine();
            }

        }

        private void tbxCourses_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

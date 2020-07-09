using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Pages
{
    public partial class DemoQAPage
    {
        public void AssertPageTitle(string expectedTitle)
        {
            Assert.AreEqual(expectedTitle, PageTitle.Text);
        }
    }
}

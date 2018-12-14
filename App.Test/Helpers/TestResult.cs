using System;
using OpenQA.Selenium;

namespace App.Test.Helpers
{
    public static class TestResult
    {
        public static void Equals(string current, string expected, bool ignoreCase = false)
        {
            if (string.Compare(current, expected, ignoreCase) != 1) throw new Exception($"{current} not equals to {expected}");
            else Console.WriteLine($"Test successfully complited");
        }

        public static void Includes(string current, string expected)
        {
            if (!(current.Contains(expected) || expected.Contains(current))) throw new Exception($"{current} not includes {expected}");
            else Console.WriteLine($"Test successfully complited");
        }

        public static bool IsElementExist(string path)
        {
            try
            {
                SeleniumPropertiesCollection.Driver.FindElement(By.XPath(path));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static void IsFailed()
        {
            Console.WriteLine("Test is failed");
            throw new Exception("Test is failed");
        }

        public static void IsSuccessed()
        {
            Console.WriteLine("Test successfully completed");
        }
    }
}

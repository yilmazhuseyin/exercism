using System;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        bool isNewYork = phoneNumber.Substring(0, 3) == "212";
        bool isFake = phoneNumber.Substring(4, phoneNumber.Length - 5).Contains("555");
        string localNumber = phoneNumber.Substring(8, 4);

        return (IsNewYork: isNewYork, IsFake: isFake, LocalNumber: localNumber);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
         return phoneNumberInfo.IsFake;
    }
}

using System;

namespace BirthdayGreetingsKata.Tests;

public static class OurDateFactory
{
    public static OurDate Create(string yyyyMMdd)
    {
        return new OurDate(DateTime.ParseExact(yyyyMMdd, "yyyy/MM/dd", null));
    }
}
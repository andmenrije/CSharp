using System;
using System.Linq;

public static class Bob
{
    const string WHATEVER_RESPONSE = "Whatever.";
    const string ASKING_RESPONSE = "Sure.";
    const string FORCEFUL_RESPONSE = "Calm down, I know what I'm doing!";
    const string SHOUTING_RESPONSE = "Whoa, chill out!";
    const string SAYING_NOTHING_RESPONSE = "Fine. Be that way!";

    public static string Response(string statement)
    {
        string newStatement = statement.Trim();

        if (newStatement.Trim().Length == 0)
            return SAYING_NOTHING_RESPONSE;

        else if (newStatement.EndsWith('?'))
            return AreAllUpperCase(newStatement) && AreAnyLetters(newStatement) ? FORCEFUL_RESPONSE : ASKING_RESPONSE;

        else if (AreAllUpperCase(newStatement))
            return AreAnyLetters(newStatement) ? SHOUTING_RESPONSE : WHATEVER_RESPONSE;

        else
            return WHATEVER_RESPONSE;
    }

    public static bool AreAllUpperCase(string statement)
    {
        return statement.Any(c => Char.IsLetter(c) && !Char.IsUpper(c)) ? false : true;
    }

    public static bool AreAnyLetters(string statement)
    {
        return statement.Any(c => Char.IsLetter(c));
    }
}
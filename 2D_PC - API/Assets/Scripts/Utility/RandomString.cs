using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class RandomString 
{
    

    public static string RandomNumber(int length)
    {
        StringBuilder str_build = new StringBuilder();

        char letter;

        for (int i = 0; i < length; i++)
        {
            int rand = UnityEngine.Random.Range(0, 10);
            letter = Convert.ToChar(rand + 48);
            str_build.Append(letter);
        }

        return str_build.ToString();
    }
}

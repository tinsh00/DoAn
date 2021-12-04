using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{

    public static sound sd;

    public AudioSource aus;
    public AudioClip cardsd, turnsd,  winsd, losesd, jointablesd;
    public AudioClip clicksd, dialogsd, timesd;

    public AudioSource BGmusic;

    void Awake()
    {
        sd = this;
        aus.mute = PlayerPrefs.GetInt("SOUND", 1) == 0;//0 is off , 1 is on 
    }

    public static bool isOn()
    {
        return !sd.aus.mute;
    }

    public static void ChangeSound()
    {
        sd.MuteSound(isOn());
    }

    public void MuteSound(bool mute)
    {
        aus.mute = mute;
        if (mute)
            PlayerPrefs.SetInt("SOUND", 0);
        else
            PlayerPrefs.SetInt("SOUND", 1);
    }

    public static void Click()
    {
        if (sd)
            sd.aus.PlayOneShot(sd.clicksd);
    }

    public void ShowDialog()
    {
        aus.PlayOneShot(dialogsd);
    }

    public void DealCard()
    {
        aus.PlayOneShot(cardsd);
    }

    public void Turn()
    {
        aus.PlayOneShot(turnsd);
    }

    public void TimeOut()
    {
        aus.PlayOneShot(timesd); // warn when waiting time is almost out
    }

    // Pick a Sit on Table
    public void JoinTable()
    {
        aus.PlayOneShot(jointablesd);
    }


    //Tournament Win
    public void Winning()
    {
        aus.PlayOneShot(winsd);
    }

    public void Losing()
    {
        aus.PlayOneShot(losesd);
    }

    public static void PlayMusic(bool play)
    {
        if (sd && !sd.aus.mute)
        {
            if (play)
                sd.BGmusic.Play();
            else
                sd.BGmusic.Stop();
        }
    }

}

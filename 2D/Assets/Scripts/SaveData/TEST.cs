//using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TEST : MonoBehaviour
{

    //[SerializeField]
    //Sprite m_InSprite;

    //SerializeTexture exportObj = new SerializeTexture();
    //SerializeTexture importObj = new SerializeTexture();

    //[ContextMenu("serialize")]
    //public void SerializeTest()
    //{
    //    Texture2D tex = m_InSprite.texture;
    //    exportObj.x = tex.width;
    //    exportObj.y = tex.height;
    //    exportObj.bytes = ImageConversion.EncodeToPNG(tex);
    //    string text = JsonConvert.SerializeObject(exportObj);
    //    File.WriteAllText(@"d:\test.json", text);
    //}
    //[ContextMenu("deserialize")]
    //public void DeSerializeTest()
    //{
    //    string text = File.ReadAllText(@"d:\test.json");
    //    importObj = JsonConvert.DeserializeObject<SerializeTexture>(text);
    //    Texture2D tex = new Texture2D(importObj.x, importObj.y);
    //    ImageConversion.LoadImage(tex, importObj.bytes);
    //    Sprite mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), Vector2.one);
    //    GetComponent<Image>().sprite = mySprite;
    //}

    //[SerializeField]
    //AudioClip m_InAudioClip;

    //[ContextMenu("serializeAudio")]
    //public void SerializeAudioTest()
    //{
    //    SerializeAudio obj = new SerializeAudio()
    //    {
    //        Name = m_InAudioClip.name,
    //        Samples = m_InAudioClip.samples,
    //        Channels = m_InAudioClip.channels,
    //        Frequency = m_InAudioClip.frequency,
    //        buff = new float[m_InAudioClip.samples * m_InAudioClip.channels]
    //    };
    //    m_InAudioClip.GetData(obj.buff, 0);
    //    string text = JsonConvert.SerializeObject(obj);
    //    File.WriteAllText(@"d:\testAudio.json", text);
    //}
    //[ContextMenu("deserializeAudio")]
    //public void DeSerializeAudioTest()
    //{
    //    AudioSource audioSource = GetComponent<AudioSource>();
    //    audioSource.Stop();
    //    string text = File.ReadAllText(@"d:\testAudio.json");
    //    SerializeAudio obj = JsonConvert.DeserializeObject<SerializeAudio>(text);
    //    AudioClip clip = AudioClip.Create("new_" + obj.Name, obj.Samples, obj.Channels, obj.Frequency, false);
    //    clip.SetData(obj.buff, 0);
    //    audioSource.clip = clip;
    //    audioSource.Play();
    //}
    //[Serializable]
    //public class SerializeAudio
    //{
    //    [SerializeField]
    //    public string Name;
    //    [SerializeField]
    //    public int Samples;
    //    [SerializeField]
    //    public int Channels;
    //    [SerializeField]
    //    public int Frequency;
    //    [SerializeField]
    //    public float[] buff;
    //}


    //[Serializable]
    //public class SerializeTexture
    //{
    //    [SerializeField]
    //    public int x;
    //    [SerializeField]
    //    public int y;
    //    [SerializeField]
    //    public byte[] bytes;
    //}
}

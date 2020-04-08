﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class Dreamlo : MonoBehaviour
{
    const string privateCode = "_K2vRcDpnE2yd5yRfVE1jAn-Wf6tHHVk6edusqouyiWg";
    const string publicCode = "5e8d0e5b403c2d12b8c5e13b";
    const string webURL = "http://dreamlo.com/lb/";
    public Highscore[] highscoresList;
    TMP_Text globalText;
    void Awake()
    {
        //call this function to upload & put your variables inside braces 
        DownloadHighscores();// & this to download
    }
    public void AddNewHighscore(string username, int score)
    {
        StartCoroutine(UploadNewHighscore(username, score));
    }
    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;
        if (string.IsNullOrEmpty(www.error))
            print("Upload Successful");
        else
        {
            print("Error uploading: " + www.error);
        }
    }

    public void DownloadHighscores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }
    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
        }
        else
        {
            print("Error Downloading: " + www.error);
        }
    }
    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);

            globalText.text = ("Global: " + highscoresList[i].score);
        }
    }
}
public struct Highscore
{
    public string username;
    public int score;
    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class DowloadLeaderboardBh : MonoBehaviour
{
    public string[] PlayersData;
    public List<string> PlayersName = new List <string>();
    public List<string> PlayersScore = new List<string>();
    [Header("References:")]
    public LeaderboardEntryBH EntryPrefab;
    public Transform EntryGroup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(GetRequest("http://dreamlo.com/lb/6ac61b388f40bb15a8d2a966/quote"));
        }
    }
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;
            //check errors
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }

            string pageContent = webRequest.downloadHandler.text;

            PlayersData = pageContent.Split('\n');
            PlayersName.Clear();
            PlayersScore.Clear();

            for (int i = 0; i < PlayersData.Length; i++)
            {
                if (!string.IsNullOrEmpty(PlayersData[i]))
                {
                    string[] lineElements = PlayersData[i].Split(',');
                    //string playerNameCleanup = lineElements[0].Trim('"');
                    string playerNameCleanup = lineElements[0].Substring(1, lineElements[0].Length - 2);
                    PlayersName.Add(playerNameCleanup);

                    string scoreCleanup = lineElements[1].Substring(1, lineElements[1].Length - 2);
                    PlayersScore.Add(scoreCleanup);


                    

                }
            }
            RefreshUI();


        }
    }

    void RefreshUI()
    {   //cerco vecchu figli
        LeaderboardEntryBH[] oldEntries= EntryGroup.GetComponentsInChildren<LeaderboardEntryBH>();
        //distruggo vecchi figli
        for (int i = 0; i < oldEntries.Length; i++)
        {
           Destroy(oldEntries[i].gameObject);
        }
        //creo nuovi
        for (int i = 0; i < PlayersName.Count; i++)
        {
           LeaderboardEntryBH currentEntry = Instantiate(EntryPrefab, EntryGroup);
            currentEntry.SetEntryValues((i + 1).ToString(), PlayersName[i], PlayersScore[i]);
        }
    }
}

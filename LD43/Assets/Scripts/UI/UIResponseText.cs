using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResponseText : MonoBehaviour
{

    public string currentMessage { get; set; }

    // Use this for initialization
    void Start()
    {
        currentMessage = "RESPONSE world";
    }

    // Update is called once per frame
    void Update()
    {
        Text t = GetComponent<Text>();
        if (!!t)
            t.text = currentMessage;
    }
}

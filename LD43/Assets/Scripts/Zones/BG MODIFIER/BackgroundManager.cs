using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

    private int z = 15;
    private int relegate_z = 14;

    private string activated_background_id;
    private Dictionary<string, string> backgrounds = new Dictionary<string, string>()
    {
        { "basic","background_basic" },
        { "hell", "background_hell" }
    };

	// Use this for initialization
	void Start () {
        activated_background_id = "basic_id";
    }

    public void changeBackground(string id)
    {
        string new_bg = "";
        bool getval_result = backgrounds.TryGetValue(id, out new_bg);
        if (!!getval_result)
        {
            foreach (Transform child in transform)
            {
                Debug.Log("LOOKIN FOR BACKGROUND .." + new_bg);
                if (child.name == new_bg)
                {
                    Debug.Log("CHANGE BACKGROUND " + new_bg);
                    child.position += new Vector3(0, 0,-1);
                    transform.position += new Vector3(0, 0, 1);
                }
            }//! foreach
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

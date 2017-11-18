using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthText : MonoBehaviour {
    public TextMesh hptext;
    public Player player;
	// Use this for initialization
	void Start () {
        //hptext.GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
        hptext.text = "" + player.health;
    }
}

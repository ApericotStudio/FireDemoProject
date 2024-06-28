using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public BodyController Body;
    public SpiritController Spirit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) //Switch Button
        {
            SwitchPlayers();
        }
    }
    public void SwitchPlayers()
    {
        if (Body.CurrentPlayer == "Battric")
        {
            Spirit.CurrentPlayer = "Battric";
            Spirit.GetComponent<SpriteRenderer>().color = Color.black;
            Body.CurrentPlayer = "Flitter";
            Body.GetComponent<SpriteRenderer>().color = Color.white;
        } else
        {
            Spirit.CurrentPlayer = "Flitter";
            Spirit.GetComponent<SpriteRenderer>().color = Color.white;
            Body.CurrentPlayer = "Battric";
            Body.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}

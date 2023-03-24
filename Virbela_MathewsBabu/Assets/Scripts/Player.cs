using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 LastPosition;
    // Start is called before the first frame update
    void Start()
    {
        LastPosition = Vector3.zero;
        /*Used Playerprefs to save the position of the player.Instead of direct value saving in playerprefs,
          We can use json format to save the state and then can be saved to playerprefs or server,to retrieve it later.*/
        transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerPosX"), transform.position.y, PlayerPrefs.GetFloat("PlayerPosZ"));
    }

    // Update is called once per frame
    void Update()
    {
        //checking for player Movement
        if (LastPosition != transform.position)
        {
            Controller.instance.PlayerMoving = true;
            LastPosition = transform.position;
        }
        else
            Controller.instance.PlayerMoving = false;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosZ", transform.position.z);
    }
}

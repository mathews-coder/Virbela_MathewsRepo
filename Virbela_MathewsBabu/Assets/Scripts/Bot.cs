using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : ObjectClass
{
    private Material DefaultMaterial;
    private void Awake()
    {
        DefaultMaterial = GetComponent<MeshRenderer>().material;
    }
    // Start is called before the first frame update
    void Start()
    {
        /*Following code will apply the base color by accessing the material from mesh renderer.
         I have added this here because each time when an Bot is created the color wll be automatically applied*/
        ApplyHiglightColor(false);

    }

    // Update is called once per frame
    void Update()
    {
        //optimized calling of distance calculation.Only when player is moving.
        if (!Controller.instance.PlayerMoving)
            return;
        print("Bot Update Call");
        CalculateDistance();
        Controller.instance.CalculateNearestObject(this);
    }

    public override void ApplyHiglightColor(bool value)
    {
        if (value)//true for highlight color
        {
            DefaultMaterial.color = Controller.instance.BotHighLightColor;
        }
        else//false for base color
        {
            DefaultMaterial.color = Controller.instance.BotBaseColor;
        }
    }
}

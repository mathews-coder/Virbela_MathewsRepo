using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will be the overall controller for the application
public class Controller : MonoBehaviour
{
    //Common properties can be accessed from this script

    //static instance for the class to easily access it from other scripts
    public static Controller instance;
    [Header("Color Part")]
    //reference to item and bot colors.Its given here so that we dont need to edit for every Bot/Item
    public Color32 ItemBaseColor;
    public Color32 ItemHighlightColor, BotBaseColor, BotHighLightColor;
    [Header("Distance Part")]
    //reference to player transform
    public Transform PlayerTransform;
    [HideInInspector]
    public float shortDistance;//stores the value of shortest of distances from bots/items to player
    private ObjectClass NearestObject;
    [Header("Bot/Item Genration")]
    [SerializeField]
    private GameObject BotPrefab;
    [SerializeField]
    private GameObject ItemPrefab;
    private Vector3 PlayerInitialPos;
    [Header("PlayerMovement")]
    [HideInInspector]
    public bool PlayerMoving;//bool to check whether player is moving or not
    void Awake()
    {
        //its in awake because the instance is accessed by Start() in other class.Awake wll be called first,then Start.
        instance = this;
    }
    private void Start()
    {
        PlayerInitialPos = PlayerTransform.position;
    }
    private void Update()
    {
        //On pressing "B" key it will generate a Bot in random position
        if (Input.GetKeyDown("b"))
        {
            GenerateObjects(BotPrefab);
        }
        else if (Input.GetKeyDown("i"))//On pressing "I" key it will generate an Item in random position
        {
            GenerateObjects(ItemPrefab);
        }
    }
    /* Calculates the nearest object to Player.
     */
    public void CalculateNearestObject(ObjectClass ObjectInstance)
    {
        //when distance of an object is less than the shortDistance,assign that object as nearest Object and apply highlight color
        if (shortDistance == 0 || ObjectInstance.DistanceToPlayer < shortDistance)
        {
            if (NearestObject)
                NearestObject.ApplyHiglightColor(false);
            NearestObject = ObjectInstance;
            NearestObject.ApplyHiglightColor(true);
        }
        //shortest distance need to be updated wrt the nearest object
        if (NearestObject)
            shortDistance = NearestObject.DistanceToPlayer;
    }
    /*Function to generate Objects at random position in relation with Player's initial position.
     Here I am reusing the same function to generate both Bots and items*/
    private void GenerateObjects(GameObject prefabObj)
    {
        Vector3 newPos = PlayerInitialPos + new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
        GameObject BotInstance = Instantiate(prefabObj, newPos, Quaternion.identity, BotPrefab.transform.parent);
    }
}

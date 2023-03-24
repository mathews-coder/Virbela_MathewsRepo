using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DemoTest
{ 
    //Test whether player is static at the starting of application
    [UnityTest]
    public IEnumerator PlayerStatic()
    {
        GameObject controlObj = new GameObject();var controller = controlObj.AddComponent<Controller>();
        GameObject playerobj = new GameObject(); var player = playerobj.AddComponent<Player>();
        controller.PlayerTransform = player.transform;
        yield return new WaitForEndOfFrame();
        Assert.IsFalse(controller.PlayerMoving);
    }
    //Test whether Distance to player is always positive or not
    [UnityTest]
    public IEnumerator DistanceValidationBot()
    {
        GameObject controlObj = new GameObject(); var controller = controlObj.AddComponent<Controller>();
        GameObject playerobj = new GameObject(); var player = playerobj.AddComponent<Player>();
        GameObject botobj = new GameObject();botobj.AddComponent<MeshRenderer>();
        var bot = botobj.AddComponent<Bot>();
        controller.PlayerTransform = player.transform;
        yield return new WaitForSeconds(1);
        Assert.IsTrue(bot.DistanceToPlayer>=0);
    }
}

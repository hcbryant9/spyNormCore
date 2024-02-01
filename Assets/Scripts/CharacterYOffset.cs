using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterYOffset : MonoBehaviour
{
    //this script was created by CompuGenius
    // this script keeps your body from floating when you walk up and down stairs ... etc
    private void LateUpdate()
    {
        var parent = transform.parent;
        var yOffset = parent.localPosition.y;
        var floorElevationOffset = parent.GetComponent<CharacterController>().bounds.min.y;

        transform.localPosition = new Vector3(transform.localPosition.x, floorElevationOffset - yOffset, transform.localPosition.z);
    }
}

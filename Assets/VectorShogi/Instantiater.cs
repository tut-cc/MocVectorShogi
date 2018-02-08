using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiater : MonoBehaviour {
    public static string prefabName = "koma1";

    public void DoInstantiate(Transform root)
    {
        PhotonNetwork.Instantiate(prefabName, root.position, root.rotation, 0);
    }
}

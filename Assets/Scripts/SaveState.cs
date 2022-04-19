using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveState
{
    public int Count { set; get; }
    public bool butterfly2 { set; get; }
    public bool butterfly3 { set; get; }
    public System.DateTime LastSaveTime { set; get; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memo : MonoBehaviour
{
    [Header("노트구조 메모장")]
    [TextArea]
    public string Memonote;

    [Header("만점은 몇점인가")]
    [TextArea]
    public string TotalScore;

    [Header("Bpm은 몇인가")]
    [TextArea]
    public string BPM;

}

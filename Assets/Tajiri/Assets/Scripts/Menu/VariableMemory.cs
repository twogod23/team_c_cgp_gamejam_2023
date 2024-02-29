using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableMemory : MonoBehaviour
{
    public bool isDiffSelected = false;//最初からこうしとけばよかった
    public bool hasExecuted = false;//update関数で常に関数が実行される事態を避ける
}

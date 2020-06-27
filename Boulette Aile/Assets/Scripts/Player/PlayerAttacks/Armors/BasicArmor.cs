using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicArmor : Armor
{
    public override IEnumerator ExecuteAction(Action onFinish)
    {
        yield return null;
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PlanetClass : DestructableObjectClass  
{
    protected override void DestroyObject() {
        //EditorSceneManager.LoadScene("Game Over");
        //TODO: Call Game Over text or scene
        base.DestroyObject();
    }
}

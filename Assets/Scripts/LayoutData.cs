using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LayoutData", menuName = "Scriptable Objects/LayoutData")]
public class LayoutData : ScriptableObject
{
    [SerializeField] private string[] grid = { };
    public string[] Grid
    {
        get
        {
            return grid;
        }

    }
}

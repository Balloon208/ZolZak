using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Fish Data", menuName = "Scriptable Object/Fish Data")]
public class FishData : ScriptableObject
{
    public int id;
    public Sprite fishimage;
    public AnimatorController fishanimation;
    public string fishname;
    public int hp;
    public int speed;
    public string skilldescription;
    public int cost;
}

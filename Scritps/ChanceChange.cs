using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "KnifeSystem/Chance")]
public class ChanceChange : ScriptableObject
{
    [Header("Шанс появления яблока (%)")]
    [Range(0,100)] public int Chance;
    [Header("Очки")]
    public int CircleScore = 10;
    public int AppleScore = 25;
    [Header("Скорость полета ножа")]
    public float knifeSpeed = 25f;
    [Header("Скорость появления нового ножа")]
    public float knifeRespawn = 0.8f;

    [Header("Curve для вращения")]
    public AnimationCurve[] curve;
}

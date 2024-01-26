using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static bool IsWithinDistance(Vector3 positionA, Vector3 positionB, float distanceSq)
    {
        Vector3 positionOffset = positionB - positionA;

        float offsetDistanceSq = positionOffset.x * positionOffset.x + positionOffset.y * positionOffset.y + positionOffset.z * positionOffset.z;

        bool isWithinDistance = distanceSq > offsetDistanceSq;

        return isWithinDistance;
    }

    public static bool IsWithinDistance(Transform transformA, Transform transformB, float distanceSq)
    {
        Vector3 positionA = transformA.position;
        Vector3 positionB = transformB.position;
        return IsWithinDistance(positionA, positionB, distanceSq);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    public int GetNearestEdge(Transform target, Transform location) {
        int min = -1;
        float distance = float.PositiveInfinity;
        for (int i = 0; i < transform.childCount; i++) {
            float currDist = Vector3.Distance(transform.GetChild(i).position, target.position);
            if (currDist < distance) {
                distance = currDist;
                min = i;
            }
        }

        int mask = 1 << LayerMask.NameToLayer("Wall");
        if (!Physics2D.Linecast(location.position,
                                    transform.GetChild(min).position, mask))
        {
            return min * 11;
        } else if (Vector3.Distance(transform.GetChild(min).position, transform.GetChild(Mod(min - 1, transform.childCount)).position)
                   < Vector3.Distance(transform.GetChild(min).position, transform.GetChild(Mod(min + 1, transform.childCount)).position)) {
            if (!Physics2D.Linecast(location.position,
                                    transform.GetChild(Mod(min - 1, transform.childCount)).position, mask)) {
                return min + Mod(min - 1, transform.childCount) * 10;
            } else {
                return min + Mod(min + 1, transform.childCount) * 10;
            }
        } else {
            if (!Physics2D.Linecast(location.position,
                                    transform.GetChild(Mod(min + 1, transform.childCount)).position, mask))
            {
                return min + Mod(min + 1, transform.childCount) * 10;
            }
            else
            {
                return min + Mod(min - 1, transform.childCount) * 10;
            }
        }
    }

    private int Mod(int x, int m) {
        return (x % m + m) % m;
    }
}

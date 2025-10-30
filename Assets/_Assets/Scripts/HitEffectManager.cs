using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectManager : Singleton<HitEffectManager>
{
    [SerializeField] HitEffectMapper[] effectMap;

    public GameObject GetEffectPrefab(HitSurfaceType surfaceType)
    {
        HitEffectMapper mapper = System.Array.Find(
            effectMap, x => x.surface == surfaceType);
        return mapper?.effPrefab;
    }
}

public enum HitSurfaceType
{
    Dirt = 0,
    Blood = 1
}

[System.Serializable]
public class HitEffectMapper
{
    [SerializeField] internal HitSurfaceType surface;
    [SerializeField] internal GameObject effPrefab;
}

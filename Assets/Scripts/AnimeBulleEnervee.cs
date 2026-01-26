using UnityEngine;

public class AnimeBulleEnervee : MonoBehaviour
{
    public Vector3 basePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        basePos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = basePos + Random.insideUnitSphere * 2f;
    }
}

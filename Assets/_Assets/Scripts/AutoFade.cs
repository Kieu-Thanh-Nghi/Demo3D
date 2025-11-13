using UnityEngine.UI;
using UnityEngine;

public class AutoFade : MonoBehaviour
{
    [SerializeField] float visibleDuration, HideDuration;
    [SerializeField] Image theImage;
    float startTime;

    public void Show()
    {
        startTime = Time.time;
        gameObject.SetActive(true);
        SetAlpha(1f);
    }

    // Update is called once per frame
    void Update()
    {
        float elapseTime = Time.time - startTime;
        if (elapseTime < visibleDuration) return;
        elapseTime -= visibleDuration;
        if(elapseTime < HideDuration)
        {
            SetAlpha(1f - elapseTime / HideDuration);
        }
        else
        {
            Hide();
        }
    }

    void SetAlpha(float alpha)
    {
        Color newColor = theImage.color;
        newColor.a = alpha;
        theImage.color = newColor;
    }

    void Hide() => gameObject.SetActive(false);

    private void OnValidate()
    {
        theImage = GetComponent<Image>();
    }
}

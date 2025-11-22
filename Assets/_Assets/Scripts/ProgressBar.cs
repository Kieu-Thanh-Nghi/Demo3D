using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Image progressBarImage;
    public void SetProgressVal(float progress)
    {
        progressBarImage.fillAmount = progress;
    }
}

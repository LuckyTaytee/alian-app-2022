using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeLevelChangerLoadingToHalamanUtama : MonoBehaviour
{
    public Animator animator;

    private string levelToLoad;

    public Transform masukanLoadingbar;

    [SerializeField]
    private float nilaiSekarang;
    [SerializeField]
    private float nilaiKecepatan;

    // Update is called once per frame
    void Update()
    {
        if (nilaiSekarang < 100)
        {
            nilaiSekarang += nilaiKecepatan * Time.deltaTime;
            Debug.Log((int)nilaiSekarang);
        }
        else
        {
            FadeToLevel("MainMenuLangit");
        }
        masukanLoadingbar.GetComponent<Image>().fillAmount = nilaiSekarang / 100;

    }
   

    public void FadeToLevel (string SceneName)
    {
        levelToLoad = SceneName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Texture[] theme;
    private int index = 0;
    private PostEffect effect;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        effect = Camera.main.GetComponent<PostEffect>();
        source = GetComponent<AudioSource>();
        StartCoroutine(Clock());
    }

    IEnumerator Clock()
    {
        while (true)
        {
            effect.SetColorTheme(theme[++index % theme.Length]);
            for (int i = 0; i < 10; i++)
            {
                source.Play();
                yield return new WaitForSeconds(1f);
            }
        }
    }
}

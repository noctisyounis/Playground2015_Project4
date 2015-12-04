using UnityEngine;
using System.Collections;

public class nextBehaviour : MonoBehaviour {
    public string m_button;
    public int m_nbreSlide = 4;
    public GameObject m_slide;
    private int m_currentSlide;
    public void onClick()
    {
        if (m_button == "suivant")
        {
            if (m_currentSlide < m_nbreSlide)
            {
            iTween.MoveTo(m_slide, new Vector3(),1f);
            m_currentSlide++;
            }
        }
        else
        {
            if (m_currentSlide > m_nbreSlide)
            {
                iTween.MoveTo(m_slide, new Vector3(), 1f);
                m_currentSlide--;
            }
        }
    }
}

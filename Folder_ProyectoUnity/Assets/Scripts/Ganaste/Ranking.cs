using UnityEngine;
using TMPro;

public class Ranking : MonoBehaviour
{
    #region Variables

    [SerializeField] private Puntos puntos;
    [SerializeField] private TMP_Text text1;
    [SerializeField] private TMP_Text text2;
    [SerializeField] private TMP_Text text3;

    #endregion

    #region Unity Method

    private void Start()
    {
        MostrarTop3();
    }

    #endregion

    #region MostrarTop3

    private void MostrarTop3()
    {
        var lista = puntos.ObtenerLista();
        int cantidad = lista.Count;

        text1.text = cantidad > 0 ? $"1° {lista[0]} pts" : "1° ---";
        text2.text = cantidad > 1 ? $"2° {lista[1]} pts" : "2° ---";
        text3.text = cantidad > 2 ? $"3° {lista[2]} pts" : "3° ---";
    }

    #endregion
}

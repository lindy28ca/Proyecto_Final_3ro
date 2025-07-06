using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPuntos", menuName = "Datos/Puntos")]
public class Puntos : ScriptableObject
{
    #region Variables

    [SerializeField] private List<int> puntos = new List<int>();

    #endregion

    #region Métodos Públicos

    public void AgregarPunto(int punto)
    {
        puntos.Add(punto);
        InsertionSort(puntos);
    }

    public List<int> ObtenerLista()
    {
        return new List<int>(puntos);
    }

    #endregion

    #region Métodos Privados

    private void InsertionSort(List<int> list)
    {
        for (int i = 1; i < list.Count; i++)
        {
            int key = list[i];
            int j = i - 1;

            while (j >= 0 && list[j] > key)
            {
                list[j + 1] = list[j];
                j--;
            }

            list[j + 1] = key;
        }
    }

    #endregion
}

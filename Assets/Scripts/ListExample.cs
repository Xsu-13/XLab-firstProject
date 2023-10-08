using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyCollections;

public class ListExample : MonoBehaviour
{
    void Start()
    {
        MyLinkedList<int> list = new();
        Debug.Log("Добавим элементы(int): ");
        list.AddLast(5);
        list.AddLast(2);
        list.AddLast(66);
        List<int> values = new(){ 7, 83, 2, 70 };
        list.AddLast(values);
        list.AddLast(55);
        Debug.Log(list);
        Debug.Log("Size: "+ list.Count);

        Debug.Log("Удалим двойки: ");
        list.RemoveValues(2);
        Debug.Log(list);
        Debug.Log("Size: " + list.Count);

        Debug.Log("Очистим список: ");
        list.Clear();
        Debug.Log("Size: " + list.Count);

        Debug.Log("Добавим элементы(int): ");
        values = new() { 27, 60, 87, 2, 11 };
        list.AddLast(values);
        Debug.Log(list);

        Debug.Log("Добавим 66 после 11: ");
        list.AddAfter(11, 66);
        Debug.Log("Добавим 5 перед 27: ");
        list.AddBefore(27, 5);
        Debug.Log(list);

        Debug.Log("------------");
        Debug.Log("Добавим элементы(string): ");
        MyLinkedList<string> list2 = new();
        list2.AddLast("5");
        list2.AddLast("7");
        list2.AddLast("66");
        Debug.Log(list2);

        Debug.Log("Удалим 7: ");
        list2.RemoveValues("7");
        Debug.Log(list2);

        Debug.Log("перечислим элементы: ");
        foreach(var l in list2)
        {
            Debug.Log(l);
        }

        Debug.Log("Добавим 7: ");
        list2.AddLast("7");

        Debug.Log("снова перечислим элементы: ");
        foreach (var l in list2)
        {
            Debug.Log(l);
        }

        Debug.Log("список содержит 66? ");
        Debug.Log(list2.Contains("66"));

        Debug.Log("список содержит 67? ");
        Debug.Log(list2.Contains("67"));
        Debug.Log("The END");
    }
}

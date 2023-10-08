using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyCollections;

public class ListExample : MonoBehaviour
{
    void Start()
    {
        MyLinkedList<int> list = new();
        Debug.Log("������� ��������(int): ");
        list.AddLast(5);
        list.AddLast(2);
        list.AddLast(66);
        List<int> values = new(){ 7, 83, 2, 70 };
        list.AddLast(values);
        list.AddLast(55);
        Debug.Log(list);
        Debug.Log("Size: "+ list.Count);

        Debug.Log("������ ������: ");
        list.RemoveValues(2);
        Debug.Log(list);
        Debug.Log("Size: " + list.Count);

        Debug.Log("������� ������: ");
        list.Clear();
        Debug.Log("Size: " + list.Count);

        Debug.Log("������� ��������(int): ");
        values = new() { 27, 60, 87, 2, 11 };
        list.AddLast(values);
        Debug.Log(list);

        Debug.Log("������� 66 ����� 11: ");
        list.AddAfter(11, 66);
        Debug.Log("������� 5 ����� 27: ");
        list.AddBefore(27, 5);
        Debug.Log(list);

        Debug.Log("------------");
        Debug.Log("������� ��������(string): ");
        MyLinkedList<string> list2 = new();
        list2.AddLast("5");
        list2.AddLast("7");
        list2.AddLast("66");
        Debug.Log(list2);

        Debug.Log("������ 7: ");
        list2.RemoveValues("7");
        Debug.Log(list2);

        Debug.Log("���������� ��������: ");
        foreach(var l in list2)
        {
            Debug.Log(l);
        }

        Debug.Log("������� 7: ");
        list2.AddLast("7");

        Debug.Log("����� ���������� ��������: ");
        foreach (var l in list2)
        {
            Debug.Log(l);
        }

        Debug.Log("������ �������� 66? ");
        Debug.Log(list2.Contains("66"));

        Debug.Log("������ �������� 67? ");
        Debug.Log(list2.Contains("67"));
        Debug.Log("The END");
    }
}

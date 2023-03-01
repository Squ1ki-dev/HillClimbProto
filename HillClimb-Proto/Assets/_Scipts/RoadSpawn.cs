using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawn : MonoBehaviour
{
    [SerializeField] private GameObject self;
    [SerializeField] private int track_length;

	//*******temporary variable*******//
    private Vector3 tmpv3;

    [SerializeField] private Transform CameraPos;

	private bool move = false;

    private List<Transform> Grounds = new List<Transform>();

    [SerializeField] private GameObject[] GroundItems;
    [SerializeField] private GameObject[] m_AllGroundItems;

    private void Awake() => Init();

    private void Init()
    {
		int index = 0; // fillin an GroundItem array, num of elements in m_AllGroundItems - the num of elements in GroundItems

        for (int i = 0; i < GroundItems.Length; i++)
		{
			GroundItems[i] = m_AllGroundItems[i + index];
		}

		GenerateGround();
        StartCoroutine(ChekGround());
    }

    private GameObject CreateGameObject(GameObject obj, bool defaultPos = true, Vector3 pos = default(Vector3))
	{
		GameObject result = null;
		if (obj != null)
		{
			if (!defaultPos)
				pos = obj.transform.position;

			result = Instantiate(obj, pos, Quaternion.identity) as GameObject;
			result.transform.SetParent(self.transform);
		}
		else
			Debug.LogError("CreateGameObject is called with null obj argument");

		return result;
	}

    private void GenerateGround()
	{
		float GroundShift = 19.15f;
		tmpv3.y = -6.4f;
		tmpv3.x = 0;
		tmpv3.z = 0;

		for (int i = 0; i < track_length; i++)
		{
			if ((i < 2) || (i > (track_length - 4)))
				Grounds.Add(CreateGameObject(GroundItems[0], true, tmpv3).transform);
			else
				Grounds.Add(CreateGameObject(GroundItems[Random.Range(1, GroundItems.Length)], true, tmpv3).transform);
			tmpv3.x += GroundShift;
		}
		Grounds.TrimExcess();
	}

    private IEnumerator ChekGround()
	{
		while (!move)
		{
			yield return new WaitForSeconds(2f);
			for (int i = 0; i < Grounds.Count; i++)
			{
				if (Mathf.Abs(Grounds[i].transform.position.x - CameraPos.transform.position.x) > 40)
					Grounds[i].gameObject.SetActive(false);		
				else
					Grounds[i].gameObject.SetActive(true);
			}
		}
	}
}

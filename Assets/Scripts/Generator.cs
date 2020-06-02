using System.Collections;
﻿using UnityEngine;

public class Generator : MonoBehaviour
{
  [SerializeField]  private GameObject[] _barriers;
  private float _startY = 10;

  private void FixedUpdate()
  {
    if(GameManager.Instance.canSpawn)
    {
      StartCoroutine("SpawnBarriers");
      GameManager.Instance.canSpawn = false;
    }
  }

  private IEnumerator SpawnBarriers()
  {
    while(true)
    {
      Instantiate(_barriers[Random.Range(0, _barriers.Length)], new Vector2(0, _startY), Quaternion.identity);
      _startY += 7;
      yield return new WaitForSeconds(GameManager.Instance.spawnRate);
    }
  }
}

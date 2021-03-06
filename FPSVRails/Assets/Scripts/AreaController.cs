﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour {
    [SerializeField] List<EnemyArea> m_enemies;
    [SerializeField] CameraMovement m_camMov;

    public void Remove(EnemyArea enemy) {
        m_enemies.Remove(enemy);
        if (m_enemies.Count == 0) {
            m_camMov.NextArea();
        }
    }

}
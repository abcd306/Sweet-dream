using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 이거랑 코인 스크립트 수정, 에셋 - 이펙트에서 삭제
public class CoinBurst : MonoBehaviour
{
    private ParticleSystem coinParticle;

        void Start()
        {
            coinParticle = GetComponent<ParticleSystem>();
        }
}

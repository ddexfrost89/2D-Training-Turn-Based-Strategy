using System;
using System.Collections.Generic;

[Serializable()]
public class UnitClass
{
    public int Type, ID, AttackType;
	public string Name;
    public float MoveEnergy, AttackEnergy;
    public float PerfectDist, maxdist;
    public List<SpecialrulesClass> SpR;
    public int minDamage, maxDamage, HP;
}
using System;

[Serializable]
public class BlockModel 
{
    public enum Type 
    {
        DK = 0,
        DS1,
        DS2,
        DSK,
        GR,
        KI,
        PO1,
        PO2,
        PO3,
        PO4,
        SK,
        SN,
        HA,
        DH,
        MStart,
        Empty,
        End,
        SN1
    };

    public Type type = Type.DK;
    public EnemyModel[] enemys;

}

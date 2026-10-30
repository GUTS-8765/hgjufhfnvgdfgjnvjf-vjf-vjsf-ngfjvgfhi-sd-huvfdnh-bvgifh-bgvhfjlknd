namespace CalcDeliveryNs;

public static class CalcDeliveryOld
{
    
    public static int Calc(int weight)
        => 200 + WeightSurcharge(weight);

    public static int WeightSurcharge(int weight)
        => weight > 10 ? (weight - 10) * 30 : 0;
}
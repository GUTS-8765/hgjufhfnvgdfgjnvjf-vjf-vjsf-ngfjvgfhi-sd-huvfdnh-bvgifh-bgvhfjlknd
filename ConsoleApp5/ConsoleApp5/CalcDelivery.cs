namespace CalcDeliveryNs;

public static class CalcDelivery
{
    
    public static int Calc(int weight)
    {
        int total = 250 + WeightSurcharge(weight);
        if (weight > 20)
            total = (int)Math.Round(total * 0.95, MidpointRounding.AwayFromZero);
        return total;
    }

    public static int WeightSurcharge(int weight)
        => weight > 10 ? (weight - 10) * 30 : 0;
}
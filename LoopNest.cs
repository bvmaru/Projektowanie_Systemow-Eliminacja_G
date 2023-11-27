namespace Eliminacja_G
{
    public class LoopNest
    {
        //Class represents the table model on the basis of which the graph can be made.
        public int nr { get; set; }
        public int W1 { get; set; }
        public int W2 { get; set; }
        public int W3 { get; set; }
        public ValueTuple<int,int> Im { get; set; }
        public ValueTuple<int, int> Ia11 { get; set; }
        public ValueTuple<int, int> Ia13 { get; set; }
        public ValueTuple<int, int> Ia21 { get; set; }
        public ValueTuple<int, int> Ia23 { get; set; }
        public string Operation { get; set; }

        //public LoopNest()
        //{
        //    nr = new int();
        //    W1 = new int();
        //    W2 = new int();
        //    W3 = new int();
        //    Im = new ValueTuple<int, int>();
        //    Ia11 = new ValueTuple<int, int>();
        //    Ia13 = new ValueTuple<int, int>();
        //    Ia21 = new ValueTuple<int, int>();
        //    Ia23 = new ValueTuple<int, int>();
        //}
    }
}

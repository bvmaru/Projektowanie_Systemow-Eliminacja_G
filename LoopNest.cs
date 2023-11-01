namespace Eliminacja_G
{
    public class LoopNest
    {
        //Class represents the table model on the basis of which the graph can be made.
        public List<int> nr { get; set; }
        public List<int> W1 { get; set; }
        public List<int> W2 { get; set; }
        public List<int> W3 { get; set; }
        public List<ValueTuple<int,int>> Im { get; set; }
        public List<ValueTuple<int, int>> Ia2 { get; set; }
        public List<ValueTuple<int, int>> Ia1 { get; set; }

        public LoopNest()
        {
            nr = new List<int>();
            W1 = new List<int>();
            W2 = new List<int>();
            W3 = new List<int>();
            Im = new List<ValueTuple<int,int>>();
            Ia2 = new List<ValueTuple<int,int>>();
            Ia1 = new List<ValueTuple<int,int>>();
        }
    }
}

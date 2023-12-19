using System.Collections.Generic;

namespace Models
{
    [System.Serializable]
    public class User
    {
        public string Name { get; set; }
        public int Balance { get; set; }
        public int Hand { get; set; }
        public List<(string, int)> History = new();
        public State.State.StateModel CurrentState { get; set; }
    }
}

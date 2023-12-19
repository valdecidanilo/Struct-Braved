namespace State
{
    public class State
    {
        public enum StateModel
        {
            Spectate,
            Betting,
            AutoBetting
        }
        public static StateModel CurrentState = StateModel.Spectate;
    }
}

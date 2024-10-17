using Ara3D.Parakeet;
using Ara3D.Parakeet.Grammars;

namespace PioneerRobot
{
    public class RobotGrammar : BaseCommonGrammar
    {
        public static readonly RobotGrammar Instance = new RobotGrammar();
        public override Rule StartRule => Command;
        //public Rule AdvanceOnFail => OnFail(Token.RepeatUntilPast(EOS | "}"));
        public Rule Right => Node(Keyword("RIGHT"));
        public Rule Left => Node(Keyword("LEFT"));
        public Rule Report => Node(Keyword("REPORT"));
        public Rule Move => Node(Keyword("MOVE"));
        public Rule XPos => Node(Integer);
        public Rule YPos => Node(Integer);
        public Rule Direction => Named(Node(Symbols(Tabletop.Directions.ToArray())));
        public Rule Place => Node(Keyword("PLACE") + XPos + Comma + YPos + Comma + Direction);
        public Rule Action => Move | Report | Left | Right | Place;
        public Rule Command => Node(Place + ZeroOrMore(Action));

    }
}

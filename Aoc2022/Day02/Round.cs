namespace Aoc2022.Day02
{
    internal abstract class Round
    {
        public Shape OpponentShape => GetOpponentShape();

        public Shape ResponseShape => GetResponseShape();

        public int ResponseValue => GetResponseValue();

        public int OpponentValue => GetOpponentValue();

        public int Score => CalculateScore();

        private readonly char opponentChar;
        
        public Round(char opponentChar)
        {
            this.opponentChar = opponentChar;
        }

        protected Shape GetResponseShape()
        {
            return (Shape)ResponseValue;
        }

        protected abstract int GetResponseValue();

        private int GetOpponentValue()
        {
            return opponentChar - 'A' + 1;
        }

        private Shape GetOpponentShape()
        {
            return (Shape)OpponentValue;
        }

        private int CalculateScore()
        {
            return ResponseValue + (int) CalculateResult();
        }

        private Result CalculateResult()
        {
            if (OpponentShape == ResponseShape)
                return Result.Draw;

            return (int)ResponseShape - 1 == (int)OpponentShape % 3 ? Result.Win : Result.Lose;
        }
    }

    internal class ResponseRound: Round
    {

        private readonly char responseChar;
        
        public ResponseRound(char opponent, char response)
        : base(opponent)
        {
            this.responseChar = response;
        }

        protected override int GetResponseValue()
        {
            return responseChar - 'X' + 1;
        }
    }

    internal class ResultRound: Round
    {
        private readonly char resultChar;
        public int ResultValue => GetResultValue();
        public Result ResultType => GetResultType();
        
        public ResultRound(char opponent, char result)
        : base(opponent)
        {
            this.resultChar = result;
        }

        private int GetResultValue()
        {
            return (resultChar - 'X') * 3;
        }

        private Result GetResultType()
        {
            return (Result) ResultValue;
        }

        protected override int GetResponseValue()
        {
            if (ResultType == Result.Draw)
                return (int) OpponentShape;
            
            return (ResultType == Result.Win ? (int)OpponentShape : (int) OpponentShape + 1) % 3 + 1;

        }
    }
}

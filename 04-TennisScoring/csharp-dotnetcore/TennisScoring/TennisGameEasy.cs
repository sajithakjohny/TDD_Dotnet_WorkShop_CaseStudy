namespace Katas
{
    public class TennisGameEasy : ITennisGame
    {
        public int P1point = 0;
        public int P2point = 0;

        public string P1res = "";
        public string P2res = "";
        private string player1Name;
        private string player2Name;

        public TennisGameEasy(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            string score = "";
            if (P1point == P2point)
            {
                if (P1point < 4)
                {
                    switch (P1point)
                    {
                        case 0:
                            score = "Love";
                            break;
                        case 1:
                            score = "Fifteen";
                            break;
                        case 2:
                            score = "Thirty";
                            break;
                    }
                    score += "-All";
                }
                if(P1point >= 3)
                    score = "Deuce";
            }
             if (P1point > 0 && P2point == 0)
            {
                switch (P1point)
                {
                    case 1:
                        P1res = "Fifteen";
                        break;
                    case 2:
                        P1res = "Thirty";
                        break;
                    case 3:
                        P1res = "Forty";
                        break;

                }
                P2res = "Love";
                score = P1res + "-" + P2res;
            }
             if (P2point > 0 && P1point == 0)
            {
                switch (P2point)
                {
                    case 1:
                        P2res = "Fifteen";
                        break;
                    case 2:
                        P2res = "Thirty";
                        break;
                    case 3:
                        P2res = "Forty";
                        break;

                }
                P1res = "Love";
                score = P1res + "-" + P2res;
            }
            if (P1point > P2point)
            {
                if (P1point < 4)
                {
                    switch (P1point)
                    {
                        case 2:
                            P1res = "Thirty";
                            break;
                        case 3:
                            P1res = "Forty";
                            break;
                    }
                    switch (P2point)
                    {
                        case 1:
                            P2res = "Fifteen";
                            break;
                        case 2:
                            P2res = "Thirty";
                            break;
                    }
                    score = P1res + "-" + P2res;
                }
                if (P2point >= 3)
                {
                    score = "Advantage player1";
                }
            }
            if (P2point > P1point)
            {
                if (P2point < 4)
                {
                    switch (P2point)
                    {
                        case 2:
                            P2res = "Thirty";
                            break;
                        case 3:
                            P2res = "Forty";
                            break;
                    }
                    switch (P1point)
                    {
                        case 1:
                            P1res = "Fifteen";
                            break;
                        case 2:
                            P1res = "Thirty";
                            break;
                    }
                    score = P1res + "-" + P2res;
                }
                if (P1point >= 3)
                {
                    score = "Advantage player2";
                }

            }             

             if (P1point >= 4 && P2point >= 0 && (P1point - P2point) >= 2)
            {
                score = "Win for player1";
            }
             if (P2point >= 4 && P1point >= 0 && (P2point - P1point) >= 2)
            {
                score = "Win for player2";
            }
            return score;           
        }

        public void SetP1Score(int number)
        {

            for (int i = 0; i < number; i++)
            {
                P1Score();
            }

        }

        public void SetP2Score(int number)
        {

            for (int i = 0; i < number; i++)
            {
                P2Score();
            }

        }

        public void P1Score()
        {
            P1point++;
        }

        public void P2Score()
        {
            P2point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }
    } 
}

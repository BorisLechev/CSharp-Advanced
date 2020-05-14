namespace Tetris
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public class ScoreManager
    {
        private readonly string hignScoreFile;

        public ScoreManager(string hignScoreFile)
        {
            this.hignScoreFile = hignScoreFile;
        }

        public int GetHignScore()
        {
            var hignScore = 0;

            if (File.Exists(this.hignScoreFile))
            {
                var allScores = File.ReadAllLines(this.hignScoreFile);

                foreach (var score in allScores)
                {
                    var match = Regex.Match(score, @" => (?<score>[0-9]+)");

                    hignScore = Math.Max(hignScore, int.Parse(match.Groups["score"].Value));
                }
            }

            return hignScore;
        }

        public void Add(int score)
        {
            File.AppendAllLines(this.hignScoreFile, new List<string>
            {
                $"[{DateTime.Now.ToString()}] {Environment.UserName} => {score}"
            });
        }
    }
}

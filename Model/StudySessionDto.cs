using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Model {
    internal class StudySessionDto {
        public StudySessionDto(string date, int score, string stackName ) {
            Date = date;
            Score = score;
            StackName = stackName; 
        }

        public string StackName { get; set; }
        public string Date { get; set; }
        public int Score { get; set; }

    }
}

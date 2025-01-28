using System;
using System.Collections.Generic;

namespace ConsoleApp9
{
    class Task2
    {
        public interface IGradeCalculator
        {
            double CalculateGrade();
        }

        public class Assignment : IGradeCalculator
        {
            private double _maxScore;
            private double _scoreAchieved;

            public double MaxScore
            {
                get { return _maxScore; }
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("MaxScore must be greater than zero.");
                    _maxScore = value;
                }
            }

            public double ScoreAchieved
            {
                get { return _scoreAchieved; }
                set
                {
                    if (value < 0 || value > MaxScore)
                        throw new ArgumentException("ScoreAchieved must be between 0 and MaxScore.");
                    _scoreAchieved = value;
                }
            }

            public double CalculateGrade()
            {
                return (ScoreAchieved / MaxScore) * 100;
            }
        }

        public class Exam : IGradeCalculator
        {
            private double _maxMarks;
            private double _marksObtained;

            public double MaxMarks
            {
                get { return _maxMarks; }
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("MaxMarks must be greater than zero.");
                    _maxMarks = value;
                }
            }

            public double MarksObtained
            {
                get { return _marksObtained; }
                set
                {
                    if (value < 0 || value > MaxMarks)
                        throw new ArgumentException("MarksObtained must be between 0 and MaxMarks.");
                    _marksObtained = value;
                }
            }

            public double CalculateGrade()
            {
                return (MarksObtained / MaxMarks) * 100;
            }
        }

        public static void Execute()
        {
            Assignment assignment = new Assignment
            {
                MaxScore = 100,
                ScoreAchieved = 85
            };

            Exam exam = new Exam
            {
                MaxMarks = 100,
                MarksObtained = 92
            };

            List<IGradeCalculator> gradeCalculators = new List<IGradeCalculator> { assignment, exam };

            foreach (var calculator in gradeCalculators)
            {
                Console.WriteLine($"{calculator.GetType().Name} Grade: {calculator.CalculateGrade():F2}%");
            }
        }
    }
}

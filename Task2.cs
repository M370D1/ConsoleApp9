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
            public double MaxScore { get; set; }
            public double ScoreAchieved { get; set; }

            public double CalculateGrade()
            {
                return (ScoreAchieved / MaxScore) * 100;
            }
        }

        public class Exam : IGradeCalculator
        {
            public double MaxMarks { get; set; }
            public double MarksObtained { get; set; }

            public double CalculateGrade()
            {
                return (MarksObtained / MaxMarks) * 100;
            }
        }

        public static void Execute()
        {
            Assignment assignment = new Assignment { MaxScore = 100, ScoreAchieved = 85 };
            Exam exam = new Exam { MaxMarks = 100, MarksObtained = 92 };

            List<IGradeCalculator> gradeCalculators = new List<IGradeCalculator> { assignment, exam };

            foreach (var calculator in gradeCalculators)
            {
                Console.WriteLine($"{calculator.GetType().Name} Grade: {calculator.CalculateGrade():F2}%");
            }
        }

    }
}

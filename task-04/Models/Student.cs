namespace StudentManagerApp.Models
{
    public class Student
    {
        public string Name { get; set; }
        public double Grade { get; set; }
        public int Age { get; set; }

        public Student(string name, double grade, int age)
        {
            Name = name;
            Grade = grade;
            Age = age;
        }

        public override string ToString()
        {
            return $"Name: {Name,-10} | Age: {Age,-3} | Grade: {Grade:F1}";
        }
    }
}

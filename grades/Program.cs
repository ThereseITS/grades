namespace grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] bands = { 80, 70, 60, 50, 40, 0 };
            char[] grades = { 'A', 'B', 'C', 'D', 'E', 'F' };

            int[] cumulativeMarks = new int[grades.Length];
            int[] counts = new int[grades.Length];

            char grade;
            int mark = 0;

            try
            {
                while ((mark = GetValidStudentMark()) != -999)
                {

                    grade = GetGrade(mark, grades, bands);
                    int index = Array.IndexOf(grades, grade);
                    cumulativeMarks[index] += mark;
                    counts[index]++;

                    Console.WriteLine($"The grade for {mark} is {grade}");



                }
                PrintReport(grades, counts, cumulativeMarks);
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("There are no students");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        static char GetGrade(int mark, char[]grades, int[] bands) 
        {
            char grade= ' ';

            for(int i=0;i<grades.Length;i++)
            {
                if (mark >= bands[i])
                {
                    grade = grades[i];
                    return grade;
                }
            }
            return grade;
        
        }

        static int GetValidStudentMark()
        {
            int mark=0;

            Console.WriteLine("Please Enter Mark: ");
            while (!(int.TryParse(Console.ReadLine(), out mark))||((mark<0)||(mark>100)) &&(mark!=-999))
            {
                Console.WriteLine("Please enter a valid mark between 0 and 100");
            }
            return mark;
        }
        static void PrintReport(char[] grades, int[] counts, int[] cumulativeMarks)
        {
            int totalStudents = 0;
            int cumulativeMark = 0;
            int average=-1;

            Console.WriteLine("Grade Report");
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > 0)
                {
                    Console.WriteLine($"{grades[i]}  {counts[i]}  {cumulativeMarks[i] / counts[i]}");
                }
                else
                {
                    Console.WriteLine($"{grades[i]}  {counts[i]}");
                }

                totalStudents += counts[i];
                cumulativeMark += cumulativeMarks[i];
            }
          
                average = (int)((double)cumulativeMark / (double)totalStudents);
            
        
            Console.WriteLine($"{average}  {totalStudents}");
        }
    }
}

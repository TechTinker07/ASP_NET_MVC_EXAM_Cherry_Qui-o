using System.Diagnostics;
using ASP_NET_MVC_EXAM_Cherry_Quiño.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_MVC_EXAM_Cherry_Quiño.Controllers
{
    public class HomeController : Controller
    {
     

        public IActionResult Index()
        {
            // 🧠 Part I: Variables and Data Types
            string studentName = " Cherry Mae";
            int score = 87;
            bool isPassed = (score >= 75);
            DateTime examDate = DateTime.Now;
            decimal tuitionFee = 15500.75m;

            ViewBag.studentName = studentName;
            ViewBag.score = score;
            ViewBag.isPassed = isPassed;
            ViewBag.ExamDate = examDate;
            ViewBag.TuitionFee = tuitionFee;

            //Grade computation gamit ang if-else
            string grade;
            if (score >= 90)
                grade = "A";
            else if (score >= 80)
                grade = "B";
            else if (score >= 75)
                grade = "C";
            else 
                grade = "F";

            ViewBag.grade = grade;


            //Congrats Message
            if (isPassed)
                ViewBag.Message = "Congratulations, you passed!";
            else
                ViewBag.Message = "Better luck next time.";

            //Loops and Arrays 
            string[] courses = { "Web Systems", "OOP", "DBMS", "UI/UX", "Networking" };
            string courselist = string.Join(",", courses);
            int courseCount = courses.Length;

            ViewBag.CourseList = courselist;
            ViewBag.CourseCount = courseCount;

            //Method for Net Fee
            decimal netFee = ComputeNetFee(tuitionFee, 10); // may 10% dicount
            ViewBag.NetFee = netFee;

            //👤 Part II: Single Object
            Student student = new Student()
            {
                Name = " Cherry",
                Age = 21,
                Course = "BSIT"
            };
            ViewBag.Student = student;

            // 👥 Part II: List of Students
            List<Student> students = new List<Student>()
            {
                new Student {Name = "Maria Santos", Age = 20, Course = "Web Systems"},
                new Student {Name = "Pedro Ramirez", Age = 21, Course = "OOP"},
                new Student {Name = "Angelica Reyes", Age = 22, Course = "DBMS"},
            };
            ViewBag.Students = students;

            //Bonus: Today's Date
            ViewBag.Today = DateTime.Now.ToString("MMMM dd, yyyy");   


            return View();
        }
        private decimal ComputeNetFee(decimal tuition, decimal discountPercent)
        {
            return tuition - (tuition * discountPercent / 100);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using SoftUni.Data;
using System.Linq;
using System;
using System.Text;
using System.Globalization;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var result = RemoveTown(context);

                Console.WriteLine(result);
            }
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var seattle = context.Towns.First(x => x.Name == "Seattle");

            var addresses = context.Addresses
                .Where(a => a.Town == seattle);

            int count = addresses.Count();

            var employees = context.Employees
                .Where(e => e.Address.Town == seattle);

            foreach (var emp in employees)
            {
                emp.Address = null;
            }

            context.Addresses.RemoveRange(addresses);

            context.Towns.Remove(seattle);

            return $"{count} addresses in Seattle were deleted";
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects.Find(2);
            var employeeProject = context.EmployeesProjects
                .Where(e => e.ProjectId == 2)
                .ToList();

            foreach (var item in employeeProject)
            {
                context.EmployeesProjects.Remove(item);
            }

            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects
                .Select(p => p.Name)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var pro in projects)
            {
                sb.AppendLine(pro);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employeess = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employeess)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                 e.Department.Name == "Tool Design" ||
                 e.Department.Name == "Marketing" ||
                 e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                emp.Salary *= (decimal)1.12;

                sb.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:F2})");
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p=>p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    Date = p.StartDate
                })
                .OrderBy(p => p.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var item in projects)
            {
                sb.AppendLine($"{item.Name}");
                sb.AppendLine($"{item.Description}");
                sb.AppendLine($"{item.Date.ToString("M/d/yyyy h:mm:ss tt")}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    ManagerName = d.Manager.FirstName + " " + d.Manager.LastName,
                    Name=d.Name,
                    EmployeesNames = d.Employees
                    .Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        JobTitle = e.JobTitle
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} – {department.ManagerName}");

                foreach (var employee in department.EmployeesNames)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FirstName=e.FirstName,
                    LastName=e.LastName,
                    JobTitle=e.JobTitle,
                    ProjectsNames=e.EmployeesProjects
                    .Select(p=> new 
                    {
                        p.Project.Name
                    })
                    .OrderBy(p=>p.Name)
                    .ToList()
                    
                })
                .ToList();
                

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employee)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");

                foreach (var item in emp.ProjectsNames)
                {
                    sb.AppendLine($"{item.Name}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var adresses = context.Addresses
                .Select(a => new 
                {
                    adresessText=a.AddressText,
                    townName=a.Town.Name,
                    employess=a.Employees.Count()
                })
                .OrderByDescending(a=>a.employess)
                .ThenBy(a => a.townName)
                .ThenBy(a => a.adresessText)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var item in adresses)
            {
                sb.AppendLine($"{item.adresessText}, {item.townName} - {item.employess} employees");
            }

            return sb.ToString().TrimEnd();   
                
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {

            var employees = context.Employees
                            .Where(e => e.EmployeesProjects
                            .Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                            .Select(e => new
                            {
                                EmployeeName = e.FirstName + " " + e.LastName,
                                ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                                Projects = e.EmployeesProjects
                                .Select(p => new
                                {
                                    ProjectName = p.Project.Name,
                                    StartDate = p.Project.StartDate,
                                    EndDate = p.Project.EndDate
                                })
                                .ToList()
                            })
                            .Take(10)
                            .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeName} - Manager: {employee.ManagerName}");

                foreach (var project in employee.Projects)
                {
                    var startDate = project.StartDate
                        .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    var endDate = project.EndDate == null ?
                        "not finished" :
                        project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    sb.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();

        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Models.Address { AddressText = "Vitoshka 15", TownId = 4 };
            var employee = context.Employees.First(e => e.LastName == "Nakov");
            employee.Address = address;
            context.SaveChanges();

            var addresses = context.Employees
                .Select(e => new { e.Address.AddressId, e.Address.AddressText })
                .OrderByDescending(a => a.AddressId)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var adr in addresses)
            {
                sb.AppendLine(adr.AddressText);
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new { e.FirstName, e.LastName, e.Department.Name, e.Salary })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.Name} - ${emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new { e.FirstName, e.Salary })
                .OrderBy(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} - {emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary,
                    e.EmployeeId
                })
                .OrderBy(e => e.EmployeeId).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
